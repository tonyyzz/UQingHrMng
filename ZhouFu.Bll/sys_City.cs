
using System;
using System.Data;
using System.Collections.Generic;

using ZhongLi.Model;
namespace ZhongLi.Bll
{
	/// <summary>
	/// sys_City
	/// </summary>
	public partial class sys_City
	{
        private readonly ZhongLi.Dal.sys_City dal = new ZhongLi.Dal.sys_City();
		public sys_City()
		{}
		#region  BasicMethod

		  /// <summary>
		/// 获得省份
		/// </summary>
        public List<ZhongLi.Model.sys_City> GetListProvince()
        {
            return dal.GetListProvince();
        }
        /// <summary>
        /// 获得城市
        /// </summary>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_City> GetListCity(string Code)
        {
            return dal.GetListCity(Code);
        }
         /// <summary>
        /// 获取县区
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public List<ZhongLi.Model.sys_City> GetListCounty(string Code)
        {
            return dal.GetListCounty(Code);
        }


		#endregion  BasicMethod
		#region  ExtensionMethod


        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetList(string strWhere, string Fields)
        {
            return dal.GetList(strWhere,Fields);
        }


		#endregion  ExtensionMethod
	}
}

