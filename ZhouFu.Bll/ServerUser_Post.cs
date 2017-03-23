using System;
using System.Data;
using System.Collections.Generic;
using ZhongLi.Common;
using ZhongLi.Model;
namespace ZhongLi.BLL
{
	/// <summary>
	/// ServerUser_Post
	/// </summary>
	public partial class ServerUser_Post
	{
		private readonly ZhongLi.DAL.ServerUser_Post dal=new ZhongLi.DAL.ServerUser_Post();
		public ServerUser_Post()
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
		public bool Exists(int SerUserPostID)
		{
			return dal.Exists(SerUserPostID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhongLi.Model.ServerUser_Post model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.ServerUser_Post model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SerUserPostID)
		{
			
			return dal.Delete(SerUserPostID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SerUserPostIDlist )
		{
			return dal.DeleteList(SerUserPostIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.ServerUser_Post GetModel(int SerUserPostID)
		{
			
			return dal.GetModel(SerUserPostID);
		}

		/// <summary>
		

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
		public List<ZhongLi.Model.ServerUser_Post> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhongLi.Model.ServerUser_Post> DataTableToList(DataTable dt)
		{
			List<ZhongLi.Model.ServerUser_Post> modelList = new List<ZhongLi.Model.ServerUser_Post>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhongLi.Model.ServerUser_Post model;
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCountPost(string strWhere)
        {
            return dal.GetRecordCountPost(strWhere);
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string Key)
        {
            return dal.GetListByPage(strWhere,orderby,startIndex,endIndex,Key);
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
        /// 删除职位 判断职位是否已匹配悬赏 如果已匹配 则返回 1  否则删除成功返回0 删除失败返回2
        /// </summary>
        /// <param name="SerUserPostID"></param>
        /// <returns>0 1 2</returns>
        public int delSerUser_Post(int SerUserPostID)
        {
            return dal.delSerUser_Post(SerUserPostID);
        }
        public DataTable getPostSerUser(int PostID)
        {
            return dal.getPostSerUser(PostID);
        }
        /// <summary>
        /// 修改排序
        /// </summary>
        /// <param name="SerUserPostID"></param>
        /// <param name="Sort"></param>
        public void UpdateSort(int SerUserPostID, int Sort)
        {
            dal.UpdateSort(SerUserPostID,Sort);
        }

        /// <summary>
        /// 设置成独家岗位
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool setSole(string ids)
        {
            return dal.setSole(ids);
        }

        /// <summary>
        /// 取消独家岗位
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool delSole(string ids)
        {
            return dal.delSole(ids);
        }
        /// <summary>
        /// 首页职位
        /// </summary>
        /// <param name="ExpectWork"></param>
        /// <returns></returns>
        public DataSet HomePagePost(int PerID)
        {
            return dal.HomePagePost(PerID);
        }
        /// <summary>
        /// 人才经纪人首页3条职位
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataTable HomeMyPost(int SerUserID)
        {
            return dal.HomeMyPost(SerUserID);
        }
        /// <summary>
        /// 职位浏览量+1
        /// </summary>
        /// <param name="SerUserPostID"></param>
        public void PostSeeCount(int SerUserPostID)
        {
            dal.PostSeeCount(SerUserPostID);
        }
        /// <summary>
        /// 首页个性推荐职位 上拉刷新
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Salary"></param>
        /// <param name="ComMat"></param>
        /// <param name="PageIndex"></param>
        /// <param name="NotIn"></param>
        /// <returns></returns>
        public DataTable HomePagePersonPost(int PerID, string Salary, string ComMat, int PageIndex, string NotIn)
        {
            return dal.HomePagePersonPost(PerID,Salary,ComMat,PageIndex,NotIn);
        }
        /// <summary>
        /// 判断职位是否正在进行中
        /// </summary>
        /// <param name="PostID"></param>
        /// <returns></returns>
        public bool checkPost(int PostID)
        {
            return dal.checkPost(PostID);
        }
        /// <summary>
        /// 更多独家职位
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable moreSolePost(int PageIndex)
        {
            return dal.moreSolePost(PageIndex);
        }
		#endregion  ExtensionMethod
	}
}

