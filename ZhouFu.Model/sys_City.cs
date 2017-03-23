/**  版本信息模板在安装目录下，可自行修改。
* sys_City.cs
*
* 功 能： N/A
* 类 名： sys_City
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/6 14:56:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// sys_City:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_City
	{
		public sys_City()
		{}
		#region Model
		private string _code;
		private string _province;
		private string _city;
		private string _county;
		private int? _citylevel;
		private string _cityzip;
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string county
		{
			set{ _county=value;}
			get{return _county;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityLevel
		{
			set{ _citylevel=value;}
			get{return _citylevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CityZip
		{
			set{ _cityzip=value;}
			get{return _cityzip;}
		}
		#endregion Model

	}
}

