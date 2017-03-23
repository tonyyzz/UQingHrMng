﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:WelfareTag
	/// </summary>
	public partial class WelfareTag
	{
		public WelfareTag()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TagID", "WelfareTag"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TagID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
			};
			parameters[0].Value = TagID;

			int result= DbHelperSQL.RunProcedure("WelfareTag_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.WelfareTag model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.TagName;
			parameters[2].Value = model.Sort;

			DbHelperSQL.RunProcedure("WelfareTag_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.WelfareTag model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
			parameters[0].Value = model.TagID;
			parameters[1].Value = model.TagName;
			parameters[2].Value = model.Sort;

			DbHelperSQL.RunProcedure("WelfareTag_Update",parameters,out rowsAffected);
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
		public bool Delete(int TagID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
			};
			parameters[0].Value = TagID;

			DbHelperSQL.RunProcedure("WelfareTag_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string TagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WelfareTag ");
			strSql.Append(" where TagID in ("+TagIDlist + ")  ");
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
		public ZhongLi.Model.WelfareTag GetModel(int TagID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
			};
			parameters[0].Value = TagID;

			ZhongLi.Model.WelfareTag model=new ZhongLi.Model.WelfareTag();
			DataSet ds= DbHelperSQL.RunProcedure("WelfareTag_GetModel",parameters,"ds");
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
		public ZhongLi.Model.WelfareTag DataRowToModel(DataRow row)
		{
			ZhongLi.Model.WelfareTag model=new ZhongLi.Model.WelfareTag();
			if (row != null)
			{
				if(row["TagID"]!=null && row["TagID"].ToString()!="")
				{
					model.TagID=int.Parse(row["TagID"].ToString());
				}
				if(row["TagName"]!=null)
				{
					model.TagName=row["TagName"].ToString();
				}
				if(row["Sort"]!=null && row["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(row["Sort"].ToString());
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
			strSql.Append("select TagID,TagName,Sort ");
			strSql.Append(" FROM WelfareTag ");
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
			strSql.Append(" TagID,TagName,Sort ");
			strSql.Append(" FROM WelfareTag ");
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
			strSql.Append("select count(1) FROM WelfareTag ");
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
				strSql.Append("order by T.TagID desc");
			}
			strSql.Append(")AS Row, T.*  from WelfareTag T ");
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
			parameters[0].Value = "WelfareTag";
			parameters[1].Value = "TagID";
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

