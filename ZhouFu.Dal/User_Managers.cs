using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using ZhongLi.Common;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:User_Managers
	/// </summary>
	public partial class User_Managers
	{
		public User_Managers()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserId", "User_Managers"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			int result= DbHelperSQL.RunProcedure("User_Managers_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.User_Managers model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256),
					new SqlParameter("@Password", SqlDbType.NVarChar,256),
					new SqlParameter("@Email", SqlDbType.NVarChar,256),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
                     new SqlParameter("@RealName", SqlDbType.NVarChar,256)                   };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.RoleId;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.RealName;

			DbHelperSQL.RunProcedure("User_Managers_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.User_Managers model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256),
					new SqlParameter("@Password", SqlDbType.NVarChar,256),
					new SqlParameter("@Email", SqlDbType.NVarChar,256),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
                       new SqlParameter("@RealName", SqlDbType.NVarChar,256)                  };
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RoleId;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.RealName;
			DbHelperSQL.RunProcedure("User_Managers_Update",parameters,out rowsAffected);
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
		public bool Delete(int UserId)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			DbHelperSQL.RunProcedure("User_Managers_Delete",parameters,out rowsAffected);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string UserIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_Managers ");
			strSql.Append(" where UserId in ("+UserIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
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
		public ZhongLi.Model.User_Managers GetModel(int UserId)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			ZhongLi.Model.User_Managers model=new ZhongLi.Model.User_Managers();
			DataSet ds= DbHelperSQL.RunProcedure("User_Managers_GetModel",parameters,"ds");
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
		public ZhongLi.Model.User_Managers DataRowToModel(DataRow row)
		{
			ZhongLi.Model.User_Managers model=new ZhongLi.Model.User_Managers();
			if (row != null)
			{
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["RoleId"]!=null && row["RoleId"].ToString()!="")
				{
					model.RoleId=int.Parse(row["RoleId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
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
			strSql.Append("select UserId,RoleId,UserName,Password,Email,CreateDate,RealName ");
			strSql.Append(" FROM User_Managers ");
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
			strSql.Append(" UserId,RoleId,UserName,Password,Email,CreateDate,RealName ");
			strSql.Append(" FROM User_Managers ");
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
			strSql.Append("select count(1) FROM User_Managers ");
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
				strSql.Append("order by T.UserId desc");
			}
            strSql.Append(")AS Row, T.*  from View_User_Managers T ");
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
			parameters[0].Value = "User_Managers";
			parameters[1].Value = "UserId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx
        public int checkuser(string user, string password)
        {
            SqlParameter para1 = new SqlParameter("@UserName",user);
            SqlParameter para2 = new SqlParameter("@Password", DESEncrypt.EncryptDES(password));
            SqlParameter[] para={para1,para2};
            DataSet ds = DbHelperSQL.Query("select UserID from User_Managers where UserName=@UserName and Password=@Password", para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return (int)ds.Tables[0].Rows[0][0];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool checkUserName(string UserName){
            SqlParameter[] para={new SqlParameter("@UserName",UserName)};
            object o= DbHelperSQL.GetSingle("select Count(1) from User_Managers where UserName=@UserName", para);
            return Convert.ToInt32(o) <= 0;
        }
		#endregion  MethodEx
	}
}

