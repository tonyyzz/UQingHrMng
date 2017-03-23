using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
    /// <summary>
    /// 数据访问类:PhoneCode
    /// </summary>
    public partial class PhoneCode
    {
        public PhoneCode()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Phone)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Phone;

            int result = DbHelperSQL.RunProcedure("PhoneCode_Exists", parameters, out rowsAffected);
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
        public void Add(ZhongLi.Model.PhoneCode model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@VerCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@SendType", SqlDbType.Int,4)};
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.VerCode;
            parameters[2].Value = model.SendTime;
            parameters[3].Value = model.SendType;

            DbHelperSQL.RunProcedure("PhoneCode_ADD", parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.PhoneCode model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@VerCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@SendType", SqlDbType.Int,4)};
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.VerCode;
            parameters[2].Value = model.SendTime;
            parameters[3].Value = model.SendType;

            DbHelperSQL.RunProcedure("PhoneCode_Update", parameters, out rowsAffected);
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
        public bool Delete(string Phone)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Phone;

            DbHelperSQL.RunProcedure("PhoneCode_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string Phonelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PhoneCode ");
            strSql.Append(" where Phone in (" + Phonelist + ")  ");
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
        public ZhongLi.Model.PhoneCode GetModel(string Phone)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Phone;

            ZhongLi.Model.PhoneCode model = new ZhongLi.Model.PhoneCode();
            DataSet ds = DbHelperSQL.RunProcedure("PhoneCode_GetModel", parameters, "ds");
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
        public ZhongLi.Model.PhoneCode DataRowToModel(DataRow row)
        {
            ZhongLi.Model.PhoneCode model = new ZhongLi.Model.PhoneCode();
            if (row != null)
            {
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["VerCode"] != null)
                {
                    model.VerCode = row["VerCode"].ToString();
                }
                if (row["SendTime"] != null && row["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                }
                if (row["SendType"] != null && row["SendType"].ToString() != "")
                {
                    model.SendType = int.Parse(row["SendType"].ToString());
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
            strSql.Append("select Phone,VerCode,SendTime,SendType ");
            strSql.Append(" FROM PhoneCode ");
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
            strSql.Append(" Phone,VerCode,SendTime,SendType ");
            strSql.Append(" FROM PhoneCode ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PhoneCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Phone desc");
            }
            strSql.Append(")AS Row, T.*  from PhoneCode T ");
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
            parameters[0].Value = "PhoneCode";
            parameters[1].Value = "Phone";
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
        /// 验证手机验证码是否正确与过期
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckPhoneCode(string phone,string code,string SendType)
        {
            deleteOverCode();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from PhoneCode where Phone='{0}' and VerCode='{1}' and SendType="+SendType+" and datediff( MINUTE, sendtime, GETDATE() )<=5", phone, code);
            int count = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
            return count > 0;
        }
        /// <summary>
        /// 删除过期的手机验证码数据
        /// </summary>
        public void deleteOverCode()
        {
            StringBuilder strSql = new StringBuilder("delete PhoneCode where datediff(MINUTE,sendtime, GETDATE())>30");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        #endregion  MethodEx
    }
}

