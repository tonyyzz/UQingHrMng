using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:JobTraining
	/// </summary>
	public partial class JobTraining
	{
		public JobTraining()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("JobTraID", "JobTraining"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int JobTraID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@JobTraID", SqlDbType.Int,4)
			};
            parameters[0].Value = JobTraID;

            int result = DbHelperSQL.RunProcedure("JobTraining_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.JobTraining model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@JobTraID", SqlDbType.Int,4),
					new SqlParameter("@JobTraType", SqlDbType.NVarChar,50),
					new SqlParameter("@JobTraName", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@JobTraDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@AbsDes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobTraTitle", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.JobTraType;
            parameters[2].Value = model.JobTraName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.JobTraDes;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.Imgurl;
            parameters[7].Value = model.AbsDes;
            parameters[8].Value = model.JobTraTitle;

            DbHelperSQL.RunProcedure("JobTraining_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.JobTraining model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@JobTraID", SqlDbType.Int,4),
					new SqlParameter("@JobTraType", SqlDbType.NVarChar,50),
					new SqlParameter("@JobTraName", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@JobTraDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@AbsDes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobTraTitle", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.JobTraID;
            parameters[1].Value = model.JobTraType;
            parameters[2].Value = model.JobTraName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.JobTraDes;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.Imgurl;
            parameters[7].Value = model.AbsDes;
            parameters[8].Value = model.JobTraTitle;

            DbHelperSQL.RunProcedure("JobTraining_Update", parameters, out rowsAffected);
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
        public bool Delete(int JobTraID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@JobTraID", SqlDbType.Int,4)
			};
            parameters[0].Value = JobTraID;

            DbHelperSQL.RunProcedure("JobTraining_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string JobTraIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobTraining ");
            strSql.Append(" where JobTraID in (" + JobTraIDlist + ")  ");
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
        public ZhongLi.Model.JobTraining GetModel(int JobTraID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@JobTraID", SqlDbType.Int,4)
			};
            parameters[0].Value = JobTraID;

            ZhongLi.Model.JobTraining model = new ZhongLi.Model.JobTraining();
            DataSet ds = DbHelperSQL.RunProcedure("JobTraining_GetModel", parameters, "ds");
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
        public ZhongLi.Model.JobTraining DataRowToModel(DataRow row)
        {
            ZhongLi.Model.JobTraining model = new ZhongLi.Model.JobTraining();
            if (row != null)
            {
                if (row["JobTraID"] != null && row["JobTraID"].ToString() != "")
                {
                    model.JobTraID = int.Parse(row["JobTraID"].ToString());
                }
                if (row["JobTraType"] != null)
                {
                    model.JobTraType = row["JobTraType"].ToString();
                }
                if (row["JobTraName"] != null)
                {
                    model.JobTraName = row["JobTraName"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["JobTraDes"] != null)
                {
                    model.JobTraDes = row["JobTraDes"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["Imgurl"] != null)
                {
                    model.Imgurl = row["Imgurl"].ToString();
                }
                if (row["AbsDes"] != null)
                {
                    model.AbsDes = row["AbsDes"].ToString();
                }
                if (row["JobTraTitle"] != null)
                {
                    model.JobTraTitle = row["JobTraTitle"].ToString();
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
            strSql.Append("select JobTraID,JobTraType,JobTraName,Phone,Sort,Imgurl,AbsDes,JobTraTitle ");
            strSql.Append(" FROM JobTraining ");
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
            strSql.Append(" JobTraID,JobTraType,JobTraName,Phone,Sort,Imgurl,AbsDes,JobTraTitle ");
            strSql.Append(" FROM JobTraining ");
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
			strSql.Append("select count(1) FROM JobTraining ");
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
				strSql.Append("order by T.JobTraID desc");
			}
			strSql.Append(")AS Row, T.*  from JobTraining T ");
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
			parameters[0].Value = "JobTraining";
			parameters[1].Value = "JobTraID";
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
        /// 修改排序
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="Sort">排序</param>
        public void UpdateSort(int id,int Sort)
        {
            SqlParameter[] para={new SqlParameter("@id",id),new SqlParameter("@Sort",Sort)};
            DbHelperSQL.ExecuteSql("update JobTraining set Sort=@Sort where JobTraID =@id",para);
        }

		#endregion  MethodEx
	}
}

