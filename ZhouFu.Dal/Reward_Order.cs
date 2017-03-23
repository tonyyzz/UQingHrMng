using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using System.Collections.Generic;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Reward_Order
	/// </summary>
	public partial class Reward_Order
	{
		public Reward_Order()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OrderID", "Reward_Order"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrderID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

            int result = DbHelperSQL.RunProcedure("Reward_Order_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.Reward_Order model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderNum", SqlDbType.NVarChar,50),
					new SqlParameter("@PerRewardID", SqlDbType.Int,4),
					new SqlParameter("@PostID", SqlDbType.Int,4),
					new SqlParameter("@RewardMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderState", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@SerRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanySize", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyNature", SqlDbType.NVarChar,50),
					new SqlParameter("@EngagePost", SqlDbType.NVarChar,50),
					new SqlParameter("@DemandPay", SqlDbType.NVarChar,50),
					new SqlParameter("@JobCity", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemand", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyMatching", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemandDes", SqlDbType.NVarChar,500),
					new SqlParameter("@RewardTime", SqlDbType.DateTime),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Post_Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@Scale", SqlDbType.NVarChar,50),
					new SqlParameter("@Nature", SqlDbType.NVarChar,50),
					new SqlParameter("@PostName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostDuty", SqlDbType.NVarChar,500),
					new SqlParameter("@Salary", SqlDbType.NVarChar,500),
					new SqlParameter("@DevelopProspect", SqlDbType.NVarChar,500),
					new SqlParameter("@DirectLeader", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkAdress", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@WelfareTag", SqlDbType.NVarChar,100),
					new SqlParameter("@Post_CompanyMatching", SqlDbType.NVarChar,500),
					new SqlParameter("@OtherPoint", SqlDbType.NVarChar,500),
					new SqlParameter("@AutoImg", SqlDbType.NVarChar,200),
					new SqlParameter("@AutoTime", SqlDbType.DateTime),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkLife", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.OrderNum;
            parameters[2].Value = model.PerRewardID;
            parameters[3].Value = model.PostID;
            parameters[4].Value = model.RewardMoney;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.OrderState;
            parameters[7].Value = model.PerID;
            parameters[8].Value = model.RealName;
            parameters[9].Value = model.SerUserID;
            parameters[10].Value = model.SerRealName;
            parameters[11].Value = model.IsDelete;
            parameters[12].Value = model.Trade;
            parameters[13].Value = model.CompanySize;
            parameters[14].Value = model.CompanyNature;
            parameters[15].Value = model.EngagePost;
            parameters[16].Value = model.DemandPay;
            parameters[17].Value = model.JobCity;
            parameters[18].Value = model.OtherDemand;
            parameters[19].Value = model.CompanyMatching;
            parameters[20].Value = model.OtherDemandDes;
            parameters[21].Value = model.RewardTime;
            parameters[22].Value = model.Company;
            parameters[23].Value = model.Post_Trade;
            parameters[24].Value = model.Scale;
            parameters[25].Value = model.Nature;
            parameters[26].Value = model.PostName;
            parameters[27].Value = model.PostDuty;
            parameters[28].Value = model.Salary;
            parameters[29].Value = model.DevelopProspect;
            parameters[30].Value = model.DirectLeader;
            parameters[31].Value = model.WorkAdress;
            parameters[32].Value = model.Address;
            parameters[33].Value = model.WelfareTag;
            parameters[34].Value = model.Post_CompanyMatching;
            parameters[35].Value = model.OtherPoint;
            parameters[36].Value = model.AutoImg;
            parameters[37].Value = model.AutoTime;
            parameters[38].Value = model.Education;
            parameters[39].Value = model.WorkLife;

            DbHelperSQL.RunProcedure("Reward_Order_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Reward_Order model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OrderNum", SqlDbType.NVarChar,50),
					new SqlParameter("@PerRewardID", SqlDbType.Int,4),
					new SqlParameter("@PostID", SqlDbType.Int,4),
					new SqlParameter("@RewardMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderState", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@SerRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanySize", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyNature", SqlDbType.NVarChar,50),
					new SqlParameter("@EngagePost", SqlDbType.NVarChar,50),
					new SqlParameter("@DemandPay", SqlDbType.NVarChar,50),
					new SqlParameter("@JobCity", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemand", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyMatching", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherDemandDes", SqlDbType.NVarChar,500),
					new SqlParameter("@RewardTime", SqlDbType.DateTime),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Post_Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@Scale", SqlDbType.NVarChar,50),
					new SqlParameter("@Nature", SqlDbType.NVarChar,50),
					new SqlParameter("@PostName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostDuty", SqlDbType.NVarChar,500),
					new SqlParameter("@Salary", SqlDbType.NVarChar,500),
					new SqlParameter("@DevelopProspect", SqlDbType.NVarChar,500),
					new SqlParameter("@DirectLeader", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkAdress", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@WelfareTag", SqlDbType.NVarChar,100),
					new SqlParameter("@Post_CompanyMatching", SqlDbType.NVarChar,500),
					new SqlParameter("@OtherPoint", SqlDbType.NVarChar,500),
					new SqlParameter("@AutoImg", SqlDbType.NVarChar,200),
					new SqlParameter("@AutoTime", SqlDbType.DateTime),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkLife", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.OrderNum;
            parameters[2].Value = model.PerRewardID;
            parameters[3].Value = model.PostID;
            parameters[4].Value = model.RewardMoney;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.OrderState;
            parameters[7].Value = model.PerID;
            parameters[8].Value = model.RealName;
            parameters[9].Value = model.SerUserID;
            parameters[10].Value = model.SerRealName;
            parameters[11].Value = model.IsDelete;
            parameters[12].Value = model.Trade;
            parameters[13].Value = model.CompanySize;
            parameters[14].Value = model.CompanyNature;
            parameters[15].Value = model.EngagePost;
            parameters[16].Value = model.DemandPay;
            parameters[17].Value = model.JobCity;
            parameters[18].Value = model.OtherDemand;
            parameters[19].Value = model.CompanyMatching;
            parameters[20].Value = model.OtherDemandDes;
            parameters[21].Value = model.RewardTime;
            parameters[22].Value = model.Company;
            parameters[23].Value = model.Post_Trade;
            parameters[24].Value = model.Scale;
            parameters[25].Value = model.Nature;
            parameters[26].Value = model.PostName;
            parameters[27].Value = model.PostDuty;
            parameters[28].Value = model.Salary;
            parameters[29].Value = model.DevelopProspect;
            parameters[30].Value = model.DirectLeader;
            parameters[31].Value = model.WorkAdress;
            parameters[32].Value = model.Address;
            parameters[33].Value = model.WelfareTag;
            parameters[34].Value = model.Post_CompanyMatching;
            parameters[35].Value = model.OtherPoint;
            parameters[36].Value = model.AutoImg;
            parameters[37].Value = model.AutoTime;
            parameters[38].Value = model.Education;
            parameters[39].Value = model.WorkLife;

            DbHelperSQL.RunProcedure("Reward_Order_Update", parameters, out rowsAffected);
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
        public bool Delete(int OrderID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

            DbHelperSQL.RunProcedure("Reward_Order_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Reward_Order ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ")  ");
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
        public ZhongLi.Model.Reward_Order GetModel(int OrderID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

            ZhongLi.Model.Reward_Order model = new ZhongLi.Model.Reward_Order();
            DataSet ds = DbHelperSQL.RunProcedure("Reward_Order_GetModel", parameters, "ds");
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
        public ZhongLi.Model.Reward_Order DataRowToModel(DataRow row)
        {
            ZhongLi.Model.Reward_Order model = new ZhongLi.Model.Reward_Order();
            if (row != null)
            {
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["OrderNum"] != null)
                {
                    model.OrderNum = row["OrderNum"].ToString();
                }
                if (row["PerRewardID"] != null && row["PerRewardID"].ToString() != "")
                {
                    model.PerRewardID = int.Parse(row["PerRewardID"].ToString());
                }
                if (row["PostID"] != null && row["PostID"].ToString() != "")
                {
                    model.PostID = int.Parse(row["PostID"].ToString());
                }
                if (row["RewardMoney"] != null && row["RewardMoney"].ToString() != "")
                {
                    model.RewardMoney = decimal.Parse(row["RewardMoney"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["OrderState"] != null && row["OrderState"].ToString() != "")
                {
                    model.OrderState = int.Parse(row["OrderState"].ToString());
                }
                if (row["PerID"] != null && row["PerID"].ToString() != "")
                {
                    model.PerID = int.Parse(row["PerID"].ToString());
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["SerUserID"] != null && row["SerUserID"].ToString() != "")
                {
                    model.SerUserID = int.Parse(row["SerUserID"].ToString());
                }
                if (row["SerRealName"] != null)
                {
                    model.SerRealName = row["SerRealName"].ToString();
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
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
                if (row["RewardTime"] != null && row["RewardTime"].ToString() != "")
                {
                    model.RewardTime = DateTime.Parse(row["RewardTime"].ToString());
                }
                if (row["Company"] != null)
                {
                    model.Company = row["Company"].ToString();
                }
                if (row["Post_Trade"] != null)
                {
                    model.Post_Trade = row["Post_Trade"].ToString();
                }
                if (row["Scale"] != null)
                {
                    model.Scale = row["Scale"].ToString();
                }
                if (row["Nature"] != null)
                {
                    model.Nature = row["Nature"].ToString();
                }
                if (row["PostName"] != null)
                {
                    model.PostName = row["PostName"].ToString();
                }
                if (row["PostDuty"] != null)
                {
                    model.PostDuty = row["PostDuty"].ToString();
                }
                if (row["Salary"] != null)
                {
                    model.Salary = row["Salary"].ToString();
                }
                if (row["DevelopProspect"] != null)
                {
                    model.DevelopProspect = row["DevelopProspect"].ToString();
                }
                if (row["DirectLeader"] != null)
                {
                    model.DirectLeader = row["DirectLeader"].ToString();
                }
                if (row["WorkAdress"] != null)
                {
                    model.WorkAdress = row["WorkAdress"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["WelfareTag"] != null)
                {
                    model.WelfareTag = row["WelfareTag"].ToString();
                }
                if (row["Post_CompanyMatching"] != null)
                {
                    model.Post_CompanyMatching = row["Post_CompanyMatching"].ToString();
                }
                if (row["OtherPoint"] != null)
                {
                    model.OtherPoint = row["OtherPoint"].ToString();
                }
                if (row["AutoImg"] != null)
                {
                    model.AutoImg = row["AutoImg"].ToString();
                }
                if (row["AutoTime"] != null && row["AutoTime"].ToString() != "")
                {
                    model.AutoTime = DateTime.Parse(row["AutoTime"].ToString());
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
            strSql.Append("select OrderID,OrderNum,PerRewardID,PostID,RewardMoney,CreateTime,OrderState,PerID,RealName,SerUserID,SerRealName,IsDelete,Trade,CompanySize,CompanyNature,EngagePost,DemandPay,JobCity,OtherDemand,CompanyMatching,OtherDemandDes,RewardTime,Company,Post_Trade,Scale,Nature,PostName,PostDuty,Salary,DevelopProspect,DirectLeader,WorkAdress,Address,WelfareTag,Post_CompanyMatching,OtherPoint,AutoImg,AutoTime,Education,WorkLife ");
            strSql.Append(" FROM Reward_Order ");
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
            strSql.Append(" OrderID,OrderNum,PerRewardID,PostID,RewardMoney,CreateTime,OrderState,PerID,RealName,SerUserID,SerRealName,IsDelete,Trade,CompanySize,CompanyNature,EngagePost,DemandPay,JobCity,OtherDemand,CompanyMatching,OtherDemandDes,RewardTime,Company,Post_Trade,Scale,Nature,PostName,PostDuty,Salary,DevelopProspect,DirectLeader,WorkAdress,Address,WelfareTag,Post_CompanyMatching,OtherPoint,AutoImg,AutoTime,Education,WorkLife ");
            strSql.Append(" FROM Reward_Order ");
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
            strSql.Append("select count(1) FROM Reward_Order ");
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
				strSql.Append("order by T.OrderID desc");
			}
            strSql.Append(")AS Row, T.OrderNum,T.RealName,T.OrderID,T.RewardMoney,T.DemandPay,EngagePost,T.CompanyNature,T.OtherDemand,T.OrderState,T.Sex,T.Photo,T.SerRealName,T.PostName,T.CreateTime,T.JobCity,T.Trade,T.OneDes,T.Education,T.WorkLife  from View_Person_Order T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 得到人才悬赏订单详情
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable GetPersonOrderDetail(int OrderID,int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select count(1) from Person_Reward_Matching where OrderID=View_Person_Order.OrderID and SerUserID="+SerUserID+") as IsMat from View_Person_Order where OrderID=" + OrderID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
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
			parameters[0].Value = "Reward_Order";
			parameters[1].Value = "OrderID";
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
        /// 人才订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable PerOrder(string PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select OrderNum,EngagePost,DemandPay,RewardMoney,OrderState,JobCity,OrderID,PostName,Salary,WorkAdress,(select count(1) from Person_Reward_Matching where OrderID=Reward_Order.OrderID and State =0) as acount,(select count(1) from Person_Reward_Matching where OrderID=Reward_Order.OrderID and State in (1,4)) as bcount,(select count(1) from Person_Reward_Matching where OrderID=Reward_Order.OrderID and State=6) as ccount from Reward_Order where PerID={0} order by CreateTime Desc", PerID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 人才订单 悬赏金额大于0的
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable PerOrderMoney(string PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select OrderNum,EngagePost,DemandPay,RewardMoney,OrderState,JobCity,OrderID,PostName,Salary,WorkAdress,(select count(1) from Person_Reward_Matching where OrderID=Reward_Order.OrderID and State =0) as acount,(select count(1) from Person_Reward_Matching where OrderID=Reward_Order.OrderID and State in (1,4)) as bcount,(select count(1) from Person_Reward_Matching where OrderID=Reward_Order.OrderID and State=6) as ccount from Reward_Order where PerID={0} and RewardMoney>0 order by CreateTime Desc", PerID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 人才经纪人订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable SerUserOrder(string SerUserID,int PageIndex,string state)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.CreateTime desc");
            strSql.Append(")AS Row, OrderNum,EngagePost,DemandPay,RewardMoney,OrderState,JobCity,OrderID,State,PerRewMatID,Trade,CompanySize,CompanyNature,PerRealName,Photo  from View_SerUserOrderDetail T ");
            if (state == "All")
            {
                strSql.Append(" WHERE SerUserID= " + SerUserID );
            }
            else
            {
                strSql.Append(" WHERE SerUserID= " + SerUserID + " and State in(" + state + ")");
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (PageIndex-1)*10+1, PageIndex*10);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 人才经纪人订单详情
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public DataTable SerUserOrderDetail(int PerRewMatID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_SerUserOrderDetail where PerRewMatID =" + PerRewMatID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 上传入职照片 进入完成待审核状态
        /// </summary>
        /// <param name="AutoImg"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setOrderAutoImg(string AutoImg,int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Reward_Order set AutoImg=@AutoImg,OrderState=2 where OrderID=@OrderID");
            SqlParameter[] para = { new SqlParameter("@AutoImg",AutoImg),new SqlParameter("@OrderID",OrderID) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="OrderState">4.求职者确认入职失败，5.人才经纪人确认入职失败6.人才经纪人确认入职</param>
        /// <returns></returns>
        public bool editOrderState(int OrderID,int OrderState)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Reward_Order set OrderState=@OrderState where OrderID=@OrderID");
            SqlParameter[] para = { new SqlParameter("@OrderState", OrderState), new SqlParameter("@OrderID",OrderID) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 得到订单支付的简略信息
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getOrderPayInfo(int PerID,int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderNum,EngagePost,PostName,RewardMoney,(select Balance from Person where PerID=@PerID) as Balance from Reward_Order where OrderID=@OrderID");
            SqlParameter[] para = { new SqlParameter("@PerID",PerID),new SqlParameter("@OrderID",OrderID)};
            return DbHelperSQL.Query(strSql.ToString(),para).Tables[0];
        }
        /// <summary>
        /// 得到入职确认图片和订单状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getOrderImgAuth(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoImg,OrderState from Reward_Order where OrderID=@OrderID");
            return DbHelperSQL.Query(strSql.ToString(),new SqlParameter("@OrderID",OrderID)).Tables[0];
        }
        /// <summary>
        /// 通过订单得到人才 ID和姓名
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getPerByOrderID(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PerID,RealName,SerUserID,RewardMoney from Reward_Order where OrderID=@OrderID");
            return DbHelperSQL.Query(strSql.ToString(), new SqlParameter("@OrderID", OrderID)).Tables[0];
        }
        /// <summary>
        /// 得到入职资料图片
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string getAutoImg(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoImg from Reward_Order where OrderID=@OrderID");
            return DbHelperSQL.GetSingle(strSql.ToString(), new SqlParameter("@OrderID", OrderID))+"";
        }
        /// <summary>
        /// 管理员审核完成订单 修改订单状态 修改悬赏状态  支付人才经纪人金额
        /// </summary>
        /// <param name="OrderID">订单ID</param>
        /// <param name="PerID">人才ID</param>
        /// <param name="SerUserID">人才经纪人ID</param>
        /// <param name="Commission">提成百分比</param>
        /// <returns></returns>
        public bool PassAuth(int OrderID, int PerID, int SerUserID, decimal RewardMoney, int Commission)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Reward_Order set OrderState=3,AutoTime=getdate() where OrderID=@OrderID";
            SqlParameter[] para1 = { new SqlParameter("@OrderID",OrderID)};
            cmd1.Parameters = para1;
            list.Add(cmd1);
            //CommandInfo cmd2 = new CommandInfo();
            //cmd2.CommandText = "update Person_Reward set RewardState=3 where PerRewardID =(select PerRewardID from Reward_Order where OrderID=@OrderID) ";
            //cmd2.Parameters = para1;
            //list.Add(cmd2);
            CommandInfo cmd5 = new CommandInfo();
            cmd5.CommandText = "update Person_Reward_Matching set State=11 where OrderID=@OrderID and SerUserID="+SerUserID;
            cmd5.Parameters = para1;
            list.Add(cmd5);
            
            if (RewardMoney != 0)
            {
                decimal comm = (decimal)Commission / 100;
                decimal payMoney = RewardMoney - RewardMoney * comm;
                CommandInfo cmd3 = new CommandInfo();
                cmd3.CommandText = "update ServerUser set Balance+=@payMoney where SerUserID=@SerUserID";
                SqlParameter[] para3 = { new SqlParameter("@SerUserID", SerUserID), new SqlParameter("@payMoney", payMoney) };
                cmd3.Parameters = para3;
                list.Add(cmd3);
                CommandInfo cmd4 = new CommandInfo();
                cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(@UserID,@RecordType,@Money,@RecordTime,1,'')";
                SqlParameter[] para4 = { new SqlParameter("@UserID", SerUserID), new SqlParameter("@RecordType", "订单入账"), new SqlParameter("@Money", payMoney), new SqlParameter("@RecordTime", DateTime.Now), new SqlParameter("@UserType",1) };
                cmd4.Parameters = para4;
                list.Add(cmd4);
            }

            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }
        /// <summary>
        /// 带审核订单数量
        /// </summary>
        /// <returns></returns>
        public int getAuthOrderCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Reward_Order where OrderState=2");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 人才经纪人确认入职失败
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PerID"></param>
        /// <param name="RewardMoney"></param>
        /// <returns></returns>
        public bool SerUserSetOrderFail(int OrderID,int PerID,decimal RewardMoney)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Reward_Order set OrderState=5 where OrderID=@OrderID";
            SqlParameter[] para1 = { new SqlParameter("@OrderID", OrderID) };
            cmd1.Parameters = para1;
            list.Add(cmd1);
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Person_Reward set RewardState=2 where PerRewardID =(select PerRewardID from Reward_Order where OrderID=@OrderID) ";
            cmd2.Parameters = para1;
            list.Add(cmd2);
            CommandInfo cmd3 = new CommandInfo();
            cmd3.CommandText = "update Person set Balance+=@RewardMoney where PerID=@PerID";
            SqlParameter[] para3 = { new SqlParameter("@PerID", PerID), new SqlParameter("@RewardMoney", RewardMoney) };
            CommandInfo cmd4 = new CommandInfo();
            cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(@UserID,@RecordType,@Money,@RecordTime,0,'')";
            SqlParameter[] para4 = { new SqlParameter("@UserID", PerID), new SqlParameter("@RecordType", "订单失败"), new SqlParameter("@Money", RewardMoney), new SqlParameter("@RecordTime", DateTime.Now) };
            cmd4.Parameters = para4;
            list.Add(cmd4);
            return DbHelperSQL.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 判断订单支付时订单是否已支付
        /// </summary>
        public bool isOrderState(string OrderNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Reward_Order where OrderState=0 and OrderNum=@OrderNum");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), new SqlParameter("@OrderNum", OrderNum)))>0;
        }
        /// <summary>
        /// 订单支付成功 1修改订单状态 2添加交易记录
        /// </summary>
        /// <param name="OrderNum"></param>
        public bool modOrderStateByOrderNum(string OrderNum,string PayType)
        {
            List<CommandInfo> list = new List<CommandInfo>();
           
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Reward_Order set OrderState=1 where OrderNum=@OrderNum";
            SqlParameter[] para2 = { new SqlParameter("@OrderNum", OrderNum) };
            cmd2.Parameters = para2;
            list.Add(cmd2);
            CommandInfo cmd4 = new CommandInfo();
            cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values((select PerID from Reward_Order where OrderNum =@OrderNum),@RecordType,(select RewardMoney from Reward_Order where OrderNum =@OrderNum),@RecordTime,0,'')";
            SqlParameter[] para4 = { new SqlParameter("@RecordType", "订单支付(" + PayType + ")"), new SqlParameter("@OrderNum", OrderNum), new SqlParameter("@RecordTime", DateTime.Now) };
            cmd4.Parameters = para4;
            list.Add(cmd4);
            return DbHelperSQL.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 指定职位 悬赏订单支付回调 修改订单状态 添加确认人才经纪人待确认信息，给人才经纪人推送消息
        /// </summary>
        /// <returns></returns>
        public bool modOrderStateByNumPost(string OrderNum, string PayType)
        {
            List<CommandInfo> list = new List<CommandInfo>();

            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Reward_Order set OrderState=11 where OrderNum=@OrderNum";
            SqlParameter[] para2 = { new SqlParameter("@OrderNum", OrderNum) };
            cmd2.Parameters = para2;
            list.Add(cmd2);
            CommandInfo cmd3 = new CommandInfo();//添加确认人才经纪人待确认信息
            cmd3.CommandText = "insert into Person_Reward_Matching (OrderID,PerID,PerRewID,SerUserID,SerPostID,MatchingTime,State,IsDelete) select OrderID,PerID,PerRewardID,SerUserID,PostID,GETDATE(),3,0 from Reward_Order where OrderNum=@OrderNum";
            cmd3.Parameters = para2;
            list.Add(cmd3);
            CommandInfo cmd4 = new CommandInfo();//添加交易记录
            cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values((select PerID from Reward_Order where OrderNum =@OrderNum),@RecordType,(select RewardMoney from Reward_Order where OrderNum =@OrderNum),@RecordTime,0,'')";
            SqlParameter[] para4 = { new SqlParameter("@RecordType", "订单支付(" + PayType + ")"), new SqlParameter("@OrderNum", OrderNum), new SqlParameter("@RecordTime", DateTime.Now) };
            cmd4.Parameters = para4;
            list.Add(cmd4);
            return DbHelperSQL.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 发送悬赏订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="PerRewardID"></param>
        /// <returns></returns>
        public string AddOrder(int PerID,int PerRewardID)
        {
            Random r = new Random();
            int n = r.Next(0, 100);
            string OrderNum = "d" + DateTime.Now.ToString("yyyyMMddHHmmssms") + n.ToString().PadLeft(2, '0');
            SqlParameter para=new SqlParameter("@PerRewardID",PerRewardID);
            DbHelperSQL.ExecuteSql("update Person_Reward set RewardState=1 where PerRewardID=@PerRewardID",para);
            int Money = Convert.ToInt32(DbHelperSQL.GetSingle("select RewardMoney from Person_Reward where PerRewardID=@PerRewardID", para));
            int State = 0;
            if (Money <= 0)
            {
                State = 1;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Reward_Order(OrderNum,PerRewardID,RewardMoney,CreateTime,OrderState,PerID,RealName,Trade,CompanySize,CompanyNature,EngagePost,");
            strSql.Append(" DemandPay,JobCity,OtherDemand,CompanyMatching,OtherDemandDes,Education,WorkLife,RewardTime) select '" + OrderNum + "' as OrderNum,PerRewardID,RewardMoney,GETDATE()," + State + ",pr.PerID,p.RealName,Trade,CompanySize,");
            strSql.Append(" CompanyNature,EngagePost,DemandPay,JobCity,OtherDemand,CompanyMatching,OtherDemandDes,pr.Education,pr.WorkLife,RewardTime from Person_Reward as pr");
            strSql.Append(" left join Person as p on p.PerID=pr.PerID");
            strSql.AppendFormat(" where PerRewardID={0};select @@IDENTITY",PerRewardID);
            int OrderID = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
            if (OrderID > 0)
            {
                return "{\"state\":0,\"OrderID\":"+OrderID+"}";
            }
            else
            {
                return "{\"state\":1}";
            }
        }
        /// <summary>
        /// 判断订单是否快要到期
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Day"></param>
        /// <returns></returns>
        public string IsOrderOver(int PerID, int Day)
        {
            StringBuilder strSql = new StringBuilder();
            int muni = (Day - 1) * 24 * 60;
            strSql.AppendFormat("select OrderID from Reward_Order where PerID={0} and DATEDIFF(minute,'2016-09-09 16:58:15.000',GETDATE())>={1} and OrderState=1", PerID, muni);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return "{\"state\":0,\"OrderID\":" + dt.Rows[0]["OrderID"] + "}";
            }
            else
            {
                return "{\"state\":1}";
            }
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool CanceOrder(int OrderID,int PerID)
        {
            SqlParameter para = new SqlParameter("@OrderID",OrderID);
            DataTable dt = DbHelperSQL.Query("select OrderState,RewardMoney from Reward_Order where OrderID=@OrderID", para).Tables[0];
            int OrderState = Convert.ToInt32(dt.Rows[0]["OrderState"]);
            decimal RewardMoney = Convert.ToDecimal(dt.Rows[0]["RewardMoney"]);
            if (OrderState == 1 || OrderState == 9 || OrderState == 11 || OrderState == 2 || OrderState == 7 || OrderState == 8)//如果是已支付或者时已支付
            {
                List<CommandInfo> list = new List<CommandInfo>();
                CommandInfo cmd2 = new CommandInfo();
                cmd2.CommandText = "update Reward_Order set OrderState=10 where OrderID=@OrderID";
                SqlParameter[] para2 = { new SqlParameter("@OrderID", OrderID) };
                cmd2.Parameters = para2;
                list.Add(cmd2);
                CommandInfo cmd3 = new CommandInfo();
                cmd3.CommandText = "update Person_Reward_Matching  set State=10 where OrderID=@OrderID ";
                cmd3.Parameters = para2;
                list.Add(cmd3);
                if (RewardMoney != 0)
                {
                    CommandInfo cmd1 = new CommandInfo();
                    cmd1.CommandText = "update Person set Balance=Balance+(select RewardMoney from Reward_Order where OrderID=@OrderID) where PerID=@PerID";
                    SqlParameter[] para1 = { new SqlParameter("@PerID", PerID), new SqlParameter("@OrderID", OrderID) };
                    cmd1.Parameters = para1;
                    list.Add(cmd1);
                    CommandInfo cmd4 = new CommandInfo();//添加交易记录
                    cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values((select PerID from Reward_Order where OrderID =@OrderID),@RecordType,(select RewardMoney from Reward_Order where OrderID =@OrderID),@RecordTime,0,'')";
                    SqlParameter[] para4 = { new SqlParameter("@RecordType", "取消订单"), new SqlParameter("@OrderID", OrderID), new SqlParameter("@RecordTime", DateTime.Now) };
                    cmd4.Parameters = para4;
                    list.Add(cmd4);
                }
                DbHelperSQL.ExecuteSqlTran(list);
                return true;
            }
            else
            {
                bool issuc = DbHelperSQL.ExecuteSql("update Reward_Order set OrderState=10 where OrderID=@OrderID", para) > 0;
                if (issuc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 启用订单  必须是取消的订单才能启用
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool UsingOrder(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Reward_Order set OrderState=0 where OrderID=@OrderID and OrderState=10");
            return DbHelperSQL.ExecuteSql(strSql.ToString(),new SqlParameter("@OrderID",OrderID))>0;
        }
        /// <summary>
        /// 修改订单到期时间和延期时间
        /// </summary>
        /// <param name="OrderCanceDay"></param>
        /// <param name="OrderDalayDay"></param>
        public void SetOrderTime(int OrderCanceDay,int OrderDalayDay)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update OrderTime set OrderCanceDay={0},OrderDelayDay={1}",OrderCanceDay,OrderDalayDay);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 延期订单
        /// </summary>
        /// <param name="OrderID"></param>
        public bool OrderDelay(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Reward_Order set CreateTime=getdate(),OrderState=1 where OrderID=@OrderID");
            return DbHelperSQL.ExecuteSql(strSql.ToString(),new SqlParameter("@OrderID",OrderID))>0;
        }
        /// <summary>
        /// 查询订单状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int getOrderState(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderState from Reward_Order where OrderID=" + OrderID);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        public DataTable getOrderInfo(string files,string OrderNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + files + " from Reward_Order where OrderNum='"+OrderNum+"'");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 得到过期时间天数
        /// </summary>
        /// <returns></returns>
        public int getOrderCanceDay(){
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderCanceDay from OrderTime");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 得到需要修改的已过期的订单
        /// </summary>
        /// <param name="OrderCanceDay"></param>
        /// <returns></returns>
        public DataTable getOrderOverTime(int OrderCanceDay)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PerID from Reward_Order Where DATEDIFF(minute,CreateTime,GETDATE())>=" + OrderCanceDay + "*24*60 and OrderState=1");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 修改过期订单的状态
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool setOrderOverTime(DataTable dt, int OrderCanceDay)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "Update Reward_Order Set OrderState=9 Where DATEDIFF(minute,CreateTime,GETDATE())>=" + OrderCanceDay + "*24*60  and OrderState=1";
            list.Add(cmd1);
            foreach (DataRow dr in dt.Rows)
            {
                CommandInfo cmd = new CommandInfo();
                cmd.CommandText = "insert into Person_Message (PerID,MesType,MesCon,SendTime)values("+dr["PerID"]+",0,'您的悬赏订单过期啦,快去延期吧',getdate())";
                list.Add(cmd);
            }
            return DbHelperSQL.ExecuteSqlTran(list) > 0;
        }

        /// <summary>
        /// 得到已经过期的订单
        /// </summary>
        /// <returns></returns>
        public DataTable getOrderOverTime()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PerID from Reward_Order Where OrderState=9");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public void setOrdernum()
        {
            DataTable dt = DbHelperSQL.Query("select OrderID,CreateTime from Reward_Order").Tables[0];
            foreach(DataRow dr in dt.Rows){
                DateTime time = (DateTime)dr["CreateTime"];
                string times = time.ToString("yyyyMMddHHmmssms");
                Random r = new Random();
                int n = r.Next(0, 100);
                string OrderNum = "d" + times + n.ToString().PadLeft(2, '0');
                string sql = "update Reward_Order set OrderNum='"+OrderNum+"' where OrderID="+dr["OrderID"];
                DbHelperSQL.ExecuteSql(sql);
            }
        }
		#endregion  MethodEx
	}
}

