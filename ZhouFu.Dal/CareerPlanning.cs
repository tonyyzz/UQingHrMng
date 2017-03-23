using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:CareerPlanning
	/// </summary>
	public partial class CareerPlanning
	{
		public CareerPlanning()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CPID", "CareerPlanning"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CPID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CPID", SqlDbType.Int,4)
			};
            parameters[0].Value = CPID;

            int result = DbHelperSQL.RunProcedure("CareerPlanning_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.CareerPlanning model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CPID", SqlDbType.Int,4),
					new SqlParameter("@CPType", SqlDbType.NVarChar,50),
					new SqlParameter("@CPName", SqlDbType.NVarChar,50),
					new SqlParameter("@CPTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CPDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@AbsDes", SqlDbType.NVarChar,200)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.CPType;
            parameters[2].Value = model.CPName;
            parameters[3].Value = model.CPTitle;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CPDes;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.ImgUrl;
            parameters[9].Value = model.AbsDes;

            DbHelperSQL.RunProcedure("CareerPlanning_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.CareerPlanning model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@CPID", SqlDbType.Int,4),
					new SqlParameter("@CPType", SqlDbType.NVarChar,50),
					new SqlParameter("@CPName", SqlDbType.NVarChar,50),
					new SqlParameter("@CPTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CPDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@AbsDes", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.CPID;
            parameters[1].Value = model.CPType;
            parameters[2].Value = model.CPName;
            parameters[3].Value = model.CPTitle;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CPDes;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.ImgUrl;
            parameters[9].Value = model.AbsDes;

            DbHelperSQL.RunProcedure("CareerPlanning_Update", parameters, out rowsAffected);
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
        public bool Delete(int CPID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@CPID", SqlDbType.Int,4)
			};
            parameters[0].Value = CPID;

            DbHelperSQL.RunProcedure("CareerPlanning_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string CPIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CareerPlanning ");
            strSql.Append(" where CPID in (" + CPIDlist + ")  ");
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
        public ZhongLi.Model.CareerPlanning GetModel(int CPID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@CPID", SqlDbType.Int,4)
			};
            parameters[0].Value = CPID;

            ZhongLi.Model.CareerPlanning model = new ZhongLi.Model.CareerPlanning();
            DataSet ds = DbHelperSQL.RunProcedure("CareerPlanning_GetModel", parameters, "ds");
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
        public ZhongLi.Model.CareerPlanning DataRowToModel(DataRow row)
        {
            ZhongLi.Model.CareerPlanning model = new ZhongLi.Model.CareerPlanning();
            if (row != null)
            {
                if (row["CPID"] != null && row["CPID"].ToString() != "")
                {
                    model.CPID = int.Parse(row["CPID"].ToString());
                }
                if (row["CPType"] != null)
                {
                    model.CPType = row["CPType"].ToString();
                }
                if (row["CPName"] != null)
                {
                    model.CPName = row["CPName"].ToString();
                }
                if (row["CPTitle"] != null)
                {
                    model.CPTitle = row["CPTitle"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CPDes"] != null)
                {
                    model.CPDes = row["CPDes"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
                }
                if (row["AbsDes"] != null)
                {
                    model.AbsDes = row["AbsDes"].ToString();
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
            strSql.Append("select CPID,CPType,CPName,CPTitle,Phone,CreateTime,Sort,ImgUrl,AbsDes ");
            strSql.Append(" FROM CareerPlanning ");
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
            strSql.Append(" CPID,CPType,CPName,CPTitle,Phone,CreateTime,Sort,ImgUrl,AbsDes ");
            strSql.Append(" FROM CareerPlanning ");
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
			strSql.Append("select count(1) FROM CareerPlanning ");
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
				strSql.Append("order by T.CPID desc");
			}
			strSql.Append(")AS Row, T.*  from CareerPlanning T ");
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
			parameters[0].Value = "CareerPlanning";
			parameters[1].Value = "CPID";
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
        public void UpdateSort(int id, int Sort)
        {
            SqlParameter[] para = { new SqlParameter("@id", id), new SqlParameter("@Sort", Sort) };
            DbHelperSQL.ExecuteSql("update CareerPlanning set Sort=@Sort where CPID =@id", para);
        }

		#endregion  MethodEx
	}
}

