using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebSystem.AppCode;
using ZhongLi.Common;
using ZhongLi.Model;

namespace WebSystem.Systestcomjun
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler, IReadOnlySessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["action"];
            string res = "";
            switch (action)
            {
                case "login":
                    string user=context.Request.Form["user"];
                    string password = context.Request.Form["password"];
                    int userid=new ZhongLi.BLL.User_Managers().checkuser(user,password);
                    if (userid == 0)
                    {
                        res = "2";
                    }
                    else
                    {
                        //context.Session["UserID"] = userid;
                        User_Managers usermng = new ZhongLi.BLL.User_Managers().GetModel(userid);
                        Roles role = new ZhongLi.BLL.Roles().GetModel(usermng.RoleId);
                        Utils.WriteCookie("role", role.ColValue);
                        Utils.WriteCookie("UserID",userid+"");
                        webHelper.addLog("登录系统");
                        res = "1";
                    }
                    break;
            }
            context.Response.Write(res);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}