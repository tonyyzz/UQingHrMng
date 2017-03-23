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
    public partial class Post : BasePage
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
                    ZhongLi.BLL.Reward_Order bll = new ZhongLi.BLL.Reward_Order();
                    ZhongLi.Model.Reward_Order order = bll.GetModel(OrderID);
                    DataTable dt = new ZhongLi.BLL.ServerUser().findField("RealName", order.SerUserID.Value);
                    if (dt.Rows.Count > 0)
                    {
                        ltlRealName.Text = dt.Rows[0][0].ToString();
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
                }
            }
        }
    }
}