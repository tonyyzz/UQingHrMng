using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZhouFu.Bll;
using ZhouFu.Common;

namespace ZhouFu.ServiceCs
{
    public class sys_dictionary
    {
        Bll.DataHandler bll = new DataHandler();

        #region 根据父ID获取字典信息
        public string GetDictionaryList(int _ParentId)
        {
            StringBuilder sbStr = new StringBuilder();
            if (_ParentId > 0)
            {
                DataSet ds = bll.GetList("sys_Dictionary", "ID,DtyName,ParentId", "ID", 100, 1, false, false, "ParentId=" + _ParentId);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        sbStr.Append("[{\"msg\":\"获取成功\",\"data\":" + EasyUIJsonHelper.TableToJson(dt) + ",\"state\":\"0\"}]");
                    }
                    else
                    {
                        sbStr.Append("[{\"msg\":\"获取成功,无对应数据,请核实传入参数.\",\"data\":\"\",\"state\":\"1\"}]");
                    }
                }
            }
            return sbStr.ToString();
        }
        #endregion

        #region 获取行政区域
        public string GetCitys(string _Action, string _Code)
        {
            StringBuilder sbStr = new StringBuilder();
            string Fields = string.Empty;
            string SqlWhere = string.Empty;
            switch (_Action)
            {
                case "_Province":
                    Fields = "Code,Province as Name";
                    SqlWhere = "LEN(Code)=2";
                    break;
                case "_City":
                    Fields = "Code,City as Name";
                    SqlWhere = string.Format("LEN(Code)=4 and Code like '{0}%'", _Code);
                    break;
                case "_County":
                    Fields = "Code,county as Name";
                    SqlWhere = string.Format("LEN(Code)=7 and Code like '{0}%'", _Code);
                    break;
            }
            DataTable dt = bll.GetList("sys_City", Fields, "Code", 100, 1, false, false, SqlWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sbStr.Append("[{\"msg\":\"获取成功\",\"data\":" + EasyUIJsonHelper.TableToJson(dt) + ",\"state\":\"0\"}]");
            }
            else
            {
                sbStr.Append("[{\"msg\":\"获取成功,无对应数据,请核实传入参数.\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 获取字典名称
        public string GetDicName(object _DicId)
        {
            string strResult = string.Empty;
            if (_DicId != null && Convert.ToInt32(_DicId) > 0)
            {
                object objName = DBUtility.DbHelperSQL.GetSingle("select DtyName from sys_Dictionary where ID=" + _DicId);
                if (objName != null)
                {
                    strResult = objName.ToString();
                }
            }
            return strResult;
        }
        #endregion

        #region 获取行政区划信息
        public string GetCitysName(object _Field,object _Code)
        {
            string strResult = string.Empty;
            if (_Field != null && _Code !=null)
            {
                object objName = DBUtility.DbHelperSQL.GetSingle(string.Format("select {0} from sys_City where Code='{1}'", _Field, _Code));
                if (objName != null)
                {
                    strResult = objName.ToString();
                }
            }
            return strResult;
        }
        #endregion
    }
}
