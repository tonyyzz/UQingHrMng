using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// Person:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Person
    {
        public Person()
        { }
        #region Model
        private int _perid;
        private string _realname;
        private string _phne;
        private string _password;
        private bool _sex;
        private string _education;
        private string _worklife;
        private string _birth;
        private string _email;
        private string _city;
        private string _onedes;
        private string _photo;
        private int? _flag;
        private string _authimg;
        private DateTime? _authtime;
        private string _mydes;
        private decimal? _balance;
        private DateTime? _regtime;
        private string _phonecode;
        private DateTime? _codetime;
        private string _imopenid;
        private string _wxopenid;
        private int? _seruserid;
        private string _qqopenid;
        private string _wbopenid;
        /// <summary>
        /// 
        /// </summary>
        public int PerID
        {
            set { _perid = value; }
            get { return _perid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phne
        {
            set { _phne = value; }
            get { return _phne; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 工作年限
        /// </summary>
        public string WorkLife
        {
            set { _worklife = value; }
            get { return _worklife; }
        }
        /// <summary>
        /// 出生年月  例：1990.1
        /// </summary>
        public string Birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 一句话描述
        /// </summary>
        public string OneDes
        {
            set { _onedes = value; }
            get { return _onedes; }
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 审核 1:已审核  0：未审核
        /// </summary>
        public int? Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 认证图片
        /// </summary>
        public string AuthImg
        {
            set { _authimg = value; }
            get { return _authimg; }
        }
        /// <summary>
        /// 认证通过时间
        /// </summary>
        public DateTime? AuthTime
        {
            set { _authtime = value; }
            get { return _authtime; }
        }
        /// <summary>
        /// 我的描述
        /// </summary>
        public string MyDes
        {
            set { _mydes = value; }
            get { return _mydes; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal? Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RegTime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneCode
        {
            set { _phonecode = value; }
            get { return _phonecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CodeTime
        {
            set { _codetime = value; }
            get { return _codetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImOpenID
        {
            set { _imopenid = value; }
            get { return _imopenid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WxOpenID
        {
            set { _wxopenid = value; }
            get { return _wxopenid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SerUserID
        {
            set { _seruserid = value; }
            get { return _seruserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQOpenID
        {
            set { _qqopenid = value; }
            get { return _qqopenid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WbOpenID
        {
            set { _wbopenid = value; }
            get { return _wbopenid; }
        }
        #endregion Model

    }
}

