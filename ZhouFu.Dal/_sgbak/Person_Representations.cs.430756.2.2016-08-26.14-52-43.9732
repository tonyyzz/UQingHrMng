using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using System.Collections.Generic;//Please add references
namespace ZhongLi.DAL
{
	/// <summary>
	/// 数据访问类:Person_Representations
	/// </summary>
	public partial class Person_Representations
	{
		public Person_Representations()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Person_Representations"); 
		}

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

			int result= DbHelperSQL.RunProcedure("Person_Representations_Exists",parameters,out rowsAffected);
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
		public int Add(ZhongLi.Model.Person_Representations model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNum", SqlDbType.NVarChar,50),
					new SqlParameter("@Reason", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.PerID;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.OrderNum;
			parameters[4].Value = model.Reason;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.State;

			DbHelperSQL.RunProcedure("Person_Representations_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.Person_Representations model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PerID", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNum", SqlDbType.NVarChar,50),
					new SqlParameter("@Reason", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PerID;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.OrderNum;
			parameters[4].Value = model.Reason;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.State;

			DbHelperSQL.RunProcedure("Person_Representations_Update",parameters,out rowsAffected);
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
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			DbHelperSQL.RunProcedure("Person_Representations_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Person_Representations ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public ZhongLi.Model.Person_Representations GetModel(int ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			ZhongLi.Model.Person_Representations model=new ZhongLi.Model.Person_Representations();
			DataSet ds= DbHelperSQL.RunProcedure("Person_Representations_GetModel",parameters,"ds");
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
		public ZhongLi.Model.Person_Representations DataRowToModel(DataRow row)
		{
			ZhongLi.Model.Person_Representations model=new ZhongLi.Model.Person_Representations();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PerID"]!=null && row["PerID"].ToString()!="")
				{
					model.PerID=int.Parse(row["PerID"].ToString());
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["OrderNum"]!=null)
				{
					model.OrderNum=row["OrderNum"].ToString();
				}
				if(row["Reason"]!=null)
				{
					model.Reason=row["Reason"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
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
			strSql.Append("select ID,PerID,RealName,OrderNum,Reason,CreateTime,State ");
			strSql.Append(" FROM Person_Representations ");
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
			strSql.Append(" ID,PerID,RealName,OrderNum,Reason,CreateTime,State ");
			strSql.Append(" FROM Person_Representations ");
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM View_Representations ");
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
				strSql.Append("order by T.ID desc");
			}
            strSql.Append(")AS Row, T.*  from View_Representations T ");
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
			parameters[0].Value = "Person_Representations";
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
        /// 修改申述状态
        /// </summary>
        /// <param name="State">状态值 1 通过 2 驳回</param>
        /// <param name="ID">主键ID</param>
        public void EditState(int State,int ID)
        {
            string sql = "update Person_Representations set State ="+State+" where ID="+ID;
            DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 根据申述ID 申述通过时修改用户余额
        /// </summary>
        /// <param name="ID"></param>
        public void EditPerBla(int ID)
        {
            string sql = "update Person set Balance=Balance+(select RewardMoney from View_Representations where ID =" + ID + ") where PerID=(select PerID from Person_Representations where ID="+ID+")";
            DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到申述 用户 金额 订单编号 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet GetInfo(int ID)
        {
            string sql = "select PerID,RealName,RewardMoney,OrderNum from View_Representations where ID="+ID;
            return DbHelperSQL.Query(sql);
        }

        public bool AuthPass(int ID)
        {
            DataSet ds = GetInfo(ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr=ds.Tables[0].Rows[0];
                List<CommandInfo> list = new List<CommandInfo>();
                //修改状态
                CommandInfo c1 = new CommandInfo();
                c1.CommandText = "update Person_Representations set State =1 where ID=@ID";
                SqlParameter[] para1 = { new SqlParameter("@ID",ID)};
                c1.Parameters = para1;
                list.Add(c1);
                //修改金额
                CommandInfo c2 = new CommandInfo();
                c2.CommandText = "update Person set Balance=Balance+@RewardMoney where PerID=@PerID";
                SqlParameter[] para2 = { new SqlParameter("@RewardMoney", dr["RewardMoney"]), new SqlParameter("@PerID",dr["PerID"]) };
                c2.Parameters = para2;
                list.Add(c2);
                CommandInfo c3 = new CommandInfo();
                c3.CommandText = "insert into TransactionRecord values(@UserID,@RecordType,@Money,@RecordTime,@UserType,@RealName)";
                SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RecordType", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@RecordTime", SqlDbType.DateTime),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50)};
                parameters[0].Value = dr["PerID"];
                parameters[1].Value = "申述";
                parameters[2].Value = (decimal)dr["RewardMoney"];
                parameters[3].Value = DateTime.Now;
                parameters[4].Value = 0;
                parameters[5].Value = dr["RealName"];
                c3.Parameters = parameters;
                list.Add(c3);
                return DbHelperSQL.ExecuteSqlTranWithIndentity(list) > 0;
            }
            return false;
        }

		#endregion  MethodEx
	}
}

