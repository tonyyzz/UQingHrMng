using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ZhouFu.DBUtility;
using System.Data;
using ZhouFu.Common;

namespace ZhouFu.ServiceCs
{
    public class sys_News
    {
        #region 获取资讯列表
        public string GetNewsList(int _ClassId, int _Page, int _PageSize)
        {
            StringBuilder sbStr = new StringBuilder();
            if (_Page == 0) { _Page = 1; }
            if (_PageSize == 0) { _PageSize = 10; }
            StringBuilder sbSqlWhere = new StringBuilder();
            sbSqlWhere.AppendFormat(" Isdel=0 and ClassId={0} and IsApp=1", _ClassId);
            ZhouFu.Bll.DataHandler bll = new Bll.DataHandler();
            DataSet ds = bll.GetList("sys_News", "ID,Title,Url,AddTime", "AddTime", _PageSize, _Page, false, false, sbSqlWhere.ToString());
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                sbStr.AppendFormat("[{\"msg\":\"查询成功，无相应的数据。\",\"data\":\"{0}\",\"state\":\"0\"}]", EasyUIJsonHelper.TableToJson(dt));
            }
            else
            {
                sbStr.Append("[{\"msg\":\"查询成功，无相应的数据。\",\"data\":\"\",\"state\":\"0\"}]");
            }
            return sbStr.ToString();
        }
        #endregion
        
    }
}
