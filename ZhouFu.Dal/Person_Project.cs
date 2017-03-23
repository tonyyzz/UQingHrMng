using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person_Project
	/// </summary>
	public partial class Person_Project
	{
		public Person_Project()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PerProID", "Person_Project"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PerProID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerProID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerProID;

			int result= DbHelperSQL.RunProcedure("Person_Project_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.Person_Project model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerProID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProDuty", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ProDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@ProLink", SqlDbType.NVarChar,100),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.PerID;
			parameters[2].Value = model.ProName;
			parameters[3].Value = model.ProDuty;
			parameters[4].Value = model.StartTime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.ProDes;
			parameters[7].Value = model.ProLink;
			parameters[8].Value = model.Colvalue;

			DbHelperSQL.RunProcedure("Person_Project_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Person_Project model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PerProID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProDuty", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ProDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@ProLink", SqlDbType.NVarChar,100),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PerProID;
			parameters[1].Value = model.PerID;
			parameters[2].Value = model.ProName;
			parameters[3].Value = model.ProDuty;
			parameters[4].Value = model.StartTime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.ProDes;
			parameters[7].Value = model.ProLink;
			parameters[8].Value = model.Colvalue;

			DbHelperSQL.RunProcedure("Person_Project_Update",parameters,out rowsAffected);
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
		public bool Delete(int PerProID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PerProID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerProID;

			DbHelperSQL.RunProcedure("Person_Project_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string PerProIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Person_Project ");
			strSql.Append(" where PerProID in ("+PerProIDlist + ")  ");
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
		public ZhongLi.Model.Person_Project GetModel(int PerProID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@PerProID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerProID;

			ZhongLi.Model.Person_Project model=new ZhongLi.Model.Person_Project();
			DataSet ds= DbHelperSQL.RunProcedure("Person_Project_GetModel",parameters,"ds");
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
		public ZhongLi.Model.Person_Project DataRowToModel(DataRow row)
		{
			ZhongLi.Model.Person_Project model=new ZhongLi.Model.Person_Project();
			if (row != null)
			{
				if(row["PerProID"]!=null && row["PerProID"].ToString()!="")
				{
					model.PerProID=int.Parse(row["PerProID"].ToString());
				}
				if(row["PerID"]!=null && row["PerID"].ToString()!="")
				{
					model.PerID=int.Parse(row["PerID"].ToString());
				}
				if(row["ProName"]!=null)
				{
					model.ProName=row["ProName"].ToString();
				}
				if(row["ProDuty"]!=null)
				{
					model.ProDuty=row["ProDuty"].ToString();
				}
				if(row["StartTime"]!=null)
				{
					model.StartTime=row["StartTime"].ToString();
				}
				if(row["EndTime"]!=null)
				{
					model.EndTime=row["EndTime"].ToString();
				}
				if(row["ProDes"]!=null)
				{
					model.ProDes=row["ProDes"].ToString();
				}
				if(row["ProLink"]!=null)
				{
					model.ProLink=row["ProLink"].ToString();
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
			strSql.Append("select PerProID,PerID,ProName,ProDuty,StartTime,EndTime,ProDes,ProLink,Colvalue ");
			strSql.Append(" FROM Person_Project ");
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
			strSql.Append(" PerProID,PerID,ProName,ProDuty,StartTime,EndTime,ProDes,ProLink,Colvalue ");
			strSql.Append(" FROM Person_Project ");
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
			strSql.Append("select count(1) FROM Person_Project ");
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
				strSql.Append("order by T.PerProID desc");
			}
			strSql.Append(")AS Row, T.*  from Person_Project T ");
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
			parameters[0].Value = "Person_Project";
			parameters[1].Value = "PerProID";
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

