using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person_Evaluate
	/// </summary>
	public partial class Person_Evaluate
	{
		public Person_Evaluate()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Person_Evaluate"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int result = DbHelperSQL.RunProcedure("Person_Evaluate_Exists", parameters, out rowsAffected);
            if (result == 1)
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
        public int Add(ZhongLi.Model.Person_Evaluate model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@PerName", SqlDbType.NVarChar,50),
					new SqlParameter("@EvaluateCon", SqlDbType.NVarChar,500),
					new SqlParameter("@EvaluateTime", SqlDbType.DateTime),
					new SqlParameter("@EvaluateUserID", SqlDbType.Int,4),
					new SqlParameter("@EvaluateName", SqlDbType.NVarChar,50),
					new SqlParameter("@EvaLevel", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@EvaluateType", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.PerID;
            parameters[2].Value = model.PerName;
            parameters[3].Value = model.EvaluateCon;
            parameters[4].Value = model.EvaluateTime;
            parameters[5].Value = model.EvaluateUserID;
            parameters[6].Value = model.EvaluateName;
            parameters[7].Value = model.EvaLevel;
            parameters[8].Value = model.OrderID;
            parameters[9].Value = model.EvaluateType;

            DbHelperSQL.RunProcedure("Person_Evaluate_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person_Evaluate model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@PerName", SqlDbType.NVarChar,50),
					new SqlParameter("@EvaluateCon", SqlDbType.NVarChar,500),
					new SqlParameter("@EvaluateTime", SqlDbType.DateTime),
					new SqlParameter("@EvaluateUserID", SqlDbType.Int,4),
					new SqlParameter("@EvaluateName", SqlDbType.NVarChar,50),
					new SqlParameter("@EvaLevel", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@EvaluateType", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PerID;
            parameters[2].Value = model.PerName;
            parameters[3].Value = model.EvaluateCon;
            parameters[4].Value = model.EvaluateTime;
            parameters[5].Value = model.EvaluateUserID;
            parameters[6].Value = model.EvaluateName;
            parameters[7].Value = model.EvaLevel;
            parameters[8].Value = model.OrderID;
            parameters[9].Value = model.EvaluateType;

            DbHelperSQL.RunProcedure("Person_Evaluate_Update", parameters, out rowsAffected);
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
        public bool Delete(int ID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Person_Evaluate_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Person_Evaluate ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public ZhongLi.Model.Person_Evaluate GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZhongLi.Model.Person_Evaluate model = new ZhongLi.Model.Person_Evaluate();
            DataSet ds = DbHelperSQL.RunProcedure("Person_Evaluate_GetModel", parameters, "ds");
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
        public ZhongLi.Model.Person_Evaluate DataRowToModel(DataRow row)
        {
            ZhongLi.Model.Person_Evaluate model = new ZhongLi.Model.Person_Evaluate();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PerID"] != null && row["PerID"].ToString() != "")
                {
                    model.PerID = int.Parse(row["PerID"].ToString());
                }
                if (row["PerName"] != null)
                {
                    model.PerName = row["PerName"].ToString();
                }
                if (row["EvaluateCon"] != null)
                {
                    model.EvaluateCon = row["EvaluateCon"].ToString();
                }
                if (row["EvaluateTime"] != null && row["EvaluateTime"].ToString() != "")
                {
                    model.EvaluateTime = DateTime.Parse(row["EvaluateTime"].ToString());
                }
                if (row["EvaluateUserID"] != null && row["EvaluateUserID"].ToString() != "")
                {
                    model.EvaluateUserID = int.Parse(row["EvaluateUserID"].ToString());
                }
                if (row["EvaluateName"] != null)
                {
                    model.EvaluateName = row["EvaluateName"].ToString();
                }
                if (row["EvaLevel"] != null && row["EvaLevel"].ToString() != "")
                {
                    model.EvaLevel = int.Parse(row["EvaLevel"].ToString());
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["EvaluateType"] != null && row["EvaluateType"].ToString() != "")
                {
                    model.EvaluateType = int.Parse(row["EvaluateType"].ToString());
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
            strSql.Append("select ID,PerID,PerName,EvaluateCon,EvaluateTime,EvaluateUserID,EvaluateName,EvaLevel,OrderID,EvaluateType ");
            strSql.Append(" FROM Person_Evaluate ");
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
            strSql.Append(" ID,PerID,PerName,EvaluateCon,EvaluateTime,EvaluateUserID,EvaluateName,EvaLevel,OrderID,EvaluateType ");
            strSql.Append(" FROM Person_Evaluate ");
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
			strSql.Append("select count(1) FROM Person_Evaluate ");
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
				strSql.Append("order by T.ID desc");
			}
            strSql.Append(")AS Row, T.*  from View_Person_Evaluate T ");
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
			parameters[0].Value = "Person_Evaluate";
			parameters[1].Value = "ID";
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

