/**  版本信息模板在安装目录下，可自行修改。
* sys_Dictionary.cs
*
* 功 能： N/A
* 类 名： sys_Dictionary
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-28 17:18:02   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// sys_Dictionary:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_Dictionary
	{
		public sys_Dictionary()
		{}
		#region Model
		private int _id;
		private string _dtyname;
		private int _parentid;
		private int? _sort=10;
		private string _edtyname;
        private string _remark;

        public string Filepath { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ID 
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DtyName
		{
			set{ _dtyname=value;}
			get{return _dtyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdtyName
		{
			set{ _edtyname=value;}
			get{return _edtyname;}
		}
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark 
        {
            set { _remark = value; }
            get { return _remark; }
        }
		#endregion Model

	}
}

