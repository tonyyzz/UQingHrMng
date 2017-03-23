
using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// sys_logs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_Logs
	{
		public sys_Logs()
		{}
		#region Model
		private int _id;
		private int? _userid;
        private string _username;
		private string _remark;
		private string  _addtime;
		private string _ipaddress;
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
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName 
        {
            set { _username = value; }
            get { return _username; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string  AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IpAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		#endregion Model

	}
}

