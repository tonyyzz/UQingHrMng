using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using System.Collections.Generic;//Please add references
namespace ZhongLi.DAL
{
    /// <summary>
    /// 数据访问类:Person_Reward_Matching
    /// </summary>
    public partial class Person_Reward_Matching
    {
        public Person_Reward_Matching()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PerRewMatID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewMatID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerRewMatID;

            int result = DbHelperSQL.RunProcedure("Person_Reward_Matching_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.Person_Reward_Matching model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewMatID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@PerRewID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@SerPostID", SqlDbType.Int,4),
					new SqlParameter("@MatchingTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@RefTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.PerID;
            parameters[3].Value = model.PerRewID;
            parameters[4].Value = model.SerUserID;
            parameters[5].Value = model.SerPostID;
            parameters[6].Value = model.MatchingTime;
            parameters[7].Value = model.State;
            parameters[8].Value = model.RefTime;
            parameters[9].Value = model.IsDelete;

            DbHelperSQL.RunProcedure("Person_Reward_Matching_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person_Reward_Matching model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewMatID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@PerRewID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@SerPostID", SqlDbType.Int,4),
					new SqlParameter("@MatchingTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@RefTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.PerRewMatID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.PerID;
            parameters[3].Value = model.PerRewID;
            parameters[4].Value = model.SerUserID;
            parameters[5].Value = model.SerPostID;
            parameters[6].Value = model.MatchingTime;
            parameters[7].Value = model.State;
            parameters[8].Value = model.RefTime;
            parameters[9].Value = model.IsDelete;

            DbHelperSQL.RunProcedure("Person_Reward_Matching_Update", parameters, out rowsAffected);
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
        public bool Delete(int PerRewMatID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewMatID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerRewMatID;

            DbHelperSQL.RunProcedure("Person_Reward_Matching_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string PerRewMatIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Person_Reward_Matching ");
            strSql.Append(" where PerRewMatID in (" + PerRewMatIDlist + ")  ");
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
        public ZhongLi.Model.Person_Reward_Matching GetModel(int PerRewMatID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PerRewMatID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerRewMatID;

            ZhongLi.Model.Person_Reward_Matching model = new ZhongLi.Model.Person_Reward_Matching();
            DataSet ds = DbHelperSQL.RunProcedure("Person_Reward_Matching_GetModel", parameters, "ds");
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
        public ZhongLi.Model.Person_Reward_Matching DataRowToModel(DataRow row)
        {
            ZhongLi.Model.Person_Reward_Matching model = new ZhongLi.Model.Person_Reward_Matching();
            if (row != null)
            {
                if (row["PerRewMatID"] != null && row["PerRewMatID"].ToString() != "")
                {
                    model.PerRewMatID = int.Parse(row["PerRewMatID"].ToString());
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["PerID"] != null && row["PerID"].ToString() != "")
                {
                    model.PerID = int.Parse(row["PerID"].ToString());
                }
                if (row["PerRewID"] != null && row["PerRewID"].ToString() != "")
                {
                    model.PerRewID = int.Parse(row["PerRewID"].ToString());
                }
                if (row["SerUserID"] != null && row["SerUserID"].ToString() != "")
                {
                    model.SerUserID = int.Parse(row["SerUserID"].ToString());
                }
                if (row["SerPostID"] != null && row["SerPostID"].ToString() != "")
                {
                    model.SerPostID = int.Parse(row["SerPostID"].ToString());
                }
                if (row["MatchingTime"] != null && row["MatchingTime"].ToString() != "")
                {
                    model.MatchingTime = DateTime.Parse(row["MatchingTime"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["RefTime"] != null && row["RefTime"].ToString() != "")
                {
                    model.RefTime = DateTime.Parse(row["RefTime"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
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
            strSql.Append("select PerRewMatID,OrderID,PerID,PerRewID,SerUserID,SerPostID,MatchingTime,State,RefTime,IsDelete ");
            strSql.Append(" FROM Person_Reward_Matching ");
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
            strSql.Append(" PerRewMatID,OrderID,PerID,PerRewID,SerUserID,SerPostID,MatchingTime,State,RefTime,IsDelete ");
            strSql.Append(" FROM Person_Reward_Matching ");
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
            strSql.Append("select count(1) FROM Person_Reward_Matching ");
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
                strSql.Append("order by T.PerRewMatID desc");
            }
            strSql.Append(")AS Row, T.*  from Person_Reward_Matching T ");
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
            parameters[0].Value = "Person_Reward_Matching";
            parameters[1].Value = "PerRewMatID";
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
        /// 匹配悬赏 事务
        /// </summary>
        /// <returns></returns>
        public bool setRewardMatching(int OrderID,int PerRewardID,int PerID,int SerUserID,int SerPostID,string SerRealName)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            //匹配悬赏
            DateTime nowdate = DateTime.Now;
            //悬赏
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "INSERT INTO Person_Reward_Matching (OrderID,PerID,PerRewID,SerUserID,SerPostID,MatchingTime,State,IsDelete)VALUES(@OrderID,@PerID,@PerRewID,@SerUserID,@SerPostID,@MatchingTime,0,0)";
            SqlParameter[] para1 = { new SqlParameter("@OrderID",OrderID),new SqlParameter("@PerID", PerID), new SqlParameter("@PerRewID", PerRewardID), new SqlParameter("@SerUserID", SerUserID),
                                  new SqlParameter("@SerPostID",SerPostID),new SqlParameter("@MatchingTime",nowdate)};
            cmd1.Parameters = para1;
            list.Add(cmd1);
            //加好友
            //CommandInfo cmd4 = new CommandInfo();
            //cmd4.CommandText = "insert into Friends (PerID,SerUserID,CreateTime) values(@PerID,@SerUserID,@CreateTime)";
            //SqlParameter[] para4 = { new SqlParameter("@PerID", PerID), new SqlParameter("@SerUserID", SerUserID), new SqlParameter("@CreateTime",nowdate) };
            //list.Add(cmd4);
            //发送消息
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "INSERT INTO Person_Message(PerID,MesType,MesCon,SendTime)VALUES(@PerID,@MesType,@MesCon,@SendTime)";
            SqlParameter[] para2 = { new SqlParameter("@PerID", PerID), new SqlParameter("@MesType", 2), new SqlParameter("@MesCon", "人才经纪人" + SerRealName + "匹配了您的悬赏订单哦，去我的订单查看吧"), new SqlParameter("@SendTime",nowdate) };
            cmd2.Parameters = para2;
            list.Add(cmd2);
            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }

        /// <summary>
        /// 得到人才经纪人提供的职位方案
        /// </summary>
        /// <returns></returns>
        public DataTable getSerUserRewardMatPost(int PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PerRewMatID,SerUserID,PostCompany,PostTrade,Scale,Nature,PostName,Salary,WorkAdress,Address,State from View_SerUser_Reward_Mat_Post where PerID=@PerID and state!=2 order by MatchingTime desc");
            SqlParameter[] para = { new SqlParameter("@PerID", PerID) };
            return DbHelperSQL.Query(strSql.ToString(), para).Tables[0];
        }
        /// <summary>
        /// 得到人才经纪人提供方案的详情
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public DataTable getSerUserRewardMatPostDetail(int PerRewMatID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_SerUser_Reward_Mat_Post where PerRewMatID =@PerRewMatID");
            return DbHelperSQL.Query(strSql.ToString(), new SqlParameter("@PerRewMatID",PerRewMatID)).Tables[0];
        }
        /// <summary>
        /// 人才确认职位方案
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <param name="PerRewardID"></param>
        /// <returns></returns>
        public int setPersonRewardPostMat(int PerRewMatID,int OrderID,int PerID,int SerUserID,string PerRealName)
        {
            //改变悬赏状态
            //改变匹配悬赏状态
            //添加订单
            //StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("update Person_Reward_Matching set State=1 where PerRewMatID={0};");
            //strSql.AppendFormat("update Person_Reward set RewardState=1 where PerRewMatID={0};");
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=1,RefTime=GETDATE() where PerRewMatID=@PerRewMatID";
            SqlParameter[] para1 = { new SqlParameter("@PerRewMatID",PerRewMatID) };
            cmd1.Parameters = para1;
            list.Add(cmd1);
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Reward_Order set OrderState=8 where OrderID=@OrderID";
            SqlParameter[] para2 = { new SqlParameter("@OrderID", OrderID) };
            cmd2.Parameters = para2;
            list.Add(cmd2);
            #region
            //CommandInfo cmd2 = new CommandInfo();
            //cmd2.CommandText = "update Person_Reward set RewardState=1 where PerRewardID=@PerRewardID";
            //SqlParameter[] para2 = { new SqlParameter("@PerRewardID",PerRewardID) };
            //cmd2.Parameters = para2;
            //list.Add(cmd2);
            //DataTable matdt = DbHelperSQL.Query("select *,s.RealName from ServerUser_Post as sp left join ServerUser as s on s.SerUserID=sp.SerUserID where sp.SerUserPostID=(select SerPostID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID + ")").Tables[0];
            //Random r = new Random();
            //int n = r.Next(0, 100);
            //string OrderNum="d"+DateTime.Now.ToString("yyyyMMddHHmmssms")+n.ToString().PadLeft(2,'0');
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Reward_Order set OrderState=8,PostID=@PostID,SerUserID=@SerUserID,SerRealName=@SerRealName,Company=@Company,Post_Trade=@Post_Trade,Scale=@Scale,Nature=@Nature,PostName=@PostName,PostDuty=@PostDuty,Salary=@Salary,DevelopProspect=@DevelopProspect,DirectLeader=@DirectLeader,WorkAdress=@WorkAdress,Address=@Address,WelfareTag=@WelfareTag,Post_CompanyMatching=@Post_CompanyMatching,OtherPoint=@OtherPoint where OrderID="+OrderID);
            //CommandInfo cmd3 = new CommandInfo();
            //cmd3.CommandText = strSql.ToString();
            //SqlParameter[] parameters = {
            //        new SqlParameter("@PostID", SqlDbType.Int,4),
            //        new SqlParameter("@SerUserID", SqlDbType.Int,4),
            //        new SqlParameter("@SerRealName", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Company", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Post_Trade", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Scale", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Nature", SqlDbType.NVarChar,50),
            //        new SqlParameter("@PostName", SqlDbType.NVarChar,50),
            //        new SqlParameter("@PostDuty", SqlDbType.NVarChar,500),
            //        new SqlParameter("@Salary", SqlDbType.NVarChar,500),
            //        new SqlParameter("@DevelopProspect", SqlDbType.NVarChar,500),
            //        new SqlParameter("@DirectLeader", SqlDbType.NVarChar,50),
            //        new SqlParameter("@WorkAdress", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Address", SqlDbType.NVarChar,200),
            //        new SqlParameter("@WelfareTag", SqlDbType.NVarChar,100),
            //        new SqlParameter("@Post_CompanyMatching", SqlDbType.NVarChar,500),
            //        new SqlParameter("@OtherPoint", SqlDbType.NVarChar,500)};
            //parameters[0].Value = matdt.Rows[0]["SerUserPostID"];
            //parameters[1].Value = matdt.Rows[0]["SerUserID"];
            //parameters[2].Value = matdt.Rows[0]["RealName"];
            //parameters[3].Value = matdt.Rows[0]["Company"];
            //parameters[4].Value = matdt.Rows[0]["Trade"];
            //parameters[5].Value = matdt.Rows[0]["Scale"];
            //parameters[6].Value = matdt.Rows[0]["Nature"];
            //parameters[7].Value = matdt.Rows[0]["PostName"];
            //parameters[8].Value = matdt.Rows[0]["PostDuty"];
            //parameters[9].Value = matdt.Rows[0]["Salary"];
            //parameters[10].Value = matdt.Rows[0]["DevelopProspect"];
            //parameters[11].Value = matdt.Rows[0]["DirectLeader"];
            //parameters[12].Value = matdt.Rows[0]["WorkAdress"];
            //parameters[13].Value = matdt.Rows[0]["Address"];
            //parameters[14].Value = matdt.Rows[0]["WelfareTag"];
            //parameters[15].Value = matdt.Rows[0]["CompanyMatching"];
            //parameters[16].Value = matdt.Rows[0]["OtherPoint"];

            //cmd3.Parameters = parameters; 
            //list.Add(cmd3);
            #endregion
            string strsql = "select count(1) from Friends where PerID=@PerID and SerUserID=@SerUserID";
            SqlParameter[] parafriend={new SqlParameter("@PerID",PerID),new SqlParameter("@SerUserID",SerUserID)};
            if (Convert.ToInt32(DbHelperSQL.GetSingle(strsql,parafriend))<=0)
            {
                CommandInfo cmd4 = new CommandInfo();
                cmd4.CommandText = "insert into Friends (PerID,SerUserID,CreateTime) values(@PerID,@SerUserID,GETDATE())";
                SqlParameter[] para4 = { new SqlParameter("@PerID", PerID), new SqlParameter("@SerUserID", SerUserID) };
                cmd4.Parameters = para4;
                list.Add(cmd4);

            }
            CommandInfo cmd6 = new CommandInfo();
            cmd6.CommandText = "INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + SerUserID + ",2,'求职者" + PerRealName + "接受了您的职位方案，去我的订单查看吧',getdate())";
            list.Add(cmd6);
            return DbHelperSQL.ExecuteSqlTran(list);
        }
        /// <summary>
        /// 忽略人才经纪人提供的方案
        /// </summary>
        /// <param name="PerRewardMatID"></param>
        /// <returns></returns>
        public bool setPersonRewardPostNoMat(int PerRewardMatID,string PerRealName,int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person_Reward_Matching set State =2,RefTime=GETDATE() where PerRewMatID=@PerRewMatID;");
            strSql.Append("INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + SerUserID + ",2,'求职者" + PerRealName + "拒绝了您的职位方案，去我的订单查看吧',getdate())");
            return DbHelperSQL.ExecuteSql(strSql.ToString(), new SqlParameter("@PerRewMatID",PerRewardMatID))>1;
        }
        /// <summary>
        /// 忽略求职者悬赏订单 1修改匹配状态 2修改订单状态 3判断悬赏金额 需不需要退款 退款则修改余额  添加交易记录 4添加系统消息
        /// </summary>
        /// <param name="PerRewardMatID"></param>
        /// <returns></returns>
        public bool setSerUserRewardNoMat(int PerRewardMatID, string SerRealName, string PostName)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            SqlParameter parame=new SqlParameter("@PerRewMatID", PerRewardMatID);
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=5,RefTime=GETDATE() where PerRewMatID=@PerRewMatID";
            SqlParameter[] para = { parame };
            cmd1.Parameters = para;
            list.Add(cmd1);
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Reward_Order set OrderState=12  where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=@PerRewMatID)";
            cmd2.Parameters = para;
            list.Add(cmd2);
            decimal RewardMoney = Convert.ToDecimal(DbHelperSQL.GetSingle("select RewardMoney from Reward_Order where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=@PerRewMatID)", parame));
            if (RewardMoney != 0)
            {
                CommandInfo cmd3 = new CommandInfo();
                cmd3.CommandText = "update Person set Balance=Balance+@RewardMoney where PerID=(select PerID from Person_Reward_Matching where PerRewMatID=@PerRewMatID)";
                SqlParameter[] para1 = { new SqlParameter("@RewardMoney", RewardMoney),parame };
                cmd3.Parameters = para1;
                list.Add(cmd3);
                CommandInfo cmd4 = new CommandInfo();//添加交易记录
                cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values((select PerID from Person_Reward_Matching where PerRewMatID =@PerRewMatID),@RecordType,@RewardMoney,@RecordTime,0,'')";
                SqlParameter[] para4 = { new SqlParameter("@RecordType", "订单退款"), parame, new SqlParameter("@RewardMoney", RewardMoney), new SqlParameter("@RecordTime", DateTime.Now) };
                cmd4.Parameters = para4;
                list.Add(cmd4);
            }
            CommandInfo cmd5 = new CommandInfo();
            cmd5.CommandText = "INSERT INTO Person_Message(PerID,MesType,MesCon,SendTime)VALUES((select PerID from Person_Reward_Matching where PerRewMatID=@PerRewMatID),@MesType,@MesCon,@SendTime)";
            SqlParameter[] para2 = { new SqlParameter("@PerRewMatID", PerRewardMatID), new SqlParameter("@MesType", 2), new SqlParameter("@MesCon", "人才经纪人" + SerRealName + "拒绝了您针对职位" + PostName + "发送的悬赏订单"), new SqlParameter("@SendTime", DateTime.Now) };
            cmd5.Parameters = para2;
            list.Add(cmd5);
            if (DbHelperSQL.ExecuteSqlTran(list) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 确认求职者悬赏订单 1修改匹配状态 2修改订单状态 //添加好友
        /// </summary>
        /// <param name="PerRewardMatID"></param>
        /// <returns></returns>
        public bool setSerUserRewardMat(int PerRewardMatID, string SerRealName, string PostName)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            SqlParameter parame = new SqlParameter("@PerRewMatID", PerRewardMatID);
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=4 where PerRewMatID=@PerRewMatID";
            SqlParameter[] para1 = { parame };
            cmd1.Parameters = para1;
            list.Add(cmd1);
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Reward_Order set OrderState=4 where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=@PerRewMatID)";
            cmd2.Parameters = para1;
            list.Add(cmd2);
            string strsql = "select count(1) from Friends where PerID=(select PerID from Person_Reward_Matching where PerRewMatID=@PerRewMatID) and SerUserID=(select SerUserID from Person_Reward_Matching where PerRewMatID=@PerRewMatID)";
            SqlParameter[] parafriend = { new SqlParameter("@PerRewMatID", PerRewardMatID) };
            if (Convert.ToInt32(DbHelperSQL.GetSingle(strsql, parafriend)) <= 0)
            {
                CommandInfo cmd4 = new CommandInfo();
                cmd4.CommandText = "insert into Friends (PerID,SerUserID,CreateTime) select PerID,SerUserID,GETDATE() from Person_Reward_Matching where PerRewMatID=@PerRewMatID";
                cmd4.Parameters = parafriend;
                list.Add(cmd4);

            }
            CommandInfo cmd5 = new CommandInfo();
            cmd5.CommandText = "INSERT INTO Person_Message(PerID,MesType,MesCon,SendTime)VALUES((select PerID from Person_Reward_Matching where PerRewMatID=@PerRewMatID),@MesType,@MesCon,@SendTime)";
            SqlParameter[] para2 = { new SqlParameter("@PerRewMatID", PerRewardMatID), new SqlParameter("@MesType", 2), new SqlParameter("@MesCon", "人才经纪人" + SerRealName + "接受了您针对职位" + PostName + "发送的悬赏订单，去我的订单查看吧"), new SqlParameter("@SendTime", DateTime.Now) };
            cmd5.Parameters = para2;
            list.Add(cmd5);
            if (DbHelperSQL.ExecuteSqlTran(list) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据订单得到已接受职位方案的职位
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable getPostByOrderID(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PostName,PostCompany,Trade,WorkAdress,Salary,State,SerPostID,PerRewMatID,SerRealName,CompanyNature,CompanySize,PhotoImg,Position from View_SerUser_Reward_Mat_Post where State in(0,1,4,6,7,8,9,10,11) and OrderID=" + OrderID + " order by MatchingTime desc");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 人才经纪人发起入职
        /// </summary>
        /// <returns></returns>
        public bool SerUserEntryPost(int PerRewMatID,string SerRealName)
        {
            //修改匹配状态 发送消息 发送推送
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=6 where PerRewMatID=" + PerRewMatID;
            list.Add(cmd1);
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "INSERT INTO Person_Message(PerID,MesType,MesCon,SendTime)VALUES((select PerID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID + "),2,'人才经纪人" + SerRealName + "已发起入职，去我的订单查看吧',getdate())";
            list.Add(cmd2);
            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }
        /// <summary>
        /// 人才经纪人发起入职失败
        /// </summary>
        /// <returns></returns>
        public bool SerUserFailPost(int PerRewMatID,string SerRealName)
        {
            //修改匹配状态 发送消息 发送推送
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=7 where PerRewMatID=" + PerRewMatID;
            list.Add(cmd1);
            //if ((DbHelperSQL.GetSingle("select orderstate from Reward_Order where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID+")")).ToString() == "4")//如果是针对悬赏  直接设置订单状态为公共悬赏订单 orderstate=8
            //{
            //    CommandInfo cmd3 = new CommandInfo();
            //    cmd3.CommandText = "update Reward_Order set OrderState=8 where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID + ")";
            //    list.Add(cmd3);
            //}
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "INSERT INTO Person_Message(PerID,MesType,MesCon,SendTime)VALUES((select PerID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID + "),2,'人才经纪人" + SerRealName + "确认您入职失败，去我的订单查看吧',getdate())";
            list.Add(cmd2);
            return DbHelperSQL.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 求职者确认入职
        /// </summary>
        /// 
        /// <returns></returns>
        public bool PerSetInPost(int PerRewMatID, int OrderID, int SerUserID, int Commission)
        {
            //修改职位状态，修改其他人才经纪人职位已接受 或 发起入职的 状态为入职失败，修改订单，付款给人才经纪人，添加消息提醒
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=8 where PerRewMatID=" + PerRewMatID;
            list.Add(cmd1);
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "update Person_Reward_Matching set State=7 where OrderID="+OrderID;
            DataTable matdt = DbHelperSQL.Query("select *,s.RealName from ServerUser_Post as sp left join ServerUser as s on s.SerUserID=sp.SerUserID where sp.SerUserPostID=(select SerPostID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID + ")").Tables[0];
            Random r = new Random();
            int n = r.Next(0, 100);
            string OrderNum = "d" + DateTime.Now.ToString("yyyyMMddHHmmssms") + n.ToString().PadLeft(2, '0');
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Reward_Order set OrderState=2,PostID=@PostID,SerUserID=@SerUserID,SerRealName=@SerRealName,Company=@Company,Post_Trade=@Post_Trade,Scale=@Scale,Nature=@Nature,PostName=@PostName,PostDuty=@PostDuty,Salary=@Salary,DevelopProspect=@DevelopProspect,DirectLeader=@DirectLeader,WorkAdress=@WorkAdress,Address=@Address,WelfareTag=@WelfareTag,Post_CompanyMatching=@Post_CompanyMatching,OtherPoint=@OtherPoint where OrderID=" + OrderID);
            CommandInfo cmd3 = new CommandInfo();
            cmd3.CommandText = strSql.ToString();
            SqlParameter[] parameters = {
                    new SqlParameter("@PostID", SqlDbType.Int,4),
                    new SqlParameter("@SerUserID", SqlDbType.Int,4),
                    new SqlParameter("@SerRealName", SqlDbType.NVarChar,50),
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
                    new SqlParameter("@OtherPoint", SqlDbType.NVarChar,500)};
            parameters[0].Value = matdt.Rows[0]["SerUserPostID"];
            parameters[1].Value = matdt.Rows[0]["SerUserID"];
            parameters[2].Value = matdt.Rows[0]["RealName"];
            parameters[3].Value = matdt.Rows[0]["Company"];
            parameters[4].Value = matdt.Rows[0]["Trade"];
            parameters[5].Value = matdt.Rows[0]["Scale"];
            parameters[6].Value = matdt.Rows[0]["Nature"];
            parameters[7].Value = matdt.Rows[0]["PostName"];
            parameters[8].Value = matdt.Rows[0]["PostDuty"];
            parameters[9].Value = matdt.Rows[0]["Salary"];
            parameters[10].Value = matdt.Rows[0]["DevelopProspect"];
            parameters[11].Value = matdt.Rows[0]["DirectLeader"];
            parameters[12].Value = matdt.Rows[0]["WorkAdress"];
            parameters[13].Value = matdt.Rows[0]["Address"];
            parameters[14].Value = matdt.Rows[0]["WelfareTag"];
            parameters[15].Value = matdt.Rows[0]["CompanyMatching"];
            parameters[16].Value = matdt.Rows[0]["OtherPoint"];
            cmd3.Parameters = parameters;
            list.Add(cmd3);
            //decimal RewardMoney = Convert.ToDecimal(DbHelperSQL.GetSingle("select RewardMoney from Reward_Order where OrderID="+OrderID));
            //if (RewardMoney != 0)
            //{
            //    decimal comm = (decimal)Commission / 100;
            //    decimal payMoney = RewardMoney - RewardMoney * comm;
            //    CommandInfo cmd5 = new CommandInfo();
            //    cmd5.CommandText = "update ServerUser set Balance+=@payMoney where SerUserID=@SerUserID";
            //    SqlParameter[] para5 = { new SqlParameter("@SerUserID", SerUserID), new SqlParameter("@payMoney", payMoney) };
            //    cmd3.Parameters = para5;
            //    list.Add(cmd5);
            //    CommandInfo cmd4 = new CommandInfo();
            //    cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(@UserID,@RecordType,@Money,@RecordTime,1,'')";
            //    SqlParameter[] para4 = { new SqlParameter("@UserID", SerUserID), new SqlParameter("@RecordType", "订单入账"), new SqlParameter("@Money", payMoney), new SqlParameter("@RecordTime", DateTime.Now), new SqlParameter("@UserType", 1) };
            //    cmd4.Parameters = para4;
            //    list.Add(cmd4);
            //}
            CommandInfo cmd7 = new CommandInfo();
            cmd7.CommandText = "update Person_Reward_Matching set State=12 where OrderID="+OrderID+" and SerUserID!=" + SerUserID;
            list.Add(cmd7);
            CommandInfo cmd6 = new CommandInfo();
            cmd6.CommandText = "INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + SerUserID + ",2,'您的悬赏订单求职者已同意入职，等待优青网审核',getdate())";
            list.Add(cmd6);
            return DbHelperSQL.ExecuteSqlTran(list)>0 ;
        }
        /// <summary>
        /// 求职者拒绝入职
        /// </summary>
        /// <returns></returns>
        public bool PerSetFailPost(int SerUserID, int PerRewMatID,string RealName)
        {
            //修改职位状态，添加消息提醒
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_Reward_Matching set State=9 where PerRewMatID=" + PerRewMatID;
            list.Add(cmd1);
            //如果是针对悬赏  直接设置订单状态为公共悬赏订单 orderstate=8
            //if ((DbHelperSQL.GetSingle("select orderstate from Reward_Order where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID+")")).ToString() == "4")
            //{
            //    CommandInfo cmd3 = new CommandInfo();
            //    cmd3.CommandText = "update Reward_Order set OrderState=8 where OrderID=(select OrderID from Person_Reward_Matching where PerRewMatID=" + PerRewMatID + ")";
            //    list.Add(cmd3);
            //}
            CommandInfo cmd2 = new CommandInfo();
            cmd2.CommandText = "INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + SerUserID + ",2,'您的悬赏订单求职者"+RealName+"已拒绝入职',getdate())";
            list.Add(cmd2);
            return DbHelperSQL.ExecuteSqlTran(list)>0;
        }
        /// <summary>
        /// 查询协议
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PerID"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataTable getSerUserRewardMatPostDetail(int OrderID,int PerID,int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_SerUser_Reward_Mat_Post where OrderID ="+OrderID+" and PerID="+PerID+" and SerUserID="+SerUserID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 查询匹配状态
        /// </summary>
        /// <param name="PerRewMatID"></param>
        /// <returns></returns>
        public int GetState(int PerRewMatID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select State from Person_Reward_Matching where PerRewMatID=" + PerRewMatID);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 首页人才经纪人3个悬赏订单
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataTable HomeSerUserOrder(int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 3 OrderNum,EngagePost,DemandPay,RewardMoney,OrderState,JobCity,OrderID,State,PerRewMatID,MatchingTime,PostName,RealName,Photo from View_SerUserOrderDetail  where SerUserID= " + SerUserID + " and State in(1,4,6,8) order by CreateTime Desc");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 悬赏订单中其他没有选中入职的职位 发送消息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="SerUserID"></param>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public string OrderAuthSerUserMsg(int OrderID,int SerUserID,string RealName)
        {
            DataTable serdt = DbHelperSQL.Query("select SerUserID from Person_Reward_Matching where OrderID="+OrderID+" and SerUserID!="+SerUserID).Tables[0];
            string SerUserIDs="";
            if (serdt.Rows.Count > 0)
            {
                List<CommandInfo> list = new List<CommandInfo>();
                foreach (DataRow dr in serdt.Rows)
                {
                    CommandInfo cmd = new CommandInfo();
                    cmd.CommandText = "INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + dr[0] + ",2,'您的匹配"+RealName+"的悬赏订单，求职者已入职其他经纪人的职位',getdate())";
                    list.Add(cmd);
                    SerUserIDs += "s"+dr[0]+",";
                }
                DbHelperSQL.ExecuteSqlTran(list);
                return SerUserIDs;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 取消悬赏订单 给人才经纪人发送消息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="SerUserID"></param>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public string OrderAuthSerUserMsg(int OrderID,string RealName)
        {
            DataTable serdt = DbHelperSQL.Query("select SerUserID from Person_Reward_Matching where OrderID=" + OrderID).Tables[0];
            string SerUserIDs = "";
            if (serdt.Rows.Count > 0)
            {
                List<CommandInfo> list = new List<CommandInfo>();
                foreach (DataRow dr in serdt.Rows)
                {
                    CommandInfo cmd = new CommandInfo();
                    cmd.CommandText = "INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + dr[0] + ",2,'您的匹配" + RealName + "的悬赏订单，求职者已取消悬赏订单',getdate())";
                    list.Add(cmd);
                    SerUserIDs += "s" + dr[0] + ",";
                }
                DbHelperSQL.ExecuteSqlTran(list);
                return SerUserIDs;
            }
            else
            {
                return "";
            }
        }
        #endregion  MethodEx
    }
}

