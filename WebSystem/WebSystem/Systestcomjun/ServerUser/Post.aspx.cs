using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ServerUser
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
                if (Request.QueryString["SerUserPostID"] != null)
                {
                    int SerUserPostID = Convert.ToInt32(Request.QueryString["SerUserPostID"]);
                    ZhongLi.BLL.ServerUser_Post bll = new ZhongLi.BLL.ServerUser_Post();
                    ZhongLi.Model.ServerUser_Post sp = bll.GetModel(SerUserPostID);
                    DataTable dt = new ZhongLi.BLL.ServerUser().findField("RealName", sp.SerUserID.Value);
                    if (dt.Rows.Count > 0)
                    {
                        ltlRealName.Text = dt.Rows[0][0].ToString();
                    }
                    ltlCompany.Text = sp.Company;
                    ltlTrade.Text = sp.Trade;
                    ltlScale.Text = sp.Scale;
                    ltlNature.Text = sp.Nature;
                    ltlPostName.Text = sp.PostName;
                    ltlPostDuty.Text = sp.PostDuty;
                    ltlSalary.Text = sp.Salary;
                    ltlDevelopProspect.Text = sp.DevelopProspect;
                    ltlDirectLeader.Text = sp.DirectLeader;
                    ltlWorkAdress.Text = sp.WorkAdress;
                    ltlAdress.Text = sp.WorkAdress;
                    ltlWelfareTag.Text = sp.WelfareTag;
                    ltlCompanyMatching.Text = sp.CompanyMatching;
                    ltlOtherPoint.Text = sp.OtherPoint;
                }
            }
        }
    }
}