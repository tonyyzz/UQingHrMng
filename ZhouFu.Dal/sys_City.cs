
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZhongLi.DBUtility;
using System.Collections.Generic;//Please add references
namespace ZhongLi.Dal
{
	/// <summary>
	/// 数据访问类:sys_City
	/// </summary>
	public partial class sys_City
	{
		public sys_City()
		{}
		#region  BasicMethod



		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhongLi.Model.sys_City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_City set ");
			strSql.Append("Code=@Code,");
			strSql.Append("Province=@Province,");
			strSql.Append("City=@City,");
			strSql.Append("county=@county,");
			strSql.Append("CityLevel=@CityLevel,");
			strSql.Append("CityZip=@CityZip");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Province", SqlDbType.VarChar,50),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@county", SqlDbType.VarChar,50),
					new SqlParameter("@CityLevel", SqlDbType.Int,4),
					new SqlParameter("@CityZip", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Province;
			parameters[2].Value = model.City;
			parameters[3].Value = model.county;
			parameters[4].Value = model.CityLevel;
			parameters[5].Value = model.CityZip;

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
		/// 获得省份
		/// </summary>
        public List<ZhongLi.Model.sys_City> GetListProvince()
		{
            List<ZhongLi.Model.sys_City> list = new List<ZhongLi.Model.sys_City>();
            string sql = "select Code,Province from sys_City where LEN(Code)=2";
            DataTable dt = DbHelperSQL.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                ZhongLi.Model.sys_City city = new Model.sys_City();
                city.Code = row["Code"].ToString();
                city.Province = row["Province"].ToString();

                list.Add(city);
            }
            return list;
			
		}
        /// <summary>
        /// 获得城市
        /// </summary>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_City> GetListCity(string Code)
        {
           
            List<ZhongLi.Model.sys_City> list = new List<ZhongLi.Model.sys_City>();
            string sql = string.Format(" select * from sys_City where LEN(Code)=4 and Code like '{0}%'",Code);
            DataTable dt = DbHelperSQL.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                ZhongLi.Model.sys_City city = new Model.sys_City();
                city.Code = row["Code"].ToString();
                city.City = row["City"].ToString();

                list.Add(city);
            }
            return list;

        }
        /// <summary>
        /// 获取县区
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_City> GetListCounty(string Code)
        {

            List<ZhongLi.Model.sys_City> list = new List<ZhongLi.Model.sys_City>();
            string sql = string.Format("select * from sys_City where LEN(Code)=7 and Code like '{0}%'", Code);
            DataTable dt = DbHelperSQL.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                ZhongLi.Model.sys_City city = new Model.sys_City();
                city.Code = row["Code"].ToString();
                city.county = row["county"].ToString();

                list.Add(city);
            }
            return list;

        }




		#endregion  BasicMethod
		#region  ExtensionMethod


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Code,Province,City,county,CityLevel,CityZip ");
            strSql.Append(" FROM sys_City ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(string strWhere,string Fields)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select {0} ", Fields != "" ? Fields : "*");
            strSql.Append(" FROM sys_City ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }




		#endregion  ExtensionMethod
	}
}

