/**  版本信息模板在安装目录下，可自行修改。
* sys_Dictionary.cs
*
* 功 能： N/A
* 类 名： sys_Dictionary
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/8 14:20:08   N/A    初版
*
* Copyright (c) 2012 ZhongLi Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Model;
using System.Text;
using ZhongLi.DBUtility;
using ZhongLi.Common;
using System.Data.SqlClient;

namespace ZhongLi.Bll
{
	/// <summary>
	/// sys_Dictionary
	/// </summary>
	public partial class sys_Dictionary
	{
		private readonly ZhongLi.Dal.sys_Dictionary  dal= new Dal.sys_Dictionary();
		public sys_Dictionary()
		{}
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
        public int Add(ZhongLi.Model.sys_Dictionary model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.sys_Dictionary model)
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
        public ZhongLi.Model.sys_Dictionary GetModel(int ID)
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
        public List<ZhongLi.Model.sys_Dictionary> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhongLi.Model.sys_Dictionary> DataTableToList(DataTable dt)
        {
            List<ZhongLi.Model.sys_Dictionary> modelList = new List<ZhongLi.Model.sys_Dictionary>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhongLi.Model.sys_Dictionary model;
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
        /// 获取模板地址
        /// </summary>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_Dictionary> GetTempletUrlList()
        {
            return dal.GetTempletUrlList();
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out  recordCount);
        }
        /// <summary>
        /// 根据where条件查询数据集合
        /// </summary>
        public IList<ZhongLi.Model.sys_Dictionary> GetListByWhere(string strWhere)
        {
            return dal.GetListByWhere(strWhere);
        }
        /// <summary>
        /// a01.将数据表转换成泛型集合接口
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <returns>泛型集合接口</returns>
        public IList<ZhongLi.Model.sys_Dictionary> Table2List(DataTable dt)
        {
            return dal.Table2List(dt);
        }
        /// <summary>
        /// 调用存储过程删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int RunDelete(int id, out int count)
        {
            return dal.RunDelete(id,out count);
        }

		#endregion  ExtensionMethod
	}
}

