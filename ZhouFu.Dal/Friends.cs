using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Friends
	/// </summary>
	public partial class Friends
	{
		public Friends()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PerID", "Friends"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PerID,int SerUserID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4)			};
			parameters[0].Value = PerID;
			parameters[1].Value = SerUserID;

			int result= DbHelperSQL.RunProcedure("Friends_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public bool Add(ZhongLi.Model.Friends model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.PerID;
			parameters[1].Value = model.SerUserID;
			parameters[2].Value = model.CreateTime;

			DbHelperSQL.RunProcedure("Friends_ADD",parameters,out rowsAffected);
            return rowsAffected > 0;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Friends model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.PerID;
			parameters[1].Value = model.SerUserID;
			parameters[2].Value = model.CreateTime;

			DbHelperSQL.RunProcedure("Friends_Update",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PerID,int SerUserID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4)			};
			parameters[0].Value = PerID;
			parameters[1].Value = SerUserID;

			DbHelperSQL.RunProcedure("Friends_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.Friends GetModel(int PerID,int SerUserID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4)			};
			parameters[0].Value = PerID;
			parameters[1].Value = SerUserID;

			ZhongLi.Model.Friends model=new ZhongLi.Model.Friends();
			DataSet ds= DbHelperSQL.RunProcedure("Friends_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhongLi.Model.Friends DataRowToModel(DataRow row)
		{
			ZhongLi.Model.Friends model=new ZhongLi.Model.Friends();
			if (row != null)
			{
				if(row["PerID"]!=null && row["PerID"].ToString()!="")
				{
					model.PerID=int.Parse(row["PerID"].ToString());
				}
				if(row["SerUserID"]!=null && row["SerUserID"].ToString()!="")
				{
					model.SerUserID=int.Parse(row["SerUserID"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PerID,SerUserID,CreateTime ");
			strSql.Append(" FROM Friends ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PerID,SerUserID,CreateTime ");
			strSql.Append(" FROM Friends ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Friends ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.SerUserID desc");
			}
			strSql.Append(")AS Row, T.*  from Friends T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Friends";
			parameters[1].Value = "SerUserID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx
        /// <summary>
        /// 人才经纪人好友
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataSet SerUserFriend(string SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from View_PersonFriendApply where ReceiveUserID ={0} and ApplyState=0;", SerUserID);
            strSql.AppendFormat("select * from View_SerUserFriend where SerUserID={0}",SerUserID);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 人才 好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataSet PersonFriend(string PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from View_ServerUserFriendApply where ReceiveUserID ={0} and ApplyState=0;",PerID);
            strSql.AppendFormat("select * from View_PersonFriend where PerID={0}",PerID);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool DelFriend(int PerID,int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete Friends where SerUserID={0} and PerID={1}", SerUserID,PerID);
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(strSql.ToString()))>0;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FriendApply(ApplyType,ApplyUserID,ApplyName,ReceiveUserID,ReceiveName,ApplyTime,ApplyState) values (@ApplyType,@ApplyUserID,@ApplyName,@ReceiveUserID,@ReceiveName,getdate(),0)");
            SqlParameter[] para = { new SqlParameter("@ApplyUserID", ApplyUserID), new SqlParameter("@ApplyType", ApplyType), new SqlParameter("@ApplyName", ApplyName), new SqlParameter("@ReceiveUserID", ReceiveUserID), new SqlParameter("@ReceiveName", ReceiveName) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0 ;
        }
        /// <summary>
        /// 同意好友申请
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool AgreeApply(int PerID,int SerUserID,int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FriendApply set ApplyState=1 where ID=" + ID);
            if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from Friends where PerID=" + PerID + " and SerUserID=" + SerUserID + "")) <= 0)
            {
                strSql.Append(";insert into Friends(PerID,SerUserID,CreateTime)values(" + PerID + "," + SerUserID + ",getdate())");
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 1;
        }
        /// <summary>
        /// 求职者拒绝好友申请
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool PerRefuseApply(int ID,int SerUserID,string RealName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FriendApply set ApplyState=2 where ID="+ID+";");
            strSql.Append("INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + SerUserID + ",0,'"+RealName+"拒绝了您的好友申请',getdate())");
            return DbHelperSQL.ExecuteSql(strSql.ToString())>0;
        }
        /// <summary>
        /// 人才经纪人拒绝好友申请
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool SerRefuseApply(int ID,int PerID,string RealName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FriendApply set ApplyState=2 where ID=" + ID + ";");
            strSql.Append("INSERT INTO Person_Message(PerID,MesType,MesCon,SendTime)VALUES(" + PerID + ",0,'" + RealName + "拒绝了您的好友申请',getdate())");
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
        }
        /// <summary>
        /// 求职者判断是否已经是好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public int PerIsFriend(int PerID,int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select (select count(1) from Friends where PerID={0} and SerUserID={1}) as fcount,(select count(1) from FriendApply where ApplyUserID={2} and ReceiveUserID={3} and ApplyType=0 and ApplyState=0) as acount", PerID, SerUserID, PerID, SerUserID);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (Convert.ToInt32(dt.Rows[0]["fcount"]) > 0)
            {
                return 2;
            }
            else if (Convert.ToInt32(dt.Rows[0]["acount"]) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// 经纪人判断是否已经是好友
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public int SerIsFriend(int PerID, int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select (select count(1) from Friends where PerID={0} and SerUserID={1}) as fcount,(select count(1) from FriendApply where ApplyUserID={2} and ReceiveUserID={3} and ApplyType=1 and ApplyState=0) as acount", PerID, SerUserID, SerUserID,PerID);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (Convert.ToInt32(dt.Rows[0]["fcount"]) > 0)
            {
                return 2;
            }
            else if (Convert.ToInt32(dt.Rows[0]["acount"]) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 人才的好友申请
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable PersonFriendApply(int PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from View_ServerUserFriendApply where ReceiveUserID ={0} and ApplyState=0",PerID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 经纪人的好友申请
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable ServerUserFriendApply(int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from View_PersonFriendApply where ReceiveUserID ={0} and ApplyState=0", SerUserID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

		#endregion  MethodEx
	}
}

