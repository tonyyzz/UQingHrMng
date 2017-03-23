using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// ServerUser_Evaluate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServerUser_Evaluate
    {
        public ServerUser_Evaluate()
        { }
        #region Model
        private int _id;
        private int? _seruserid;
        private string _realname;
        private string _evaluatecon;
        private DateTime? _evaluatetime;
        private int? _evaluateuserid;
        private string _evaluatename;
        private int? _evalevel;
        private int? _orderid;
        private int? _evaluatetype;
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
        public int? SerUserID
        {
            set { _seruserid = value; }
            get { return _seruserid; }
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
        /// 评价内容
        /// </summary>
        public string EvaluateCon
        {
            set { _evaluatecon = value; }
            get { return _evaluatecon; }
        }
        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime? EvaluateTime
        {
            set { _evaluatetime = value; }
            get { return _evaluatetime; }
        }
        /// <summary>
        /// 评价人ID
        /// </summary>
        public int? EvaluateUserID
        {
            set { _evaluateuserid = value; }
            get { return _evaluateuserid; }
        }
        /// <summary>
        /// 评价人名称
        /// </summary>
        public string EvaluateName
        {
            set { _evaluatename = value; }
            get { return _evaluatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EvaLevel
        {
            set { _evalevel = value; }
            get { return _evalevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EvaluateType
        {
            set { _evaluatetype = value; }
            get { return _evaluatetype; }
        }
        #endregion Model

    }
}

