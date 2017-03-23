using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.UserManagers
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (Utils.GetCookie("UserID") != "")
            {
                string action = context.Request.Form["action"];
                if (action == "chkuser")
                {
                    string user = context.Request.Form["User"];
                    if (new ZhongLi.BLL.User_Managers().checkUserName(user))
                    {
                        context.Response.Write("true");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }

                }
            }
            else
            {
                context.Response.Write("cookieNull");
            }
            
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