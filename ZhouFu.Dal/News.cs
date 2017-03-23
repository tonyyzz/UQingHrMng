using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:News
	/// </summary>
	public partial class News
	{
		public News()
		{}
		#region  Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(ZhongLi.Model.News model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@NewsCon", SqlDbType.NVarChar,-1),
					new SqlParameter("@Hot", SqlDbType.Bit,1),
					new SqlParameter("@NewsType", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@AbsDes", SqlDbType.NVarChar,200)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.NewsCon;
            parameters[4].Value = model.Hot;
            parameters[5].Value = model.NewsType;
            parameters[6].Value = model.ImgUrl;
            parameters[7].Value = model.AbsDes;

            DbHelperSQL.RunProcedure("News_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.News model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@NewsCon", SqlDbType.NVarChar,-1),
					new SqlParameter("@Hot", SqlDbType.Bit,1),
					new SqlParameter("@NewsType", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@AbsDes", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.NewsID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.NewsCon;
            parameters[4].Value = model.Hot;
            parameters[5].Value = model.NewsType;
            parameters[6].Value = model.ImgUrl;
            parameters[7].Value = model.AbsDes;

            DbHelperSQL.RunProcedure("News_Update", parameters, out rowsAffected);
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
        public bool Delete(int NewsID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsID;

            DbHelperSQL.RunProcedure("News_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string NewsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from News ");
            strSql.Append(" where NewsID in (" + NewsIDlist + ")  ");
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
        public ZhongLi.Model.News GetModel(int NewsID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsID;

            ZhongLi.Model.News model = new ZhongLi.Model.News();
            DataSet ds = DbHelperSQL.RunProcedure("News_GetModel", parameters, "ds");
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
        public ZhongLi.Model.News DataRowToModel(DataRow row)
        {
            ZhongLi.Model.News model = new ZhongLi.Model.News();
            if (row != null)
            {
                if (row["NewsID"] != null && row["NewsID"].ToString() != "")
                {
                    model.NewsID = int.Parse(row["NewsID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["NewsCon"] != null)
                {
                    model.NewsCon = row["NewsCon"].ToString();
                }
                if (row["Hot"] != null && row["Hot"].ToString() != "")
                {
                    if ((row["Hot"].ToString() == "1") || (row["Hot"].ToString().ToLower() == "true"))
                    {
                        model.Hot = true;
                    }
                    else
                    {
                        model.Hot = false;
                    }
                }
                if (row["NewsType"] != null && row["NewsType"].ToString() != "")
                {
                    model.NewsType = int.Parse(row["NewsType"].ToString());
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
            strSql.Append("select NewsID,Title,CreateTime,NewsCon,Hot,NewsType,ImgUrl,AbsDes ");
            strSql.Append(" FROM News ");
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
            strSql.Append(" NewsID,Title,CreateTime,Hot,NewsType,ImgUrl,AbsDes ");
            strSql.Append(" FROM News ");
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
			strSql.Append("select count(1) FROM News ");
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
				strSql.Append("order by T.NewsID desc");
			}
            strSql.Append(")AS Row, T.NewsID,T.Title,T.CreateTime,T.Hot,T.NewsType,T.ImgUrl,T.AbsDes,T.Name  from View_News T ");
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
			parameters[0].Value = "News";
			parameters[1].Value = "NewsID";
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

