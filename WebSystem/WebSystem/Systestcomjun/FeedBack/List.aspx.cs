using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.FeedBack
{
    public partial class List : BasePage
    {
        ZhongLi.BLL.FeedBack bll=new ZhongLi.BLL.FeedBack();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bindDate();
            }
        }

        private void bindDate(){
            string IsRead = txtIsRead.Value;
            string strWhere = "";
            if (IsRead == "0")
            {
                strWhere = " State=0";
            }
            else if (IsRead == "1")
            {
                strWhere = " State=1";
            }
            AspNetPager1.RecordCount =bll.GetRecordCount(strWhere);
            Repeater1.DataSource =bll.GetListByPage(strWhere, " ID desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
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
                if (bll.DeleteList(ids))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除用户反馈','删除成功！','',1)</script>");
                    bindDate();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除用户反馈','删除失败！','',2)</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtIsRead.Value = "0";
            bindDate();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindDate();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtIsRead.Value = "1";
            bindDate();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            txtIsRead.Value = "";
            bindDate();
        }
    }
}