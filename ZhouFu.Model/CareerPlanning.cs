using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// CareerPlanning:职业规划单位表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CareerPlanning
	{
        public CareerPlanning()
        { }
        #region Model
        private int _cpid;
        private string _cptype;
        private string _cpname;
        private string _cptitle;
        private string _phone;
        private DateTime? _createtime;
        private string _cpdes;
        private int? _sort;
        private string _imgurl;
        private string _absdes;
        /// <summary>
        /// 
        /// </summary>
        public int CPID
        {
            set { _cpid = value; }
            get { return _cpid; }
        }
        /// <summary>
        /// 职业规划类型：1：企业  2：个人
        /// </summary>
        public string CPType
        {
            set { _cptype = value; }
            get { return _cptype; }
        }
        /// <summary>
        /// 职业规划名称
        /// </summary>
        public string CPName
        {
            set { _cpname = value; }
            get { return _cpname; }
        }
        /// <summary>
        /// 职业规划标题
        /// </summary>
        public string CPTitle
        {
            set { _cptitle = value; }
            get { return _cptitle; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 职业规划描述
        /// </summary>
        public string CPDes
        {
            set { _cpdes = value; }
            get { return _cpdes; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AbsDes
        {
            set { _absdes = value; }
            get { return _absdes; }
        }
        #endregion Model
	}
}

