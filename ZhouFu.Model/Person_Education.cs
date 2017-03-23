using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// Person_Education:教育经历(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Person_Education
	{
		public Person_Education()
		{}
		#region Model
		private int _pereduid;
		private int? _perid;
		private string _schoolname;
		private string _major;
		private string _graduationyear;
		private string _education;
		private DateTime? _createtime;
		private string _colvalue;
		/// <summary>
		/// 
		/// </summary>
		public int PerEduID
		{
			set{ _pereduid=value;}
			get{return _pereduid;}
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
		/// 学校名称
		/// </summary>
		public string SchoolName
		{
			set{ _schoolname=value;}
			get{return _schoolname;}
		}
		/// <summary>
		/// 所学专业
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 毕业年份
		/// </summary>
		public string GraduationYear
		{
			set{ _graduationyear=value;}
			get{return _graduationyear;}
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
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
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

