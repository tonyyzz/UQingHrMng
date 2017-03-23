using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.SysLog
{
    public partial class List : BasePage
    {
        ZhongLi.Bll.sys_Logs bll = new ZhongLi.Bll.sys_Logs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("13"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                databind();
            }
        }

        private string getwhere()
        {
            string UserName = Utils.ReplaceString(txtUserName.Text.Trim());
            string Remark = Utils.ReplaceString(txtRemark.Text.Trim());
            string where = " (UserName like '%" + UserName + "%' or RealName like '%" + UserName + "%') and Remark like '%" + Remark + "%'";
            return where;
        }

        private void databind()
        {
            string where = getwhere();
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, " AddTime desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            string ids = "";
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
                ids = ids.TrimEnd(',');
                if (bll.DeleteList(ids))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除日志','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除日志','删除失败！','',2)</script>");
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databind();
        }
    }
}