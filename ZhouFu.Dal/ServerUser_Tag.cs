using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:ServerUser_Tag
	/// </summary>
	public partial class ServerUser_Tag
	{
		public ServerUser_Tag()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SerUserTagID", "ServerUser_Tag"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SerUserTagID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserTagID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserTagID;

			int result= DbHelperSQL.RunProcedure("ServerUser_Tag_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.ServerUser_Tag model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserTagID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.SerUserID;
			parameters[2].Value = model.TagName;
			parameters[3].Value = model.Colvalue;

			DbHelperSQL.RunProcedure("ServerUser_Tag_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.ServerUser_Tag model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserTagID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SerUserTagID;
			parameters[1].Value = model.SerUserID;
			parameters[2].Value = model.TagName;
			parameters[3].Value = model.Colvalue;

			DbHelperSQL.RunProcedure("ServerUser_Tag_Update",parameters,out rowsAffected);
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
		public bool Delete(int SerUserTagID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserTagID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserTagID;

			DbHelperSQL.RunProcedure("ServerUser_Tag_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string SerUserTagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServerUser_Tag ");
			strSql.Append(" where SerUserTagID in ("+SerUserTagIDlist + ")  ");
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
		public ZhongLi.Model.ServerUser_Tag GetModel(int SerUserTagID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserTagID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserTagID;

			ZhongLi.Model.ServerUser_Tag model=new ZhongLi.Model.ServerUser_Tag();
			DataSet ds= DbHelperSQL.RunProcedure("ServerUser_Tag_GetModel",parameters,"ds");
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
		public ZhongLi.Model.ServerUser_Tag DataRowToModel(DataRow row)
		{
			ZhongLi.Model.ServerUser_Tag model=new ZhongLi.Model.ServerUser_Tag();
			if (row != null)
			{
				if(row["SerUserTagID"]!=null && row["SerUserTagID"].ToString()!="")
				{
					model.SerUserTagID=int.Parse(row["SerUserTagID"].ToString());
				}
				if(row["SerUserID"]!=null && row["SerUserID"].ToString()!="")
				{
					model.SerUserID=int.Parse(row["SerUserID"].ToString());
				}
				if(row["TagName"]!=null)
				{
					model.TagName=row["TagName"].ToString();
				}
				if(row["Colvalue"]!=null)
				{
					model.Colvalue=row["Colvalue"].ToString();
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
			strSql.Append("select SerUserTagID,SerUserID,TagName,Colvalue ");
			strSql.Append(" FROM ServerUser_Tag ");
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
			strSql.Append(" SerUserTagID,SerUserID,TagName,Colvalue ");
			strSql.Append(" FROM ServerUser_Tag ");
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
			strSql.Append("select count(1) FROM ServerUser_Tag ");
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
				strSql.Append("order by T.SerUserTagID desc");
			}
			strSql.Append(")AS Row, T.*  from ServerUser_Tag T ");
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
			parameters[0].Value = "ServerUser_Tag";
			parameters[1].Value = "SerUserTagID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

