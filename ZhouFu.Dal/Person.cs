using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using System.Collections.Generic;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person
	/// </summary>
	public partial class Person
	{
		public Person()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PerID", "Person"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PerID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4)
			};
			parameters[0].Value = PerID;

			int result= DbHelperSQL.RunProcedure("Person_Exists",parameters,out rowsAffected);
			if(result==1)
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
        public int Add(ZhongLi.Model.Person model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Phne", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkLife", SqlDbType.NVarChar,50),
					new SqlParameter("@Birth", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@OneDes", SqlDbType.NVarChar,100),
					new SqlParameter("@Photo", SqlDbType.NVarChar,200),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@AuthImg", SqlDbType.NVarChar,200),
					new SqlParameter("@AuthTime", SqlDbType.DateTime),
					new SqlParameter("@MyDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@Balance", SqlDbType.Decimal,9),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@PhoneCode", SqlDbType.NVarChar,50),
					new SqlParameter("@CodeTime", SqlDbType.DateTime),
					new SqlParameter("@ImOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WxOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@QQOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WbOpenID", SqlDbType.NVarChar,200)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phne;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Education;
            parameters[6].Value = model.WorkLife;
            parameters[7].Value = model.Birth;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.City;
            parameters[10].Value = model.OneDes;
            parameters[11].Value = model.Photo;
            parameters[12].Value = model.Flag;
            parameters[13].Value = model.AuthImg;
            parameters[14].Value = model.AuthTime;
            parameters[15].Value = model.MyDes;
            parameters[16].Value = model.Balance;
            parameters[17].Value = model.RegTime;
            parameters[18].Value = model.PhoneCode;
            parameters[19].Value = model.CodeTime;
            parameters[20].Value = model.ImOpenID;
            parameters[21].Value = model.WxOpenID;
            parameters[22].Value = model.SerUserID;
            parameters[23].Value = model.QQOpenID;
            parameters[24].Value = model.WbOpenID;

            DbHelperSQL.RunProcedure("Person_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.Person model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Phne", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkLife", SqlDbType.NVarChar,50),
					new SqlParameter("@Birth", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@OneDes", SqlDbType.NVarChar,100),
					new SqlParameter("@Photo", SqlDbType.NVarChar,200),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@AuthImg", SqlDbType.NVarChar,200),
					new SqlParameter("@AuthTime", SqlDbType.DateTime),
					new SqlParameter("@MyDes", SqlDbType.NVarChar,-1),
					new SqlParameter("@Balance", SqlDbType.Decimal,9),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@PhoneCode", SqlDbType.NVarChar,50),
					new SqlParameter("@CodeTime", SqlDbType.DateTime),
					new SqlParameter("@ImOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WxOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@QQOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WbOpenID", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.PerID;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phne;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Education;
            parameters[6].Value = model.WorkLife;
            parameters[7].Value = model.Birth;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.City;
            parameters[10].Value = model.OneDes;
            parameters[11].Value = model.Photo;
            parameters[12].Value = model.Flag;
            parameters[13].Value = model.AuthImg;
            parameters[14].Value = model.AuthTime;
            parameters[15].Value = model.MyDes;
            parameters[16].Value = model.Balance;
            parameters[17].Value = model.RegTime;
            parameters[18].Value = model.PhoneCode;
            parameters[19].Value = model.CodeTime;
            parameters[20].Value = model.ImOpenID;
            parameters[21].Value = model.WxOpenID;
            parameters[22].Value = model.SerUserID;
            parameters[23].Value = model.QQOpenID;
            parameters[24].Value = model.WbOpenID;

            DbHelperSQL.RunProcedure("Person_Update", parameters, out rowsAffected);
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
        public bool Delete(int PerID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerID;

            DbHelperSQL.RunProcedure("Person_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string PerIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Person ");
            strSql.Append(" where PerID in (" + PerIDlist + ")  ");
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
        public ZhongLi.Model.Person GetModel(int PerID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PerID", SqlDbType.Int,4)
			};
            parameters[0].Value = PerID;

            ZhongLi.Model.Person model = new ZhongLi.Model.Person();
            DataSet ds = DbHelperSQL.RunProcedure("Person_GetModel", parameters, "ds");
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
        public ZhongLi.Model.Person DataRowToModel(DataRow row)
        {
            ZhongLi.Model.Person model = new ZhongLi.Model.Person();
            if (row != null)
            {
                if (row["PerID"] != null && row["PerID"].ToString() != "")
                {
                    model.PerID = int.Parse(row["PerID"].ToString());
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["Phne"] != null)
                {
                    model.Phne = row["Phne"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    if ((row["Sex"].ToString() == "1") || (row["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                if (row["Education"] != null)
                {
                    model.Education = row["Education"].ToString();
                }
                if (row["WorkLife"] != null)
                {
                    model.WorkLife = row["WorkLife"].ToString();
                }
                if (row["Birth"] != null)
                {
                    model.Birth = row["Birth"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["OneDes"] != null)
                {
                    model.OneDes = row["OneDes"].ToString();
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
                if (row["Flag"] != null && row["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(row["Flag"].ToString());
                }
                if (row["AuthImg"] != null)
                {
                    model.AuthImg = row["AuthImg"].ToString();
                }
                if (row["AuthTime"] != null && row["AuthTime"].ToString() != "")
                {
                    model.AuthTime = DateTime.Parse(row["AuthTime"].ToString());
                }
                if (row["MyDes"] != null)
                {
                    model.MyDes = row["MyDes"].ToString();
                }
                if (row["Balance"] != null && row["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(row["Balance"].ToString());
                }
                if (row["RegTime"] != null && row["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["RegTime"].ToString());
                }
                if (row["PhoneCode"] != null)
                {
                    model.PhoneCode = row["PhoneCode"].ToString();
                }
                if (row["CodeTime"] != null && row["CodeTime"].ToString() != "")
                {
                    model.CodeTime = DateTime.Parse(row["CodeTime"].ToString());
                }
                if (row["ImOpenID"] != null)
                {
                    model.ImOpenID = row["ImOpenID"].ToString();
                }
                if (row["WxOpenID"] != null)
                {
                    model.WxOpenID = row["WxOpenID"].ToString();
                }
                if (row["SerUserID"] != null && row["SerUserID"].ToString() != "")
                {
                    model.SerUserID = int.Parse(row["SerUserID"].ToString());
                }
                if (row["QQOpenID"] != null)
                {
                    model.QQOpenID = row["QQOpenID"].ToString();
                }
                if (row["WbOpenID"] != null)
                {
                    model.WbOpenID = row["WbOpenID"].ToString();
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
            strSql.Append("select PerID,RealName,Phne,Password,Sex,Education,WorkLife,Birth,Email,City,OneDes,Photo,Flag,AuthImg,AuthTime,MyDes,Balance,RegTime,PhoneCode,CodeTime,ImOpenID,WxOpenID,SerUserID,QQOpenID,WbOpenID ");
            strSql.Append(" FROM Person ");
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
            strSql.Append(" PerID,RealName,Phne,Password,Sex,Education,WorkLife,Birth,Email,City,OneDes,Photo,Flag,AuthImg,AuthTime,MyDes,Balance,RegTime,PhoneCode,CodeTime,ImOpenID,WxOpenID,SerUserID,QQOpenID,WbOpenID ");
            strSql.Append(" FROM Person ");
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
			strSql.Append("select count(1) FROM Person ");
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
				strSql.Append("order by T.PerID desc");
			}
			strSql.Append(")AS Row, T.*  from Person T ");
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
			parameters[0].Value = "Person";
			parameters[1].Value = "PerID";
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
        /// 查询求职者指定信息
        /// </summary>
        /// <param name="field">如：RealName,Phone</param>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public DataTable findField(string field,int ID)
        {
            string sql = "select "+field+" from Person where PerID="+ID;
            return DbHelperSQL.Query(sql).Tables[0];
        }
        public DataTable findField(string field, string IDs)
        {
            string sql = "select " + field + " from Person where PerID in(" + IDs+")";
            return DbHelperSQL.Query(sql).Tables[0];
        }
        /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int checklogin(string Phone,string Password)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select Password from Person where Phne ='{0}'", Phone);
            DataTable dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString().Equals(Password))
                {
                    return 0;//登陆成功
                }
                else
                {
                    return 1;//密码错误
                }
            }
            else
            {
                return 2;//账号不存在
            }
        }
        /// <summary>
        /// 验证手机号持否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool checkphone(string phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from Person where Phne='{0}'",phone);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString())) > 0;
        }
        /// <summary>
        /// 根据条件查询部分信息
        /// </summary>
        /// <param name="filed">要查询的字段</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable findinfo(string filed,string where){
            StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("select {0} from Person where {1}",filed,where);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="perid"></param>
        /// <returns></returns>
        public bool editPwd(string password,int perid){
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person set Password=@Password where PerID=@PerID");
            SqlParameter[] para = { new SqlParameter("@Password", password), new SqlParameter("@PerID", perid) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 修改个人描述
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="MyDes"></param>
        /// <returns></returns>
        public bool editMyDes(string PerID, string MyDes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person set MyDes=@MyDes where PerID=@PerID");
            SqlParameter[] para = { new SqlParameter("@MyDes",MyDes),
                                  new SqlParameter("@PerID",PerID)};
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 保存头像
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        public bool setPhoto(int PerID,string Photo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person set Photo=@Photo where PerID=@PerID");
            SqlParameter[] para = { new SqlParameter("@PerID",PerID),
                                  new SqlParameter("@Photo",Photo)};
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 保存身份认证
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        public bool setAutoImg(int PerID, string AuthImg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person set AuthImg=@AuthImg,Flag=1 where PerID=@PerID");
            SqlParameter[] para = { new SqlParameter("@PerID",PerID),
                                  new SqlParameter("@AuthImg",AuthImg)};
            return DbHelperSQL.ExecuteSql(strSql.ToString(), para) > 0;
        }
        /// <summary>
        /// 得到电话
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public string getPhone(string PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select Phne from Person where PerID={0}",PerID);
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }
        /// <summary>
        /// 修改手机后
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool ModPhone(string Phone,string PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person set Phne="+Phone+" where PerID="+PerID);
            return DbHelperSQL.ExecuteSql(strSql.ToString())>0;
        }
        /// <summary>
        /// 得到身份认证状态
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public int getFlag(string PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select Flag from Person where PerID={0}",PerID);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 得到余额
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public decimal getBalance(string PerID)
        {
            StringBuilder strSql = new StringBuilder("select Balance from Person where PerID=@PerID");
            SqlParameter para = new SqlParameter("@PerID",PerID);
            return Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString(),para));
        }
        /// <summary>
        /// 余额支付并修改订单状态
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool BalancePay(int PerID,int OrderID){
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select OrderNum,RewardMoney,SerUserID from Reward_Order where OrderID={0}",OrderID);
            DataTable odt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            int Balance = Convert.ToInt32(DbHelperSQL.GetSingle("select Balance from Person where PerID="+PerID+""));
            if (Convert.ToInt32(odt.Rows[0][1]) <= Balance)
            {
                List<CommandInfo> list = new List<CommandInfo>();
                CommandInfo cmd1 = new CommandInfo();
                cmd1.CommandText = "update Person set Balance = Balance-(select RewardMoney from Reward_Order where OrderID =@OrderID) where PerID=@PerID";
                SqlParameter[] para1 = { new SqlParameter("@OrderID", OrderID), new SqlParameter("@PerID", PerID) };
                cmd1.Parameters = para1;
                list.Add(cmd1);
                int state = 1;
                string t = odt.Rows[0][0].ToString().Substring(0,1);
                if (t.Equals("y"))
                {
                    state = 11;
                    CommandInfo cmd3 = new CommandInfo();
                    cmd3.CommandText = "insert into Person_Reward_Matching (OrderID,PerID,PerRewID,SerUserID,SerPostID,MatchingTime,State,IsDelete)  select OrderID,PerID,PerRewardID,SerUserID,PostID,GETDATE(),3,0 from Reward_Order where OrderID="+OrderID;
                    list.Add(cmd3);
                    CommandInfo cmd5 = new CommandInfo();
                    cmd5.CommandText = "INSERT INTO ServerUser_Message(SerUserID,MesType,MesCon,SendTime)VALUES(" + odt.Rows[0][2] + ",2,'您的职位有新的悬赏订单等待确认哦，赶紧去“我匹配的悬赏”里面查看吧',getdate())";
                    list.Add(cmd5);
                }
                CommandInfo cmd2 = new CommandInfo();
                cmd2.CommandText = "update Reward_Order set OrderState="+state+" where OrderID=@OrderID";
                SqlParameter[] para2 = { new SqlParameter("@OrderID", OrderID) };
                cmd2.Parameters = para2;
                list.Add(cmd2);
                CommandInfo cmd4 = new CommandInfo();
                cmd4.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) values(@UserID,@RecordType,(select RewardMoney from Reward_Order where OrderID =@OrderID),@RecordTime,0,'')";
                SqlParameter[] para4 = { new SqlParameter("@UserID", PerID), new SqlParameter("@RecordType", "订单支付(余额)"), new SqlParameter("@OrderID", OrderID), new SqlParameter("@RecordTime", DateTime.Now), new SqlParameter("@UserType", 0) };
                cmd4.Parameters = para4;
                list.Add(cmd4);
                return DbHelperSQL.ExecuteSqlTran(list) > 0;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 修改融云聊天token
        /// </summary>
        /// <param name="perid"></param>
        /// <param name="ImOpenID"></param>
        public void editImOpenID(int perid,string ImOpenID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update Person set ImOpenID=@ImOpenID where PerID=@PerID");
            SqlParameter[] para = { new SqlParameter("@ImOpenID",ImOpenID),new SqlParameter("@PerID",perid)};
            DbHelperSQL.ExecuteSql(strSql.ToString(),para);
        }
        /// <summary>
        /// 得到待认证的人才
        /// </summary>
        /// <returns></returns>
        public int getAuthPersonCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Person where Flag=1");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 添加人才测评
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="assessments_id"></param>
        /// <param name="examination_id"></param>
        /// <param name="assessment_name"></param>
        /// <param name="reportURL"></param>
        /// <param name="created"></param>
        /// <returns></returns>
        public bool AddPersonTest(int PerID, int assessments_id, int examination_id, string assessment_name, string reportURL,string created,int AnsID )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Person_Test(PerID,assessments_id,examination_id,assessment_name,reportURL,created,AnsID)values(@PerID,@assessments_id,@examination_id,@assessment_name,@reportURL,@created,@AnsID)");
            SqlParameter[] para = { new SqlParameter("@PerID", SqlDbType.Int, 4),
                                      new SqlParameter("@assessments_id", SqlDbType.Int),
                                      new SqlParameter("@examination_id", SqlDbType.Int),
                                      new SqlParameter("@assessment_name", SqlDbType.NVarChar, 50),
                                      new SqlParameter("@reportURL", SqlDbType.NVarChar, 500),
                                      new SqlParameter("@created", SqlDbType.NVarChar, 50),
                                      new SqlParameter("@AnsID", SqlDbType.Int)
                                  };
            para[0].Value = PerID;
            para[1].Value = assessments_id;
            para[2].Value = examination_id;
            para[3].Value = assessment_name;
            para[4].Value = reportURL;
            para[5].Value = created;
            para[6].Value = AnsID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), para) > 0;
        }
        /// <summary>
        /// 得到人才测评
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public DataTable getPersonTest(int PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PerTestID,AnsID,reportURL,created from Person_Test where PerID=@PerID");
            return DbHelperSQL.Query(strSql.ToString(),new SqlParameter("@PerID",PerID)).Tables[0];
        }
        /// <summary>
        /// 修改人才测评
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="created"></param>
        /// <param name="AnsID"></param>
        /// <param name="reportURL"></param>
        /// <returns></returns>
        public bool editPersonTest(int PerID, string created, int AnsID, string reportURL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Person_Test set reportURL=@ReportUrl,AnsID=@AnsID,created=@created where PerID=@PerID");
            SqlParameter[] para = { new SqlParameter("@reportURL", reportURL), new SqlParameter("@AnsID", AnsID), new SqlParameter("@created", created), new SqlParameter("@PerID", PerID) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(), para)>0;
        }
        /// <summary>
        /// 添加充值订单
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="RealName"></param>
        /// <param name="Money"></param>
        /// <param name="PayType"></param>
        /// <returns></returns>
        public string AddPayCheck(int PerID,string RealName,decimal Money,string PayType)
        {
            StringBuilder strSql = new StringBuilder();
            Random r = new Random();
            int n = r.Next(0, 10);
            string PayCheckNum = "c"+DateTime.Now.ToString("yyyyMMddHHmmssms") + PerID + n;
            strSql.Append("insert into Person_PayCheck(PerID,RealName,PayCheckNum,Money,CreateTime,PayType,PayState)values(@PerID,@RealName,@PayCheckNum,@Money,getdate(),@PayType,0)");
            SqlParameter[] para = { new SqlParameter("@PerID", PerID), new SqlParameter("@RealName", RealName), new SqlParameter("@PayCheckNum", PayCheckNum), new SqlParameter("@Money",Money),new SqlParameter("@PayType",PayType) };
            if (DbHelperSQL.ExecuteSql(strSql.ToString(), para) > 0)
            {
                return PayCheckNum;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 判断充值订单状态是否已改变
        /// </summary>
        /// <param name="PayCheckNum"></param>
        /// <returns></returns>
        public bool IsPayCheck(string PayCheckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Person_PayCheck where PayState=0 and PayCheckNum=@PayCheckNum");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(),new SqlParameter("@PayCheckNum",PayCheckNum)))>0;
        }
        /// <summary>
        /// 修改充值状态和添加金额
        /// </summary>
        /// <param name="PayCheckNum"></param>
        /// <returns></returns>
        public bool EditPayCheck(string PayCheckNum,string PayType)
        {
            //修改状态  修改余额 添加记录
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo cmd1 = new CommandInfo();
            cmd1.CommandText = "update Person_PayCheck set PayState =1 where PayCheckNum=@PayCheckNum";
            SqlParameter[] para = { new SqlParameter("@PayCheckNum", PayCheckNum) };
            cmd1.Parameters = para;
            list.Add(cmd1);
            CommandInfo cmd2 =new CommandInfo();
            cmd2.CommandText = "update Person set Balance+=(select Money from Person_PayCheck where PayCheckNum=@PayCheckNum) where PerID=(select PerID from Person_PayCheck where PayCheckNum=@PayCheckNum)";
            cmd2.Parameters = para;
            list.Add(cmd2);
            CommandInfo cmd3 = new CommandInfo();
            cmd3.Parameters = para;
            cmd3.CommandText = "insert into TransactionRecord(UserID,RecordType,Money,RecordTime,UserType,RealName) select PerID,'充值(" + PayType + ")',Money,GETDATE(),0,RealName from Person_PayCheck where PayCheckNum=@PayCheckNum";
            list.Add(cmd3);
            return DbHelperSQL.ExecuteSqlTran(list)>2;
        }
        /// <summary>
        /// 人才经纪人转换求职这身份
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public string PersonFromSerUser(int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            string str = "";
            DataTable dt =DbHelperSQL.Query("select PerID,RealName,Phne,Photo,Flag,ImOpenID from Person where Phne=(select Phone from ServerUser where SerUserID=" + SerUserID + ")").Tables[0];
            if (dt.Rows.Count > 0)
            {
                str="{\"perid\":" + dt.Rows[0]["PerID"] + ",\"realname\":\"" + dt.Rows[0]["RealName"] + "\",\"photo\":\"" + dt.Rows[0]["Photo"] + "\",\"flag\":" + dt.Rows[0]["Flag"] + ",\"token\":\"" + dt.Rows[0]["ImOpenID"] + "\"}";
            }
            else
            {
                DataTable SerUserDt = new ServerUser().findField("RealName,Phone,Password,Sex,PhotoImg,Email", SerUserID);
                strSql.Append("insert into Person (RealName,Phne,Password,Sex,Photo,Email,Flag,RegTime,Balance)values('" + SerUserDt.Rows[0]["RealName"] + "','" + SerUserDt.Rows[0]["Phone"] + "','" + SerUserDt.Rows[0]["Password"] + "','" + SerUserDt.Rows[0]["Sex"] + "','" + SerUserDt.Rows[0]["PhotoImg"] + "','" + SerUserDt.Rows[0]["Email"] + "',0,getdate(),0);select @@IDENTITY");
                int PerID = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
                str = "{\"perid\":" + PerID + ",\"realname\":\"" + SerUserDt.Rows[0]["RealName"] + "\",\"photo\":\"" + SerUserDt.Rows[0]["PhotoImg"] + "\",\"flag\":0,\"token\":\"\"}";
            }
            return str;
        }
        /// <summary>
        /// 判断是否有教育经历
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public int IsSendOrder(int PerID)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter para = new SqlParameter("@PerID",PerID);
            strSql.Append("select (select count(1) from Person_ExpectWork where PerID=@PerID) as pe,(select count(1) from Person_Test where PerID=@PerID) as pt,(select count(1) from Person_Reward where PerID=@PerID) as pr,(select count(1) from Reward_Order where PerID=@PerID and OrderState not in(3,5,10,12)) as po");
            DataTable dt = DbHelperSQL.Query(strSql.ToString(),para).Tables[0];
            if (Convert.ToInt32(dt.Rows[0]["pe"]) > 0 && Convert.ToInt32(dt.Rows[0]["pr"]) > 0 && Convert.ToInt32(dt.Rows[0]["po"]) <= 0)//&& Convert.ToInt32(dt.Rows[0]["pt"]) > 0
            {
                return 0;//可以发送
            }
            else if (Convert.ToInt32(dt.Rows[0]["pe"]) <= 0)
            {
                return 1;//期望工作没有
            }
            //else if (Convert.ToInt32(dt.Rows[0]["pt"]) <= 0)
            //{
                //return 2;//测评没有
            //}
            else if (Convert.ToInt32(dt.Rows[0]["pr"]) <= 0)
            {
                return 3;//悬赏没有
            }else{
                return 4;//又订单正在进行
            }
        }
        /// <summary>
        /// 查看三方登陆是否已登陆过
        /// </summary>
        /// <param name="OpenIDType"></param>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public DataTable getPersonByOpenID(string OpenIDType,string OpenID)
        {
            string where = "";
            switch (OpenIDType)
            {
                case "wx":
                    where = " WxOpenID='"+OpenID+"'";
                    break;
                case "qq":
                    where = " QQOpenID='" + OpenID + "'";
                    break;
                case "wb":
                    where = " WbOpenID='" + OpenID + "'";
                    break;
            }
            DataTable dt = DbHelperSQL.Query("select PerID,RealName,Phne,Photo,Flag,ImOpenID,Password from Person where " + where).Tables[0];
            return dt;
        }
        public DataSet test(string RealName)
        {
            string sql = "select * from Person where RealName like '%'+@RealName+'%'";
            SqlParameter para=new SqlParameter("@RealName",RealName);
            DataSet ds = DbHelperSQL.Query(sql,para);
            return ds;
        }
        
		#endregion  MethodEx

        #region 收藏 0新闻 1职业规划 2职业培训
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="CollID"></param>
        /// <param name="CollType"></param>
        /// <returns></returns>
        public bool AddPerson_Coll(int PerID,int CollID,int CollType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Person_Collection(PerID,CollID,CollectionTime,CollType)values(@PerID,@CollID,getdate(),@CollType)");
            SqlParameter[] para = { new SqlParameter("@PerID", PerID), new SqlParameter("@CollID", CollID), new SqlParameter("@CollType",CollType) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        #endregion
	}
}

