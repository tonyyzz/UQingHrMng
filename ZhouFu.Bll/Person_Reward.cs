using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// Person_Reward
	/// </summary>
	public partial class Person_Reward
	{
		private readonly ZhongLi.DAL.Person_Reward dal=new ZhongLi.DAL.Person_Reward();
		public Person_Reward()
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
		public bool Exists(int PerRewardID)
		{
			return dal.Exists(PerRewardID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.Person_Reward model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Person_Reward model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PerRewardID)
		{
			
			return dal.Delete(PerRewardID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PerRewardIDlist )
		{
			return dal.DeleteList(PerRewardIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.Person_Reward GetModel(int PerRewardID)
		{
			
			return dal.GetModel(PerRewardID);
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
		public List<ZhongLi.Model.Person_Reward> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.Person_Reward> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.Person_Reward> modelList = new List<ZhongLi.Model.Person_Reward>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.Person_Reward model;
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
        /// 修改悬赏
        /// </summary>
        /// <param name="reward"></param>
        /// <returns></returns>
        public bool editPersonReward(ZhongLi.Model.Person_Reward reward)
        {
            return dal.editPersonReward(reward);
        }
        /// <summary>
        /// 获取人才经纪人匹配的悬赏
        /// </summary>
        /// <param name="SerUserID">经纪人ID</param>
        /// <param name="PageIndex">当前分页</param>
        /// <returns></returns>
        public DataTable getSerUserReward(string SerUserID, int PageIndex)
        {
            return dal.getSerUserReward(SerUserID,PageIndex);
        }
        /// <summary>
        /// 人才经纪人悬赏匹配详情
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public DataTable getSerUserRewardDetail(int PerRewMatID)
        {
            return dal.getSerUserRewardDetail(PerRewMatID);
        }

        /// <summary>
        /// 悬赏列表
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable getRewardList(int PageIndex)
        {
            return dal.getRewardList(PageIndex);
        }

        /// <summary>
        /// 得到悬赏详情
        /// </summary>
        /// <param name="PerRewardID"></param>
        /// <returns></returns>
        public DataTable getRewardDetail(string PerRewardID,string SerUserID)
        {
            return dal.getRewardDetail(PerRewardID, SerUserID);
        }
        
		#endregion  ExtensionMethod
	}
}

