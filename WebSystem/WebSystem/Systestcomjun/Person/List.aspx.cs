using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Person
{
    public partial class List : System.Web.UI.Page
    {
        ZhongLi.BLL.Person bll = new ZhongLi.BLL.Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Utils.CheckRole("4"))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                    return;
                }
                databind();
            }
        }

        private string getwhere()
        {
            string key = Utils.ReplaceString(txtkey.Text);
            string where = " RealName like '%" + key + "%' or Phne like '%" + key + "%'";
            return where;
        }

        private void databind()
        {
            string where = getwhere();
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage("","RegTime desc",AspNetPager1.StartRecordIndex,AspNetPager1.EndRecordIndex);
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
                string delinfo = webHelper.delInfo("Person", "RealName", "PerID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除求职者：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除求职者','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除求职者','删除失败！','',2)</script>");
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

        public string strFlag(string flag)
        {
            string str = "";
            switch (flag)
            {
                case "0":
                    str = "未认证";
                    break;
                case "1":
                    str = "待审核";
                    break;
                case "2":
                    str = "已认证";
                    break;
                case "3":
                    str = "已驳回";
                    break;
            }
            return str;
        }
    }
}