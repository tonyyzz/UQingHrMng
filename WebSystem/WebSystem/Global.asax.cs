using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using WebSystem.Systestcomjun.AppCode;
using cn.jpush.api.push.mode;
using System.Data;

namespace WebSystem
{
    public class Global : System.Web.HttpApplication
    {
        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {

        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //Thread T_Recharge = new Thread(WebSystem.AppCode.ThreadHelper.RechargeThreadByHx);
            //T_Recharge.Start();
            System.Timers.Timer aTimer = new System.Timers.Timer(60 * 60 * 1000);//60 * 60 * 1000
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();

        }

        void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 11 || DateTime.Now.Hour == 12)
            {
                try
                {
                    ZhongLi.BLL.Reward_Order bll = new ZhongLi.BLL.Reward_Order();
                    int OrderCanceTime = bll.getOrderCanceDay();//订单过期天数
                    //已经过期的订单数据
                    DataTable IsOverDt = bll.getOrderOverTime();
                    //给已过期的订单的用户发送推送
                    foreach (DataRow dr in IsOverDt.Rows)
                    {

                        JPushApiExample.ALERT = "您有悬赏订单已过期，快去延期吧~";
                        JPushApiExample.MSG_CONTENT = "您有悬赏订单已过期，快去延期吧~";
                        PushPayload pushsms1 = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + dr["PerID"], "Order");
                        JPushApiExample.push(pushsms1);

                    }
                    //过期订单还没有修改状态的订单
                    DataTable OverDt = bll.getOrderOverTime(OrderCanceTime);
                    if (OverDt.Rows.Count > 0)
                    {
                        if (bll.setOrderOverTime(OverDt, OrderCanceTime))
                        {
                            foreach (DataRow dr in OverDt.Rows)
                            {
                                JPushApiExample.ALERT = "您有悬赏订单已过期，快去延期吧~";
                                JPushApiExample.MSG_CONTENT = "您有悬赏订单已过期，快去延期吧~";
                                PushPayload pushsms1 = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + dr["PerID"], "Order");
                                JPushApiExample.push(pushsms1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        private int _count = 0;
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Cookies != null)
            {
                if (WebSystem.AppCode._360safe.CookieData())
                {
                    Response.Write("您提交的Cookie数据有恶意字符！");
                    Response.End();
                }
            }

            if (Request.UrlReferrer != null)
            {
                if (WebSystem.AppCode._360safe.referer())
                {
                    Response.Write("您提交的Referrer数据有恶意字符！");
                    Response.End();
                }
            }
            //控制页面是否要跳转到https
            //var url = Request.Url.ToString();
            //if (!string.IsNullOrEmpty(url))
            //{
            //    var reg = @"(?<url>[^?]*)[\?](?<can>[^=]*)[\=](?<id>[\d]+)";//匹配带参数的url
            //    Match m = Regex.Match(Request.Url.ToString(), reg, RegexOptions.IgnoreCase);
            //    if (m.Success)
            //    {

            //    }
            //    else
            //    {
            //        switch (url)
            //        {
            //            case "http:///center/landed.aspx":
            //                if (_count != 1)
            //                {
            //                    if (url.StartsWith("http"))
            //                    {
            //                        _count = 1;
            //                        url = url.Replace("http", "https");
            //                        Response.Redirect(url);
            //                        Response.End();
            //                    }
            //                }
            //                else
            //                {
            //                    _count = 0;
            //                }
            //                break;
            //            default:
            //                if (_count != 1)
            //                {
            //                    if (url.StartsWith("https"))
            //                    {
            //                        _count = 1;
            //                        url = url.Replace("https", "http");
            //                        Response.Redirect(url);
            //                        Response.End();
            //                    }
            //                }
            //                else
            //                {
            //                    _count = 0;
            //                }
            //                break;
            //        }
            //    }
            //}

            if (Request.RequestType.ToUpper() == "GET")
            {
                if (WebSystem.AppCode._360safe.GetData())
                {
                    Response.Write("您提交的Get数据有恶意字符！");
                    Response.End();
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Response.Redirect("Error.html");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }
}