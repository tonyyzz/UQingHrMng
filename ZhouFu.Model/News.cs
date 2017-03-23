using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// News:内容管理表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class News
	{
        public News()
        { }
        #region Model
        private int _newsid;
        private string _title;
        private DateTime? _createtime;
        private string _newscon;
        private bool _hot;
        private int? _newstype;
        private string _imgurl;
        private string _absdes;
        /// <summary>
        /// 
        /// </summary>
        public int NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsCon
        {
            set { _newscon = value; }
            get { return _newscon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Hot
        {
            set { _hot = value; }
            get { return _hot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? NewsType
        {
            set { _newstype = value; }
            get { return _newstype; }
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

