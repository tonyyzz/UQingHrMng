using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:ServerUser_Post
	/// </summary>
	public partial class ServerUser_Post
	{
		public ServerUser_Post()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SerUserPostID", "ServerUser_Post"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SerUserPostID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SerUserPostID", SqlDbType.Int,4)
			};
            parameters[0].Value = SerUserPostID;

            int result = DbHelperSQL.RunProcedure("ServerUser_Post_Exists", parameters, out rowsAffected);
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
        public int Add(ZhongLi.Model.ServerUser_Post model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SerUserPostID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@Scale", SqlDbType.NVarChar,50),
					new SqlParameter("@Nature", SqlDbType.NVarChar,50),
					new SqlParameter("@PostName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostDuty", SqlDbType.NVarChar,-1),
					new SqlParameter("@Salary", SqlDbType.NVarChar,500),
					new SqlParameter("@DevelopProspect", SqlDbType.NVarChar,-1),
					new SqlParameter("@DirectLeader", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkAdress", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@WelfareTag", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyMatching", SqlDbType.NVarChar,500),
					new SqlParameter("@OtherPoint", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@IsSole", SqlDbType.Int,4),
					new SqlParameter("@ComImg", SqlDbType.NVarChar,500),
					new SqlParameter("@SeeCount", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.SerUserID;
            parameters[2].Value = model.Company;
            parameters[3].Value = model.Trade;
            parameters[4].Value = model.Scale;
            parameters[5].Value = model.Nature;
            parameters[6].Value = model.PostName;
            parameters[7].Value = model.PostDuty;
            parameters[8].Value = model.Salary;
            parameters[9].Value = model.DevelopProspect;
            parameters[10].Value = model.DirectLeader;
            parameters[11].Value = model.WorkAdress;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.WelfareTag;
            parameters[14].Value = model.CompanyMatching;
            parameters[15].Value = model.OtherPoint;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.Colvalue;
            parameters[18].Value = model.IsSole;
            parameters[19].Value = model.ComImg;
            parameters[20].Value = model.SeeCount;

            DbHelperSQL.RunProcedure("ServerUser_Post_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(ZhongLi.Model.ServerUser_Post model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SerUserPostID", SqlDbType.Int,4),
					new SqlParameter("@SerUserID", SqlDbType.Int,4),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Trade", SqlDbType.NVarChar,50),
					new SqlParameter("@Scale", SqlDbType.NVarChar,50),
					new SqlParameter("@Nature", SqlDbType.NVarChar,50),
					new SqlParameter("@PostName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostDuty", SqlDbType.NVarChar,-1),
					new SqlParameter("@Salary", SqlDbType.NVarChar,500),
					new SqlParameter("@DevelopProspect", SqlDbType.NVarChar,-1),
					new SqlParameter("@DirectLeader", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkAdress", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@WelfareTag", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyMatching", SqlDbType.NVarChar,500),
					new SqlParameter("@OtherPoint", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Colvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@IsSole", SqlDbType.Int,4),
					new SqlParameter("@ComImg", SqlDbType.NVarChar,500),
					new SqlParameter("@SeeCount", SqlDbType.Int,4)};
            parameters[0].Value = model.SerUserPostID;
            parameters[1].Value = model.SerUserID;
            parameters[2].Value = model.Company;
            parameters[3].Value = model.Trade;
            parameters[4].Value = model.Scale;
            parameters[5].Value = model.Nature;
            parameters[6].Value = model.PostName;
            parameters[7].Value = model.PostDuty;
            parameters[8].Value = model.Salary;
            parameters[9].Value = model.DevelopProspect;
            parameters[10].Value = model.DirectLeader;
            parameters[11].Value = model.WorkAdress;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.WelfareTag;
            parameters[14].Value = model.CompanyMatching;
            parameters[15].Value = model.OtherPoint;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.Colvalue;
            parameters[18].Value = model.IsSole;
            parameters[19].Value = model.ComImg;
            parameters[20].Value = model.SeeCount;

            DbHelperSQL.RunProcedure("ServerUser_Post_Update", parameters, out rowsAffected);
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
        public bool Delete(int SerUserPostID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SerUserPostID", SqlDbType.Int,4)
			};
            parameters[0].Value = SerUserPostID;

            DbHelperSQL.RunProcedure("ServerUser_Post_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string SerUserPostIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServerUser_Post ");
            strSql.Append(" where SerUserPostID in (" + SerUserPostIDlist + ")  ");
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
        public ZhongLi.Model.ServerUser_Post GetModel(int SerUserPostID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SerUserPostID", SqlDbType.Int,4)
			};
            parameters[0].Value = SerUserPostID;

            ZhongLi.Model.ServerUser_Post model = new ZhongLi.Model.ServerUser_Post();
            DataSet ds = DbHelperSQL.RunProcedure("ServerUser_Post_GetModel", parameters, "ds");
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
        public ZhongLi.Model.ServerUser_Post DataRowToModel(DataRow row)
        {
            ZhongLi.Model.ServerUser_Post model = new ZhongLi.Model.ServerUser_Post();
            if (row != null)
            {
                if (row["SerUserPostID"] != null && row["SerUserPostID"].ToString() != "")
                {
                    model.SerUserPostID = int.Parse(row["SerUserPostID"].ToString());
                }
                if (row["SerUserID"] != null && row["SerUserID"].ToString() != "")
                {
                    model.SerUserID = int.Parse(row["SerUserID"].ToString());
                }
                if (row["Company"] != null)
                {
                    model.Company = row["Company"].ToString();
                }
                if (row["Trade"] != null)
                {
                    model.Trade = row["Trade"].ToString();
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
                if (row["CompanyMatching"] != null)
                {
                    model.CompanyMatching = row["CompanyMatching"].ToString();
                }
                if (row["OtherPoint"] != null)
                {
                    model.OtherPoint = row["OtherPoint"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Colvalue"] != null)
                {
                    model.Colvalue = row["Colvalue"].ToString();
                }
                if (row["IsSole"] != null && row["IsSole"].ToString() != "")
                {
                    model.IsSole = int.Parse(row["IsSole"].ToString());
                }
                if (row["ComImg"] != null)
                {
                    model.ComImg = row["ComImg"].ToString();
                }
                if (row["SeeCount"] != null && row["SeeCount"].ToString() != "")
                {
                    model.SeeCount = int.Parse(row["SeeCount"].ToString());
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
            strSql.Append("select SerUserPostID,SerUserID,Company,Trade,Scale,Nature,PostName,PostDuty,Salary,DevelopProspect,DirectLeader,WorkAdress,Address,WelfareTag,CompanyMatching,OtherPoint,CreateTime,Colvalue,IsSole,ComImg,SeeCount ");
            strSql.Append(" FROM ServerUser_Post ");
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
            strSql.Append(" SerUserPostID,SerUserID,Company,Trade,Scale,Nature,PostName,PostDuty,Salary,DevelopProspect,DirectLeader,WorkAdress,Address,WelfareTag,CompanyMatching,OtherPoint,CreateTime,Colvalue,IsSole,ComImg,SeeCount ");
            strSql.Append(" FROM ServerUser_Post ");
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
			strSql.Append("select count(1) FROM ServerUser_Post ");
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCountPost(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM View_ServerUser_Post ");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by " + orderby );
			}
			else
			{
				strSql.Append("order by T.SerUserPostID desc");
			}
            strSql.Append(")AS Row, T.*  from View_ServerUser_Post T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex,string Key)
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
                strSql.Append("order by T.SerUserPostID desc");
            }
            strSql.Append(")AS Row, T.*  from ServerUser_Post T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter para = new SqlParameter("@Key",Key);
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
			parameters[0].Value = "ServerUser_Post";
			parameters[1].Value = "SerUserPostID";
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
        /// 删除职位 判断职位是否已匹配悬赏 如果已匹配 则返回 1  否则删除成功返回0 删除失败返回2
        /// </summary>
        /// <param name="SerUserPostID"></param>
        /// <returns>0 1 2</returns>
        public int delSerUser_Post(int SerUserPostID)
        {
            int f= (int)DbHelperSQL.GetSingle("select count(1) from Person_Reward_Matching where SerPostID=" + SerUserPostID+" and State not in(2,5,7,9,10)");
            if (f > 0)
            {
                return 1;
            }
            else
            {
                return Delete(SerUserPostID)==true?0:2;
            }
        }
        public DataTable getPostSerUser(int PostID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sp.*,s.RealName,s.Company as SerCompany,s.PhotoImg,s.Position from ServerUser_Post as sp left join ServerUser as s on  s.SerUserID=sp.SerUserID where sp.SerUserPostID=@PostID");
            return DbHelperSQL.Query(strSql.ToString(),new SqlParameter("@PostID",PostID)).Tables[0];
        }
        /// <summary>
        /// 修改排序
        /// </summary>
        /// <param name="SerUserPostID"></param>
        /// <param name="Sort"></param>
        public void UpdateSort(int SerUserPostID,int Sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServerUser_Post set Colvalue='"+Sort+"' where SerUserPostID="+SerUserPostID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 设置成独家岗位
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool setSole(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser_Post set IsSole=1 where SerUserPostID in ({0})",ids);
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(strSql.ToString()))>0;
        }

        /// <summary>
        /// 取消独家岗位
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool delSole(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser_Post set IsSole=2 where SerUserPostID in ({0})", ids);
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(strSql.ToString())) > 0;
        }
        /// <summary>
        /// 首页职位
        /// </summary>
        /// <param name="ExpectWork"></param>
        /// <returns></returns>
        public DataSet HomePagePost(int PerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 3 Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from View_ServerUser_Post where IsSole=1 order by Convert(int,ColValue),CreateTime desc;");
            if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from Person_ExpectWork where PerID=" + PerID + "")) > 0)
            {
                strSql.AppendFormat("select top 5 Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from View_ServerUser_Post where PostName=(select ExpectedPostion from Person_ExpectWork where PerID={0}) order by CreateTime desc;", PerID);
                strSql.Append("select top 5 Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from View_ServerUser_Post where IsSole=2 order by NEWID(), CreateTime desc");
            }
            else
            {
                strSql.Append("select top 5 Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from View_ServerUser_Post where IsSole=2 order by NEWID(), CreateTime desc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 首页个性推荐职位 上拉刷新
        /// </summary>
        /// <param name="PerID"></param>
        /// <param name="Salary"></param>
        /// <param name="ComMat"></param>
        /// <param name="PageIndex"></param>
        /// <param name="NotIn"></param>
        /// <returns></returns>
        public DataTable HomePagePersonPost(int PerID,string Salary,string ComMat,int PageIndex,string NotIn)
        {
            string[] ComMats = ComMat.Split(',');
            string MatWhere = " IsSole=2";
            if (Salary != "")
            {
                MatWhere += " and Salary='" + Salary + "'";
            }
            if (ComMat != "")
            {
                foreach (string mat in ComMats)
                {
                    MatWhere += " and CompanyMatching like '%" + mat + "%'";
                }
            }
            StringBuilder strSql = new StringBuilder();
            if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from Person_ExpectWork where PerID=" + PerID + "")) > 0)//判断是否填了期望职位
            {
                int count = Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from ServerUser_Post where PostName=(select ExpectedPostion from Person_ExpectWork where PerID=" + PerID + ")"));
                if (count > 0)//判断当前期望职位是否有职位
                {
                    MatWhere += " and PostName=(select ExpectedPostion from Person_ExpectWork where PerID=" + PerID + ")";
                    return HomeExpectPost(MatWhere, PageIndex);
                }
                else
                {
                    return HomeRandomPost(MatWhere,NotIn);
                }
            }
            else
            {
                return HomeRandomPost(MatWhere, NotIn);
            }
        }
        /// <summary>
        /// 首页期望职位  筛选
        /// </summary>
        /// <param name="where"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        private DataTable HomeExpectPost(string where,int PageIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.CreateTime desc");
            strSql.Append(")AS Row, Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from ServerUser_Post T ");
            strSql.Append(" WHERE " + where);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (PageIndex-1)*5+1, PageIndex*5);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 首页 随机职位推荐
        /// </summary>
        /// <returns></returns>
        private DataTable HomeRandomPost(string where,string NotIn)
        {
            StringBuilder strSql = new StringBuilder();
            if (NotIn != "")
            {
                where += " and SerUserPostID not in (" + NotIn + ")";
            }
            strSql.Append("select top 5 Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from View_ServerUser_Post where "+where+" order by NEWID(), CreateTime desc");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 人才经纪人首页3条职位
        /// </summary>
        /// <param name="SerUserID"></param>
        /// <returns></returns>
        public DataTable HomeMyPost(int SerUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top 3 *,(select count(1) from Person_Reward_Matching where SerPostID=ServerUser_Post.SerUserPostID and state not in(0,2)) as matCount from ServerUser_Post where SerUserID={0}", SerUserID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 职位浏览量+1
        /// </summary>
        /// <param name="SerUserPostID"></param>
        public void PostSeeCount(int SerUserPostID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update ServerUser_Post set SeeCount+=1 where SerUserPostID={0} ",SerUserPostID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 判断职位是否正在进行中
        /// </summary>
        /// <param name="PostID"></param>
        /// <returns></returns>
        public bool checkPost(int PostID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from Person_Reward_Matching where SerPostID={0} and State in (1,4,6,8)",PostID);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString())) <= 0;
        }
        /// <summary>
        /// 更多独家职位
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable moreSolePost(int PageIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.CreateTime desc");
            strSql.Append(")AS Row, Company,PostName,PhotoImg,SerUserPostID,SerUserID,Salary,Trade,ComImg,SeeCount,WorkAdress from View_ServerUser_Post T ");
            strSql.Append(" WHERE IsSole=1");
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (PageIndex - 1) * 10 + 1, PageIndex * 10);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
		#endregion  MethodEx
	}
}

