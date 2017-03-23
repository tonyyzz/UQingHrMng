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
    public partial class List : BasePage
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
                redatabind();
            }
        }

        private void redatabind()
        {
            string realname =Utils.ReplaceString(txtRealName.Text.Trim());
            string where = " RealName like '%"+realname+"%'";
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, " CreateDate desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            redatabind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            redatabind();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            string ids="";
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkid");
                if (chk.Checked)
                {
                    HiddenField txtid = (HiddenField)item.FindControl("txtid");
                    ids += txtid.Value + ",";
                }
            }
            if (ids != "")
            {
                ids=ids.TrimEnd(',');
                string delinfo = webHelper.delInfo("User_Managers", "UserName", "UserID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除了用户："+delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除用户','删除成功！','',1)</script>");
                    redatabind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除用户','删除失败！','',2)</script>");
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("czmm"))
            {
                int UserID = Convert.ToInt32(e.CommandArgument);
                User_Managers user = bll.GetModel(UserID);
                user.Password = DESEncrypt.EncryptDES("123456");
                if (bll.Update(user))
                {
                    redatabind();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('重置密码','重置密码成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('重置密码','重置密码失败！','',2)</script>");
                }
            }
        }

     

     
    }
}