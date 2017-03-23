using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebSystem.Systestcomjun.ashx
{
    /// <summary>
    /// sys_City 的摘要说明
    /// </summary>
    public class sys_City : IHttpHandler
    {
        string strResult = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string types = context.Request["types"];
            switch (types)
            {
                case "ProvinceLoad"://省份加载
                    ProvinceLoad(context);
                    break;
                case "CityLoad"://城市加载
                    CityLoad(context);
                    break;
                case "CountyLoad"://县区加载
                    CountyLoad(context);
                    break;
            }
            context.Response.Write(strResult);
            context.Response.End();
        }
        /// <summary>
        /// 获取省份
        /// </summary>
        /// <param name="context"></param>
        public void ProvinceLoad(HttpContext context)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = new ZhongLi.Bll.sys_City().GetList(" LEN(Code)=2 ", "Code,Province");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                strResult = ZhongLi.Common.EasyUIJsonHelper.TableToJson(ds.Tables[0]);
                strResult = strResult.Insert(1, "{\"Code\":\"0\",\"Province\":\"省份\"},");
            }
        }
        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="context"></param>
        public void CityLoad(HttpContext context)
        {
            string code = context.Request["code"];
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = new ZhongLi.Bll.sys_City().GetList(" LEN(Code)=4 and  Code like '"+code+"%'", "Code,City");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                strResult = ZhongLi.Common.EasyUIJsonHelper.TableToJson(ds.Tables[0]);
                strResult = strResult.Insert(1, "{\"Code\":\"0\",\"City\":\"城市\"},");
            }
        }
        /// <summary>
        /// 获取县区
        /// </summary>
        /// <param name="context"></param>
        public void CountyLoad(HttpContext context)
        {
            string code = context.Request["code"];
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = new ZhongLi.Bll.sys_City().GetList(" LEN(Code)=7 and  Code like '" + code + "%'", "Code,county");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                strResult = ZhongLi.Common.EasyUIJsonHelper.TableToJson(ds.Tables[0]);
                strResult = strResult.Insert(1, "{\"Code\":\"0\",\"county\":\"区县\"},");
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