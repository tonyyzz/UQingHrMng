using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
    /// <summary>
    /// ServerUser_Message
    /// </summary>
    public partial class ServerUser_Message
    {
        private readonly ZhongLi.DAL.ServerUser_Message dal = new ZhongLi.DAL.ServerUser_Message();
        public ServerUser_Message()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SerMesID)
        {
            return dal.Exists(SerMesID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhongLi.Model.ServerUser_Message model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.ServerUser_Message model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SerMesID)
        {

            return dal.Delete(SerMesID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SerMesIDlist)
        {
            return dal.DeleteList(SerMesIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhongLi.Model.ServerUser_Message GetModel(int SerMesID)
        {

            return dal.GetModel(SerMesID);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhongLi.Model.ServerUser_Message> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhongLi.Model.ServerUser_Message> DataTableToList(DataTable dt)
        {
            List<ZhongLi.Model.ServerUser_Message> modelList = new List<ZhongLi.Model.ServerUser_Message>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhongLi.Model.ServerUser_Message model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到所有未读消息
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public int getMsgCount(int SerUserID)
        {
            return dal.getMsgCount(SerUserID);
        }
        /// <summary>
        /// 得到消息数量列表
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public DataTable getMsgCountByType(int SerUserID)
        {
            return dal.getMsgCountByType(SerUserID);
        }
         /// <summary>
        /// 得到分类的详细列表并设置已读
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="MsgType"></param>
        /// <returns></returns>
        public DataTable getMsgByType(int SerUserID, int MsgType)
        {
            return dal.getMsgByType(SerUserID,MsgType);
        }
        #endregion  ExtensionMethod
    }
}

