using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// ChannelCnvestment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ChannelCnvestment
    {
        public ChannelCnvestment()
        { }
        #region Model
        private int _id;
        private string _company;
        private string _address;
        private string _linkman;
        private string _phone;
        private string _email;
        private string _mainbusiness;
        private string _city;
        private string _teamsize;
        private string _mainadvantage;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 公司全称
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
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
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 主营业务
        /// </summary>
        public string MainBusiness
        {
            set { _mainbusiness = value; }
            get { return _mainbusiness; }
        }
        /// <summary>
        /// 意向代理城市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 团队规模
        /// </summary>
        public string TeamSize
        {
            set { _teamsize = value; }
            get { return _teamsize; }
        }
        /// <summary>
        /// 主要优势
        /// </summary>
        public string MainAdvantage
        {
            set { _mainadvantage = value; }
            get { return _mainadvantage; }
        }
        #endregion Model

    }
}

