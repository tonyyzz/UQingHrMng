using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// ServerUser_Post:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServerUser_Post
    {
        public ServerUser_Post()
        { }
        #region Model
        private int _seruserpostid;
        private int? _seruserid;
        private string _company;
        private string _trade;
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
        private string _companymatching;
        private string _otherpoint;
        private DateTime? _createtime;
        private string _colvalue;
        private int? _issole;
        private string _comimg;
        private int? _seecount;
        /// <summary>
        /// 
        /// </summary>
        public int SerUserPostID
        {
            set { _seruserpostid = value; }
            get { return _seruserpostid; }
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
        public string Trade
        {
            set { _trade = value; }
            get { return _trade; }
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
        public string CompanyMatching
        {
            set { _companymatching = value; }
            get { return _companymatching; }
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
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Colvalue
        {
            set { _colvalue = value; }
            get { return _colvalue; }
        }
        /// <summary>
        /// 是否独家
        /// </summary>
        public int? IsSole
        {
            set { _issole = value; }
            get { return _issole; }
        }
        /// <summary>
        /// 公司环境图片
        /// </summary>
        public string ComImg
        {
            set { _comimg = value; }
            get { return _comimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SeeCount
        {
            set { _seecount = value; }
            get { return _seecount; }
        }
        #endregion Model

    }
}

