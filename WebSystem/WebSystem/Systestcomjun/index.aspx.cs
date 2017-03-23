using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;
using ZhongLi.Model;

namespace WebSystem.Systestcomjun
{
    public partial class index : BasePage
    {
        public string role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            role = Utils.GetCookie("role");
            int UserID = Convert.ToInt32(Utils.GetCookie("UserID"));
            User_Managers user = new ZhongLi.BLL.User_Managers().GetModel(UserID);
            ltlUserName.Text = user.UserName;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("UserID","");
            Response.Redirect("login.aspx");
        }
    }
}