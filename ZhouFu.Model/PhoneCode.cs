using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// PhoneCode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PhoneCode
    {
        public PhoneCode()
        { }
        #region Model
        private string _phone;
        private string _vercode;
        private DateTime? _sendtime;
        private int? _sendtype;
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VerCode
        {
            set { _vercode = value; }
            get { return _vercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 0:注册手机验证码，1：找回密码验证2：更换手机号验证
        /// </summary>
        public int? SendType
        {
            set { _sendtype = value; }
            get { return _sendtype; }
        }
        #endregion Model

    }
}

