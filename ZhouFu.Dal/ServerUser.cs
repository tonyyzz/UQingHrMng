using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:ServerUser
	/// </summary>
	public partial class ServerUser
	{
		public ServerUser()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SerUserID", "ServerUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SerUserID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserID;

			int result= DbHelperSQL.RunProcedure("ServerUser_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.ServerUser model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@PhotoImg", SqlDbType.NVarChar,200),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Position", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkCity", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Describe", SqlDbType.NVarChar,500),
					new SqlParameter("@IDCardImg", SqlDbType.NVarChar,200),
					new SqlParameter("@IDCardTime", SqlDbType.DateTime),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@SerImg", SqlDbType.NVarChar,200),
					new SqlParameter("@SerTime", SqlDbType.DateTime),
					new SqlParameter("@Balance", SqlDbType.Decimal,9),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@IDCardState", SqlDbType.Int,4),
					new SqlParameter("@SerImgState", SqlDbType.Int,4),
					new SqlParameter("@ImOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WxOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@QQOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WbOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@AttestType", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.RealName;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.PhotoImg;
			parameters[4].Value = model.Trade;
			parameters[5].Value = model.Company;
			parameters[6].Value = model.Position;
			parameters[7].Value = model.WorkCity;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Phone;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.Describe;
			parameters[12].Value = model.IDCardImg;
			parameters[13].Value = model.IDCardTime;
			parameters[14].Value = model.Flag;
			parameters[15].Value = model.SerImg;
			parameters[16].Value = model.SerTime;
			parameters[17].Value = model.Balance;
			parameters[18].Value = model.RegTime;
			parameters[19].Value = model.Password;
			parameters[20].Value = model.IDCardState;
			parameters[21].Value = model.SerImgState;
			parameters[22].Value = model.ImOpenID;
			parameters[23].Value = model.WxOpenID;
			parameters[24].Value = model.PerID;
			parameters[25].Value = model.QQOpenID;
			parameters[26].Value = model.WbOpenID;
			parameters[27].Value = model.AttestType;

			DbHelperSQL.RunProcedure("ServerUser_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.ServerUser model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@PhotoImg", SqlDbType.NVarChar,200),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Position", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkCity", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Describe", SqlDbType.NVarChar,500),
					new SqlParameter("@IDCardImg", SqlDbType.NVarChar,200),
					new SqlParameter("@IDCardTime", SqlDbType.DateTime),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@SerImg", SqlDbType.NVarChar,200),
					new SqlParameter("@SerTime", SqlDbType.DateTime),
					new SqlParameter("@Balance", SqlDbType.Decimal,9),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@IDCardState", SqlDbType.Int,4),
					new SqlParameter("@SerImgState", SqlDbType.Int,4),
					new SqlParameter("@ImOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WxOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@QQOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@WbOpenID", SqlDbType.NVarChar,200),
					new SqlParameter("@AttestType", SqlDbType.Int,4)};
			parameters[0].Value = model.SerUserID;
			parameters[1].Value = model.RealName;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.PhotoImg;
			parameters[4].Value = model.Trade;
			parameters[5].Value = model.Company;
			parameters[6].Value = model.Position;
			parameters[7].Value = model.WorkCity;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Phone;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.Describe;
			parameters[12].Value = model.IDCardImg;
			parameters[13].Value = model.IDCardTime;
			parameters[14].Value = model.Flag;
			parameters[15].Value = model.SerImg;
			parameters[16].Value = model.SerTime;
			parameters[17].Value = model.Balance;
			parameters[18].Value = model.RegTime;
			parameters[19].Value = model.Password;
			parameters[20].Value = model.IDCardState;
			parameters[21].Value = model.SerImgState;
			parameters[22].Value = model.ImOpenID;
			parameters[23].Value = model.WxOpenID;
			parameters[24].Value = model.PerID;
			parameters[25].Value = model.QQOpenID;
			parameters[26].Value = model.WbOpenID;
			parameters[27].Value = model.AttestType;

			DbHelperSQL.RunProcedure("ServerUser_Update",parameters,out rowsAffected);
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
		public bool Delete(int SerUserID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserID;

			DbHelperSQL.RunProcedure("ServerUser_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string SerUserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServerUser ");
			strSql.Append(" where SerUserID in ("+SerUserIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ZhongLi.Model.ServerUser GetModel(int SerUserID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@SerUserID", SqlDbType.Int,4)
			};
			parameters[0].Value = SerUserID;

			ZhongLi.Model.ServerUser model=new ZhongLi.Model.ServerUser();
			DataSet ds= DbHelperSQL.RunProcedure("ServerUser_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
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
		public ZhongLi.Model.ServerUser DataRowToModel(DataRow row)
		{
			ZhongLi.Model.ServerUser model=new ZhongLi.Model.ServerUser();
			if (row != null)
			{
				if(row["SerUserID"]!=null && row["SerUserID"].ToString()!="")
				{
					model.SerUserID=int.Parse(row["SerUserID"].ToString());
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					if((row["Sex"].ToString()=="1")||(row["Sex"].ToString().ToLower()=="true"))
					{
						model.Sex=true;
					}
					else
					{
						model.Sex=false;
					}
				}
				if(row["PhotoImg"]!=null)
				{
					model.PhotoImg=row["PhotoImg"].ToString();
				}
				if(row["Trade"]!=null)
				{
					model.Trade=row["Trade"].ToString();
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["Position"]!=null)
				{
					model.Position=row["Position"].ToString();
				}
				if(row["WorkCity"]!=null)
				{
					model.WorkCity=row["WorkCity"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Describe"]!=null)
				{
					model.Describe=row["Describe"].ToString();
				}
				if(row["IDCardImg"]!=null)
				{
					model.IDCardImg=row["IDCardImg"].ToString();
				}
				if(row["IDCardTime"]!=null && row["IDCardTime"].ToString()!="")
				{
					model.IDCardTime=DateTime.Parse(row["IDCardTime"].ToString());
				}
				if(row["Flag"]!=null && row["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(row["Flag"].ToString());
				}
				if(row["SerImg"]!=null)
				{
					model.SerImg=row["SerImg"].ToString();
				}
				if(row["SerTime"]!=null && row["SerTime"].ToString()!="")
				{
					model.SerTime=DateTime.Parse(row["SerTime"].ToString());
				}
				if(row["Balance"]!=null && row["Balance"].ToString()!="")
				{
					model.Balance=decimal.Parse(row["Balance"].ToString());
				}
				if(row["RegTime"]!=null && row["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(row["RegTime"].ToString());
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["IDCardState"]!=null && row["IDCardState"].ToString()!="")
				{
					model.IDCardState=int.Parse(row["IDCardState"].ToString());
				}
				if(row["SerImgState"]!=null && row["SerImgState"].ToString()!="")
				{
					model.SerImgState=int.Parse(row["SerImgState"].ToString());
				}
				if(row["ImOpenID"]!=null)
				{
					model.ImOpenID=row["ImOpenID"].ToString();
				}
				if(row["WxOpenID"]!=null)
				{
					model.WxOpenID=row["WxOpenID"].ToString();
				}
				if(row["PerID"]!=null && row["PerID"].ToString()!="")
				{
					model.PerID=int.Parse(row["PerID"].ToString());
				}
				if(row["QQOpenID"]!=null)
				{
					model.QQOpenID=row["QQOpenID"].ToString();
				}
				if(row["WbOpenID"]!=null)
				{
					model.WbOpenID=row["WbOpenID"].ToString();
				}
				if (row["AttestType"] != null && row["AttestType"].ToString() != "")
				{
					model.AttestType = int.Parse(row["AttestType"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SerUserID,RealName,Sex,PhotoImg,Trade,Company,Position,WorkCity,Address,Phone,Email,Describe,IDCardImg,IDCardTime,Flag,SerImg,SerTime,Balance,RegTime,Password,IDCardState,SerImgState,ImOpenID,WxOpenID,PerID,QQOpenID,WbOpenID ");
			strSql.Append(" FROM ServerUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" SerUserID,RealName,Sex,PhotoImg,Trade,Company,Position,WorkCity,Address,Phone,Email,Describe,IDCardImg,IDCardTime,Flag,SerImg,SerTime,Balance,RegTime,Password,IDCardState,SerImgState,ImOpenID,WxOpenID,PerID,QQOpenID,WbOpenID ");
			strSql.Append(" FROM ServerUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("select count(1) FROM ServerUser ");
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

			strSql.AppendFormat(@" 
with    T1
          as ( select su.SerUserID, su.RealName, su.Sex, su.PhotoImg, su.Trade, su.Company, su.Position, su.WorkCity,
                    su.Address, su.Phone, su.Email, su.Describe, su.IDCardImg, su.IDCardTime, su.Flag, su.SerImg,
                    su.SerTime, su.Balance, su.RegTime, su.Password, su.IDCardState, su.SerImgState, su.ImOpenID,
                    su.WxOpenID, su.PerID, su.QQOpenID, su.WbOpenID, su.AttestType, sp.CreateTime as ListPostCreateTime
                from ServerUser su
                    left join ServerUser_Post sp on su.SerUserID = sp.SerUserID) 
");
			strSql.AppendFormat(@" select T.Row, T.SerUserID, T.RealName, T.Sex, T.PhotoImg, T.Trade, T.Company, T.Position, T.WorkCity, T.Address,
            T.Phone, T.Email, T.Describe, T.IDCardImg, T.IDCardTime, T.Flag, T.SerImg, T.SerTime, T.Balance, T.RegTime,
            T.Password, T.IDCardState, T.SerImgState, T.ImOpenID, T.WxOpenID, T.PerID, T.QQOpenID, T.WbOpenID,
            T.AttestType, T.ListPostCreateTime
        from ( select row_number() over ( ");
			if (!string.IsNullOrWhiteSpace(orderby))
			{
				strSql.AppendFormat(@" order by {0} ", orderby);
			}
			else
			{
				strSql.AppendFormat(@" order by SerUserID desc ");
			}
			strSql.AppendFormat(@" ) as Row ,
                    T2.SerUserID ,
                    T2.RealName ,
                    T2.Sex ,
                    T2.PhotoImg ,
                    T2.Trade ,
                    T2.Company ,
                    T2.Position ,
                    T2.WorkCity ,
                    T2.Address ,
                    T2.Phone ,
                    T2.Email ,
                    T2.Describe ,
                    T2.IDCardImg ,
                    T2.IDCardTime ,
                    T2.Flag ,
                    T2.SerImg ,
                    T2.SerTime ,
                    T2.Balance ,
                    T2.RegTime ,
                    T2.Password ,
                    T2.IDCardState ,
                    T2.SerImgState ,
                    T2.ImOpenID ,
                    T2.WxOpenID ,
                    T2.PerID ,
                    T2.QQOpenID ,
                    T2.WbOpenID ,
                    T2.AttestType ,
                    T2.ListPostCreateTime
                from ( select row_number() over ( partition  by SerUserID  ");
			if (!string.IsNullOrWhiteSpace(orderby))
			{
				strSql.AppendFormat(@" order by {0} ", orderby);
			}
			else
			{
				strSql.AppendFormat(@" order by SerUserID desc ");
			}
			strSql.AppendFormat(@"  ) LEV ,
                            *
                        from T1 ) as T2
                where LEV = 1 ");
			if (!string.IsNullOrWhiteSpace(strWhere))
			{
				strSql.AppendFormat(@" and {0} ", strWhere);
			}
			strSql.AppendFormat(@" ) as T ");
			strSql.AppendFormat(@" where Row between {0} and {1}", startIndex, endIndex);

			//strSql.Append("SELECT * FROM ( ");
			//strSql.Append(" SELECT ROW_NUMBER() OVER (");
			//if (!string.IsNullOrEmpty(orderby.Trim()))
			//{
			//	strSql.Append("order by T." + orderby);
			//}
			//else
			//{
			//	strSql.Append("order by T.SerUserID desc");
			//}
			//strSql.Append(")AS Row, T.*  from ServerUser T ");
			//if (!string.IsNullOrEmpty(strWhere.Trim()))
			//{
			//	strSql.Append(" WHERE " + strWhere);
			//}
			//strSql.Append(" ) TT");
			//strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "ServerUser";
			parameters[1].Value = "SerUserID";
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
        /// 查询职业介绍人指定信息
        /// </summary>
        /// <param name="field">如：RealName,Phone</param>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public DataTable findField(string field, int ID)
        {
            string sql = "select " + field + " from ServerUser where SerUserID=" + ID;
            return DbHelperSQL.Query(sql).Tables[0];
        }
        public DataTable findField(string field, string IDs)
        {
            string sql = "select " + field + " from ServerUser where SerUserID in (" + IDs+")";
            return DbHelperSQL.Query(sql).Tables[0];
        }
        /// <summary>
        /// 根据条件查询部分信息
        /// </summary>
        /// <param name="filed">要查询的字段</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable findinfo(string filed, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select {0} from ServerUser where {1}", filed, where);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int checklogin(string Phone, string Password)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select Password from ServerUser where Phone ='{0}'", Phone);
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
            strSql.AppendFormat("select count(1) from ServerUser where Phone='{0}'", phone);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString())) > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="perid"></param>
        /// <returns></returns>
        public bool editPwd(string password, int seruserid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServerUser set Password=@Password where SerUserID=@SerUserID");
            SqlParameter[] para = { new SqlParameter("@Password", password), new SqlParameter("@SerUserID", seruserid) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(), para) > 0;
        }
        /// <summary>
        /// 保存个人资料
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="RealName"></param>
        /// <param name="Sex"></param>
        /// <param name="Trade"></param>
        /// <param name="Company"></param>
        /// <param name="Position"></param>
        /// <param name="WorkCity"></param>
        /// <param name="Address"></param>
        /// <param name="Email"></param>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public bool saveSerUser(string RealName,string Sex,string Trade,string Company,string Position,string WorkCity,string Address,string Email,string SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServerUser set RealName=@RealName,Sex=@Sex,Trade=@Trade,Company=@Company,Position=@Position,WorkCity=@WorkCity,Address=@Address,Email=@Email");
            strSql.Append(" where SerUserID=@SerUserID");
            SqlParameter[] para = { 
                                  new SqlParameter("@RealName",RealName),
                                  new SqlParameter("@Sex",Sex),
                                  new SqlParameter("@Position",Position),
                                  new SqlParameter("@Trade",Trade),
                                  new SqlParameter("@Company",Company),
                                  new SqlParameter("@WorkCity",WorkCity),
                                  new SqlParameter("@Address",Address),
                                  new SqlParameter("@Email",Email),
                                  new SqlParameter("@SerUserID",SerUserID)
                                  };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 保存自我描述
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="Describe"></param>
        /// <returns></returns>
        public bool saveDescribe(string SerUserID, string Describe)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServerUser set Describe=@Describe where SerUserID=@SerUserID");
            SqlParameter[] para = { new SqlParameter("@Describe", Describe),new SqlParameter("@SerUserID",SerUserID) };
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }
        /// <summary>
        /// 保存身份认证图片
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="IDCardImg"></param>
        /// <returns></returns>
        public bool saveIDCardImg(string SerUserID,string IDCardImg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser set IDCardImg='{0}',IDCardState=1 where SerUserID={1}", IDCardImg, SerUserID);
            return DbHelperSQL.ExecuteSql(strSql.ToString())>0;
        }
        /// <summary>
        /// 保存职能身份认证图片
        /// </summary>
        /// <param name="SerUserID"></param>//数据库flag状态 0未上传 1只通过身份 2通过职能身份认证 3全部通过 
        /// <param name="IDCardImg"></param>//app状态  0 未上传 1等待身份认证审核 2等待职能身份认证审核 3通过了所有身份认证
        /// <returns></returns>
        public bool saveSerImg(string SerUserID, string SerImg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser set SerImg='{0}',SerImgState=1 where SerUserID={1}", SerImg, SerUserID);
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
        }
        /// <summary>
        /// 身份认证上传
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="url1"></param>
        /// <param name="url2"></param>
        public bool uploadIdCardApprove(int SerUserID,string url1,string url2,int attestType)
        {
            StringBuilder strSql = new StringBuilder();
			strSql.AppendFormat("update ServerUser set IDCardImg='{0}',SerImg='{1}',Flag=1,AttestType={2} where SerUserID={3}", url1, url2, attestType, SerUserID);
            return DbHelperSQL.ExecuteSql(strSql.ToString())>0;
        }
        /// <summary>
        /// 保存头像
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        public bool savePhoto(string SerUserID, string Photo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser set PhotoImg=@PhotoImg where SerUserID={0}", SerUserID);
            SqlParameter[] para = { new SqlParameter("@PhotoImg",Photo)};
            return DbHelperSQL.ExecuteSql(strSql.ToString(),para)>0;
        }

        /// <summary>
        /// 得到电话
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public string getPhone(string SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select Phone from ServerUser where SerUserID={0}", SerUserID);
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }
        /// <summary>
        /// 修改手机号码
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public bool ModPhone(string Phone, string SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServerUser set Phone=" + Phone + " where SerUserID=" + SerUserID);
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
        }
        /// <summary>
        /// 经纪人列表 按订单成交数量排序
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable SerUserList(int PageIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from(");
            strSql.Append("SELECT t.SerUserID,t.Sex,t.RealName,t.Position,t.Company,t.Trade,t.WorkCity,t.PhotoImg,");
            strSql.Append("(select count(1) from Reward_order where SerUserID=t.SerUserID) as ordercount,");
            strSql.Append(" ROW_NUMBER() over(order by (select count(1) from Reward_order where SerUserID=t.SerUserID) desc) as row ");
            strSql.Append("from ServerUser as t where t.Flag=1) as tt");
            strSql.AppendFormat(" WHERE tt.Row between {0} and {1}", (PageIndex-1)*10+1, PageIndex*10);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 修改融云聊天token
        /// </summary>
        /// <param name="perid"></param>
        /// <param name="ImOpenID"></param>
        public void editImOpenID(int SerUserID, string ImOpenID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser set ImOpenID=@ImOpenID where SerUserID=@SerUserID");
            SqlParameter[] para = { new SqlParameter("@ImOpenID", ImOpenID), new SqlParameter("@SerUserID", SerUserID) };
            DbHelperSQL.ExecuteSql(strSql.ToString(), para);
        }
        /// <summary>
        /// 得到待认证人才经纪人数量
        /// </summary>
        /// <returns></returns>
        public int getSerUserAuthCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServerUser where Flag=1");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 求职者身份转换为人才经纪人
        /// </summary>
        /// <param name="PerID"></param>
        /// <returns></returns>
        public string SerUserFromPerson(int PerID)
        {
            StringBuilder strSql = new StringBuilder();
            string str = "";
            DataTable dt = DbHelperSQL.Query("select SerUserID,RealName,PhotoImg,Flag,IDCardImg,SerImg,IDCardState,SerImgState,ImOpenID from ServerUser where Phone=(select Phne from Person where PerID=" + PerID + ")").Tables[0];
            if (dt.Rows.Count > 0)
            {
                str = "{\"seruserid\":" + dt.Rows[0]["SerUserID"] + ",\"realname\":\"" + dt.Rows[0]["RealName"] + "\",\"PhotoImg\":\"" + dt.Rows[0]["PhotoImg"] + "\",\"IDCardState\":" + dt.Rows[0]["IDCardState"] + ",\"SerImgState\":" + dt.Rows[0]["SerImgState"] + ",\"token\":\"" + dt.Rows[0]["ImOpenID"] + "\"}";
            }
            else
            {
                DataTable PerDt = new Person().findField("RealName,Phne,Password,Sex,Photo,Email", PerID);
                strSql.Append("insert into ServerUser (RealName,Phone,Password,Sex,PhotoImg,Email,Flag,SerImgState,IDCardState,RegTime,Balance)values(");
                strSql.Append("'" + PerDt.Rows[0]["RealName"] + "','" + PerDt.Rows[0]["Phne"] + "','" + PerDt.Rows[0]["Password"] + "','" + PerDt.Rows[0]["Sex"] + "','" + PerDt.Rows[0]["Photo"] + "','" + PerDt.Rows[0]["Email"] + "',0,0,0,getdate(),0);select @@IDENTITY");
                int SerUserID = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
                str = "{\"seruserid\":" + SerUserID + ",\"realname\":\"" + PerDt.Rows[0]["RealName"] + "\",\"PhotoImg\":\"" + PerDt.Rows[0]["Photo"] + "\",\"IDCardState\":0,\"SerImgState\":0,\"token\":\"\"}";
            }
            return str;
        }

        
		#endregion  MethodEx
	}
}

