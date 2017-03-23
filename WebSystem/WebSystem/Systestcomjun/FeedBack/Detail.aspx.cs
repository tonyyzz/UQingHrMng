using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.FeedBack
{
    public partial class Detail : BasePage
    {
        ZhongLi.BLL.FeedBack bll = new ZhongLi.BLL.FeedBack();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    ZhongLi.Model.FeedBack fb = bll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
                    ltlCon.Text = fb.Con;
                    if (fb.State == 1)
                    {
                        btnsave.Text = "已阅";
                        btnsave.Enabled = false;
                    }
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                ZhongLi.Model.FeedBack fb = bll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
                fb.State=1;
                bll.Update(fb);
                Response.Redirect("Detail.aspx?ID=" + Request.QueryString["ID"]);
            }
        }
    }
}