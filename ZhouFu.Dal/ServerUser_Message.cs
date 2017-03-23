using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
    /// <summary>
    /// 数据访问类:ServerUser_Message
    /// </summary>
    public partial class ServerUser_Message
    {
        public ServerUser_Message()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SerMesID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SerMesID", SqlDbType.Int,4)
			};
            parameters[0].Value = SerMesID;

            int result = DbHelperSQL.RunProcedure("ServerUser_Message_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.ServerUser_Message model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SerMesID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@MesType", SqlDbType.Int,4),
					new SqlParameter("@DataID", SqlDbType.Int,4),
					new SqlParameter("@MesCon", SqlDbType.NVarChar,200),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Bit,1),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@TargetID", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.SerUserID;
            parameters[2].Value = model.MesType;
            parameters[3].Value = model.DataID;
            parameters[4].Value = model.MesCon;
            parameters[5].Value = model.SendTime;
            parameters[6].Value = model.IsRead;
            parameters[7].Value = model.ReadTime;
            parameters[8].Value = model.Colvalue;
            parameters[9].Value = model.TargetID;

            DbHelperSQL.RunProcedure("ServerUser_Message_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.ServerUser_Message model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SerMesID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@MesType", SqlDbType.Int,4),
					new SqlParameter("@DataID", SqlDbType.Int,4),
					new SqlParameter("@MesCon", SqlDbType.NVarChar,200),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Bit,1),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@TargetID", SqlDbType.Int,4)};
            parameters[0].Value = model.SerMesID;
            parameters[1].Value = model.SerUserID;
            parameters[2].Value = model.MesType;
            parameters[3].Value = model.DataID;
            parameters[4].Value = model.MesCon;
            parameters[5].Value = model.SendTime;
            parameters[6].Value = model.IsRead;
            parameters[7].Value = model.ReadTime;
            parameters[8].Value = model.Colvalue;
            parameters[9].Value = model.TargetID;

            DbHelperSQL.RunProcedure("ServerUser_Message_Update", parameters, out rowsAffected);
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
        public bool Delete(int SerMesID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SerMesID", SqlDbType.Int,4)
			};
            parameters[0].Value = SerMesID;

            DbHelperSQL.RunProcedure("ServerUser_Message_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string SerMesIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServerUser_Message ");
            strSql.Append(" where SerMesID in (" + SerMesIDlist + ")  ");
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
        public ZhongLi.Model.ServerUser_Message GetModel(int SerMesID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SerMesID", SqlDbType.Int,4)
			};
            parameters[0].Value = SerMesID;

            ZhongLi.Model.ServerUser_Message model = new ZhongLi.Model.ServerUser_Message();
            DataSet ds = DbHelperSQL.RunProcedure("ServerUser_Message_GetModel", parameters, "ds");
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
        public ZhongLi.Model.ServerUser_Message DataRowToModel(DataRow row)
        {
            ZhongLi.Model.ServerUser_Message model = new ZhongLi.Model.ServerUser_Message();
            if (row != null)
            {
                if (row["SerMesID"] != null && row["SerMesID"].ToString() != "")
                {
                    model.SerMesID = int.Parse(row["SerMesID"].ToString());
                }
                if (row["SerUserID"] != null && row["SerUserID"].ToString() != "")
                {
                    model.SerUserID = int.Parse(row["SerUserID"].ToString());
                }
                if (row["MesType"] != null && row["MesType"].ToString() != "")
                {
                    model.MesType = int.Parse(row["MesType"].ToString());
                }
                if (row["DataID"] != null && row["DataID"].ToString() != "")
                {
                    model.DataID = int.Parse(row["DataID"].ToString());
                }
                if (row["MesCon"] != null)
                {
                    model.MesCon = row["MesCon"].ToString();
                }
                if (row["SendTime"] != null && row["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                }
                if (row["IsRead"] != null && row["IsRead"].ToString() != "")
                {
                    if ((row["IsRead"].ToString() == "1") || (row["IsRead"].ToString().ToLower() == "true"))
                    {
                        model.IsRead = true;
                    }
                    else
                    {
                        model.IsRead = false;
                    }
                }
                if (row["ReadTime"] != null && row["ReadTime"].ToString() != "")
                {
                    model.ReadTime = DateTime.Parse(row["ReadTime"].ToString());
                }
                if (row["Colvalue"] != null)
                {
                    model.Colvalue = row["Colvalue"].ToString();
                }
                if (row["TargetID"] != null && row["TargetID"].ToString() != "")
                {
                    model.TargetID = int.Parse(row["TargetID"].ToString());
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
            strSql.Append("select SerMesID,SerUserID,MesType,DataID,MesCon,SendTime,IsRead,ReadTime,Colvalue,TargetID ");
            strSql.Append(" FROM ServerUser_Message ");
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
            strSql.Append(" SerMesID,SerUserID,MesType,DataID,MesCon,SendTime,IsRead,ReadTime,Colvalue,TargetID ");
            strSql.Append(" FROM ServerUser_Message ");
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
            strSql.Append("select count(1) FROM ServerUser_Message ");
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
                strSql.Append("order by T.SerMesID desc");
            }
            strSql.Append(")AS Row, T.*  from ServerUser_Message T ");
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
            parameters[0].Value = "ServerUser_Message";
            parameters[1].Value = "SerMesID";
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
        /// 得到所有未读消息
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public int getMsgCount(int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Count(1) from ServerUser_Message where SerUserID=@SerUserID and (IsRead is null or IsRead ='false')");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), new SqlParameter("@SerUserID", SerUserID)));
        }
        /// <summary>
        /// 得到消息数量列表
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public DataTable getMsgCountByType(int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c,p.MesType,MesCon,SendTime from(");
            strSql.Append("Select MesType,COUNT(*) as c,MAX(SerMesID) as SerMesID  From ServerUser_Message where SerUserID=@SerUserID and (IsRead is null or IsRead ='false') Group by MesType");
            strSql.Append(") as t left join ServerUser_Message as p on p.SerMesID=t.SerMesID");
            return DbHelperSQL.Query(strSql.ToString(), new SqlParameter("@SerUserID", SerUserID)).Tables[0];
        }
        /// <summary>
        /// 得到分类的详细列表并设置已读
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="MsgType"></param>
        /// <returns></returns>
        public DataTable getMsgByType(int SerUserID, int MsgType)
        {
            StringBuilder strSqlUpdate = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from ServerUser_Message where SerUserID={0} and MesType={1} order by SendTime desc", SerUserID, MsgType);
            DataTable dt= DbHelperSQL.Query(strSql.ToString()).Tables[0];
            strSqlUpdate.AppendFormat("update ServerUser_Message set IsRead='True',ReadTime=getdate() where SerUserID={0} and MesType={1} and (IsRead is NULL or IsRead='false')", SerUserID, MsgType);
            DbHelperSQL.ExecuteSql(strSqlUpdate.ToString());
            return dt;
        }
        #endregion  MethodEx
    }
}

