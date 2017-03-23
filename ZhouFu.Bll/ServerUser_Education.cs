using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// ServerUser_Education
	/// </summary>
	public partial class ServerUser_Education
	{
		private readonly ZhongLi.DAL.ServerUser_Education dal=new ZhongLi.DAL.ServerUser_Education();
		public ServerUser_Education()
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
		public bool Exists(int SerUserEduID)
		{
			return dal.Exists(SerUserEduID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.ServerUser_Education model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.ServerUser_Education model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SerUserEduID)
		{
			
			return dal.Delete(SerUserEduID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SerUserEduIDlist )
		{
			return dal.DeleteList(SerUserEduIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.ServerUser_Education GetModel(int SerUserEduID)
		{
			
			return dal.GetModel(SerUserEduID);
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
		public List<ZhongLi.Model.ServerUser_Education> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.ServerUser_Education> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.ServerUser_Education> modelList = new List<ZhongLi.Model.ServerUser_Education>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.ServerUser_Education model;
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

		#endregion  ExtensionMethod
	}
}

