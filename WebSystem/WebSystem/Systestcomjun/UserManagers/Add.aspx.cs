using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;
using ZhongLi.Model;

namespace WebSystem.Systestcomjun.UserManagers
{
    public partial class Add : BasePage
    {
        ZhongLi.BLL.User_Managers bll = new ZhongLi.BLL.User_Managers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("2"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                ddlRole.DataSource = new ZhongLi.BLL.Roles().GetAllList();
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleID";
                ddlRole.DataBind();
                ltlTitle.Text = "新增用户";
                if (Request.QueryString["UserID"] != null)
                {
                    int UserID = Convert.ToInt32(Request.QueryString["UserID"]);
                    ltlTitle.Text = "修改用户";
                    User_Managers user=bll.GetModel(UserID);
                    txtUserName.Text = user.UserName;
                    txtRealName.Text = user.RealName;
                    txtEmail.Text = user.Email;
                    ddlRole.SelectedValue = user.RoleId + "";

                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            User_Managers user = null;
            if (Request.QueryString["UserID"] != null)
            {
                user = bll.GetModel(Convert.ToInt32(Request.QueryString["UserID"]));
            }
            else
            {
                user = new User_Managers();
                user.CreateDate = DateTime.Now;
                user.Password = DESEncrypt.EncryptDES("123456");
            }
            user.UserName = txtUserName.Text.Trim();
            user.RealName = txtRealName.Text.Trim();
            user.Email = txtEmail.Text;
            user.RoleId = Convert.ToInt32(ddlRole.SelectedValue);
            if (user.UserId == 0)
            {
                if (bll.Add(user) > 0)
                {
                    webHelper.addLog("新添加了用户“"+user.UserName+"”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增用户','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增用户','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.Update(user))
                {
                    webHelper.addLog("修改了用户“" + user.UserName + "”的个人信息");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑用户','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑用户','保存失败','',2);</script>");
                }
            }
        }
    }
}