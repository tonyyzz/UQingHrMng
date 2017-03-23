using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person_Education
	/// </summary>
	public partial class Person_Education
	{
		public Person_Education()
		{}
		#region  Method


		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(ZhongLi.Model.Person_Education model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerEduID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationYear", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.PerID;
			parameters[2].Value = model.SchoolName;
			parameters[3].Value = model.Major;
			parameters[4].Value = model.GraduationYear;
			parameters[5].Value = model.Education;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.Colvalue;

			DbHelperSQL.RunProcedure("Person_Education_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Person_Education model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PerEduID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationYear", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PerEduID;
			parameters[1].Value = model.PerID;
			parameters[2].Value = model.SchoolName;
			parameters[3].Value = model.Major;
			parameters[4].Value = model.GraduationYear;
			parameters[5].Value = model.Education;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.Colvalue;

			DbHelperSQL.RunProcedure("Person_Education_Update",parameters,out rowsAffected);
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
		public bool Delete(int PerEduID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PerEduID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerEduID;

			DbHelperSQL.RunProcedure("Person_Education_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string PerEduIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Person_Education ");
			strSql.Append(" where PerEduID in ("+PerEduIDlist + ")  ");
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
		public ZhongLi.Model.Person_Education GetModel(int PerEduID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@PerEduID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerEduID;

			ZhongLi.Model.Person_Education model=new ZhongLi.Model.Person_Education();
			DataSet ds= DbHelperSQL.RunProcedure("Person_Education_GetModel",parameters,"ds");
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
		public ZhongLi.Model.Person_Education DataRowToModel(DataRow row)
		{
			ZhongLi.Model.Person_Education model=new ZhongLi.Model.Person_Education();
			if (row != null)
			{
				if(row["PerEduID"]!=null && row["PerEduID"].ToString()!="")
				{
					model.PerEduID=int.Parse(row["PerEduID"].ToString());
				}
				if(row["PerID"]!=null && row["PerID"].ToString()!="")
				{
					model.PerID=int.Parse(row["PerID"].ToString());
				}
				if(row["SchoolName"]!=null)
				{
					model.SchoolName=row["SchoolName"].ToString();
				}
				if(row["Major"]!=null)
				{
					model.Major=row["Major"].ToString();
				}
				if(row["GraduationYear"]!=null)
				{
					model.GraduationYear=row["GraduationYear"].ToString();
				}
				if(row["Education"]!=null)
				{
					model.Education=row["Education"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select PerEduID,PerID,SchoolName,Major,GraduationYear,Education,CreateTime,Colvalue ");
			strSql.Append(" FROM Person_Education ");
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
			strSql.Append(" PerEduID,PerID,SchoolName,Major,GraduationYear,Education,CreateTime,Colvalue ");
			strSql.Append(" FROM Person_Education ");
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
			strSql.Append("select count(1) FROM Person_Education ");
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
				strSql.Append("order by T.PerEduID desc");
			}
			strSql.Append(")AS Row, T.*  from Person_Education T ");
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
			parameters[0].Value = "Person_Education";
			parameters[1].Value = "PerEduID";
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

