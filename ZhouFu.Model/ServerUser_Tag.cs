using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// ServerUser_Tag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServerUser_Tag
	{
		public ServerUser_Tag()
		{}
		#region Model
		private int _serusertagid;
		private int? _seruserid;
		private string _tagname;
		private string _colvalue;
		/// <summary>
		/// 
		/// </summary>
		public int SerUserTagID
		{
			set{ _serusertagid=value;}
			get{return _serusertagid;}
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
		public string TagName
		{
			set{ _tagname=value;}
			get{return _tagname;}
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

