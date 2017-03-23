using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// Person_Project:项目经历(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Person_Project
	{
		public Person_Project()
		{}
		#region Model
		private int _perproid;
		private int? _perid;
		private string _proname;
		private string _produty;
		private string _starttime;
		private string _endtime;
		private string _prodes;
		private string _prolink;
		private string _colvalue;
		/// <summary>
		/// 
		/// </summary>
		public int PerProID
		{
			set{ _perproid=value;}
			get{return _perproid;}
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
		/// 项目名称
		/// </summary>
		public string ProName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 你的职责
		/// </summary>
		public string ProDuty
		{
			set{ _produty=value;}
			get{return _produty;}
		}
		/// <summary>
		/// 项目开始时间
		/// </summary>
		public string StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 项目结束时间
		/// </summary>
		public string EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 项目描述
		/// </summary>
		public string ProDes
		{
			set{ _prodes=value;}
			get{return _prodes;}
		}
		/// <summary>
		/// 项目链接（若有）
		/// </summary>
		public string ProLink
		{
			set{ _prolink=value;}
			get{return _prolink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Colvalue
		{
			set{ _colvalue=value;}
			get{return _colvalue;}
		}
		#endregion Model

	}
}

