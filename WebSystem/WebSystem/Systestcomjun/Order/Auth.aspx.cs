using cn.jpush.api.push.mode;
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
using ZhongLi.Model;

namespace WebSystem.Systestcomjun.Order
{
    public partial class Auth : BasePage
    {
        ZhongLi.BLL.Reward_Order bll = new ZhongLi.BLL.Reward_Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null)
            {
                int OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
                ZhongLi.Model.Reward_Order order = new ZhongLi.BLL.Reward_Order().GetModel(OrderID);
                DataTable Perdt = new ZhongLi.BLL.Person().findField("RealName,AuthImg", order.PerID.Value);
                if (Perdt.Rows.Count > 0)
                {
                    ltlRealName.Text = Perdt.Rows[0][0].ToString();
                    img_PerImg.ImageUrl = Perdt.Rows[0][1].ToString();
                }
                ltlRewardMoney.Text = order.RewardMoney.ToString();
                ltlRewardTime.Text = order.RewardTime.ToString();
                ltlTrade.Text = order.Trade;
                ltlCompanySize.Text = order.CompanySize;
                ltlCompanyNature.Text = order.CompanyNature;
                ltlEngagePost.Text = order.EngagePost;
                ltlDemandPay.Text = order.DemandPay;
                ltlJobCity.Text = order.JobCity;
                ltlOtherDemand.Text = order.OtherDemand;
                ltlCompanyMatching.Text = order.CompanyMatching;
                ltlOtherDemandDes.Text = order.OtherDemandDes;
                DataTable Serdt = new ZhongLi.BLL.ServerUser().findField("RealName,IDCardImg", order.SerUserID.Value);
                if (Perdt.Rows.Count > 0)
                {
                    ltlRealName.Text = Serdt.Rows[0][0].ToString();
                    ing_SerUserImg.ImageUrl = Serdt.Rows[0][1].ToString();
                }
                ltlCompany.Text = order.Company;
                ltlTrade.Text = order.Post_Trade;
                ltlScale.Text = order.Scale;
                ltlNature.Text = order.Nature;
                ltlPostName.Text = order.PostName;
                ltlPostDuty.Text = order.PostDuty;
                ltlSalary.Text = order.Salary;
                ltlDevelopProspect.Text = order.DevelopProspect;
                ltlDirectLeader.Text = order.DirectLeader;
                ltlWorkAdress.Text = order.WorkAdress;
                ltlAdress.Text = order.WorkAdress;
                ltlWelfareTag.Text = order.WelfareTag;
                ltlCompanyMatching.Text = order.Post_CompanyMatching;
                ltlOtherPoint.Text = order.OtherPoint;
                //DataTable dt = bll.getOrderImgAuth(OrderID) ;
                //img_Auth.ImageUrl = dt.Rows[0]["AutoImg"].ToString();
                //if (dt.Rows[0]["OrderState"].ToString() != "2")
                //{
                //    btnAuth.Visible = false;
                //    btnAuth.Visible = false;
                //}
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null)
            {
                int OrderID=Convert.ToInt32(Request.QueryString["OrderID"]);
                DataTable perdt = bll.getPerByOrderID(OrderID);
                int PerID = Convert.ToInt32(perdt.Rows[0]["PerID"]);
                string RealName = perdt.Rows[0]["RealName"].ToString();
                int SerUserID = Convert.ToInt32(perdt.Rows[0]["SerUserID"]);
                decimal RewardMoney = Convert.ToDecimal(perdt.Rows[0]["RewardMoney"]);
                siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
                if (bll.PassAuth(OrderID, PerID, SerUserID, RewardMoney, site.Commission))
                {
                    DateTime time = DateTime.Now;
                    //添加消息表
                    ZhongLi.Model.Person_Message msg = new ZhongLi.Model.Person_Message();
                    msg.MesCon = "您的悬赏订单审核通过啦，恭喜您成功入职！";
                    msg.SendTime = time;
                    msg.PerID = PerID;
                    msg.MesType = 0;
                    new ZhongLi.BLL.Person_Message().Add(msg);
                    ZhongLi.Model.ServerUser_Message sermsg = new ZhongLi.Model.ServerUser_Message();
                    sermsg.MesCon = "您的订单审核通过啦，您已获得悬赏佣金，赶紧去钱包查看吧！";
                    sermsg.SendTime = time;
                    sermsg.SerUserID = SerUserID;
                    sermsg.MesType = 0;
                    new ZhongLi.BLL.ServerUser_Message().Add(sermsg);
                    //推送通知
                    //求职者
                    JPushApiExample.ALERT = "您的悬赏订单审核通过啦，恭喜您成功入职！";
                    JPushApiExample.MSG_CONTENT = "您的悬赏订单审核通过啦，恭喜您成功入职！";
                    PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "OrderAuth");
                    JPushApiExample.push(pushsms);
                    //人才经纪人
                    JPushApiExample.ALERT = "您的订单审核通过啦，您已获得悬赏佣金，赶紧去钱包查看吧！";
                    JPushApiExample.MSG_CONTENT = "您的订单审核通过啦，您已获得悬赏佣金，赶紧去钱包查看吧！";
                    PushPayload pushsms1 = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "OrderAuth");
                    JPushApiExample.push(pushsms1);
                    webHelper.addLog("通过了“" + RealName + "”的入职资料审核");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('入职协议审核','审核成功！','Auth.aspx?OrderID=" + OrderID + "',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('入职协议审核','审核失败！','Auth.aspx?OrderID=" + OrderID + "',1)</script>");
                }
            }
        }

        protected void btnPerbh_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null)
            {
                int OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
                DataTable perdt = bll.getPerByOrderID(OrderID);
                int PerID = Convert.ToInt32(perdt.Rows[0]["PerID"]);
                string RealName = perdt.Rows[0]["RealName"].ToString();
                int SerUserID = Convert.ToInt32(perdt.Rows[0]["SerUserID"]);
                if (bll.editOrderState(OrderID, 7))
                {
                    DateTime time = DateTime.Now;
                    //添加消息表
                    ZhongLi.Model.Person_Message msg = new ZhongLi.Model.Person_Message();
                    msg.MesCon = "您的悬赏订单没有通过审核，快去检查入职协议并重新上传资料吧";
                    msg.SendTime = time;
                    msg.PerID = PerID;
                    msg.MesType = 0;
                    new ZhongLi.BLL.Person_Message().Add(msg);
                    //添加消息表
                    ZhongLi.Model.ServerUser_Message sermsg = new ZhongLi.Model.ServerUser_Message();
                    sermsg.MesCon = "您的悬赏订单没有通过审核，快去检查入职协议并重新上传资料吧";
                    sermsg.SendTime = time;
                    sermsg.SerUserID = PerID;
                    sermsg.MesType = 0;
                    new ZhongLi.BLL.ServerUser_Message().Add(sermsg);
                    //推送通知
                    
                    JPushApiExample.ALERT = "您的订单没有通过审核，去检查一下您入职协议中的认证资料吧";
                    JPushApiExample.MSG_CONTENT = "您的订单没有通过审核，去检查一下您入职协议中的认证资料吧";
                    PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "OrderAuth");
                    JPushApiExample.push(pushsms);
                    
                    JPushApiExample.ALERT = "您的订单没有通过审核，去检查一下入职协议吧";
                    JPushApiExample.MSG_CONTENT = "您的订单没有通过审核，去检查一下入职协议吧";
                    PushPayload pushsms1 = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "OrderAuth");
                    JPushApiExample.push(pushsms1);
                    webHelper.addLog("不通过“" + RealName + "”的悬赏订单审核");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('入职协议审核','审核成功！','Auth.aspx?OrderID=" + OrderID + "',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('入职协议审核','审核失败！','Auth.aspx?OrderID=" + OrderID + "',1)</script>");
                }
            }
        }
    }
}