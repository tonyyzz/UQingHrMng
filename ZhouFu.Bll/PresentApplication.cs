using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
using ZhongLi.DBUtility;
namespace ZhongLi.BLL
{
	/// <summary>
	/// PresentApplication
	/// </summary>
	public partial class PresentApplication
	{
		private readonly ZhongLi.DAL.PresentApplication dal=new ZhongLi.DAL.PresentApplication();
		public PresentApplication()
		{}
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
		public int  Add(ZhongLi.Model.PresentApplication model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.PresentApplication model)
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
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.PresentApplication GetModel(int ID)
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.PresentApplication> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.PresentApplication> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.PresentApplication> modelList = new List<ZhongLi.Model.PresentApplication>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.PresentApplication model;
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
        /// 提现申请审核通过
        /// </summary>
        /// <param name="AdminID"></param>
        /// <param name="AdminName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool authPass(int AdminID, string AdminName, int ID,int UserType,int UserID)
        {
            return dal.authPass(AdminID,AdminName,ID,UserType,UserID);
        }
        /// <summary>
        /// 提现申请审核通过
        /// </summary>
        /// <param name="AdminID"></param>
        /// <param name="AdminName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool noauthPass(int AdminID, string AdminName, int ID, int UserType, int UserID)
        {
            return dal.noauthPass(AdminID, AdminName, ID, UserType, UserID);
        }

        /// <summary>
        /// 支付失败  修改状态  添加余额 消息记录
        /// </summary>
        /// <param name="AdminID"></param>
        /// <param name="AdminName"></param>
        /// <param name="ID"></param>
        /// <param name="UserType"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool PayFail(int AdminID, string AdminName, int ID, int UserType, int UserID, decimal Money)
        {
            return dal.PayFail(AdminID,AdminName,ID,UserType,UserID,Money);
        }
        /// <summary>
        /// 添加提现申请
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="RealName"></param>
        /// <param name="PreType"></param>
        /// <param name="Account"></param>
        /// <param name="Money"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public bool AddPresent(int UserID, string RealName, int PreType, string Account, decimal Money, int UserType, string AccountName)
        {
            return dal.AddPresent(UserID,RealName,PreType,Account,Money,UserType,AccountName);
        }
        /// <summary>
        /// 添加批次
        /// </summary>
        /// <param name="Batch_Num"></param>
        /// <param name="Batch_Fee"></param>
        /// <returns></returns>
        public int AddBatch(string Batch_No,int Batch_Num, decimal Batch_Fee, int AdminID)
        {
            return dal.AddBatch(Batch_No,Batch_Num, Batch_Fee, AdminID);
        }
        /// <summary>
        /// 修改选中提现的批次
        /// </summary>
        /// <param name="IDs"></param>
        /// <param name="BatchID"></param>
        /// <returns></returns>
        public bool editPresentBatch(string IDs, int BatchID)
        {
            return dal.editPresentBatch(IDs,BatchID);
        }
        /// <summary>
        /// 判断该批次是否已处理过了
        /// </summary>
        /// <returns></returns>
        public bool IsBatch(string BatchNo)
        {
            return dal.IsBatch(BatchNo);
        }
        /// <summary>
        /// 通过流水号集合查询用户
        /// </summary>
        /// <param name="PreNums"></param>
        /// <returns></returns>
        public DataTable getUserByPreNum(string PreNums)
        {
            return dal.getUserByPreNum(PreNums);
        }
        /// <summary>
        /// 执行提现批量付款后 回调处理事物
        /// </summary>
        /// <returns></returns>
        public bool exPreTran(List<CommandInfo> list)
        {
            return dal.exPreTran(list);
        }

        /// <summary>
        /// 批次分页获取数据列表
        /// </summary>
        public DataSet GetBatchListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetBatchListByPage(strWhere,orderby,startIndex,endIndex);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetBatchRecordCount(string strWhere)
        {
            return dal.GetBatchRecordCount(strWhere);
        }
        /// <summary>
        /// 根据ID得到批次信息
        /// </summary>
        /// <param name="BatchID"></param>
        /// <returns></returns>
        public DataTable getBatchByID(int BatchID)
        {
            return dal.getBatchByID(BatchID);
        }
        /// <summary>
        /// 判断选中的是否有支付失败的
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool checkPay(string ids)
        {
            return dal.checkPay(ids);
        }
        #endregion  ExtensionMethod
	}
}

