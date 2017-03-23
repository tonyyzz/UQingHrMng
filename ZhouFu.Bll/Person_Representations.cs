using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
    /// <summary>
    /// Person_Representations
    /// </summary>
    public partial class Person_Representations
    {
        private readonly ZhongLi.DAL.Person_Representations dal = new ZhongLi.DAL.Person_Representations();
        public Person_Representations()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

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
        public int Add(ZhongLi.Model.Person_Representations model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person_Representations model)
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
        public ZhongLi.Model.Person_Representations GetModel(int ID)
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
        public List<ZhongLi.Model.Person_Representations> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhongLi.Model.Person_Representations> DataTableToList(DataTable dt)
        {
            List<ZhongLi.Model.Person_Representations> modelList = new List<ZhongLi.Model.Person_Representations>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhongLi.Model.Person_Representations model;
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
        /// 修改申述状态
        /// </summary>
        /// <param name="State">状态值 1 通过 2 驳回</param>
        /// <param name="ID">主键ID</param>
        public void EditState(int State, int ID)
        {
            dal.EditState(State, ID);
        }

        /// <summary>
        /// 根据申述ID 申述通过时修改用户余额
        /// </summary>
        /// <param name="ID"></param>
        public void EditPerBla(int ID)
        {
            dal.EditPerBla(ID);
        }

        /// <summary>
        /// 得到申述 用户 金额 订单编号 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet GetInfo(int ID)
        {
            return dal.GetInfo(ID);
        }
        /// <summary>
        /// 通过申述审核 修改申述状态 修改用户余额  添加交易记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool AuthPass(int ID)
        {
            return dal.AuthPass(ID);
        }

        #endregion  ExtensionMethod
    }
}

