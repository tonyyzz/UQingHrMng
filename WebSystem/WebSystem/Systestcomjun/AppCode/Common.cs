using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;

namespace WebSystem.Systestcomjun.AppCode
{
    public class Common
    {
        /// <summary>
        /// 将list转化为json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2Json<T>(IList<T> list)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"total\":" + list.Count + ", \"rows\":");
            sb.Append(jss.Serialize(list));
            sb.Append("}");
            return sb.ToString();
        }





        /// <summary>
        /// 将根节点转化为json对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2JsonParentByDictionary(IList<ZhongLi.Model.sys_Dictionary> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"total\":" + list.Count + ", \"rows\":[");
            foreach (var item in list)
            {
                if (item.ParentId == 0)
                {
                    sb.Append("{");
                    sb.Append("\"ID\":" + item.ID + ",\"DtyName\":\"" + item.DtyName + "\",\"EdtyName\":\"" + item.EdtyName + "\",\"Sort\":\"" + item.Sort + "\",\"state\":\"closed\"");
                    sb.Append("},");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// 将子节点转化为json对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2JsonSubByDictionary(IList<ZhongLi.Model.sys_Dictionary> list, int id)
        {
            if (list == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            //获取父级节点
            IList<ZhongLi.Model.sys_Dictionary> parent = (from p in list
                                                        where p.ParentId == id
                                                        select p).ToList();

            sb.Append("{\"total\":" + list.Count + ", \"rows\":[");
            foreach (var item in parent)
            {
                //得到当前父节点下面的所有子节点
                IList<ZhongLi.Model.sys_Dictionary> child = (from p in list
                                                           where p.ParentId == item.ID
                                                           select p).ToList();
                //当前父节点是否有子节点
                if (child.Count > 0)
                {
                    sb.Append("{");
                    sb.Append("\"ID\":" + item.ID + ",\"DtyName\":\"" + item.DtyName + "\",\"EdtyName\":\"" + item.EdtyName + "\",\"Sort\":\"" + item.Sort + "\",\"_parentId\":" + item.ParentId + ",\"state\":\"closed\"");
                    sb.Append("},");
                }
                else
                {
                    sb.Append("{");
                    sb.Append("\"ID\":" + item.ID + ",\"DtyName\":\"" + item.DtyName + "\",\"EdtyName\":\"" + item.EdtyName + "\",\"Sort\":\"" + item.Sort + "\",\"_parentId\":" + item.ParentId + "");
                    sb.Append("},");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            sb.Append("}");
            return sb.ToString();
        }






        /// <summary>
        /// 生成表单编辑赋值 JSON格式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="displayCount"></param>
        /// <returns></returns>
        public static string CreateJsonOne(DataTable dt)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString().ToLower() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString().ToLower() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }

                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }

        }




        /// <summary>
        /// 递归将DataTable转化为适合jquery easy ui 控件tree ,combotree 的 json
        /// 该方法最后还要 将结果稍微处理下,将最前面的,"children" 字符去掉.
        /// </summary>
        /// <param name="dt">要转化的表</param>
        /// <param name="pField">表中的父节点字段</param>
        /// <param name="pValue">表中顶层节点的值,没有 可以输入为0</param>
        /// <param name="kField">关键字字段名称</param>
        /// <param name="TextField">要显示的文本 对应的字段</param>
        /// <returns></returns>
        public static string TableToEasyUITreeJson(DataTable dt, string pField, string pValue, string kField, string TextField)
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
                if (pValue == "0")
                {
                    sb.Append(",\"state\":\"closed\"");
                }
                sb.Append(TableToEasyUITreeJson(dt, pField, pcv, kField, TextField).TrimEnd(','));
                sb.Append("},");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();

        }



        /// <summary>
        /// 返回easyui中treegrid使用的json格式
        /// </summary>
        /// <param name="dt">datatable数据</param>
        /// <param name="count">总的条数</param>
        /// <param name="pColName">父ID字段名</param>
        /// <param name="rootId">根节点的值</param>
        /// <returns></returns>
        public static string DataTotreegridJson(DataTable dt, int count, string pColName, object rootId)
        {
            StringBuilder sbjson = new StringBuilder();
            sbjson.Append("{");
            sbjson.Append("\"total\":" + count + ",\"rows\":[");
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        sbjson.Append(",");
                        sbjson.Append("{");
                        foreach (DataColumn dc in dt.Columns)
                        {
                            if (dt.Columns.IndexOf(dc) > 0)
                            {
                                sbjson.Append(",");
                                sbjson.Append("\"" + dc.ColumnName + "\":\"" + dt.Rows[i][dc.ColumnName].ToString().Trim() + "\"");
                            }
                            else
                            {
                                sbjson.Append("\"" + dc.ColumnName + "\":\"" + dt.Rows[i][dc.ColumnName].ToString().Trim() + "\"");
                            }
                        }
                        sbjson.Append(",");
                        if (dt.Rows[i][pColName].ToString().Trim() == rootId.ToString())
                        {
                            sbjson.Append("\"state\":\"closed\"");
                        }
                        else
                        {
                            sbjson.Append("\"_parentId\":" + dt.Rows[i][pColName].ToString().Trim() + "");
                        }
                        sbjson.Append("}");
                    }
                    else
                    {
                        sbjson.Append("{");
                        foreach (DataColumn dc in dt.Columns)
                        {
                            if (dt.Columns.IndexOf(dc) > 0)
                            {
                                sbjson.Append(",");
                                sbjson.Append("\"" + dc.ColumnName + "\":\"" + dt.Rows[i][dc.ColumnName].ToString().Trim() + "\"");
                            }
                            else
                            {
                                sbjson.Append("\"" + dc.ColumnName + "\":\"" + dt.Rows[i][dc.ColumnName].ToString().Trim() + "\"");
                            }
                        }
                        sbjson.Append(",");
                        if (dt.Rows[i][pColName].ToString().Trim() == rootId.ToString())
                        {
                            sbjson.Append("\"state\":\"closed\"");
                        }
                        else
                        {
                            sbjson.Append("\"_parentId\":" + dt.Rows[i][pColName].ToString().Trim() + "");
                        }
                        sbjson.Append("}");
                    }
                }
            }
            sbjson.Append("]}");
            return sbjson.ToString();
        }





        /// <summary>DataTableToJson序列化
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SerializeDataTable(DataTable dt, int total)
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
            return toJson(jsonList);//调用Serializer方法 
        }



        /// <summary>DataTableToJson序列化
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SerializeDataTable(DataTable dt)
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
            return toJson(list);//调用Serializer方法 
        }


        public static string toJson(object d)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(d);
        }


        /// <summary>   
        /// DataSet装换为泛型集合   
        /// </summary>   
        /// <typeparam name="T"></typeparam>   
        /// <param name="p_DataSet">DataSet</param>   
        /// <param name="p_TableIndex">待转换数据表索引</param>   
        /// <returns></returns>   
        public static IList<T> DataSetToIList<T>(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;
            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化   
            IList<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值   
                        if (pi.Name.Equals(p_Data.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理   
                            if (p_Data.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, p_Data.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }  
    }
}