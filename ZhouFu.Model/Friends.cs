using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// Friends:职业介绍人和求职者好友表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Friends
	{
		public Friends()
		{}
		#region Model
		private int _perid;
		private int _seruserid;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int PerID
		{
			set{ _perid=value;}
			get{return _perid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SerUserID
		{
			set{ _seruserid=value;}
			get{return _seruserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

