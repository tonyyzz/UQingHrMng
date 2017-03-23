using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZhongLi.DBUtility;

namespace ZhongLi.Dal
{
    public partial class DataHandler
    {
        public DataHandler()
        { }
        /// <summary>
        /// 此分页存储过程直接用皱建的，没修改 大家可以用自己的
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="getFields">需要返回的列</param>
        /// <param name="orderName">排序的字段名</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isGetCount">返回记录总数,非 0 值则返回</param>
        /// <param name="orderType">设置排序类型,0表示升序非0降序</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string tableName, string getFields, string orderName, int pageSize, int pageIndex, bool isGetCount, bool orderType, string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                  new SqlParameter("@PageSize", SqlDbType.Int),
               new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar, 1500)            
                                     };
            parameters[0].Value = tableName;
            parameters[1].Value = getFields;
            parameters[2].Value = orderName;
            parameters[3].Value = pageSize;
            parameters[4].Value = pageIndex;
            parameters[5].Value = isGetCount ? 1 : 0;
            parameters[6].Value = orderType ? 1 : 0;
            parameters[7].Value = strWhere;
            return DbHelperSQL.RunProcedure("pro_pageList", parameters, "ds");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="tbFields">返回字段</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <param name="total">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetList(string tbName, string tbFields, int pageSize, int pageIndex, string strWhere, string strOrder, out int total)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tbName", SqlDbType.VarChar, 255),
                    new SqlParameter("@tbFields", SqlDbType.VarChar, 1000),
                    new SqlParameter("@pageSize", SqlDbType.Int),
                    new SqlParameter("@pageIndex", SqlDbType.Int),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@StrOrder", SqlDbType.VarChar,255),
                    new SqlParameter("@Total", SqlDbType.Int) };
            parameters[0].Value = tbName;
            parameters[1].Value = tbFields;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = strWhere;
            parameters[5].Value = strOrder;
            parameters[6].Direction = ParameterDirection.Output;
            return DbHelperSQL.RunProcOutput("spSqlPageByRownumber", parameters, "ds", out total);
        }

        public DataSet GetList(string sql)
        {
            return DbHelperSQL.Query(sql);
        }

        public object ExecuteNonQuery(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 获取相应的字段名
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="getField">查询字段</param>
        /// <param name="pkField">主键列名</param>
        /// <param name="pkID">主键值</param>
        /// <returns></returns>
        public string GetField(string tableName, string getField, string pkField, string pkID)
        {
            string sql = string.Format("SELECT {0} FROM {1} where {2}={3}", getField, tableName, pkField, pkID);
            return DbHelperSQL.ExecuteScalar(sql, CommandType.Text) + "";
        }

        public string GetSum(string tableName, string sumField, string sqlWhere)
        {
            string sql = string.Format("SELECT isnull(sum({0}),0) FROM {1} where {2}", sumField, tableName, sqlWhere);
            return DbHelperSQL.ExecuteScalar(sql, CommandType.Text) + "";
        }

        /// <summary>
        /// 执行sql语句返回结果
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public string GetSingle(string strSql)
        {
            return Convert.ToString(DbHelperSQL.GetSingle(strSql));
        }
    }
}
