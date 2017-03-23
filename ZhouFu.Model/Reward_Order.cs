using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// Reward_Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Reward_Order
    {
        public Reward_Order()
        { }
        #region Model
        private int _orderid;
        private string _ordernum;
        private int? _perrewardid;
        private int? _postid;
        private decimal? _rewardmoney;
        private DateTime? _createtime;
        private int? _orderstate;
        private int? _perid;
        private string _realname;
        private int? _seruserid;
        private string _serrealname;
        private int? _isdelete;
        private string _trade;
        private string _companysize;
        private string _companynature;
        private string _engagepost;
        private string _demandpay;
        private string _jobcity;
        private string _otherdemand;
        private string _companymatching;
        private string _otherdemanddes;
        private DateTime? _rewardtime;
        private string _company;
        private string _post_trade;
        private string _scale;
        private string _nature;
        private string _postname;
        private string _postduty;
        private string _salary;
        private string _developprospect;
        private string _directleader;
        private string _workadress;
        private string _address;
        private string _welfaretag;
        private string _post_companymatching;
        private string _otherpoint;
        private string _autoimg;
        private DateTime? _autotime;
        private string _education;
        private string _worklife;
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 悬赏ID
        /// </summary>
        public int? PerRewardID
        {
            set { _perrewardid = value; }
            get { return _perrewardid; }
        }
        /// <summary>
        /// 服务商职位ID
        /// </summary>
        public int? PostID
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// 悬赏金额
        /// </summary>
        public decimal? RewardMoney
        {
            set { _rewardmoney = value; }
            get { return _rewardmoney; }
        }
        /// <summary>
        /// 订单生成时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 订单状态 
        /// </summary>
        public int? OrderState
        {
            set { _orderstate = value; }
            get { return _orderstate; }
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
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
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
        public string SerRealName
        {
            set { _serrealname = value; }
            get { return _serrealname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 从事行业
        /// </summary>
        public string Trade
        {
            set { _trade = value; }
            get { return _trade; }
        }
        /// <summary>
        /// 公司规模
        /// </summary>
        public string CompanySize
        {
            set { _companysize = value; }
            get { return _companysize; }
        }
        /// <summary>
        /// 公司性质    国企、上市公司、拟上市公司、创业型、小微企业
        /// </summary>
        public string CompanyNature
        {
            set { _companynature = value; }
            get { return _companynature; }
        }
        /// <summary>
        /// 从事岗位
        /// </summary>
        public string EngagePost
        {
            set { _engagepost = value; }
            get { return _engagepost; }
        }
        /// <summary>
        /// 薪资要求
        /// </summary>
        public string DemandPay
        {
            set { _demandpay = value; }
            get { return _demandpay; }
        }
        /// <summary>
        /// 期望工资地点
        /// </summary>
        public string JobCity
        {
            set { _jobcity = value; }
            get { return _jobcity; }
        }
        /// <summary>
        /// 其他福利要求
        /// </summary>
        public string OtherDemand
        {
            set { _otherdemand = value; }
            get { return _otherdemand; }
        }
        /// <summary>
        /// 公司配套环境
        /// </summary>
        public string CompanyMatching
        {
            set { _companymatching = value; }
            get { return _companymatching; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherDemandDes
        {
            set { _otherdemanddes = value; }
            get { return _otherdemanddes; }
        }
        /// <summary>
        /// 悬赏时间
        /// </summary>
        public DateTime? RewardTime
        {
            set { _rewardtime = value; }
            get { return _rewardtime; }
        }
        /// <summary>
        /// 推荐公司名称
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 所属行业
        /// </summary>
        public string Post_Trade
        {
            set { _post_trade = value; }
            get { return _post_trade; }
        }
        /// <summary>
        /// 公司规模
        /// </summary>
        public string Scale
        {
            set { _scale = value; }
            get { return _scale; }
        }
        /// <summary>
        /// 公司性质   国企、上市公司、拟上市公司、创业型、小微企业
        /// </summary>
        public string Nature
        {
            set { _nature = value; }
            get { return _nature; }
        }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PostName
        {
            set { _postname = value; }
            get { return _postname; }
        }
        /// <summary>
        /// 岗位职责
        /// </summary>
        public string PostDuty
        {
            set { _postduty = value; }
            get { return _postduty; }
        }
        /// <summary>
        /// 提供待遇：薪资标准，固定薪资部分+奖金或提成部分
        /// </summary>
        public string Salary
        {
            set { _salary = value; }
            get { return _salary; }
        }
        /// <summary>
        /// 发展前景描述
        /// </summary>
        public string DevelopProspect
        {
            set { _developprospect = value; }
            get { return _developprospect; }
        }
        /// <summary>
        /// 直接领导
        /// </summary>
        public string DirectLeader
        {
            set { _directleader = value; }
            get { return _directleader; }
        }
        /// <summary>
        /// 工作地点：某省某市某区
        /// </summary>
        public string WorkAdress
        {
            set { _workadress = value; }
            get { return _workadress; }
        }
        /// <summary>
        /// 办公地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 提供的福利
        /// </summary>
        public string WelfareTag
        {
            set { _welfaretag = value; }
            get { return _welfaretag; }
        }
        /// <summary>
        /// 公司配套环境：地铁附近、免费停车、商圈周边、写字楼；
        /// </summary>
        public string Post_CompanyMatching
        {
            set { _post_companymatching = value; }
            get { return _post_companymatching; }
        }
        /// <summary>
        /// 其他卖点：如股票期权、美女如云等
        /// </summary>
        public string OtherPoint
        {
            set { _otherpoint = value; }
            get { return _otherpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AutoImg
        {
            set { _autoimg = value; }
            get { return _autoimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AutoTime
        {
            set { _autotime = value; }
            get { return _autotime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkLife
        {
            set { _worklife = value; }
            get { return _worklife; }
        }
        #endregion Model

    }
}

