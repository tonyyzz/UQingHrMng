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
    public partial class SerUserPost : BasePage
    {
        ZhongLi.BLL.ServerUser_Post bll = new ZhongLi.BLL.ServerUser_Post();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        private void databind()
        {
			string where = " 1=1 ";
			string orderStr = "";
			string timeOrderStr = ddTimeOrder.SelectedValue;
			int timeOrderInt = 0; int.TryParse(timeOrderStr, out timeOrderInt);
			if (timeOrderInt <= 0 || timeOrderInt > 2)
			{
				timeOrderInt = 1;
			}
			switch (timeOrderInt)
			{
				case 1: orderStr = "CreateTime desc"; break;
				case 2: orderStr = "CreateTime asc"; break;
				default: orderStr = "CreateTime desc"; break;
			}

            string key = Utils.ReplaceString(txtkey.Text.Trim());
			if (ddlIsSole.SelectedValue != "")
			{
				where += " and IsSole=" + ddlIsSole.SelectedValue;
			}
			if (!string.IsNullOrWhiteSpace(key))
			{
				where += " and (RealName like '%" + key + "%' or PostName like '%" + key + "%' or Company like '%" + key + "%')";
			}
            AspNetPager1.RecordCount = bll.GetRecordCountPost(where);
			Repeater1.DataSource = bll.GetListByPage(where, "CONVERT(int,Colvalue)," + orderStr, AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
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
                string delinfo = webHelper.delInfo("ServerUser_Post", "PostName", "SerUserPostID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除人才经纪人职位：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除人才经纪人职位','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除人才经纪人职位','删除失败！','',2)</script>");
                }
            }
        }

        protected void btnSaveSort_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                int id = Convert.ToInt32(((HiddenField)item.FindControl("txtid")).Value);
                int Sort = Convert.ToInt32(((TextBox)item.FindControl("txtSort")).Text);
                bll.UpdateSort(id, Sort);
            }
            databind();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('修改排序','保存成功！','',1)</script>");
        }

        protected void btnSetSole_Click(object sender, EventArgs e)
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
                if (bll.setSole(ids))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除人才经纪人职位','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除人才经纪人职位','删除失败！','',2)</script>");
                }
            }
        }

        protected void btnDelSole_Click(object sender, EventArgs e)
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
                if (bll.delSole(ids))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除人才经纪人职位','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除人才经纪人职位','删除失败！','',2)</script>");
                }
            }
        }
    }
}