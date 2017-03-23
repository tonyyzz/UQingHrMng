using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// ChatReacord:求职者和职业介绍人交流表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ChatReacord
	{
		public ChatReacord()
		{}
		#region Model
		private int _chatrecordid;
		private int? _perid;
		private int? _seruserid;
		private int? _sendtype;
		private string _sendcon;
		private DateTime? _sendtime;
		private int? _contype;
		/// <summary>
		/// 
		/// </summary>
		public int ChatRecordID
		{
			set{ _chatrecordid=value;}
			get{return _chatrecordid;}
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
		public int? SerUserID
		{
			set{ _seruserid=value;}
			get{return _seruserid;}
		}
		/// <summary>
		/// 发送类型  0为求职者 1为服务商
		/// </summary>
		public int? SendType
		{
			set{ _sendtype=value;}
			get{return _sendtype;}
		}
		/// <summary>
		/// 聊天内容
		/// </summary>
		public string SendCon
		{
			set{ _sendcon=value;}
			get{return _sendcon;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 消息类型  ：0普通蚊子 1面试邀请 2 图片 3表情
		/// </summary>
		public int? ConType
		{
			set{ _contype=value;}
			get{return _contype;}
		}
		#endregion Model

	}
}

