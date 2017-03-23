using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.JobTraining
{
    public partial class List : System.Web.UI.Page
    {
        ZhongLi.BLL.JobTraining bll = new ZhongLi.BLL.JobTraining();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("6"))
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
            string JobTraTitle = Utils.ReplaceString(txtJobTraTitle.Text.Trim());
            string where = " JobTraTitle like '%" + JobTraTitle + "%'";
            return where;
        }

        private void databind()
        {
            string where = getwhere();
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, " sort ", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
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
                string delinfo = webHelper.delInfo("JobTraining", "JobTraTitle", "JobTraID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除职位信息：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除职位信息','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除职位信息','删除失败！','',2)</script>");
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

        protected void btnSaveSort_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                int id = Convert.ToInt32(((HiddenField)item.FindControl("txtid")).Value);
                int Sort = Convert.ToInt32(((TextBox)item.FindControl("txtSort")).Text);
                bll.UpdateSort(id,Sort);
            }
            databind();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('修改排序','保存成功！','',1)</script>");
        }
    }
}