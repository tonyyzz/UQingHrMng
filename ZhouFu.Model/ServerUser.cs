using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// ServerUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServerUser
    {
        public ServerUser()
        { }
        #region Model
        private int _seruserid;
        private string _realname;
        private bool _sex;
        private string _photoimg;
        private string _trade;
        private string _company;
        private string _position;
        private string _workcity;
        private string _address;
        private string _phone;
        private string _email;
        private string _describe;
        private string _idcardimg;
        private DateTime? _idcardtime;
        private int? _flag;
        private string _serimg;
        private DateTime? _sertime;
        private decimal? _balance;
        private DateTime? _regtime;
        private string _password;
        private int? _idcardstate;
        private int? _serimgstate;
        private string _imopenid;
        private string _wxopenid;
        private int? _perid;
        private string _qqopenid;
        private string _wbopenid;
        /// <summary>
        /// 
        /// </summary>
        public int SerUserID
        {
            set { _seruserid = value; }
            get { return _seruserid; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
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
        /// 头像
        /// </summary>
        public string PhotoImg
        {
            set { _photoimg = value; }
            get { return _photoimg; }
        }
        /// <summary>
        /// 行业
        /// </summary>
        public string Trade
        {
            set { _trade = value; }
            get { return _trade; }
        }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 工作地区
        /// </summary>
        public string WorkCity
        {
            set { _workcity = value; }
            get { return _workcity; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 自我介绍
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        /// <summary>
        /// 身份证认证图片
        /// </summary>
        public string IDCardImg
        {
            set { _idcardimg = value; }
            get { return _idcardimg; }
        }
        /// <summary>
        /// 认证时间
        /// </summary>
        public DateTime? IDCardTime
        {
            set { _idcardtime = value; }
            get { return _idcardtime; }
        }
        /// <summary>
        /// 用户状态  0：未认证  1：已认证身份证 2：已认证服务商身份
        /// </summary>
        public int? Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SerImg
        {
            set { _serimg = value; }
            get { return _serimg; }
        }
        /// <summary>
        /// 服务认证时间
        /// </summary>
        public DateTime? SerTime
        {
            set { _sertime = value; }
            get { return _sertime; }
        }
        /// <summary>
        /// 
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
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IDCardState
        {
            set { _idcardstate = value; }
            get { return _idcardstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SerImgState
        {
            set { _serimgstate = value; }
            get { return _serimgstate; }
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
        public int? PerID
        {
            set { _perid = value; }
            get { return _perid; }
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

