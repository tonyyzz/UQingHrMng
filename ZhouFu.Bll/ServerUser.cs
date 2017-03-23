using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// ServerUser
	/// </summary>
	public partial class ServerUser
	{
		private readonly ZhongLi.DAL.ServerUser dal=new ZhongLi.DAL.ServerUser();
		public ServerUser()
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
		public bool Exists(int SerUserID)
		{
			return dal.Exists(SerUserID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.ServerUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.ServerUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SerUserID)
		{
			
			return dal.Delete(SerUserID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SerUserIDlist )
		{
			return dal.DeleteList(SerUserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.ServerUser GetModel(int SerUserID)
		{
			
			return dal.GetModel(SerUserID);
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
		public List<ZhongLi.Model.ServerUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.ServerUser> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.ServerUser> modelList = new List<ZhongLi.Model.ServerUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.ServerUser model;
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
        /// 查询职业介绍人指定信息
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
        public DataTable findinfo(string filed, string where)
        {
            return dal.findinfo(filed,where);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="perid"></param>
        /// <returns></returns>
        public bool editPwd(string password, int seruserid)
        {
            return dal.editPwd(password, seruserid);
        }

        /// <summary>
        /// 保存个人资料
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="RealName"></param>
        /// <param name="Sex"></param>
        /// <param name="Trade"></param>
        /// <param name="Company"></param>
        /// <param name="Position"></param>
        /// <param name="WorkCity"></param>
        /// <param name="Address"></param>
        /// <param name="Email"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public bool saveSerUser(string RealName, string Sex, string Trade, string Company, string Position, string WorkCity, string Address, string Email, string SerUserID)
        {
            return dal.saveSerUser(RealName, Sex, Trade, Company, Position, WorkCity, Address, Email, SerUserID);
        }
        /// <summary>
        /// 保存自我描述
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="Describe"></param>
        /// <returns></returns>
        public bool saveDescribe(string SerUserID, string Describe)
        {
            return dal.saveDescribe(SerUserID, Describe);
        }
        /// <summary>
        /// 保存身份认证图片
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="IDCardImg"></param>
        /// <returns></returns>
        public bool saveIDCardImg(string SerUserID, string IDCardImg)
        {
            return dal.saveIDCardImg(SerUserID,IDCardImg);
        }

        /// <summary>
        /// 保存职能身份认证图片
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="IDCardImg"></param>
        /// <returns></returns>
        public bool saveSerImg(string SerUserID, string SerImg)
        {
            return dal.saveSerImg(SerUserID,SerImg);
        }

        /// <summary>
        /// 保存头像
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        public bool savePhoto(string SerUserID, string Photo)
        {
            return dal.savePhoto(SerUserID,Photo);
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
            return dal.ModPhone(Phone, PerID);
        }

        /// <summary>
        /// 经纪人列表 按订单成交数量排序
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable SerUserList(int PageIndex)
        {
            return dal.SerUserList(PageIndex);
        }
        /// <summary>
        /// 修改融云聊天token
        /// </summary>
        /// <param name="perid"></param>
        /// <param name="ImOpenID"></param>
        public void editImOpenID(int SerUserID, string ImOpenID)
        {
            dal.editImOpenID(SerUserID,ImOpenID);
        }
        /// <summary>
        /// 得到待认证人才经纪人数量
        /// </summary>
        /// <returns></returns>
        public int getSerUserAuthCount()
        {
            return dal.getSerUserAuthCount();
        }
        /// <summary>
        /// 求职者身份转换为人才经纪人
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public string SerUserFromPerson(int PerID)
        {
            return dal.SerUserFromPerson(PerID);
        }
        /// <summary>
        /// 身份认证上传
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="url1"></param>
        /// <param name="url2"></param>
        public bool uploadIdCardApprove(int SerUserID, string url1, string url2)
        {
            return dal.uploadIdCardApprove(SerUserID,url1,url2);
        }
		#endregion  ExtensionMethod
	}
}

