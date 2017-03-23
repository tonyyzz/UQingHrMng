using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using System.Collections.Generic;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:PresentApplication
	/// </summary>
	public partial class PresentApplication
	{
        public PresentApplication()
        { }
        #region  Method
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

            int result = DbHelperSQL.RunProcedure("PresentApplication_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.PresentApplication model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassTime", SqlDbType.DateTime),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@PayAdminID", SqlDbType.Int,4),
					new SqlParameter("@PayAdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@WxAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@AliAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@PreType", SqlDbType.Int,4),
					new SqlParameter("@WxAccountName", SqlDbType.NVarChar,50),
					new SqlParameter("@AliAccounttName", SqlDbType.NVarChar,50),
					new SqlParameter("@PreNum", SqlDbType.NVarChar,50),
					new SqlParameter("@BatchID", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.State;
            parameters[5].Value = model.AdminID;
            parameters[6].Value = model.AdminName;
            parameters[7].Value = model.PassTime;
            parameters[8].Value = model.UserType;
            parameters[9].Value = model.PayTime;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.PayAdminID;
            parameters[12].Value = model.PayAdminName;
            parameters[13].Value = model.WxAccount;
            parameters[14].Value = model.AliAccount;
            parameters[15].Value = model.PreType;
            parameters[16].Value = model.WxAccountName;
            parameters[17].Value = model.AliAccounttName;
            parameters[18].Value = model.PreNum;
            parameters[19].Value = model.BatchID;

            DbHelperSQL.RunProcedure("PresentApplication_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.PresentApplication model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassTime", SqlDbType.DateTime),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@PayAdminID", SqlDbType.Int,4),
					new SqlParameter("@PayAdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@WxAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@AliAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@PreType", SqlDbType.Int,4),
					new SqlParameter("@WxAccountName", SqlDbType.NVarChar,50),
					new SqlParameter("@AliAccounttName", SqlDbType.NVarChar,50),
					new SqlParameter("@PreNum", SqlDbType.NVarChar,50),
					new SqlParameter("@BatchID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.State;
            parameters[5].Value = model.AdminID;
            parameters[6].Value = model.AdminName;
            parameters[7].Value = model.PassTime;
            parameters[8].Value = model.UserType;
            parameters[9].Value = model.PayTime;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.PayAdminID;
            parameters[12].Value = model.PayAdminName;
            parameters[13].Value = model.WxAccount;
            parameters[14].Value = model.AliAccount;
            parameters[15].Value = model.PreType;
            parameters[16].Value = model.WxAccountName;
            parameters[17].Value = model.AliAccounttName;
            parameters[18].Value = model.PreNum;
            parameters[19].Value = model.BatchID;

            DbHelperSQL.RunProcedure("PresentApplication_Update", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("PresentApplication_Delete", parameters, out rowsAffected);
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
            strSql.Append("delete from PresentApplication ");
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
        public ZhongLi.Model.PresentApplication GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZhongLi.Model.PresentApplication model = new ZhongLi.Model.PresentApplication();
            DataSet ds = DbHelperSQL.RunProcedure("PresentApplication_GetModel", parameters, "ds");
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
        public ZhongLi.Model.PresentApplication DataRowToModel(DataRow row)
        {
            ZhongLi.Model.PresentApplication model = new ZhongLi.Model.PresentApplication();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["AdminID"] != null && row["AdminID"].ToString() != "")
                {
                    model.AdminID = int.Parse(row["AdminID"].ToString());
                }
                if (row["AdminName"] != null)
                {
                    model.AdminName = row["AdminName"].ToString();
                }
                if (row["PassTime"] != null && row["PassTime"].ToString() != "")
                {
                    model.PassTime = DateTime.Parse(row["PassTime"].ToString());
                }
                if (row["UserType"] != null && row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                if (row["PayTime"] != null && row["PayTime"].ToString() != "")
                {
                    model.PayTime = DateTime.Parse(row["PayTime"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["PayAdminID"] != null && row["PayAdminID"].ToString() != "")
                {
                    model.PayAdminID = int.Parse(row["PayAdminID"].ToString());
                }
                if (row["PayAdminName"] != null)
                {
                    model.PayAdminName = row["PayAdminName"].ToString();
                }
                if (row["WxAccount"] != null)
                {
                    model.WxAccount = row["WxAccount"].ToString();
                }
                if (row["AliAccount"] != null)
                {
                    model.AliAccount = row["AliAccount"].ToString();
                }
                if (row["PreType"] != null && row["PreType"].ToString() != "")
                {
                    model.PreType = int.Parse(row["PreType"].ToString());
                }
                if (row["WxAccountName"] != null)
                {
                    model.WxAccountName = row["WxAccountName"].ToString();
                }
                if (row["AliAccounttName"] != null)
                {
                    model.AliAccounttName = row["AliAccounttName"].ToString();
                }
                if (row["PreNum"] != null)
                {
                    model.PreNum = row["PreNum"].ToString();
                }
                if (row["BatchID"] != null && row["BatchID"].ToString() != "")
                {
                    model.BatchID = int.Parse(row["BatchID"].ToString());
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
            strSql.Append("select ID,UserID,RealName,Money,State,AdminID,AdminName,PassTime,UserType,PayTime,CreateTime,PayAdminID,PayAdminName,WxAccount,AliAccount,PreType,WxAccountName,AliAccounttName,PreNum,BatchID ");
            strSql.Append(" FROM PresentApplication ");
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
            strSql.Append(" ID,UserID,RealName,Money,State,AdminID,AdminName,PassTime,UserType,PayTime,CreateTime,PayAdminID,PayAdminName,WxAccount,AliAccount,PreType,WxAccountName,AliAccounttName,PreNum,BatchID ");
            strSql.Append(" FROM PresentApplication ");
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
            strSql.Append("select count(1) FROM PresentApplication ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from PresentApplication T ");
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
            parameters[0].Value = "PresentApplication";
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
        /// <summary>
        /// 提现申请审核通过
        /// </summary>
        /// <param name="AdminID"></param>
        /// <param name="AdminName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool authPass(int AdminID,string AdminName,int ID,int UserType,int UserID)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update PresentApplication set State=1,AdminID=" + AdminID + ",AdminName='" + AdminName + "' where ID=" + ID;
            list.Add(cmd1);
            if (UserType == 0)
            {
                CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                msgcmd.CommandText = "insert into Person_Message (PerID,MesType,SendTime,MesCon)values(" + UserID + ",0,getdate(),'您的提现申请审核通过啦，优青将会在3个工作日之内将体现金额支付到您的账户')";
                list.Add(msgcmd);
            }
            else
            {
                CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                msgcmd.CommandText = "insert into ServerUser_Message (SerUserID,MesType,SendTime,MesCon)values(" + UserID + ",0,getdate(),'您的提现申请审核通过啦，优青将会在3个工作日之内将体现金额支付到您的账户')";
                list.Add(msgcmd);
            }
           
            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }
        /// <summary>
        /// 不通过审核
        /// </summary>
        /// <param name="AdminID"></param>
        /// <param name="AdminName"></param>
        /// <param name="ID"></param>
        /// <param name="UserType"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool noauthPass(int AdminID, string AdminName, int ID, int UserType, int UserID)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update PresentApplication set State=4,AdminID=" + AdminID + ",AdminName='" + AdminName + "' where ID=" + ID;
            list.Add(cmd1);
            if (UserType == 0)
            {
                CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                msgcmd.CommandText = "insert into Person_Message (PerID,MesType,SendTime,MesCon)values(" + UserID + ",0,getdate(),'您的提现申请没有通过审核')";
                list.Add(msgcmd);
            }
            else
            {
                CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                msgcmd.CommandText = "insert into ServerUser_Message (SerUserID,MesType,SendTime,MesCon)values(" + UserID + ",0,getdate(),'您的提现申请没有通过审核')";
                list.Add(msgcmd);
            }
            return DbHelperSQL.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 支付失败  修改状态  添加余额 消息记录
        /// </summary>
        /// <param name="AdminID"></param>
        /// <param name="AdminName"></param>
        /// <param name="ID"></param>
        /// <param name="UserType"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool PayFail(int AdminID, string AdminName, int ID, int UserType, int UserID,decimal Money)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update PresentApplication set State=3,PayAdminID=" + AdminID + ",PayAdminName='" + AdminName + "' where ID=" + ID;
            list.Add(cmd1);
            if (UserType == 0)
            {
                CommandInfo blacmd = new CommandInfo();
                blacmd.CommandText = "update Person set Balance+=" + Money + " where PerID=" + UserID;
                list.Add(blacmd);
                CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                msgcmd.CommandText = "insert into Person_Message (PerID,MesType,SendTime,MesCon)values(" +UserID+ ",1,getdate(),'您的提现支付失败了，资金已退回到您的钱包，请检查您提现时填的资料是否正确')";
                list.Add(msgcmd);
            }
            else
            {
                CommandInfo blacmd = new CommandInfo();
                blacmd.CommandText = "update ServerUser set Balance+=" + Money + " where SerUserID=" + UserID;
                list.Add(blacmd);
                CommandInfo msgcmd = new CommandInfo();//添加消息提醒
                msgcmd.CommandText = "insert into ServerUser_Message (SerUserID,MesType,SendTime,MesCon)values(" + UserID + ",1,getdate(),'您的提现支付失败了，资金已退回到您的钱包，请检查您提现时填的资料是否正确')";
                list.Add(msgcmd);
            }
            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }
        /// <summary>
        /// 添加提现申请
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="RealName"></param>
        /// <param name="PreType"></param>
        /// <param name="Account"></param>
        /// <param name="Money"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public bool AddPresent(int UserID, string RealName, int PreType, string Account, decimal Money, int UserType, string AccountName)
        {
            StringBuilder strSql = new StringBuilder();
            //修改余额
            if (UserType == 0)
            {
                DbHelperSQL.ExecuteSql("update Person set Balance-="+Money+" where PerID="+UserID);
            }
            else
            {
                DbHelperSQL.ExecuteSql("update ServerUser set Balance-=" + Money + " where SerUserID=" + UserID);
            }
            Random r = new Random();
            int n = r.Next(0, 100);
            string PreNum = "yq" + DateTime.Now.ToString("yyyyMMddHHmmssms") + n.ToString().PadLeft(2, '0');
            strSql.Append("insert into PresentApplication(UserID,RealName,Money,State,UserType,CreateTime,");
            if (PreType == 0)
            {
                strSql.Append("AliAccount,AliAccounttName,PreType,PreNum) values(@UserID,@RealName,@Money,0,@UserType,GETDATE(),@Account,@AccountName,@PreType,@PreNum)");
            }
            else
            {
                strSql.Append("WxAccount,WxAccountName,PreType,PreNum) values(@UserID,@RealName,@Money,0,@UserType,GETDATE(),@Account,@AccountName,@PreType,@PreNum)");
            }
            SqlParameter[] para = { new SqlParameter("@UserID", UserID), new SqlParameter("@RealName", RealName), new SqlParameter("@Money", Money), new SqlParameter("@Account", Account), new SqlParameter("@PreType", PreType), new SqlParameter("@AccountName", AccountName), new SqlParameter("@UserType", UserType), new SqlParameter("@PreNum", PreNum) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 添加批次
        /// </summary>
        /// <param name="Batch_Num"></param>
        /// <param name="Batch_Fee"></param>
        /// <returns></returns>
        public int AddBatch(string Batch_No,int Batch_Num,decimal Batch_Fee,int AdminID)
        {
            StringBuilder strSql = new StringBuilder();
            
            strSql.Append("insert into PresentApplication_Batch(Batch_No,Pay_Date,Batch_Num,Batch_Fee,BatchState,PayAdminID,PayAdminName,CrateTime) values");
            strSql.Append("(@Batch_No,getdate(),@Batch_Num,@Batch_Fee,0,@PayAdminID,(select RealName from User_Managers where UserId =@PayAdminID),getdate());select @@IDENTITY");
            SqlParameter[] para = { new SqlParameter("@Batch_No", Batch_No), new SqlParameter("@Batch_Num", Batch_Num), new SqlParameter("@Batch_Fee", Batch_Fee), new SqlParameter("@PayAdminID", AdminID) };
            object obj = DbHelperSQL.GetSingle(strSql.ToString(),para);
            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 修改选中提现的批次
        /// </summary>
        /// <param name="IDs"></param>
        /// <param name="BatchID"></param>
        /// <returns></returns>
        public bool editPresentBatch(string IDs, int BatchID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PresentApplication set BatchID="+BatchID+" where ID in ("+IDs+")");
            return DbHelperSQL.ExecuteSql(strSql.ToString())>0;
        }
        /// <summary>
        /// 判断该批次是否已处理过了
        /// </summary>
        /// <returns></returns>
        public bool IsBatch(string BatchNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BatchID from PresentApplication_Batch where Batch_No=@Batch_No and BatchState=0");
            return DbHelperSQL.Query(strSql.ToString(), new SqlParameter("@Batch_No",BatchNo)).Tables[0].Rows.Count>0;
        }
        /// <summary>
        /// 通过流水号集合查询用户
        /// </summary>
        /// <param name="PreNums"></param>
        /// <returns></returns>
        public DataTable getUserByPreNum(string PreNums)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserID,UserType,Money from PresentApplication where PreNum in(" + PreNums + ")");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 执行提现批量付款后 回调处理事物
        /// </summary>
        /// <returns></returns>
        public bool exPreTran(List<CommandInfo> list)
        {
            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }

        /// <summary>
        /// 批次分页获取数据列表
        /// </summary>
        public DataSet GetBatchListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.BatchID desc");
            }
            strSql.Append(")AS Row, T.*  from PresentApplication_Batch T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetBatchRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PresentApplication_Batch ");
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
        /// 根据ID得到批次信息
        /// </summary>
        /// <param name="BatchID"></param>
        /// <returns></returns>
        public DataTable getBatchByID(int BatchID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from PresentApplication_Batch where BatchID="+BatchID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 判断选中的是否有支付失败的
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool checkPay(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PresentApplication where ID in("+ids+") and (state=3 or state=2)");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()))>0;
        }
		#endregion  MethodEx
	}
}

