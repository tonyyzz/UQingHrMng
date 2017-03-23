using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Model;

namespace WebSystem
{
    public partial class news : System.Web.UI.Page
    {
        public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["n"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["n"]);
                News n = new ZhongLi.BLL.News().GetModel(id);
                title = n.Title;
                //ltlCon.Text = n.NewsCon;
                Response.Redirect(n.NewsCon);
            }
        }
    }
}