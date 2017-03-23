using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;
using ZhongLi.Model;

namespace WebSystem.Systestcomjun.Role
{
    public partial class Add : BasePage
    {
        ZhongLi.BLL.Roles bll = new ZhongLi.BLL.Roles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("3"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                ltlTitle.Text = "新增角色";
                if (Request.QueryString["RoleID"] != null)
                {
                    ltlTitle.Text = "编辑角色";
                    int RoleID = Convert.ToInt32(Request.QueryString["RoleID"]);
                    Roles role = bll.GetModel(RoleID);
                    txtRoleName.Text = role.RoleName;
                    if (role.ColValue != "" && role.ColValue!=null)
                    {
                        string[] roles = role.ColValue.Split(',');
                        foreach (ListItem item in chklist.Items)
                        {
                            if (roles.Contains(item.Value))
                            {
                                item.Selected = true;
                            }
                        }
                    }

                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Roles role = null;
            if (Request.QueryString["RoleID"] != null)
            {
                role = bll.GetModel(Convert.ToInt32(Request.QueryString["RoleID"]));
            }
            else
            {
                role = new Roles();
                role.CreateTime = DateTime.Now;
                role.Description = "";
                role.ParentID = 0;
            }
            role.RoleName = txtRoleName.Text;
            string roles = "";
            foreach(ListItem item in chklist.Items){
                if (item.Selected)
                {
                    roles += item.Value+",";
                }
            }
            if (roles != "")
            {
                role.ColValue = roles.TrimEnd(',');
            }
            else
            {
                role.ColValue="";
            }
            if (role.RoleId == 0)
            {
                if (bll.Add(role) > 0)
                {
                    webHelper.addLog("新添加了角色“" + role.RoleName + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增角色','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增角色','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.Update(role))
                {
                    webHelper.addLog("修改了角色“" + role.RoleName + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑角色','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑角色','保存失败','',2);</script>");
                }
            }
        }
    }
}