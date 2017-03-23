using Com.Admin.Alipay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using WebSystem.Systestcomjun.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.PresentApplication
{
    public partial class PayList : BasePage
    {
        ZhongLi.BLL.PresentApplication bll = new ZhongLi.BLL.PresentApplication();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("11"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                databind();
            }
        }

        private void databind()
        {
            string key = Utils.ReplaceString(txtkey.Text.Trim());
            string where = " RealName like '%" + key + "%' and State in (1,2,3)";
            if (ddl_PayState.SelectedValue != "")
            {
                where += " and State="+ddl_PayState.SelectedValue;
            }
            if (ddl_PreType.SelectedValue != "")
            {
                where += " and PreType=" + ddl_PreType.SelectedValue;
            }
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, "ID desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkid");
                if (chk.Checked)
                {
                    HiddenField txtid = (HiddenField)item.FindControl("txtid");
                    ids += txtid.Value + ",";
                }
            }
            if (ids != "")
            {
                ids = ids.TrimEnd(',');
                string delinfo = webHelper.delInfo("PresentApplication", "RealName", "ID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除提现申请：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除提现申请','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除提现申请','删除失败！','',2)</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("payFail"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                int adminid = Convert.ToInt32(Utils.GetCookie("UserID"));
                string adminname = new ZhongLi.BLL.User_Managers().GetModel(adminid).RealName;
                string realname = ((Literal)e.Item.FindControl("ltlrealname")).Text;
                ZhongLi.Model.PresentApplication p=bll.GetModel(ID);
                if (bll.PayFail(adminid, adminname, ID,p.UserType.Value,p.UserID.Value,p.Money.Value))
                {
                    //推送通知
                    PushClass push = new PushClass();
                    push.title = "优青通知：";
                    push.content = "您的提现申请支付失败了，资金已退回到您的钱包，请检查您提现时填的资料是否正确";
                    push.type = "1";
                    push.platform = "0";
                    push.groupName = "";

                    if (p.UserType.Value == 0)//用户类型为人才
                    {
                        push.userIds = "p" + p.UserID;
                    }
                    else
                    {
                        push.userIds = "s" + p.UserID;
                    }
                    push.ts_01();
                    webHelper.addLog(adminname + "设置" + realname + "的提现申请支付失败");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('审核提现申请','操作成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('审核提现申请','操作失败！','',2)</script>");
                }

            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string ids = "";
            string t = "0";//第一次是得到是支付宝或者是微信
            int i=0;//第一次是得到是支付宝或者是微信
            bool isPay = true;//判断是否都是同一类型
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkid");
                if (chk.Checked)
                {
                    HiddenField txtid = (HiddenField)item.FindControl("txtid");
                    HiddenField txtPreType = (HiddenField)item.FindControl("txtPreType");
                    if (i == 0)
                    {
                        t = txtPreType.Value;
                    }
                    else
                    {
                        if (!t.Equals(txtPreType.Value))
                        {
                            isPay = false;
                            break;
                        }
                    }
                    ids += txtid.Value + ",";
                    i++;
                }
            }
            if (ids != "")
            {
                if (isPay)
                {
                    ids = ids.TrimEnd(',');
                    if(t=="0")//支付宝
                    {
                        //1生成批次 2修改提现申请的批次 3拼接数据 4发送请求
                        if (!bll.checkPay(ids))
                        {
                            DataTable dt = bll.GetList(" ID in(" + ids + ")").Tables[0];
                            int batch_num = dt.Rows.Count;//付款总笔数
                            string detail_data = "";//付款详细数据
                            decimal Batch_Fee = 0;//付款总金额
                            foreach (DataRow dr in dt.Rows)
                            {
                                //detail_data += dr["PreNum"] + "^";//流水号
                                //detail_data += dr["AliAccount"] + "^";//收款账号
                                //detail_data += dr["AliAccounttName"] + "^";//收款姓名
                                //detail_data += dr["Money"] + "^"; ;//付款金额
                                Batch_Fee += Convert.ToDecimal(dr["Money"]);
                                //detail_data += "提现";//备注
                                //detail_data += "|";
                            }
                            //detail_data = detail_data.TrimEnd('|');
                            int AdminID = Convert.ToInt32(Utils.GetCookie("UserID"));
                            //生成批次
                            //string NowDay = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";//当天0点
                            int NowBatch = bll.GetBatchRecordCount(" datediff(day,CrateTime,getdate())=0");//当天支付了多少批次
                            string dateStr = DateTime.Now.ToString("yyyyMMdd");//当天
                            string Batch_No = dateStr + (NowBatch + 1).ToString().PadLeft(3, '0');//当前批次号
                            int BatchID = bll.AddBatch(Batch_No, batch_num, Batch_Fee, AdminID);
                            if (BatchID > 0)
                            {

                                ////修改提现数据的批次
                                if (bll.editPresentBatch(ids, BatchID))
                                {
                                    Response.Write("<script>window.open('pay.aspx?BatchID=" + BatchID + "')</script>");
                                    //把请求参数打包成数组
                                    //SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                                    //sParaTemp.Add("partner", Config.Partner);
                                    //sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
                                    //sParaTemp.Add("service", "batch_trans_notify");
                                    //sParaTemp.Add("notify_url", "http://www.uqinger.com/Systestcomjun/PresentApplication/notify_url.aspx");
                                    //sParaTemp.Add("email", "58191362@qq.com");
                                    //sParaTemp.Add("account_name", "武汉优青人力资源有限公司");
                                    //sParaTemp.Add("pay_date", DateTime.Now.ToString("yyyyMMdd"));
                                    //sParaTemp.Add("batch_no", Batch_No);
                                    //sParaTemp.Add("batch_fee", Batch_Fee.ToString());
                                    //sParaTemp.Add("batch_num", batch_num.ToString());
                                    //sParaTemp.Add("detail_data", detail_data);
                                    ////建立请求
                                    //string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
                                    //Response.Write(sHtmlText);
                                }
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('操作失败','请选择未支付的提现申请','',2)</script>");
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('操作失败','请选择同类型的提现，只能同时选择支付宝或者微信','',2)</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('操作失败','请勾选需要支付的提现申请','',2)</script>");
            }
        }
    }
}