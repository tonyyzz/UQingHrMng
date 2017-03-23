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

namespace WebSystem.Systestcomjun.ServerUser
{
    public partial class Auth : BasePage
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
                if (Request.QueryString["SerUserID"] != null)
                {
                    int SerUserID = Convert.ToInt32(Request.QueryString["SerUserID"]);
                    ZhongLi.Model.ServerUser user = bll.GetModel(SerUserID);
                    img_Idcard.ImageUrl = user.IDCardImg;
                    //img_SerImg.ImageUrl = user.SerImg ;
                    switch (user.Flag)
                    {
                        case 0:
                            img_Idcard.ImageUrl = "";
                            btnSerImg.Enabled = false;
                            btnSerbh.Visible = false;
                            break;
                        case 1:
                            break;
                        case 2:
                            btnSerImg.Enabled = false;
                            btnSerImg.Text = "已通过";
                            btnSerbh.Visible = false;
                            break;
                        case 3:
                            btnSerImg.Enabled = false;
                            btnSerImg.Text = "已驳回";
                            btnSerbh.Visible = false;
                            break;
                    }
                }
            }
        }

        

        protected void btnSerImg_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SerUserID"] != null)
            {
                int SerUserID = Convert.ToInt32(Request.QueryString["SerUserID"]);
                ZhongLi.Model.ServerUser user = bll.GetModel(SerUserID);
                user.Flag = 2;
                bll.Update(user);
                //添加消息表
                ZhongLi.Model.ServerUser_Message msg = new ZhongLi.Model.ServerUser_Message();
                msg.MesCon = "您的身份认证通过啦";
                msg.SendTime = DateTime.Now;
                msg.SerUserID = SerUserID;
                msg.MesType = 0;
                new ZhongLi.BLL.ServerUser_Message().Add(msg);
                //推送通知
                JPushApiExample.ALERT = "您的身份认证通过啦";
                JPushApiExample.MSG_CONTENT = "您的身份认证通过啦";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "SerAuto");
                JPushApiExample.push(pushsms);

                webHelper.addLog("通过了职业介绍人“" + user.RealName + "”的职能身份认证");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('职业介绍人职业身份认证','认证成功！','Auth.aspx?SerUserID=" + user.SerUserID + "',1)</script>");
            }
        }
        protected void btnSerbh_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SerUserID"] != null)
            {
                int SerUserID = Convert.ToInt32(Request.QueryString["SerUserID"]);
                ZhongLi.Model.ServerUser user = bll.GetModel(SerUserID);
                user.Flag = 3;
                bll.Update(user);
                //添加消息表
                ZhongLi.Model.ServerUser_Message msg = new ZhongLi.Model.ServerUser_Message();
                msg.MesCon = "您的身份认证没有通过审核，需要重新上传哦";
                msg.SendTime = DateTime.Now;
                msg.SerUserID = SerUserID;
                msg.MesType = 0;
                new ZhongLi.BLL.ServerUser_Message().Add(msg);
                //推送通知
                JPushApiExample.ALERT = "您的身份认证没有通过审核，需要重新上传哦";
                JPushApiExample.MSG_CONTENT = "您的身份认证没有通过审核，需要重新上传哦";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s"+SerUserID, "SerAuth");
                JPushApiExample.push(pushsms);
                webHelper.addLog("驳回了职业介绍人“" + user.RealName + "”的职能身份认证");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('职业介绍人职业身份认证','认证成功！','Auth.aspx?SerUserID='" + user.SerUserID + ",1)</script>");
            }
        }
       
    }
}