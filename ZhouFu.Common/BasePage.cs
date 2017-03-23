using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhongLi.Common
{
    public partial class BasePage:System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            if (Utils.GetCookie("UserID") == "")
            {
                Response.Redirect("/Systestcomjun/login.aspx");
            }
        }
    }
}
