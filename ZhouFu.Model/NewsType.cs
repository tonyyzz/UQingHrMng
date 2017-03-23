using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// NewsType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsType
	{
		public NewsType()
		{}
		#region Model
		private int _newstypeid;
		private string _name;
		private DateTime? _createtime;
		private string _colvalue;
		/// <summary>
		/// 
		/// </summary>
		public int NewsTypeID
		{
			set{ _newstypeid=value;}
			get{return _newstypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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

