using cn.jpush.api.push.mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using WebSystem.Systestcomjun.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.PresentApplication
{
    public partial class AuthList : BasePage
    {
        ZhongLi.BLL.PresentApplication bll = new ZhongLi.BLL.PresentApplication();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("11"))
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
            string where = " RealName like '%"+key+"%'";
            AspNetPager1.RecordCount = bll.GetRecordCount(where);
            Repeater1.DataSource = bll.GetListByPage(where," state",AspNetPager1.StartRecordIndex,AspNetPager1.EndRecordIndex);
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
                string delinfo = webHelper.delInfo("PresentApplication", "RealName", "ID", ids);
                if (bll.DeleteList(ids))
                {
                    webHelper.addLog("删除提现申请：" + delinfo);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除提现申请','删除成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除提现申请','删除失败！','',2)</script>");
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            int adminid = Convert.ToInt32(Utils.GetCookie("UserID"));
            string adminname = new ZhongLi.BLL.User_Managers().GetModel(adminid).RealName;
            string realname = ((Literal)e.Item.FindControl("ltlrealname")).Text;
            ZhongLi.Model.PresentApplication p = bll.GetModel(ID);
            if (e.CommandName.Equals("auth"))
            {
                if (bll.authPass(adminid, adminname, ID,p.UserType.Value,p.UserID.Value))
                {
                    //推送通知
                    string UserID = "";
                    if (p.UserType.Value == 0)//用户类型为人才
                    {
                        UserID = "p" + p.UserID;
                    }
                    else
                    {
                        UserID = "s" + p.UserID;
                    }
                    JPushApiExample.ALERT = "您的提现申请审核通过啦，优青将会在3个工作日之内将体现金额支付到您的账户";
                    JPushApiExample.MSG_CONTENT = "您的提现申请审核通过啦，优青将会在3个工作日之内将体现金额支付到您的账户";
                    PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras(UserID, "Present");
                    JPushApiExample.push(pushsms);
                    webHelper.addLog(adminname + "通过了：" + realname + "的提现申请");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('审核提现申请','操作成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('审核提现申请','操作失败！','',2)</script>");
                }

            }
            if (e.CommandName.Equals("noauth"))
            {
                if (bll.noauthPass(adminid, adminname, ID, p.UserType.Value, p.UserID.Value))
                {
                    //推送通知
                    //推送通知
                    string UserID = "";
                    if (p.UserType.Value == 0)//用户类型为人才
                    {
                        UserID = "p" + p.UserID;
                    }
                    else
                    {
                        UserID = "s" + p.UserID;
                    }
                    JPushApiExample.ALERT = "您的提现申请没有通过审核";
                    JPushApiExample.MSG_CONTENT = "您的提现申请没有通过审核";
                    PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras(UserID, "Present");
                    JPushApiExample.push(pushsms);
                    webHelper.addLog(adminname + "没通过：" + realname + "的提现申请");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('审核提现申请','操作成功！','',1)</script>");
                    databind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('审核提现申请','操作失败！','',2)</script>");
                }
            }
        }

        public string stateStr(string s)
        {
            string str = "";
            switch (s)
            {
                case "0":
                    str = "未审核";
                    break;
                case "1":
                    str = "已审核";
                    break;
                case "2":
                    str = "已支付";
                    break;
                case "3":
                    str = "支付失败";
                    break;
                case "4":
                    str = "审核不通过";
                    break;
            }
            return str;
        }
    }
}