using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// Person_Reward:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Person_Reward
    {
        public Person_Reward()
        { }
        #region Model
        private int _perrewardid;
        private int? _perid;
        private string _trade;
        private string _companysize;
        private string _companynature;
        private string _engagepost;
        private string _demandpay;
        private string _jobcity;
        private string _otherdemand;
        private string _companymatching;
        private string _otherdemanddes;
        private decimal? _rewardmoney;
        private DateTime? _rewardtime;
        private int? _rewardstate;
        private int? _isdelete;
        private string _education;
        private string _worklife;
        /// <summary>
        /// 
        /// </summary>
        public int PerRewardID
        {
            set { _perrewardid = value; }
            get { return _perrewardid; }
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
        /// 悬赏金额
        /// </summary>
        public decimal? RewardMoney
        {
            set { _rewardmoney = value; }
            get { return _rewardmoney; }
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
        /// 悬赏状态
        /// </summary>
        public int? RewardState
        {
            set { _rewardstate = value; }
            get { return _rewardstate; }
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
        /// 学历
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string WorkLife
        {
            set { _worklife = value; }
            get { return _worklife; }
        }
        #endregion Model

    }
}

