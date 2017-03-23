using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;

namespace ZhongLi.Common
{
    public class SiteHelper
    {
        #region 属性

        /**/
        /// <summary>
        /// 当前 HttpContent 对象
        /// </summary>
        public static HttpContext CurHttpContext
        {
            get { return HttpContext.Current; }
        }

        /**/
        /// <summary>
        /// 当前 AppDomain 对象
        /// </summary>
        public static AppDomain CurAppDomain
        {
            get { return AppDomain.CurrentDomain; }
        }

        /**/
        /// <summary>
        /// 当前 HttpApplication 对象
        /// </summary>
        public static HttpApplicationState CurHttpApplication
        {
            get { return CurHttpContext.Application; }
        }

        /**/
        /// <summary>
        /// 当前 Server 对象
        /// </summary>
        public static HttpServerUtility CurServer
        {
            get { return CurHttpContext.Server; }
        }

        /**/
        /// <summary>
        /// 当前 Cache 对象
        /// </summary>
        public static Cache CurCache
        {
            get { return CurHttpContext.Cache; }
        }

        /**/
        /// <summary>
        /// 当前 Session 对象
        /// </summary>
        public static HttpSessionState CurSession
        {
            get { return CurHttpContext.Session; }
        }

        /// <summary>
        /// 当前 Request 对象
        /// </summary>
        public static HttpRequest CurRequest
        {
            get { return CurHttpContext.Request; }
        }

        /// <summary>
        /// 当前 Response 对象
        /// </summary>
        public static HttpResponse CurResponse
        {
            get { return CurHttpContext.Response; }
        }

        /// <summary>
        /// 当前应用程序域根目录的绝对路径
        /// </summary>
        public static string CurAppDomainPath
        {
            get { return CurAppDomain.BaseDirectory; }
        }

        /// <summary>
        /// 当前站点根目录的绝对路径
        /// </summary>
        public static string CurSitePath
        {
            get { return CurServer.MapPath("~"); }
        }

        /// <summary>
        /// 当前 RequestCookies 对象
        /// </summary>
        public static HttpCookieCollection CurRequestCookies
        {
            get { return CurRequest.Cookies; }
        }

        /// <summary>
        /// 当前 ResponseCookies 对象
        /// </summary>
        public static HttpCookieCollection CurResponseCookies
        {
            get { return CurResponse.Cookies; }
        }

        /// <summary>
        /// 当前站点虚拟应用程序根路径
        /// </summary>
        public static string CurRequestAppPath
        {
            get { return CurRequest.ApplicationPath; }
        }

        /// <summary>
        /// 当前站点BaseURL
        /// </summary>
        public static string CurSiteBaseUrl
        {
            get
            {
                string strPort = CurRequest.Url.Port == 80 ? "" : ":" + CurRequest.Url.Port.ToString();
                if (CurRequestAppPath == "/")
                {
                    return @"http://" + CurRequest.Url.Host + strPort;
                }
                else
                {
                    return @"http://" + CurRequest.Url.Host + strPort + CurRequest.ApplicationPath;
                }
            }
        }
        #endregion
    }
}
