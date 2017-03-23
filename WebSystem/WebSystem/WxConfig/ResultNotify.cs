using cn.jpush.api.push.mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.Systestcomjun.AppCode;

namespace WxPayAPI
{
    /// <summary>
    /// 支付结果通知回调处理类
    /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
    /// </summary>
    public class ResultNotify:Notify
    {
        public ResultNotify(Page page):base(page)
        {
        }

        public override void ProcessNotify()
        {
            WxPayData notifyData = GetNotifyData();
            WxLogger("微信回调");
            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                WxLogger("支付订单不存在");
                Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();
            string out_trade_no = notifyData.GetValue("out_trade_no").ToString();
            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxLogger("订单查询失败");
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
            //查询订单成功
            else
            {
                WxLogger("订单查询成功");
                string t = out_trade_no.Substring(0, 1);
                //WxLogger("编号" + sPara["out_trade_no"] + "--t:" + t);
                if (t.Equals("d"))
                {
                    WxLogger("订单");
                    if (new ZhongLi.BLL.Reward_Order().isOrderState(out_trade_no))
                    {
                        bool issuss = new ZhongLi.BLL.Reward_Order().modOrderStateByOrderNum(out_trade_no, "微信");
                        WxLogger("修改数据库：" + issuss);
                    }
                    else
                    {
                        WxLogger("已修改数据库：" + out_trade_no);
                    }
                }
                else if (t.Equals("c"))
                {
                    WxLogger("充值");
                    if (new ZhongLi.BLL.Person().IsPayCheck(out_trade_no))
                    {
                        bool issuss = new ZhongLi.BLL.Person().EditPayCheck(out_trade_no,"微信");
                        WxLogger("修改数据库：" + issuss);
                    }
                    else
                    {
                        WxLogger("已修改数据库" + out_trade_no);
                    }
                }
                else if (t.Equals("y"))
                {
                    WxLogger("指定职位订单悬赏");
                    if (new ZhongLi.BLL.Reward_Order().isOrderState(out_trade_no))
                    {
                        bool issuss = new ZhongLi.BLL.Reward_Order().modOrderStateByNumPost(out_trade_no, "微信");
                        WxLogger("执行结果：" + issuss);
                        if (issuss)
                        {
                            DataTable dt = new ZhongLi.BLL.Reward_Order().getOrderInfo("SerUserID,RealName,EngagePost", out_trade_no);
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

                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                Log.Info(this.GetType().ToString(), "order query success : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
        }
        //日志
        void WxLogger(string log)
        {
            string logFile = HttpContext.Current.Server.MapPath("/log.txt");

            File.AppendAllText(logFile, string.Format("{0}:{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log));

        }
        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}