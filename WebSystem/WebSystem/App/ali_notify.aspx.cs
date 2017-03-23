using cn.jpush.api.push.mode;
using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.Systestcomjun.AppCode;

namespace WebSystem.App
{
    public partial class ali_notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WxLogger("进入回调函数ali_notify");
            try
            {
                Dictionary<string, string> sPara = GetRequestPost();
                string notify_id =Request.Form["notify_id"];//获取notify_id
                string sign = Request.Form["sign"];//获取sign
                //过滤空值、sign与sign_type参数
                //Dictionary<string, string> aaa = Core.FilterPara(sPara);

                //获取待签名字符串
                //string preSignStr = Core.CreateLinkString(aaa);
                //WxLogger("参数:" + preSignStr);
                if (notify_id != null && notify_id != "")//判断是否有带返回参数
                {
                    Notify aliNotify = new Notify();
                    //WxLogger("公钥：" + Config.alipay_public_key.Trim());
                    //WxLogger("sign：" + sign);
                    //WxLogger("issign:" + aliNotify.GetSignVeryfy(sPara, sign));
                    //WxLogger("ResponseTxt:" + aliNotify.GetResponseTxt(Request.Form["notify_id"]));
                    //WxLogger("公钥:" + Notify.getPublicKeyStr(Config.alipay_public_key), context);
                    if (aliNotify.GetResponseTxt(notify_id) == "true")
                    {
                        if (aliNotify.GetSignVeryfy(sPara, sign))
                        {
                            //卖家支付宝账号	//订单号//
                            WxLogger("验证成功");
                            WxLogger("订单号：" + sPara["out_trade_no"]);
                            WxLogger("金额：" + sPara["total_fee"]);
                            //修改订单状态
                            string t = sPara["out_trade_no"].Substring(0, 1);
                            //WxLogger("编号" + sPara["out_trade_no"] + "--t:" + t);
                            if (t.Equals("d"))
                            {
                                WxLogger("订单");
                                if (new ZhongLi.BLL.Reward_Order().isOrderState(sPara["out_trade_no"]))
                                {
                                    bool issuss = new ZhongLi.BLL.Reward_Order().modOrderStateByOrderNum(sPara["out_trade_no"], "支付宝");
                                    WxLogger("修改数据库：" + issuss);
                                }
                                else
                                {
                                    WxLogger("已修改数据库：" + sPara["out_trade_no"]);
                                }
                            }
                            else if (t.Equals("c"))
                            {
                                WxLogger("充值");
                                if (new ZhongLi.BLL.Person().IsPayCheck(sPara["out_trade_no"]))
                                {
                                    bool issuss = new ZhongLi.BLL.Person().EditPayCheck(sPara["out_trade_no"], "支付宝");
                                    WxLogger("修改数据库：" + issuss);
                                }
                                else
                                {
                                    WxLogger("已修改数据库" + sPara["out_trade_no"]);
                                }
                            }
                            else if (t.Equals("y"))
                            {
                                WxLogger("指定职位订单悬赏");
                                if (new ZhongLi.BLL.Reward_Order().isOrderState(sPara["out_trade_no"]))
                                {
                                    bool issuss = new ZhongLi.BLL.Reward_Order().modOrderStateByNumPost(sPara["out_trade_no"], "支付宝");
                                    WxLogger("执行结果："+issuss);
                                    if (issuss)
                                    {
                                        DataTable dt = new ZhongLi.BLL.Reward_Order().getOrderInfo("SerUserID,RealName,EngagePost", sPara["out_trade_no"]);
                                        JPushApiExample.ALERT = "求职者" + dt.Rows[0]["RealName"] + "针对您的职位 " + dt.Rows[0]["EngagePost"] + "发送了悬赏订单，赶紧去我的订单里面查看吧";
                                        JPushApiExample.MSG_CONTENT = "求职者" + dt.Rows[0]["RealName"] + "针对您的职位" + dt.Rows[0]["EngagePost"] + "发送了悬赏订单，赶紧去我的订单里面查看吧";
                                        PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + dt.Rows[0]["SerUserID"], "Order");
                                        JPushApiExample.push(pushsms);
                                    }
                                }
                                else
                                {

                                }
                                
                            }
                            Response.Write("success");
                        }
                        else
                        {
                            WxLogger("订单号：" + sPara["out_trade_no"]);
                            WxLogger("验证失败");
                            Response.Write("sign fail!");
                        }

                    }
                    else
                    {
                        Response.Write("sign fail!");
                    }
                }
                else
                {
                    // Response.Write("非通知参数!");
                }
            }
            catch (Exception ex)
            {
                WxLogger("异常：" + ex.Message);
            }
        }
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public Dictionary<string, string> GetRequestPost()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
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
            string logFile = Request.MapPath("/log.txt");

            File.AppendAllText(logFile, string.Format("{0}:{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log));

        }
    }
}