using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person_Skill
	/// </summary>
	public partial class Person_Skill
	{
		public Person_Skill()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PerSkillID", "Person_Skill"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PerSkillID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerSkillID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerSkillID;

			int result= DbHelperSQL.RunProcedure("Person_Skill_Exists",parameters,out rowsAffected);
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
        public int Add(ZhongLi.Model.Person_Skill model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PerSkillID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SkillName", SqlDbType.NVarChar,50),
					new SqlParameter("@MasterDegree", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.PerID;
            parameters[2].Value = model.SkillName;
            parameters[3].Value = model.MasterDegree;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.Colvalue;

            DbHelperSQL.RunProcedure("Person_Skill_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person_Skill model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerSkillID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@SkillName", SqlDbType.NVarChar,50),
					new SqlParameter("@MasterDegree", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PerSkillID;
            parameters[1].Value = model.PerID;
            parameters[2].Value = model.SkillName;
            parameters[3].Value = model.MasterDegree;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.Colvalue;

            DbHelperSQL.RunProcedure("Person_Skill_Update", parameters, out rowsAffected);
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
        public bool Delete(int PerSkillID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerSkillID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerSkillID;

            DbHelperSQL.RunProcedure("Person_Skill_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string PerSkillIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Person_Skill ");
            strSql.Append(" where PerSkillID in (" + PerSkillIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public ZhongLi.Model.Person_Skill GetModel(int PerSkillID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PerSkillID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerSkillID;

            ZhongLi.Model.Person_Skill model = new ZhongLi.Model.Person_Skill();
            DataSet ds = DbHelperSQL.RunProcedure("Person_Skill_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
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
        public ZhongLi.Model.Person_Skill DataRowToModel(DataRow row)
        {
            ZhongLi.Model.Person_Skill model = new ZhongLi.Model.Person_Skill();
            if (row != null)
            {
                if (row["PerSkillID"] != null && row["PerSkillID"].ToString() != "")
                {
                    model.PerSkillID = int.Parse(row["PerSkillID"].ToString());
                }
                if (row["PerID"] != null && row["PerID"].ToString() != "")
                {
                    model.PerID = int.Parse(row["PerID"].ToString());
                }
                if (row["SkillName"] != null)
                {
                    model.SkillName = row["SkillName"].ToString();
                }
                if (row["MasterDegree"] != null)
                {
                    model.MasterDegree = row["MasterDegree"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Colvalue"] != null)
                {
                    model.Colvalue = row["Colvalue"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PerSkillID,PerID,SkillName,MasterDegree,CreateTime,Colvalue ");
            strSql.Append(" FROM Person_Skill ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PerSkillID,PerID,SkillName,MasterDegree,CreateTime,Colvalue ");
            strSql.Append(" FROM Person_Skill ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append("select count(1) FROM Person_Skill ");
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
				strSql.Append("order by T.PerSkillID desc");
			}
			strSql.Append(")AS Row, T.*  from Person_Skill T ");
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
			parameters[0].Value = "Person_Skill";
			parameters[1].Value = "PerSkillID";
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

