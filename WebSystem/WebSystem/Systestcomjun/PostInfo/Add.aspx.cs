using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSystem.Systestcomjun.PostInfo
{
    public partial class Add : System.Web.UI.Page
    {
        ZhongLi.BLL.PostType bll = new ZhongLi.BLL.PostType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["ID"]);
                    txtPostName.Text = bll.GetPostName(ID);
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string PostName=txtPostName.Text;
            int TID = Convert.ToInt32(Request.QueryString["TID"]);
            if (Request.QueryString["ID"] != null)
            {
                if (bll.UpdatePostName(Convert.ToInt32(Request.QueryString["ID"]), PostName))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('修改职位信息','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('修改职位信息','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.AddPostName(PostName,TID))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增职位信息','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增职位信息','保存失败','',2)</script>");
                }
            }
        }


    }
}