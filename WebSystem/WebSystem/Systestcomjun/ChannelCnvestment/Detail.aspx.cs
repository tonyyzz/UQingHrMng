using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ChannelCnvestment
{
    public partial class Detail : System.Web.UI.Page
    {
        ZhongLi.BLL.ChannelCnvestment bll = new ZhongLi.BLL.ChannelCnvestment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("18"))
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
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            ZhongLi.Model.ChannelCnvestment c = bll.GetModel(ID);
            ltlCompany.Text = c.Company;
            ltlAddress.Text = c.Address;
            ltlPhone.Text = c.Phone;
            ltlLinkMan.Text = c.LinkMan;
            ltlEmail.Text = c.Email;
            ltlCity.Text = c.City;
            ltlTeamSize.Text = c.TeamSize;
            ltlMainBusiness.Text = c.MainBusiness;
            ltlMainAdvantage.Text = c.MainAdvantage;
        }
    }
}