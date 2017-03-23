using System;
namespace ZhongLi.Model
{
	/// <summary>
	/// PresentApplication:提现(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PresentApplication
	{
        public PresentApplication()
        { }
        #region Model
        private int _id;
        private int? _userid;
        private string _realname;
        private decimal? _money;
        private int? _state;
        private int? _adminid;
        private string _adminname;
        private DateTime? _passtime;
        private int? _usertype;
        private DateTime? _paytime;
        private DateTime? _createtime;
        private int? _payadminid;
        private string _payadminname;
        private string _wxaccount;
        private string _aliaccount;
        private int? _pretype;
        private string _wxaccountname;
        private string _aliaccounttname;
        private string _prenum;
        private int? _batchid;
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
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 提现申请状态
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int? AdminID
        {
            set { _adminid = value; }
            get { return _adminid; }
        }
        /// <summary>
        /// 审核通过管理员姓名
        /// </summary>
        public string AdminName
        {
            set { _adminname = value; }
            get { return _adminname; }
        }
        /// <summary>
        /// 审核通过时间
        /// </summary>
        public DateTime? PassTime
        {
            set { _passtime = value; }
            get { return _passtime; }
        }
        /// <summary>
        /// 用户类型  0 求职者 1服务商
        /// </summary>
        public int? UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 提现支付时间
        /// </summary>
        public DateTime? PayTime
        {
            set { _paytime = value; }
            get { return _paytime; }
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
        /// 提现支付管理员ID
        /// </summary>
        public int? PayAdminID
        {
            set { _payadminid = value; }
            get { return _payadminid; }
        }
        /// <summary>
        /// 提现支付管理员姓名
        /// </summary>
        public string PayAdminName
        {
            set { _payadminname = value; }
            get { return _payadminname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WxAccount
        {
            set { _wxaccount = value; }
            get { return _wxaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliAccount
        {
            set { _aliaccount = value; }
            get { return _aliaccount; }
        }
        /// <summary>
        /// 0支付宝1 微信
        /// </summary>
        public int? PreType
        {
            set { _pretype = value; }
            get { return _pretype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WxAccountName
        {
            set { _wxaccountname = value; }
            get { return _wxaccountname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliAccounttName
        {
            set { _aliaccounttname = value; }
            get { return _aliaccounttname; }
        }
        /// <summary>
        /// 提现编号
        /// </summary>
        public string PreNum
        {
            set { _prenum = value; }
            get { return _prenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BatchID
        {
            set { _batchid = value; }
            get { return _batchid; }
        }
        #endregion Model
	}
}

