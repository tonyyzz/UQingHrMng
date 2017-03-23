using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ServerUser
{
    public partial class List : BasePage
    {
        ZhongLi.BLL.ServerUser bll = new ZhongLi.BLL.ServerUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("5"))
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
            string key = Utils.ReplaceString(txtkey.Text);
            string where = " (RealName like '%" + key + "%' or Phone like '%" + key + "%')";
            if(ddlauth.SelectedValue!=""){
                where += " and Flag=" + ddlauth.SelectedValue;
            }
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where, "RegTime desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
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
                string delinfo = webHelper.delInfo("ServerUser", "RealName", "SerUserID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除职业介绍人：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除职业介绍人','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除职业介绍人','删除失败！','',2)</script>");
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

        public string authstate(string state)
        {
            string res = "";
            switch (state)
            {
                case "0":
                    res = "未认证";
                    break;
                case "1":
                    res = "<span style='color:blue'>待审核</span>";
                    break;
                case "2":
                    res = "<span style='color:green'>已认证</span>";
                    break;
                case "3":
                    res = "<span style='color:red'>驳回</span>";
                    break;
            }
            return res;
        }
    }
}