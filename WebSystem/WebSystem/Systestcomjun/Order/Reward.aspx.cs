using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Order
{
    public partial class Reward : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("10"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderID"] != null)
                {
                    int OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
                    ZhongLi.Model.Reward_Order order = new ZhongLi.BLL.Reward_Order().GetModel(OrderID);
                    DataTable dt = new ZhongLi.BLL.Person().findField("RealName", order.PerID.Value);
                    if (dt.Rows.Count > 0)
                    {
                        ltlRealName.Text = dt.Rows[0][0].ToString();
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
                    ltlEducation.Text = order.Education;
                    ltlWorkLife.Text = order.WorkLife;
                }
            }
        }
    }
}