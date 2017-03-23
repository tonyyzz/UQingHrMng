using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// JobTraining:职业培训表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JobTraining
	{
        public JobTraining()
        { }
        #region Model
        private int _jobtraid;
        private string _jobtratype;
        private string _jobtraname;
        private string _phone;
        private string _jobtrades;
        private int? _sort;
        private string _imgurl;
        private string _absdes;
        private string _jobtratitle;
        /// <summary>
        /// ID
        /// </summary>
        public int JobTraID
        {
            set { _jobtraid = value; }
            get { return _jobtraid; }
        }
        /// <summary>
        /// 职业培训类型   企业    个人
        /// </summary>
        public string JobTraType
        {
            set { _jobtratype = value; }
            get { return _jobtratype; }
        }
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string JobTraName
        {
            set { _jobtraname = value; }
            get { return _jobtraname; }
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
        /// 职业培训描述
        /// </summary>
        public string JobTraDes
        {
            set { _jobtrades = value; }
            get { return _jobtrades; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Imgurl
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
        /// <summary>
        /// 职业培训单位标题
        /// </summary>
        public string JobTraTitle
        {
            set { _jobtratitle = value; }
            get { return _jobtratitle; }
        }
        #endregion Model
	}
}

