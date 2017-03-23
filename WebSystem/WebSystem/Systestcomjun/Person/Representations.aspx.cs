using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Person
{
    public partial class Representations : BasePage
    {
        ZhongLi.BLL.Person_Representations bll = new ZhongLi.BLL.Person_Representations();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("8"))
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
            string key = Utils.ReplaceString(txtkey.Text.Trim());
            string where = " RealName like '%"+key+"%' or Phne like '%"+key+"%'";
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where," State ",AspNetPager1.StartRecordIndex,AspNetPager1.EndRecordIndex);
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
                string delinfo = webHelper.delInfo("View_Representations", "RealName,OrderNum", "ID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除申述：" + delinfo+"");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除申述','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除申述','删除失败！','',2)</script>");
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            
            databind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("auth"))
            {
                if (bll.AuthPass(ID))
                {
                    string delinfo = webHelper.delInfo("View_Representations", "RealName,OrderNum", "ID", ID + "");
                    webHelper.addLog("通过申述：" + delinfo + "");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('通过申述','操作成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('通过申述','操作失败！','',2)</script>");

                }
                
            }
            if (e.CommandName.Equals("bohui"))
            {
                bll.EditState(2, ID);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('驳回申述','操作成功！','',1)</script>");
            }
            databind();
        }
    }
}