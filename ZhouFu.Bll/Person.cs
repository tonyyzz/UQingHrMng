using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// Person
	/// </summary>
	public partial class Person
	{
		private readonly ZhongLi.DAL.Person dal=new ZhongLi.DAL.Person();
		public Person()
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
		public bool Exists(int PerID)
		{
			return dal.Exists(PerID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.Person model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Person model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PerID)
		{
			
			return dal.Delete(PerID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PerIDlist )
		{
			return dal.DeleteList(PerIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.Person GetModel(int PerID)
		{
			
			return dal.GetModel(PerID);
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
		public List<ZhongLi.Model.Person> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.Person> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.Person> modelList = new List<ZhongLi.Model.Person>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.Person model;
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
        /// 查询求职者指定信息
        /// </summary>
        /// <param name="field">如：RealName,Phone</param>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public DataTable findField(string field, int ID)
        {
            return dal.findField(field,ID);
        }
        public DataTable findField(string field, string IDs)
        {
            return dal.findField(field,IDs);
        }
         /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int checklogin(string Phone, string Password)
        {
            return dal.checklogin(Phone,Password);
        }

        /// <summary>
        /// 验证手机号持否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool checkphone(string phone)
        {
            return dal.checkphone(phone);
        }

        /// <summary>
        /// 根据条件查询部分信息
        /// </summary>
        /// <param name="filed">要查询的字段</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable findinfo(string filed,string where){
            return dal.findinfo(filed,where);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="perid"></param>
        /// <returns></returns>
        public bool editPwd(string password, int perid)
        {
            return dal.editPwd(password,perid);
        }
        /// <summary>
        /// 修改个人描述
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="MyDes"></param>
        /// <returns></returns>
        public bool editMyDes(string PerID, string MyDes)
        {
            return dal.editMyDes(PerID,MyDes);
        }
         /// <summary>
        /// 保存头像
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        public bool setPhoto(int PerID, string Photo)
        {
            return dal.setPhoto(PerID,Photo);
        }
        /// <summary>
        /// 保存身份认证
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        public bool setAutoImg(int PerID, string AutoImg)
        {
            return dal.setAutoImg(PerID,AutoImg);
        }

        /// <summary>
        /// 得到电话
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public string getPhone(string PerID)
        {
            return dal.getPhone(PerID);
        }

         /// <summary>
        /// 修改手机后
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool ModPhone(string Phone, string PerID)
        {
            return dal.ModPhone(Phone,PerID);
        }

        /// <summary>
        /// 得到身份认证状态
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public int getFlag(string PerID)
        {
            return dal.getFlag(PerID);
        }

        /// <summary>
        /// 得到余额
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public decimal getBalance(string PerID)
        {
            return dal.getBalance(PerID);
        }
        /// <summary>
        /// 余额支付并修改订单状态
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool BalancePay(int PerID, int OrderID)
        {
            return dal.BalancePay(PerID,OrderID);
        }

        /// <summary>
        /// 修改融云聊天token
        /// </summary>
        /// <param name="perid"></param>
        /// <param name="ImOpenID"></param>
        public void editImOpenID(int perid, string ImOpenID)
        {
            dal.editImOpenID(perid,ImOpenID);
        }
        /// <summary>
        /// 得到待认证的人才
        /// </summary>
        /// <returns></returns>
        public int getAuthPersonCount()
        {
            return dal.getAuthPersonCount();
        }
        /// <summary>
        /// 添加人才测评
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="assessments_id"></param>
        /// <param name="examination_id"></param>
        /// <param name="assessment_name"></param>
        /// <param name="reportURL"></param>
        /// <param name="created"></param>
        /// <returns></returns>
        public bool AddPersonTest(int PerID, int assessments_id, int examination_id, string assessment_name, string reportURL, string created, int AnsID)
        {
            return dal.AddPersonTest(PerID, assessments_id, examination_id, assessment_name, reportURL, created, AnsID);
        }
        /// <summary>
        /// 得到人才测评
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable getPersonTest(int PerID)
        {
            return dal.getPersonTest(PerID);
        }
        /// <summary>
        /// 修改人才测评
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="created"></param>
        /// <param name="AnsID"></param>
        /// <param name="reportURL"></param>
        /// <returns></returns>
        public bool editPersonTest(int PerID, string created, int AnsID, string reportURL)
        {
            return dal.editPersonTest(PerID,created,AnsID,reportURL);
        }
        /// <summary>
        /// 添加充值订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="RealName"></param>
        /// <param name="Money"></param>
        /// <param name="PayType"></param>
        /// <returns></returns>
        public string AddPayCheck(int PerID, string RealName, decimal Money, string PayType)
        {
            return dal.AddPayCheck(PerID,RealName,Money,PayType);
        }
        /// <summary>
        /// 修改充值状态和添加金额
        /// </summary>
        /// <param name="PayCheckNum"></param>
        /// <returns></returns>
        public bool EditPayCheck(string PayCheckNum,string PayType)
        {
            return dal.EditPayCheck(PayCheckNum,PayType);
        }
        /// <summary>
        /// 判断充值订单状态是否已改变
        /// </summary>
        /// <param name="PayCheckNum"></param>
        /// <returns></returns>
        public bool IsPayCheck(string PayCheckNum)
        {
            return dal.IsPayCheck(PayCheckNum);
        }
        /// <summary>
        /// 人才经纪人转换求职这身份
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public string PersonFromSerUser(int SerUserID)
        {
            return dal.PersonFromSerUser(SerUserID);
        }
        /// <summary>
        /// 判断是否有教育经历
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public int IsSendOrder(int PerID)
        {
            return dal.IsSendOrder(PerID);
        }

        /// <summary>
        /// 查看三方登陆是否已登陆过
        /// </summary>
        /// <param name="OpenIDType"></param>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public DataTable getPersonByOpenID(string OpenIDType,string OpenID){
            return dal.getPersonByOpenID(OpenIDType, OpenID);
        }
		#endregion  ExtensionMethod

        #region 收藏 0新闻 1职业规划 2职业培训
        //public bool AddPerson_Coll(int PerID,int CollID,int CollType)
        //{
           
        //}
        #endregion
        public DataSet test(string RealName)
        {
            return dal.test(RealName);
        }
    }
}

