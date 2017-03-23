using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.CooperativePartner
{
    public partial class list : System.Web.UI.Page
    {
        ZhongLi.BLL.CooperativePartner bll = new ZhongLi.BLL.CooperativePartner();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("14"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                databind();
            }

        }
        public void databind()
        {
            string where = getwhere();
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, " Sort,CreateDate desc ", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
        }
        private string getwhere()
        {
            string Name = Utils.ReplaceString(txtTitle.Text.Trim());
            string where = " Name like '%" + Name + "%'";
            return where;
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
                string delinfo = webHelper.delInfo("News", "Title", "NewsID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除内容：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除内容','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除内容','删除失败！','',2)</script>");
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