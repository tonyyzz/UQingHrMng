using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:ServerUser_Education
	/// </summary>
	public partial class ServerUser_Education
	{
		public ServerUser_Education()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SerUserEduID", "ServerUser_Education"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SerUserEduID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserEduID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserEduID;

			int result= DbHelperSQL.RunProcedure("ServerUser_Education_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.ServerUser_Education model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserEduID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EduDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.SerUserID;
			parameters[2].Value = model.SchoolName;
			parameters[3].Value = model.Major;
			parameters[4].Value = model.Education;
			parameters[5].Value = model.StartTime;
			parameters[6].Value = model.EndTime;
			parameters[7].Value = model.EduDes;
			parameters[8].Value = model.CreateTime;

			DbHelperSQL.RunProcedure("ServerUser_Education_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.ServerUser_Education model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserEduID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EduDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.SerUserEduID;
			parameters[1].Value = model.SerUserID;
			parameters[2].Value = model.SchoolName;
			parameters[3].Value = model.Major;
			parameters[4].Value = model.Education;
			parameters[5].Value = model.StartTime;
			parameters[6].Value = model.EndTime;
			parameters[7].Value = model.EduDes;
			parameters[8].Value = model.CreateTime;

			DbHelperSQL.RunProcedure("ServerUser_Education_Update",parameters,out rowsAffected);
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
		public bool Delete(int SerUserEduID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserEduID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserEduID;

			DbHelperSQL.RunProcedure("ServerUser_Education_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string SerUserEduIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServerUser_Education ");
			strSql.Append(" where SerUserEduID in ("+SerUserEduIDlist + ")  ");
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
		public ZhongLi.Model.ServerUser_Education GetModel(int SerUserEduID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserEduID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserEduID;

			ZhongLi.Model.ServerUser_Education model=new ZhongLi.Model.ServerUser_Education();
			DataSet ds= DbHelperSQL.RunProcedure("ServerUser_Education_GetModel",parameters,"ds");
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
		public ZhongLi.Model.ServerUser_Education DataRowToModel(DataRow row)
		{
			ZhongLi.Model.ServerUser_Education model=new ZhongLi.Model.ServerUser_Education();
			if (row != null)
			{
				if(row["SerUserEduID"]!=null && row["SerUserEduID"].ToString()!="")
				{
					model.SerUserEduID=int.Parse(row["SerUserEduID"].ToString());
				}
				if(row["SerUserID"]!=null && row["SerUserID"].ToString()!="")
				{
					model.SerUserID=int.Parse(row["SerUserID"].ToString());
				}
				if(row["SchoolName"]!=null)
				{
					model.SchoolName=row["SchoolName"].ToString();
				}
				if(row["Major"]!=null)
				{
					model.Major=row["Major"].ToString();
				}
				if(row["Education"]!=null)
				{
					model.Education=row["Education"].ToString();
				}
				if(row["StartTime"]!=null)
				{
					model.StartTime=row["StartTime"].ToString();
				}
				if(row["EndTime"]!=null)
				{
					model.EndTime=row["EndTime"].ToString();
				}
				if(row["EduDes"]!=null)
				{
					model.EduDes=row["EduDes"].ToString();
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
			strSql.Append("select SerUserEduID,SerUserID,SchoolName,Major,Education,StartTime,EndTime,EduDes,CreateTime ");
			strSql.Append(" FROM ServerUser_Education ");
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
			strSql.Append(" SerUserEduID,SerUserID,SchoolName,Major,Education,StartTime,EndTime,EduDes,CreateTime ");
			strSql.Append(" FROM ServerUser_Education ");
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
			strSql.Append("select count(1) FROM ServerUser_Education ");
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
				strSql.Append("order by T.SerUserEduID desc");
			}
			strSql.Append(")AS Row, T.*  from ServerUser_Education T ");
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
			parameters[0].Value = "ServerUser_Education";
			parameters[1].Value = "SerUserEduID";
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

