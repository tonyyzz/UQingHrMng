using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.PostInfo
{
    public partial class List : System.Web.UI.Page
    {
        ZhongLi.BLL.PostType bll = new ZhongLi.BLL.PostType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        private void databind()
        {
            if (Request.QueryString["TID"] != null)
            {
                int TID = Convert.ToInt32(Request.QueryString["TID"]);
                txtTID.Value = TID + "";
                string key = Utils.ReplaceString(txtKey.Text.Trim());
                string where = " PostName like '%" + key + "%' and ColInt="+TID;
                AspNetPager1.RecordCount = bll.GetPostRecordCount(where);
                Repeater1.DataSource = bll.GetPostListByPage(where, "", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
                Repeater1.DataBind();
            }
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
                if (bll.DeletePostName(ids))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除职位数据','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除职位数据','删除失败！','',2)</script>");
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