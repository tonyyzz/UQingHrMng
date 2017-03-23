using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Reflection;

namespace ZhongLi.Common
{
    public class EasyUIJsonHelper
    {


        /// <summary>
        /// (1)TreeGrid 非异步 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="total">总条数</param>
        /// <param name="pCol">父ID字段名</param>
        /// <param name="rootValue">根节点的值</param>
        /// <returns></returns>
        public static string TableToTreeGrid(DataTable dt, int total, string pCol, object rootValue)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> jsonList = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                if (result[pCol].ToString() != rootValue.ToString())
                {
                    result.Add("_parentId", result[pCol]);
                }
                else
                {
                    result.Add("state", "closed");
                }
                list.Add(result);
            }
            jsonList.Add("total", total);
            jsonList.Add("rows", list);
            return ToJson(jsonList);//调用Serializer方法 
        }

        /// </summary>
        /// <param name="dt"></param>
        ///<param name="total">总条数</param>
        ///<param name="pCol">父ID字段名</param>
        ///<param name="rootValue">根节点的值</param>
        ///<param name="contrastdt">对比数据源</param>
        ///<param name="ColumnName">数据源字段名</param>
        ///<param name="ColumnName">对比数据源字段名</param>
        /// <returns></returns>
        public static string TableToTreeGrid(DataTable dt, int total, string pCol, object rootValue, DataTable contrastdt, string dtColumnName, string contrastColumnName)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> jsonList = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                    if (dc.ColumnName == dtColumnName)//如为对比字段
                    {
                        if (contrastdt.Rows.Count > 0)
                        {
                            for (int i = 0; i < contrastdt.Rows.Count; i++)
                            {
                                if (dr[dc].ToString() == contrastdt.Rows[i][contrastColumnName].ToString())
                                {
                                    result.Add("checked", "true");
                                }
                                else
                                {
                                    string dcvalue = dr[dc].ToString();
                                    string convalue = contrastdt.Rows[i][contrastColumnName].ToString();
                                }
                            }
                        }
                    }
                }
                if (result[pCol].ToString() != rootValue.ToString())
                {
                    result.Add("_parentId", result[pCol]);
                }
                else
                {
                    result.Add("state", "closed");
                }
                list.Add(result);
            }
            jsonList.Add("total", total);
            jsonList.Add("rows", list);
            return ToJson(jsonList);//调用Serializer方法 
        }



        /// <summary>
        /// 将根节点转化为json对象 (1_1)TreeGrid异步
        /// </summary>
        /// <param name="list">根节点数据集合</param>
        /// <returns></returns>
        public static string GetRootJson(DataTable dt, int total, string pCol, object rootValue)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> jsonList = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
            {
                if (dr[pCol].ToString() == rootValue.ToString())
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        result.Add(dc.ColumnName, dr[dc].ToString());
                    }
                    result.Add("state", "closed");
                    list.Add(result);
                }
            }
            jsonList.Add("total", total);
            jsonList.Add("rows", list);
            return ToJson(jsonList);//调用Serializer方法 
        }


        /// <summary>
        /// 获得子节点数据  (1_2)TreeGrid异步
        /// </summary>
        /// <param name="dt">所有数据集合</param>
        /// <param name="id">传过来的id</param>
        /// <param name="total">总条数</param>
        /// <param name="pCol">父ID字段名</param>
        /// <param name="idCol">ID字段名</param>
        /// <returns></returns>
        public static string GetSubJson(DataTable dt, int id, int total, string pCol, string idCol)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> jsonList = new Dictionary<string, object>();

            string p = string.Format("{0}='{1}'", pCol, id);
            DataRow[] parents = dt.Select(p);
            if (parents.Length < 1)
            {
                return "[]";
            }
            foreach (var item in parents)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, item[dc].ToString());
                }
                result.Add("_parentId", result[pCol]);
                string c = string.Format("{0}='{1}'", pCol, item[idCol].ToString());
                DataRow[] childs = dt.Select(c);
                if (childs.Length > 0)
                {
                    result.Add("state", "closed");
                }
                list.Add(result);
            }
            jsonList.Add("total", total);
            jsonList.Add("rows", list);
            return ToJson(jsonList);//调用Serializer方法 
        }

        //(2)tree ,combotree
        /// <summary>
        /// 递归将DataTable转化为适合jquery easy ui 控件tree ,combotree 的 json
        /// 该方法最后还要 将结果稍微处理下,将最前面的,"children" 字符去掉;    返回结果.Substring(12)
        /// </summary>
        /// <param name="dt">要转化的表</param>
        /// <param name="pField">表中的父节点字段</param>
        /// <param name="pValue">表中顶层节点的值,没有 可以输入为0</param>
        /// <param name="kField">关键字字段名称</param>
        /// <param name="TextField">要显示的文本 对应的字段</param>
        /// <returns></returns>
        public static string TableToTree(DataTable dt, string pField, string pValue, string kField, string TextField)
        {
            StringBuilder sb = new StringBuilder();
            string filter = string.Empty;
            if (pValue.ToString() == "")
            {
                filter = string.Format("{0} is null", pField);
            }
            else
            {
                filter = string.Format("{0}='{1}'", pField, pValue);
            }
            DataRow[] drs = dt.Select(filter);
            if (drs.Length < 1)
                return "";
            sb.Append(",\"children\":[");
            foreach (DataRow dr in drs)
            {
                string pcv = dr[kField].ToString();
                sb.Append("{");
                sb.AppendFormat("\"id\":\"{0}\",", dr[kField].ToString());
                sb.AppendFormat("\"text\":\"{0}\"", dr[TextField].ToString());
                sb.Append(TableToTree(dt, pField, pcv, kField, TextField).TrimEnd(','));
                sb.Append("},");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();

        }

        //(3)datagrid 
        /// <summary>
        /// datagrid 序列化
        /// </summary>
        /// <param name="dt">数据集合</param>
        ///<param name="total">总条数</param>
        /// <returns></returns>
        public static string TableToDataGrid(DataTable dt, int total)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> jsonList = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                list.Add(result);
            }
            jsonList.Add("total", total);
            jsonList.Add("rows", list);
            return ToJson(jsonList);//调用Serializer方法 
        }

        //(4)combobox 表单  
        /// <summary>
        /// combobox 表单 普通json 不带总条数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string TableToJson(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                list.Add(result);
            }
            return ToJson(list);//调用Serializer方法 
        }


        /// <summary>
        /// 将list集合转换为json   datagrid
        /// </summary>
        /// <param name="list"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static string ListToJson(object list, int total)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("total", total);
            d.Add("rows", list);
            return ToJson(d);
        }


        /// <summary>
        /// 将集合转换为json
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToJson(object d)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(d);
        }


        /// <summary>
        /// 将表单里的值赋值到对象
        /// </summary>
        /// <param name="Form"></param>
        /// <param name="obj"></param>
        public static void Form2Model(NameValueCollection Form, Object obj)
        {

            Type type = obj.GetType();
            PropertyInfo[] pi = type.GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo m in pi)
            {
                string name = m.Name;
                string value = Form[name];
                object val = m.GetValue(obj, null);
                if (value == "" && val != null)
                {
                    m.SetValue(obj, null, null);
                }

                if (!"".Equals(value) && value != null)
                {
                    Type Propertytype = m.PropertyType;
                    Object o = null;
                    if (Propertytype.ToString() == "System.Nullable`1[System.Decimal]")
                    {
                        o = Convert.ToDecimal(value);
                    }
                    else if (Propertytype.ToString() == "System.Nullable`1[System.Int32]")
                    {
                        o = Convert.ToInt32(value);
                    }
                    else if (Propertytype.ToString() == "System.Nullable`1[System.DateTime]")
                    {
                        o = Convert.ToDateTime(value);
                    }
                    else if (Propertytype.ToString() == "System.Nullable`1[System.Single]")
                    {
                        o = Convert.ToSingle(value);
                    }
                    else
                    {
                        o = Convert.ChangeType(value, Propertytype);
                    }
                    m.SetValue(obj, o, null);
                }
            }
        }

    }
}
