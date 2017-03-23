using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// Person_Representations:申述(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Person_Representations
	{
		public Person_Representations()
		{}
		#region Model
		private int _id;
		private int? _perid;
		private string _realname;
		private string _ordernum;
		private string _reason;
		private DateTime? _createtime;
		private int? _state;
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
		public int? PerID
		{
			set{ _perid=value;}
			get{return _perid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 订单编号
		/// </summary>
		public string OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 申述理由
		/// </summary>
		public string Reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 申述状态 0待审核 1通过  2驳回
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

