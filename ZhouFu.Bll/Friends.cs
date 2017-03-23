using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// Friends
	/// </summary>
	public partial class Friends
	{
		private readonly ZhongLi.DAL.Friends dal=new ZhongLi.DAL.Friends();
		public Friends()
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
		public bool Exists(int PerID,int SerUserID)
		{
			return dal.Exists(PerID,SerUserID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhongLi.Model.Friends model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Friends model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PerID,int SerUserID)
		{
			
			return dal.Delete(PerID,SerUserID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.Friends GetModel(int PerID,int SerUserID)
		{
			
			return dal.GetModel(PerID,SerUserID);
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
		public List<ZhongLi.Model.Friends> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.Friends> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.Friends> modelList = new List<ZhongLi.Model.Friends>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.Friends model;
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
        /// 人才经纪人好友
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataSet SerUserFriend(string SerUserID)
        {
            return dal.SerUserFriend(SerUserID);
        }

        /// <summary>
        /// 人才 好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataSet PersonFriend(string PerID)
        {
            return dal.PersonFriend(PerID);
        }

        /// <summary>
        /// 好友申请
        /// </summary>
        /// <param name="ApplyUserID"></param>
        /// <param name="ApplyName"></param>
        /// <param name="ReceiveUserID"></param>
        /// <param name="ReceiveName"></param>
        /// <param name="ApplyType"></param>
        /// <returns></returns>
        public bool PersonApply(int ApplyUserID, string ApplyName, int ReceiveUserID, string ReceiveName, int ApplyType)
        {
            return dal.PersonApply(ApplyUserID,ApplyName,ReceiveUserID,ReceiveName,ApplyType);
        }

        /// <summary>
        /// 同意好友申请
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool AgreeApply(int PerID, int SerUserID, int ID)
        {
            return dal.AgreeApply(PerID,SerUserID,ID);
        }
        /// <summary>
        /// 求职者拒绝好友申请
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool PerRefuseApply(int ID, int SerUserID, string RealName)
        {
            return dal.PerRefuseApply(ID,SerUserID,RealName);
        }
        /// <summary>
        /// 经纪人拒绝好友申请
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool SerRefuseApply(int ID, int PerID, string RealName)
        {
            return dal.SerRefuseApply(ID, PerID, RealName);
        }
        /// <summary>
        /// 经纪人是否已经是好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public int SerIsFriend(int PerID, int SerUserID)
        {
            return dal.SerIsFriend(PerID,SerUserID);
        }

        /// <summary>
        ///求职者 判断是否已经是好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public int PerIsFriend(int PerID, int SerUserID)
        {
            return dal.PerIsFriend(PerID, SerUserID);
        }

        /// <summary>
        /// 人才删除好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool DelFriend(int PerID, int SerUserID)
        {
            return dal.DelFriend(PerID,SerUserID);
        }
		#endregion  ExtensionMethod
	}
}

