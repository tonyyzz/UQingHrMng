using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ServerUser
{
    public partial class More : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("4"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["SerUserID"] != null)
                {
                    int SerUserID = Convert.ToInt32(Request.QueryString["SerUserID"]);
                    ZhongLi.Model.ServerUser user = new ZhongLi.BLL.ServerUser().GetModel(SerUserID);
                    //自我介绍
                    ltldes.Text = user.Describe;
                    //工作经历
                    rptWork.DataSource = new ZhongLi.BLL.ServerUser_Work().GetList(" SerUserID="+SerUserID);
                    rptWork.DataBind();
                    //教育经历
                    rptEdu.DataSource = new ZhongLi.BLL.ServerUser_Education().GetList(" SerUserID="+SerUserID);
                    rptEdu.DataBind();
                    //标签
                    rptTag.DataSource = new ZhongLi.BLL.ServerUser_Tag().GetList(" SerUserID="+SerUserID);
                    rptTag.DataBind();
                    //评价
                    rptEvaluate.DataSource = new ZhongLi.BLL.ServerUser_Evaluate().GetList(" SerUserID="+SerUserID);
                    rptEvaluate.DataBind();
                }
            }
        }
    }
}