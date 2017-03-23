using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// FeedBack:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class FeedBack
    {
        public FeedBack()
        { }
        #region Model
        private int _id;
        private int? _userid;
        private string _username;
        private int? _usertype;
        private string _con;
        private DateTime? _createtime;
        private int? _state;
        private string _colvalue;
        private string _colvalue2;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 0求职者1经纪人
        /// </summary>
        public int? UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Con
        {
            set { _con = value; }
            get { return _con; }
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
        /// 0未读1已读
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColValue
        {
            set { _colvalue = value; }
            get { return _colvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColValue2
        {
            set { _colvalue2 = value; }
            get { return _colvalue2; }
        }
        #endregion Model

    }
}

