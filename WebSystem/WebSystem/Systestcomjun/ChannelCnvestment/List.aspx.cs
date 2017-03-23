using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ChannelCnvestment
{
    public partial class List : System.Web.UI.Page
    {
        ZhongLi.BLL.ChannelCnvestment bll = new ZhongLi.BLL.ChannelCnvestment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("18"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                databind();
            }
        }

        private void databind()
        {
            string CPTitle = Utils.ReplaceString(txtCPTitle.Text.Trim());
            string where = " Company like '%" + CPTitle + "%'";
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, " ID desc ", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
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
                string delinfo = webHelper.delInfo("ChannelCnvestment", "Company", "ID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除渠道招商：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除渠道招商','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除渠道招商','删除失败！','',2)</script>");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            databind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            databind();
        }
    }
}