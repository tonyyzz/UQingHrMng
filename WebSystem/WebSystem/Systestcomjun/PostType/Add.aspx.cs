using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.PostType
{
    public partial class Add : BasePage
    {
        ZhongLi.BLL.PostType bll = new ZhongLi.BLL.PostType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("17"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["ID"]);
                    ZhongLi.Model.PostType p = bll.GetModel(ID);
                    txtPostTypeName.Text = p.PostTypeName;
                    txtSort.Text = p.Sort + "";
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.PostType p = null;
            if (Request.QueryString["ID"] == null)
            {
                p = new ZhongLi.Model.PostType();
                if (Request.QueryString["PID"] != null)
                {
                    p.ParentID = Convert.ToInt32(Request.QueryString["PID"]);
                }
                else
                {
                    p.ParentID = 0;
                }
            }
            else
            {
                p = bll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
            }
            p.PostTypeName = txtPostTypeName.Text.Trim();
            p.Sort = Convert.ToInt32(txtSort.Text);
            if (Request.QueryString["ID"] == null)
            {
                if (bll.Add(p) > 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('职位类型','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('职位类型','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.Update(p))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('职位类型','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('职位类型','保存失败','',2)</script>");
                }
            }
        }
    }
}