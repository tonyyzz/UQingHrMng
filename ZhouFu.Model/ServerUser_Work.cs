using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// ServerUser_Work:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServerUser_Work
	{
		public ServerUser_Work()
		{}
		#region Model
		private int _seruserworkid;
		private int? _seruserid;
		private string _company;
		private string _position;
		private string _starttime;
		private string _endtime;
		private string _workdes;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int SerUserWorkID
		{
			set{ _seruserworkid=value;}
			get{return _seruserworkid;}
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
		/// 
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkDes
		{
			set{ _workdes=value;}
			get{return _workdes;}
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

