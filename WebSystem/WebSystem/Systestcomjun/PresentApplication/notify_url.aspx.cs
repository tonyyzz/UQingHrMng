using cn.jpush.api.push.mode;
using Com.Admin.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.Systestcomjun.AppCode;
using ZhongLi.DBUtility;

namespace WebSystem.Systestcomjun.PresentApplication
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();
            WxLogger("进入回调");
            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
                
                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码
                    try
                    {
                        WxLogger("验证成功");
                        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                        //批量付款数据中转账成功的详细信息
                        // 1.修改批次支付状态 2.修改每个提现的状态 3提现成功需要减掉余额并添加交易记录  推送消息提醒
                        ZhongLi.BLL.PresentApplication bll = new ZhongLi.BLL.PresentApplication();
                        string batch_no = Request.Form["batch_no"];
                        WxLogger("批次号：" + batch_no);
                        if (bll.IsBatch(batch_no))
                        {
                            List<CommandInfo> list = new List<CommandInfo>();
                            string success_details = Request.Form["success_details"];
                           
                            string SucPreNums = "";//支付成功流水号集合
                           

                            //修改批次状态
                            CommandInfo cmd1 = new CommandInfo();
                            cmd1.CommandText = "update PresentApplication_Batch set BatchState=1 where Batch_No=@Batch_No";
                            SqlParameter[] para1 = { new SqlParameter("@Batch_No", batch_no) };
                            cmd1.Parameters = para1;
                            list.Add(cmd1);
                            if (!string.IsNullOrWhiteSpace(success_details))
                            {
                                string[] suc = success_details.Split('|');
                                WxLogger("获取成功的success_details：" + success_details);
                                foreach (string sucdetail in suc)
                                {
                                    string[] sucdetals = sucdetail.Split('^');
                                    SucPreNums += "'" + sucdetals[0] + "'" + ",";
                                }
                            }
                            //批量付款数据中转账失败的详细信息
                            string fail_details = Request.Form["fail_details"];
                            WxLogger("获取失败的success_details：" + fail_details);
                            string FailPreNum = "";//支付失败流水号集合
                            if (!string.IsNullOrWhiteSpace(fail_details))
                            {
                                string[] fail = fail_details.Split('|');
                                foreach (string faildetail in fail)
                                {
                                    string[] f = faildetail.Split('^');
                                    FailPreNum += "'" + f[0] + "'" + ",";
                                }
                            }
                            DataTable SusUserdt = null;
                            DataTable FailUserdt = null;
                            if (SucPreNums != "")
                            {
                                SucPreNums = SucPreNums.TrimEnd(',');
                                //修改所有成功的提现的状态
                                CommandInfo cmd2 = new CommandInfo();
                                cmd2.CommandText = "update PresentApplication set State=2 where PreNum in (" + SucPreNums + ")";
                                list.Add(cmd2);
                                SusUserdt = bll.getUserByPreNum(SucPreNums);
                                //循环所有用户  修改余额和添加交易记录
                                foreach (DataRow dr in SusUserdt.Rows)
                                {
                                    if (dr["UserType"].ToString() == "0")//用户类型为人才
                                    {
                                        //CommandInfo blacmd = new CommandInfo();//修改余额
                                        //blacmd.CommandText = "update Person set Balance-=(select Money from PresentApplication where ID =" + dr["ID"] + ") where PerID=" + dr["UserID"];
                                        //list.Add(blacmd);
                                        CommandInfo reccmd = new CommandInfo();//添加交易记录
                                        reccmd.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(" + dr["UserID"] + ",'提现(支付宝)'," + dr["Money"] + ",getdate(),0,'')";
                                        list.Add(reccmd);
                                        CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                                        msgcmd.CommandText = "insert into Person_Message (PerID,MesType,SendTime,MesCon)values(" + dr["UserID"] + ",1,getdate(),'您的提现申请已经支付啦,提现资金将会在5-10分钟内到帐')";
                                        list.Add(msgcmd);
                                    }
                                    else//类型为人才经纪人
                                    {
                                        CommandInfo blacmd = new CommandInfo();//修改余额
                                        blacmd.CommandText = "update ServerUser set Balance-=(select Money from PresentApplication where ID =" + dr["ID"] + ") where SerUserID=" + dr["UserID"];
                                        list.Add(blacmd);
                                        CommandInfo reccmd = new CommandInfo();//添加交易记录
                                        reccmd.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(" + dr["UserID"] + ",'提现(支付宝)'," + dr["Money"] + ",getdate(),1,'')";
                                        list.Add(reccmd);
                                        CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                                        msgcmd.CommandText = "insert into ServerUser_Message (SerUserID,MesType,SendTime,MesCon)values(" + dr["UserID"] + ",1,getdate(),'您的提现申请已经支付啦,提现资金将会在5-10分钟内到帐')";
                                        list.Add(msgcmd);
                                    }
                                }

                            }
                            if (FailPreNum != "")
                            {
                                FailPreNum = FailPreNum.TrimEnd(',');
                                CommandInfo cmd3 = new CommandInfo();
                                cmd3.CommandText = "update PresentApplication set State=3 where PreNum in (" + FailPreNum + ")";
                                list.Add(cmd3);
                                FailUserdt = bll.getUserByPreNum(FailPreNum);
                                foreach (DataRow dr in FailUserdt.Rows)
                                {
                                    if (dr["UserType"].ToString() == "0")//用户类型为人才
                                    {
                                        CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                                        msgcmd.CommandText = "insert into Person_Message (PerID,MesType,SendTime,MesCon)values(" + dr["UserID"] + ",1,getdate(),'您的提现申请支付失败了，资金已退回到您的钱包，请检查您提现时填写的账号资料是否正确')";
                                        list.Add(msgcmd);
                                        CommandInfo blacmd = new CommandInfo();
                                        blacmd.CommandText = "update Person set Balance+="+dr["Money"]+" where PerID="+dr["UserID"];
                                        list.Add(blacmd);
                                        //CommandInfo reccmd = new CommandInfo();//添加交易记录
                                        //reccmd.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(" + dr["UserID"] + ",'提现失败退款'," + dr["Money"] + ",getdate(),0,'')";
                                        //list.Add(reccmd);
                                    }
                                    else
                                    {
                                        CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                                        msgcmd.CommandText = "insert into ServerUser_Message (SerUserID,MesType,SendTime,MesCon)values(" + dr["UserID"] + ",1,getdate(),'您的提现申请支付失败了，资金已退回到您的钱包，请检查您提现时填写的账号资料是否正确')";
                                        list.Add(msgcmd);
                                        CommandInfo blacmd = new CommandInfo();
                                        blacmd.CommandText = "update ServerUser set Balance+=" + dr["Money"] + " where SerUserID=" + dr["UserID"];
                                        list.Add(blacmd);
                                        //CommandInfo reccmd = new CommandInfo();//添加交易记录
                                        //reccmd.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(" + dr["UserID"] + ",'提现失败退款'," + dr["Money"] + ",getdate(),1,'')";
                                        //list.Add(reccmd);
                                    }
                                }
                            }
                            if (bll.exPreTran(list))//事物执行成功则发送推送
                            {
                                WxLogger("事务执行成功");
                                if (SusUserdt != null)
                                {
                                    foreach (DataRow dr in SusUserdt.Rows)
                                    {
                                        //推送通知
                                        string UserID="";
                                        if (dr["UserType"].ToString() == "0")//用户类型为人才
                                        {
                                            UserID = "p" + dr["UserID"];
                                        }
                                        else
                                        {
                                            UserID = "s" + dr["UserID"];
                                        }
                                        JPushApiExample.ALERT = "您的提现申请已经支付啦,提现资金将会在5-10分钟内到帐";
                                        JPushApiExample.MSG_CONTENT = "您的提现申请已经支付啦,提现资金将会在5-10分钟内到帐";
                                        PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras(UserID, "Present");
                                        JPushApiExample.push(pushsms);
                                    }
                                }
                                if (FailUserdt != null)
                                {
                                    foreach (DataRow dr in FailUserdt.Rows)
                                    {
                                        //推送通知
                                        string UserID = "";
                                        if (dr["UserType"].ToString() == "0")//用户类型为人才
                                        {
                                            UserID = "p" + dr["UserID"];
                                        }
                                        else
                                        {
                                            UserID = "s" + dr["UserID"];
                                        }
                                        JPushApiExample.ALERT = "您的提现申请支付失败了，资金已退回到您的钱包，请检查您提现时填写的账号资料是否正确";
                                        JPushApiExample.MSG_CONTENT = "您的提现申请支付失败了，资金已退回到您的钱包，请检查您提现时填写的账号资料是否正确";
                                        PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras(UserID, "Present");
                                        JPushApiExample.push(pushsms);
                                    }
                                }
                            }
                            //判断是否在商户网站中已经做过了这次通知返回的处理
                            //如果没有做过处理，那么执行商户的业务程序
                            //如果有做过处理，那么不执行商户的业务程序
                            WxLogger("成功！");
                            Response.Write("success");  //请不要修改或删除

                            //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        }
                        else
                        {
                            WxLogger("批次已被处理或没有该批次，批次：" + batch_no);
                            Response.Write("success");
                        }
                    }catch(Exception ex){
                        WxLogger("异常：" + ex.Message);
                    }
                }
                else//验证失败
                {
                    WxLogger("验证失败");
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }

        //日志
        void WxLogger(string log)
        {
            string logFile = Request.MapPath("/log1.txt");

            File.AppendAllText(logFile, string.Format("{0}:{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log));

        }
    }
}