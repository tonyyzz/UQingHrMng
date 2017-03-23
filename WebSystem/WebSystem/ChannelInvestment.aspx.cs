using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSystem
{
    public partial class ChannelInvestment : System.Web.UI.Page
    {
        public static string log = null;
        public static string phone = null;
        public static string mail = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ZhongLi.Model.siteconfig config = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            log = config.log;
            phone = config.phone;
            mail = config.mail;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.ChannelCnvestment c = new ZhongLi.Model.ChannelCnvestment();
            c.Company = txtCompany.Text;
            c.Address = txtAddress.Text;
            c.LinkMan = txtLinkMan.Text;
            c.Phone = txtPhone.Text;
            c.Email = txtEmail.Text;
            c.City = txtCity.Text;
            c.MainBusiness = txtMainBusiness.Text;
            c.MainAdvantage = txtMainAdvantage.Text;
            c.TeamSize = txtTeamSize.Text;
            new ZhongLi.BLL.ChannelCnvestment().Add(c);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>document.body.onload=sload;function sload(){alert('提交申请成功！');window.location = 'index.aspx';}</script>");
        }
    }
}