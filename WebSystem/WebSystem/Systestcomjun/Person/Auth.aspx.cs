using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using WebSystem.Systestcomjun.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Person
{
    public partial class Auth : BasePage
    {
        ZhongLi.BLL.Person bll = new ZhongLi.BLL.Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("4"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (Request.QueryString["PerID"]!=null)
            {
                int PerID = Convert.ToInt32(Request.QueryString["PerID"]);
                ZhongLi.Model.Person person = bll.GetModel(PerID);
                if (person.AuthImg != "")
                {
                    img_Auto.ImageUrl = person.AuthImg;
                }
                else
                {
                    btnsave.Text = "尚未上传认证图片";
                    btnsave.Enabled = false;
                }
                if (person.Flag == 2)
                {
                    btnsave.Text = "已认证";
                    btnsave.Enabled = false;
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["PerID"] != null)
            {
                int PerID = Convert.ToInt32(Request.QueryString["PerID"]);
                ZhongLi.Model.Person person = bll.GetModel(PerID);
                person.Flag = 2;
                bll.Update(person);
                //添加消息表
                ZhongLi.Model.Person_Message msg = new ZhongLi.Model.Person_Message();
                msg.MesCon = "您的身份认证通过啦,赶紧去发布职位悬赏吧~";
                msg.SendTime = DateTime.Now;
                msg.PerID = PerID;
                msg.MesType = 0;
                new ZhongLi.BLL.Person_Message().Add(msg);
                //推送通知
                PushClass push = new PushClass();
                push.title = "优青通知";
                push.content = "您的身份认证通过啦，赶紧去发布职位悬赏吧~";
                push.type = "1";
                push.platform = "0";
                push.groupName = "person";
                push.userIds = "p" + PerID;
                push.ts_01();
                
                webHelper.addLog("通过了求职者“" + person.RealName + "”的身份认证");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('求职者认证','认证成功！','Auth.aspx?PerID='"+person.PerID+",1)</script>");
            }
        }

        protected void btnPerbh_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["PerID"] != null)
            {
                int PerID = Convert.ToInt32(Request.QueryString["PerID"]);
                ZhongLi.Model.Person person = bll.GetModel(PerID);
                person.Flag = 3;
                person.AuthTime = DateTime.Now;
                bll.Update(person);
                //添加消息表
                ZhongLi.Model.Person_Message msg = new ZhongLi.Model.Person_Message();
                msg.MesCon = "您的身份认证被驳回了，需要重新上传哦";
                msg.SendTime = DateTime.Now;
                msg.PerID = PerID;
                msg.MesType = 0;
                new ZhongLi.BLL.Person_Message().Add(msg);
                //推送通知
                PushClass push = new PushClass();
                push.title = "优青通知：";
                push.content = "您的身份认证被驳回了，需要重新上传哦";
                push.type = "1";
                push.platform = "0";
                push.groupName = "person";
                push.userIds = "p" + PerID;
                push.ts_01();

                webHelper.addLog("通过了求职者“" + person.RealName + "”的身份认证");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('求职者认证','认证成功！','Auth.aspx?PerID='" + person.PerID + ",1)</script>");
            }
        }
    }
}