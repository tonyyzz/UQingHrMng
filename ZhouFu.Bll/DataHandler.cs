using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZhongLi.Bll
{
    public partial class DataHandler
    {
        public DataHandler() { }

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
        private readonly ZhongLi.Dal.DataHandler dal = new ZhongLi.Dal.DataHandler();
        public DataSet GetList(string tableName, string getFields, string orderName, int pageSize, int pageIndex, bool isGetCount, bool orderType, string strWhere)
        {
            return dal.GetList(tableName, getFields, orderName, pageSize, pageIndex, isGetCount, orderType, strWhere);
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
        /// <param name="totalcount"></param>
        /// <returns></returns>
        public DataSet GetList(string tbName, string tbFields, int pageSize, int pageIndex, string strWhere, string strOrder, out int total)
        {
            return dal.GetList(tbName, tbFields, pageSize, pageIndex, strWhere, strOrder, out total);
        }
        public DataSet GetList(string sql)
        {
            return dal.GetList(sql);
        }

        public object ExecuteNonQuery(string sql)
        {
            return dal.ExecuteNonQuery(sql);
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
            return dal.GetField(tableName, getField, pkField, pkID);
        }

        public string GetSum(string tableName, string sumField, string sqlWhere)
        {
            return dal.GetSum(tableName, sumField, sqlWhere);
        }

        /// <summary>
        /// 执行sql语句返回结果
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public string GetSingle(string strSql)
        {
            return dal.GetSingle(strSql);
        }

    }
}
