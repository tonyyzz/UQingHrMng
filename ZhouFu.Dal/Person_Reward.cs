using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person_Reward
	/// </summary>
	public partial class Person_Reward
	{
		public Person_Reward()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PerRewardID", "Person_Reward"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PerRewardID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewardID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerRewardID;

            int result = DbHelperSQL.RunProcedure("Person_Reward_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.Person_Reward model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewardID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanySize", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyNature", SqlDbType.NVarChar,50),
					new SqlParameter("@EngagePost", SqlDbType.NVarChar,50),
					new SqlParameter("@DemandPay", SqlDbType.NVarChar,50),
					new SqlParameter("@JobCity", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemand", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyMatching", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemandDes", SqlDbType.NVarChar,500),
					new SqlParameter("@RewardMoney", SqlDbType.Decimal,9),
					new SqlParameter("@RewardTime", SqlDbType.DateTime),
					new SqlParameter("@RewardState", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkLife", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.PerID;
            parameters[2].Value = model.Trade;
            parameters[3].Value = model.CompanySize;
            parameters[4].Value = model.CompanyNature;
            parameters[5].Value = model.EngagePost;
            parameters[6].Value = model.DemandPay;
            parameters[7].Value = model.JobCity;
            parameters[8].Value = model.OtherDemand;
            parameters[9].Value = model.CompanyMatching;
            parameters[10].Value = model.OtherDemandDes;
            parameters[11].Value = model.RewardMoney;
            parameters[12].Value = model.RewardTime;
            parameters[13].Value = model.RewardState;
            parameters[14].Value = model.IsDelete;
            parameters[15].Value = model.Education;
            parameters[16].Value = model.WorkLife;

            DbHelperSQL.RunProcedure("Person_Reward_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person_Reward model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewardID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanySize", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyNature", SqlDbType.NVarChar,50),
					new SqlParameter("@EngagePost", SqlDbType.NVarChar,50),
					new SqlParameter("@DemandPay", SqlDbType.NVarChar,50),
					new SqlParameter("@JobCity", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemand", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyMatching", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemandDes", SqlDbType.NVarChar,500),
					new SqlParameter("@RewardMoney", SqlDbType.Decimal,9),
					new SqlParameter("@RewardTime", SqlDbType.DateTime),
					new SqlParameter("@RewardState", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkLife", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PerRewardID;
            parameters[1].Value = model.PerID;
            parameters[2].Value = model.Trade;
            parameters[3].Value = model.CompanySize;
            parameters[4].Value = model.CompanyNature;
            parameters[5].Value = model.EngagePost;
            parameters[6].Value = model.DemandPay;
            parameters[7].Value = model.JobCity;
            parameters[8].Value = model.OtherDemand;
            parameters[9].Value = model.CompanyMatching;
            parameters[10].Value = model.OtherDemandDes;
            parameters[11].Value = model.RewardMoney;
            parameters[12].Value = model.RewardTime;
            parameters[13].Value = model.RewardState;
            parameters[14].Value = model.IsDelete;
            parameters[15].Value = model.Education;
            parameters[16].Value = model.WorkLife;

            DbHelperSQL.RunProcedure("Person_Reward_Update", parameters, out rowsAffected);
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
        public bool Delete(int PerRewardID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewardID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerRewardID;

            DbHelperSQL.RunProcedure("Person_Reward_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string PerRewardIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Person_Reward ");
            strSql.Append(" where PerRewardID in (" + PerRewardIDlist + ")  ");
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
        public ZhongLi.Model.Person_Reward GetModel(int PerRewardID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewardID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerRewardID;

            ZhongLi.Model.Person_Reward model = new ZhongLi.Model.Person_Reward();
            DataSet ds = DbHelperSQL.RunProcedure("Person_Reward_GetModel", parameters, "ds");
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
        public ZhongLi.Model.Person_Reward DataRowToModel(DataRow row)
        {
            ZhongLi.Model.Person_Reward model = new ZhongLi.Model.Person_Reward();
            if (row != null)
            {
                if (row["PerRewardID"] != null && row["PerRewardID"].ToString() != "")
                {
                    model.PerRewardID = int.Parse(row["PerRewardID"].ToString());
                }
                if (row["PerID"] != null && row["PerID"].ToString() != "")
                {
                    model.PerID = int.Parse(row["PerID"].ToString());
                }
                if (row["Trade"] != null)
                {
                    model.Trade = row["Trade"].ToString();
                }
                if (row["CompanySize"] != null)
                {
                    model.CompanySize = row["CompanySize"].ToString();
                }
                if (row["CompanyNature"] != null)
                {
                    model.CompanyNature = row["CompanyNature"].ToString();
                }
                if (row["EngagePost"] != null)
                {
                    model.EngagePost = row["EngagePost"].ToString();
                }
                if (row["DemandPay"] != null)
                {
                    model.DemandPay = row["DemandPay"].ToString();
                }
                if (row["JobCity"] != null)
                {
                    model.JobCity = row["JobCity"].ToString();
                }
                if (row["OtherDemand"] != null)
                {
                    model.OtherDemand = row["OtherDemand"].ToString();
                }
                if (row["CompanyMatching"] != null)
                {
                    model.CompanyMatching = row["CompanyMatching"].ToString();
                }
                if (row["OtherDemandDes"] != null)
                {
                    model.OtherDemandDes = row["OtherDemandDes"].ToString();
                }
                if (row["RewardMoney"] != null && row["RewardMoney"].ToString() != "")
                {
                    model.RewardMoney = decimal.Parse(row["RewardMoney"].ToString());
                }
                if (row["RewardTime"] != null && row["RewardTime"].ToString() != "")
                {
                    model.RewardTime = DateTime.Parse(row["RewardTime"].ToString());
                }
                if (row["RewardState"] != null && row["RewardState"].ToString() != "")
                {
                    model.RewardState = int.Parse(row["RewardState"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
                }
                if (row["Education"] != null)
                {
                    model.Education = row["Education"].ToString();
                }
                if (row["WorkLife"] != null)
                {
                    model.WorkLife = row["WorkLife"].ToString();
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
            strSql.Append("select PerRewardID,PerID,Trade,CompanySize,CompanyNature,EngagePost,DemandPay,JobCity,OtherDemand,CompanyMatching,OtherDemandDes,RewardMoney,RewardTime,RewardState,IsDelete,Education,WorkLife ");
            strSql.Append(" FROM Person_Reward ");
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
            strSql.Append(" PerRewardID,PerID,Trade,CompanySize,CompanyNature,EngagePost,DemandPay,JobCity,OtherDemand,CompanyMatching,OtherDemandDes,RewardMoney,RewardTime,RewardState,IsDelete,Education,WorkLife ");
            strSql.Append(" FROM Person_Reward ");
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
			strSql.Append("select count(1) FROM Person_Reward ");
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
				strSql.Append("order by T.PerRewardID desc");
			}
			strSql.Append(")AS Row, T.*  from Person_Reward T ");
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
			parameters[0].Value = "Person_Reward";
			parameters[1].Value = "PerRewardID";
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
        /// 修改悬赏
        /// </summary>
        /// <param name="reward"></param>
        /// <returns></returns>
        public bool editPersonReward(ZhongLi.Model.Person_Reward reward)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person_Reward set Trade=@Trade,CompanySize=@CompanySize,CompanyNature=@CompanyNature,EngagePost=@EngagePost,");
            strSql.Append("DemandPay=@DemandPay,JobCity=@JobCity,OtherDemand=@OtherDemand,CompanyMatching=@CompanyMatching,RewardMoney=@RewardMoney,OtherDemandDes=@OtherDemandDes,Education=@Education,WorkLife=@WorkLife");
            strSql.Append(" where PerRewardID=@PerRewardID");
            SqlParameter[] para = { new SqlParameter("@Trade",reward.Trade),
                                    new SqlParameter("@CompanySize",reward.CompanySize),
                                    new SqlParameter("@CompanyNature",reward.CompanyNature),
                                  new SqlParameter("@EngagePost",reward.EngagePost),
                                  new SqlParameter("@DemandPay",reward.DemandPay),
                                  new SqlParameter("@JobCity",reward.JobCity),
                                  new SqlParameter("@OtherDemand",reward.OtherDemand),
                                  new SqlParameter("@CompanyMatching",reward.CompanyMatching),
                                  new SqlParameter("@RewardMoney",reward.RewardMoney),
                                  new SqlParameter("@OtherDemandDes",reward.OtherDemandDes),
                                  new SqlParameter("@PerRewardID",reward.PerRewardID),
                                  new SqlParameter("@Education",reward.Education),
                                  new SqlParameter("@WorkLife",reward.WorkLife)
                                  };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0 ;
        }
        /// <summary>
        /// 获取人才经纪人匹配的悬赏
        /// </summary>
        /// <param name="SerUserID">经纪人ID</param>
        /// <param name="PageIndex">当前分页</param>
        /// <returns></returns>
        public DataTable getSerUserReward(string SerUserID,int PageIndex)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.PerRewMatID desc");
			strSql.Append(")AS Row, T.*  from View_SerUserReword T ");
			strSql.AppendFormat(" WHERE SerUserID={0}",SerUserID );
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (PageIndex-1)*20+1, PageIndex*20);
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 人才经纪人悬赏匹配详情
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public DataTable getSerUserRewardDetail(int PerRewMatID)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("select * from View_SerUserRewardDetail where PerRewMatID={0}",PerRewMatID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 悬赏列表
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable getRewardList(int PageIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.RewardMoney desc");
            strSql.Append(")AS Row, T.*  from View_RewardList T ");
            strSql.AppendFormat(" WHERE RewardState=0");
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (PageIndex - 1) * 10 + 1, PageIndex * 10);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 得到悬赏详情
        /// </summary>
        /// <param name="PerRewardID"></param>
        /// <returns></returns>
        public DataTable getRewardDetail(string PerRewardID,string SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select *,(select COUNT(1) from Person_Reward_Matching where SerUserID={0} and PerRewID={1}) as IsMat from View_RewardList where PerRewardID={1}",SerUserID, PerRewardID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        
		#endregion  MethodEx
	}
}

