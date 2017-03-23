using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// TransactionRecord:求职者和职业介绍人 交易记录表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TransactionRecord
	{
		public TransactionRecord()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private string _recordtype;
		private decimal? _money;
		private DateTime? _recordtime;
		private int? _usertype;
		private string _realname;
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
		/// 记录类型  悬赏 提现等等
		/// </summary>
		public string RecordType
		{
			set{ _recordtype=value;}
			get{return _recordtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 交易时间
		/// </summary>
		public DateTime? RecordTime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 用户类型  0 求职者 1服务商
		/// </summary>
		public int? UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		#endregion Model

	}
}

