
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using ZhongLi.Common;
using System.Collections.Generic;//Please add references
namespace ZhongLi.Dal
{
	public partial class sys_Dictionary
	{
		public sys_Dictionary()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("ID", "sys_Dictionary"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_Dictionary");
            strSql.Append(" where ID=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhongLi.Model.sys_Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_Dictionary(");
            strSql.Append("DtyName,ParentId,Sort,EdtyName,Remark,Filepath)");
			strSql.Append(" values (");
            strSql.Append("@DtyName,@ParentId,@Sort,@EdtyName,@Remark,@Filepath)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DtyName", SqlDbType.NVarChar,20),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@EdtyName", SqlDbType.VarChar,20),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Filepath", SqlDbType.VarChar,300)            
                                        };
			parameters[0].Value = model.DtyName;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.Sort;
			parameters[3].Value = model.EdtyName;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.Filepath;
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.sys_Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_Dictionary set ");
			strSql.Append("DtyName=@DtyName,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("Sort=@Sort,");
			strSql.Append("EdtyName=@EdtyName,");
            strSql.Append("Filepath=@Filepath,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@DtyName", SqlDbType.NVarChar,20),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@EdtyName", SqlDbType.VarChar,20),
                    new SqlParameter("@Filepath", SqlDbType.VarChar,300),    
                    new SqlParameter("@Remark",SqlDbType.Text),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.DtyName;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.Sort;
			parameters[3].Value = model.EdtyName;
            parameters[4].Value = model.Filepath;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_Dictionary ");
            strSql.Append(" where ID=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_Dictionary ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
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
		public ZhongLi.Model.sys_Dictionary GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,DtyName,ParentId,Sort,EdtyName,Remark,Filepath from sys_Dictionary ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			ZhongLi.Model.sys_Dictionary model=new ZhongLi.Model.sys_Dictionary();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public ZhongLi.Model.sys_Dictionary DataRowToModel(DataRow row)
		{
			ZhongLi.Model.sys_Dictionary model=new ZhongLi.Model.sys_Dictionary();
			if (row != null)
			{
                if (row["ID"] != null && row["ID"].ToString() != "")
				{
                    model.ID = int.Parse(row["ID"].ToString());
				}
				if(row["DtyName"]!=null)
				{
					model.DtyName=row["DtyName"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(row["ParentId"].ToString());
				}
				if(row["Sort"]!=null && row["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(row["Sort"].ToString());
				}
				if(row["EdtyName"]!=null)
				{
					model.EdtyName=row["EdtyName"].ToString();
				}
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Filepath"] != null)
                {
                    model.Filepath = row["Filepath"].ToString();
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
            strSql.Append("select ID,DtyName,ParentId,Sort,EdtyName,Remark,Filepath ");
            strSql.Append(" FROM sys_Dictionary");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" ID,DtyName,ParentId,Sort,EdtyName,Remark,Filepath ");
			strSql.Append(" FROM sys_Dictionary ");
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
			strSql.Append("select count(1) FROM sys_Dictionary ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from sys_Dictionary T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}



        /// <summary>
        /// 获取模板地址
        /// </summary>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_Dictionary> GetTempletUrlList()
        {
            string sql = "select ID,DtyName as TempletUrl from dbo.sys_Dictionary where ParentId='268'";
            DataTable dt = DbHelperSQL.ExecuteDataTable(sql, CommandType.Text);
            List<ZhongLi.Model.sys_Dictionary> list = new List<Model.sys_Dictionary>();
            foreach (DataRow row in dt.Rows)
            {
                ZhongLi.Model.sys_Dictionary TempletUrl = new Model.sys_Dictionary();
                TempletUrl.ID = Convert.ToInt32(row["ID"]);
                TempletUrl.DtyName = row["TempletUrl"].ToString();
                list.Add(TempletUrl);
            }
            return list;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM sys_Dictionary where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 根据where条件查询数据集合
        /// </summary>
        public IList<ZhongLi.Model.sys_Dictionary> GetListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM sys_Dictionary ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetDataTable(strSql.ToString());
            IList<ZhongLi.Model.sys_Dictionary> list = null;
            if (dt.Rows.Count > 0)
            {
                list = Table2List(dt);
            }
            return list;
        }


        /// <summary>
        /// a01.将数据表转换成泛型集合接口
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <returns>泛型集合接口</returns>
        public IList<ZhongLi.Model.sys_Dictionary> Table2List(DataTable dt)
        {
            List<ZhongLi.Model.sys_Dictionary> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ZhongLi.Model.sys_Dictionary>();
                ZhongLi.Model.sys_Dictionary model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ZhongLi.Model.sys_Dictionary();
                    LoadEntityData(model, dr);
                    list.Add(model);
                }
                return list;
            }
            return null;
        }


        /// <summary>
        /// 加载实体数据(将行数据装入实体对象中)
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="dr">数据行</param>
        public void LoadEntityData(ZhongLi.Model.sys_Dictionary model, DataRow dr)
        {
            if (dr.Table.Columns.Contains("ID") && !dr.IsNull("ID"))
            {
                model.ID = int.Parse(dr["ID"].ToString());
            }

            if (dr.Table.Columns.Contains("ParentId") && !dr.IsNull("ParentId"))
            {
                model.ParentId = int.Parse(dr["ParentId"].ToString());
            }

            if (dr.Table.Columns.Contains("DtyName") && !dr.IsNull("DtyName"))
            {
                model.DtyName = dr["DtyName"].ToString();
            }

            if (dr.Table.Columns.Contains("EdtyName") && !dr.IsNull("EdtyName"))
            {
                model.EdtyName = dr["EdtyName"].ToString();
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                model.Remark = dr["Remark"].ToString();
            }

            if (dr.Table.Columns.Contains("Sort") && !dr.IsNull("Sort"))
            {
                model.Sort = int.Parse(dr["Sort"].ToString());
            }
            if (dr.Table.Columns.Contains("Filepath") && !dr.IsNull("Filepath"))
            {
                model.Filepath = dr["Filepath"].ToString();
            }
        }

        /// <summary>
        /// 调用存储过程删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int RunDelete(int id, out int count)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = id;
            return DbHelperSQL.RunProcedure("DeleteNoteByDic", parameters, out count);

        }

        /// <summary>
        /// 获取sys_Model集合
        /// </summary>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_Dictionary> GetModelList()
        {
            string sql = "select * from sys_Dictionary";
            DataTable dt = DbHelperSQL.GetDataTable(sql);
            List<ZhongLi.Model.sys_Dictionary> list = new List<ZhongLi.Model.sys_Dictionary>();
            foreach (DataRow row in dt.Rows)
            {
                ZhongLi.Model.sys_Dictionary model = new ZhongLi.Model.sys_Dictionary();
                model.ID = Convert.ToInt32(row["ID"]);
                model.DtyName = row["DtyName"].ToString();
                model.ParentId = Convert.ToInt32(row["ParentId"]);
                model.Sort = Convert.ToInt32(row["Sort"]);
                model.EdtyName = row["EdtyName"].ToString();
                model.Remark = row["Remark"].ToString();
                model.Filepath = row["Filepath"].ToString();
                list.Add(model);
            }
            return list;

        }

		#endregion  ExtensionMethod
	}
}

