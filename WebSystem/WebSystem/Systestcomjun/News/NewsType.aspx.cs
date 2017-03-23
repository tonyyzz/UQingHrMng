using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.News
{
    public partial class NewsType : BasePage
    {
        ZhongLi.BLL.NewsType bll = new ZhongLi.BLL.NewsType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("9"))
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
            AspNetPager1.RecordCount = bll.GetRecordCount("");
            Repeater1.DataSource = bll.GetListByPage("", "NewsTypeID desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
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
                string delinfo = webHelper.delInfo("NewsType", "Name", "NewsTypeID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除内容类型：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除内容类型','删除成功！','NewsType.aspx',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除内容类型','删除失败！','',2)</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = txtTitle.Text;
            ZhongLi.Model.NewsType nt=new ZhongLi.Model.NewsType();
            nt.Name=name;
            nt.CreateTime=DateTime.Now;
            bll.Add(nt);
            webHelper.addLog("新增内容类型：" + name);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('新增内容类型','新增成功！','NewsType.aspx',1)</script>");
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            
            databind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("save"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ZhongLi.Model.NewsType nt = bll.GetModel(id);
                string name = ((TextBox)e.Item.FindControl("txtName")).Text.Trim();
                nt.Name = name;
                if (bll.Update(nt))
                {
                    webHelper.addLog("修改内容类型：" + name);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('修改内容类型','新增成功！','NewsType.aspx',1)</script>");
                }
                else
                {

                }
            }
        }
    }
}