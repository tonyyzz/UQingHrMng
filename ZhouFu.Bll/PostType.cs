using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
    /// <summary>
    /// PostType
    /// </summary>
    public partial class PostType
    {
        private readonly ZhongLi.DAL.PostType dal = new ZhongLi.DAL.PostType();
        public PostType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhongLi.Model.PostType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.PostType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhongLi.Model.PostType GetModel(int ID)
        {

            return dal.GetModel(ID);
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
        public List<ZhongLi.Model.PostType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhongLi.Model.PostType> DataTableToList(DataTable dt)
        {
            List<ZhongLi.Model.PostType> modelList = new List<ZhongLi.Model.PostType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhongLi.Model.PostType model;
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
        /// 修改排序
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Sort"></param>
        public void UpdateSort(int ID, int Sort)
        {
            dal.UpdateSort(ID,Sort);
        }
        /// <summary>
        /// 添加职位信息
        /// </summary>
        /// <param name="PostName"></param>
        /// <returns></returns>
        public bool AddPostName(string PostName, int PID)
        {
            return dal.AddPostName(PostName,PID);
        }
        /// <summary>
        /// 修改职位信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="PostName"></param>
        /// <returns></returns>
        public bool UpdatePostName(int ID, string PostName)
        {
            return dal.UpdatePostName(ID,PostName);
        }
        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeletePostName(string IDs)
        {
            return dal.DeletePostName(IDs);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetPostListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetPostListByPage(strWhere,orderby,startIndex,endIndex);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetPostRecordCount(string strWhere)
        {
            return dal.GetPostRecordCount(strWhere);
        }
        /// <summary>
        /// 得到职位名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetPostName(int ID)
        {
            return dal.GetPostName(ID);
        }
        /// <summary>
        /// 所有职位信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPostName(int ID)
        {
            return dal.GetAllPostName(ID);
        }
        #endregion  ExtensionMethod
    }
}

