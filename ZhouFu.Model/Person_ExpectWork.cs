using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// Person_ExpectWork:期望工作(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Person_ExpectWork
	{
		public Person_ExpectWork()
		{}
		#region Model
		private int _perexid;
		private int? _perid;
		private string _expectedpostion;
		private string _worktype;
		private string _excity;
		private string _exsalary;
		private string _remark;
		private DateTime? _createtime;
		private string _colvalue;
		/// <summary>
		/// 
		/// </summary>
		public int PerExID
		{
			set{ _perexid=value;}
			get{return _perexid;}
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
		/// 期望职位
		/// </summary>
		public string ExpectedPostion
		{
			set{ _expectedpostion=value;}
			get{return _expectedpostion;}
		}
		/// <summary>
		/// 工作类型  全职 兼职 实习
		/// </summary>
		public string WorkType
		{
			set{ _worktype=value;}
			get{return _worktype;}
		}
		/// <summary>
		/// 期望城市
		/// </summary>
		public string ExCity
		{
			set{ _excity=value;}
			get{return _excity;}
		}
		/// <summary>
		/// 期望薪水
		/// </summary>
		public string ExSalary
		{
			set{ _exsalary=value;}
			get{return _exsalary;}
		}
		/// <summary>
		/// 补充说明
		/// </summary>
		public string ReMark
		{
			set{ _remark=value;}
			get{return _remark;}
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

