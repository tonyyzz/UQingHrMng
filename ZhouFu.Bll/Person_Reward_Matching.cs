using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
    /// <summary>
    /// Person_Reward_Matching
    /// </summary>
    public partial class Person_Reward_Matching
    {
        private readonly ZhongLi.DAL.Person_Reward_Matching dal = new ZhongLi.DAL.Person_Reward_Matching();
        public Person_Reward_Matching()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PerRewMatID)
        {
            return dal.Exists(PerRewMatID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhongLi.Model.Person_Reward_Matching model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person_Reward_Matching model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PerRewMatID)
        {

            return dal.Delete(PerRewMatID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PerRewMatIDlist)
        {
            return dal.DeleteList(PerRewMatIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhongLi.Model.Person_Reward_Matching GetModel(int PerRewMatID)
        {

            return dal.GetModel(PerRewMatID);
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
        public List<ZhongLi.Model.Person_Reward_Matching> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhongLi.Model.Person_Reward_Matching> DataTableToList(DataTable dt)
        {
            List<ZhongLi.Model.Person_Reward_Matching> modelList = new List<ZhongLi.Model.Person_Reward_Matching>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhongLi.Model.Person_Reward_Matching model;
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
        /// 匹配悬赏 事务
        /// </summary>
        /// <returns></returns>
        public bool setRewardMatching(int OrderID, int PerRewardID, int PerID, int SerUserID, int SerPostID, string SerRealName)
        {
            return dal.setRewardMatching(OrderID,PerRewardID,PerID,SerUserID,SerPostID,SerRealName);
        }
        /// <summary>
        /// 得到人才经纪人提供的职位方案
        /// </summary>
        /// <returns></returns>
        public DataTable getSerUserRewardMatPost(int PerID)
        {
            return dal.getSerUserRewardMatPost(PerID);
        }

        /// <summary>
        /// 得到人才经纪人提供方案的详情
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public DataTable getSerUserRewardMatPostDetail(int PerRewMatID)
        {
            return dal.getSerUserRewardMatPostDetail(PerRewMatID);
        }

        /// <summary>
        /// 人才确认职位方案
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <param name="PerRewardID"></param>
        /// <returns></returns>
        public int setPersonRewardPostMat(int PerRewMatID, int OrderID, int PerID, int SerUserID, string PerRealName)
        {
            return dal.setPersonRewardPostMat(PerRewMatID, OrderID, PerID, SerUserID, PerRealName);
        }
        /// <summary>
        /// 忽略人才经纪人提供的方案
        /// </summary>
        /// <param name="PerRewardMatID"></param>
        /// <returns></returns>
        public bool setPersonRewardPostNoMat(int PerRewardMatID,string PerRealName,int SerUserID)
        {
            return dal.setPersonRewardPostNoMat(PerRewardMatID, PerRealName,SerUserID);
        }
         /// <summary>
        /// 忽略求职者悬赏订单 1修改匹配状态 2修改订单状态 3判断悬赏金额 需不需要退款 退款则修改余额  添加交易记录
        /// </summary>
        /// <param name="PerRewardMatID"></param>
        /// <returns></returns>
        public bool setSerUserRewardNoMat(int PerRewardMatID,string SerRealName,string PostName)
        {
            return dal.setSerUserRewardNoMat(PerRewardMatID, SerRealName, PostName);
        }
        /// <summary>
        /// 确认求职者悬赏订单 1修改匹配状态 2修改订单状态 
        /// </summary>
        /// <param name="PerRewardMatID"></param>
        /// <returns></returns>
        public bool setSerUserRewardMat(int PerRewardMatID, string SerRealName, string PostName)
        {
            return dal.setSerUserRewardMat(PerRewardMatID, SerRealName,PostName);
        }

        /// <summary>
        /// 根据订单得到已接受职位方案的职位
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getPostByOrderID(int OrderID)
        {
            return dal.getPostByOrderID(OrderID);
        }
        /// <summary>
        /// 人才经纪人发起入职
        /// </summary>
        /// <returns></returns>
        public bool SerUserEntryPost( int PerRewMatID,string SerRealName)
        {
            return dal.SerUserEntryPost(PerRewMatID, SerRealName);
        }
        /// <summary>
        /// 人才经纪人发起入职
        /// </summary>
        /// <returns></returns>
        public bool SerUserFailPost(int PerRewMatID,string SerRealName)
        {
            return dal.SerUserFailPost(PerRewMatID, SerRealName);
        }
        /// <summary>
        /// 求职者确认入职
        /// </summary>
        /// <returns></returns>
        public bool PerSetInPost(int PerRewMatID, int OrderID, int SerUserID, int Commission)
        {
            return dal.PerSetInPost(PerRewMatID,OrderID,SerUserID,Commission);
        }
        /// <summary>
        /// 求职者拒绝入职
        /// </summary>
        /// <returns></returns>
        public bool PerSetFailPost(int SerUserID, int PerRewMatID,string RealName)
        {
            return dal.PerSetFailPost(SerUserID,PerRewMatID,RealName);
        }
        /// <summary>
        /// 查询协议
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataTable getSerUserRewardMatPostDetail(int OrderID, int PerID, int SerUserID)
        {
            return dal.getSerUserRewardMatPostDetail(OrderID,PerID,SerUserID);
        }
        /// <summary>
        /// 查询匹配状态
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public int GetState(int PerRewMatID)
        {
            return dal.GetState(PerRewMatID);
        }
        /// <summary>
        /// 首页人才经纪人3个悬赏订单
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataTable HomeSerUserOrder(int SerUserID)
        {
            return dal.HomeSerUserOrder(SerUserID);
        }

        /// <summary>
        /// 悬赏订单中其他没有选中入职的职位 发送消息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="SerUserID"></param>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public string OrderAuthSerUserMsg(int OrderID, int SerUserID, string RealName)
        {
            return dal.OrderAuthSerUserMsg(OrderID,SerUserID,RealName);
        }
        /// <summary>
        /// 取消悬赏订单 给人才经纪人发送消息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="SerUserID"></param>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public string OrderAuthSerUserMsg(int OrderID, string RealName)
        {
            return dal.OrderAuthSerUserMsg(OrderID,RealName);
        }
        #endregion  ExtensionMethod
    }
}

