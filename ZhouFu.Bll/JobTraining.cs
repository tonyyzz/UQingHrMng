using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// JobTraining
	/// </summary>
	public partial class JobTraining
	{
		private readonly ZhongLi.DAL.JobTraining dal=new ZhongLi.DAL.JobTraining();
		public JobTraining()
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
		public bool Exists(int JobTraID)
		{
			return dal.Exists(JobTraID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.JobTraining model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.JobTraining model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int JobTraID)
		{
			
			return dal.Delete(JobTraID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string JobTraIDlist )
		{
			return dal.DeleteList(JobTraIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.JobTraining GetModel(int JobTraID)
		{
			
			return dal.GetModel(JobTraID);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.JobTraining> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.JobTraining> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.JobTraining> modelList = new List<ZhongLi.Model.JobTraining>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.JobTraining model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        /// <param name="id">主键ID</param>
        /// <param name="Sort">排序</param>
        public void UpdateSort(int id, int Sort)
        {
            dal.UpdateSort(id,Sort);
        }
		#endregion  ExtensionMethod
	}
}

