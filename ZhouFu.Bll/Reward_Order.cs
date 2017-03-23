using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// Reward_Order
	/// </summary>
	public partial class Reward_Order
	{
		private readonly ZhongLi.DAL.Reward_Order dal=new ZhongLi.DAL.Reward_Order();
		public Reward_Order()
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
		public bool Exists(int OrderID)
		{
			return dal.Exists(OrderID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.Reward_Order model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Reward_Order model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OrderID)
		{
			
			return dal.Delete(OrderID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string OrderIDlist )
		{
			return dal.DeleteList(OrderIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.Reward_Order GetModel(int OrderID)
		{
			
			return dal.GetModel(OrderID);
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
		public List<ZhongLi.Model.Reward_Order> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.Reward_Order> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.Reward_Order> modelList = new List<ZhongLi.Model.Reward_Order>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.Reward_Order model;
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
        /// 人才订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable PerOrder(string PerID)
        {
            return dal.PerOrder(PerID);
        }
        /// <summary>
        /// 人才订单 悬赏金额大于0的
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable PerOrderMoney(string PerID)
        {
            return dal.PerOrderMoney(PerID);
        }
        /// <summary>
        /// 人才经纪人订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable SerUserOrder(string SerUserID,int PageIndex,string state)
        {
            return dal.SerUserOrder(SerUserID,PageIndex,state);
        }
        /// <summary>
        /// 人才经纪人订单详情
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public DataTable SerUserOrderDetail(int PerRewMatID)
        {
            return dal.SerUserOrderDetail(PerRewMatID);
        }
        /// <summary>
        /// 上传入职照片 进入完成待审核状态
        /// </summary>
        /// <param name="AutoImg"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setOrderAutoImg(string AutoImg, int OrderID)
        {
            return dal.setOrderAutoImg(AutoImg,OrderID);
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="OrderState">4.求职者确认入职失败，5.人才经纪人确认入职失败6.人才经纪人确认入职</param>
        /// <returns></returns>
        public bool editOrderState(int OrderID, int OrderState)
        {
            return dal.editOrderState(OrderID,OrderState);
        }
        /// <summary>
        /// 得到订单支付的简略信息
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getOrderPayInfo(int PerID, int OrderID)
        {
            return dal.getOrderPayInfo(PerID,OrderID);
        }
        /// <summary>
        /// 得到入职确认图片和订单状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getOrderImgAuth(int OrderID)
        {
            return dal.getOrderImgAuth(OrderID);
        }
        /// <summary>
        /// 通过订单得到人才 ID和姓名
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getPerByOrderID(int OrderID)
        {
            return dal.getPerByOrderID(OrderID);
        }
        /// <summary>
        /// 得到入职资料图片
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string getAutoImg(int OrderID)
        {
            return dal.getAutoImg(OrderID);
        }
        /// <summary>
        /// 管理员审核完成订单 修改订单状态 修改悬赏状态  支付人才经纪人金额
        /// </summary>
        /// <param name="OrderID">订单ID</param>
        /// <param name="PerID">人才ID</param>
        /// <param name="SerUserID">人才经纪人ID</param>
        /// <param name="Commission">提成百分比</param>
        /// <returns></returns>
        public bool PassAuth(int OrderID, int PerID, int SerUserID, decimal RewardMoney, int Commission)
        {
            return dal.PassAuth(OrderID,PerID,SerUserID,RewardMoney,Commission);
        }
        /// <summary>
        /// 带审核订单数量
        /// </summary>
        /// <returns></returns>
        public int getAuthOrderCount()
        {
            return dal.getAuthOrderCount();
        }

        /// <summary>
        /// 人才经纪人确认入职失败
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PerID"></param>
        /// <param name="RewardMoney"></param>
        /// <returns></returns>
        public bool SerUserSetOrderFail(int OrderID, int PerID, decimal RewardMoney)
        {
            return dal.SerUserSetOrderFail(OrderID,PerID,RewardMoney);
        }
        /// <summary>
        /// 订单支付成功 1修改订单状态 2添加交易记录
        /// </summary>
        /// <param name="OrderNum"></param>
        public bool modOrderStateByOrderNum(string OrderNum, string PayType)
        {
            return dal.modOrderStateByOrderNum(OrderNum,PayType);
        }
        /// <summary>
        /// 判断订单支付时订单是否已支付
        /// </summary>
        public bool isOrderState(string OrderNum)
        {
            return dal.isOrderState(OrderNum);
        }

        /// <summary>
        /// 发送悬赏订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="PerRewardID"></param>
        /// <returns></returns>
        public string AddOrder(int PerID, int PerRewardID)
        {
            return dal.AddOrder(PerID,PerRewardID);
        }
        /// <summary>
        /// 得到人才悬赏订单详情
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable GetPersonOrderDetail(int OrderID,int SerUserID)
        {
            return dal.GetPersonOrderDetail(OrderID, SerUserID);
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool CanceOrder(int OrderID, int PerID)
        {
            return dal.CanceOrder(OrderID,PerID);
        }
        /// <summary>
        /// 启用订单  必须是取消的订单才能启用
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool UsingOrder(int OrderID)
        {
            return dal.UsingOrder(OrderID);
        }
        /// <summary>
        /// 修改订单到期时间和延期时间
        /// </summary>
        /// <param name="OrderCanceDay"></param>
        /// <param name="OrderDalayDay"></param>
        public void SetOrderTime(int OrderCanceDay, int OrderDalayDay)
        {
            dal.SetOrderTime(OrderCanceDay,OrderDalayDay);
        }
        /// <summary>
        /// 判断订单是否快要到期
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Day"></param>
        /// <returns></returns>
        public string IsOrderOver(int PerID, int Day)
        {
            return dal.IsOrderOver(PerID, Day);
        }
        /// <summary>
        /// 指定职位 悬赏订单支付回调 修改订单状态 添加确认人才经纪人待确认信息，给人才经纪人推送消息
        /// </summary>
        /// <returns></returns>
        public bool modOrderStateByNumPost(string OrderNum, string PayType)
        {
            return dal.modOrderStateByNumPost(OrderNum,PayType);
        }
        /// <summary>
        /// 延期订单
        /// </summary>
        /// <param name="OrderID"></param>
        public bool OrderDelay(int OrderID)
        {
            return dal.OrderDelay(OrderID);
        }
        /// <summary>
        /// 查询订单状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int getOrderState(int OrderID)
        {
            return dal.getOrderState(OrderID);
        }
        public DataTable getOrderInfo(string files, string OrderNum)
        {
            return dal.getOrderInfo(files,OrderNum);
        }
        /// <summary>
        /// 得到过期时间天数
        /// </summary>
        /// <returns></returns>
        public int getOrderCanceDay()
        {
            return dal.getOrderCanceDay();
        }

        /// <summary>
        /// 得到需要修改的已过期的订单
        /// </summary>
        /// <param name="OrderCanceDay"></param>
        /// <returns></returns>
        public DataTable getOrderOverTime(int OrderCanceDay)
        {
            return dal.getOrderOverTime(OrderCanceDay);
        }
        /// <summary>
        /// 修改过期订单的状态
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool setOrderOverTime(DataTable dt, int OrderCanceDay)
        {
            return dal.setOrderOverTime(dt,OrderCanceDay);
        }
        /// <summary>
        /// 得到已经过期的订单
        /// </summary>
        /// <returns></returns>
        public DataTable getOrderOverTime()
        {
            return dal.getOrderOverTime();
        }
        public void setOrdernum()
        {
             dal.setOrdernum();
        }
		#endregion  ExtensionMethod
	}
}

