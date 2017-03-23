using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// ServerUser_Education:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServerUser_Education
	{
		public ServerUser_Education()
		{}
		#region Model
		private int _serusereduid;
		private int? _seruserid;
		private string _schoolname;
		private string _major;
		private string _education;
		private string _starttime;
		private string _endtime;
		private string _edudes;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int SerUserEduID
		{
			set{ _serusereduid=value;}
			get{return _serusereduid;}
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
		public string SchoolName
		{
			set{ _schoolname=value;}
			get{return _schoolname;}
		}
		/// <summary>
		/// 专业
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string Education
		{
			set{ _education=value;}
			get{return _education;}
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
		/// 教育经历描述
		/// </summary>
		public string EduDes
		{
			set{ _edudes=value;}
			get{return _edudes;}
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

