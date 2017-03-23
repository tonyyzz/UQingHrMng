using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// Person_Report:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Person_Report
    {
        public Person_Report()
        { }
        #region Model
        private int _id;
        private int? _perid;
        private int? _seruserid;
        private string _reportreason;
        private DateTime? _reporttime;
        private string _colvalue;
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
        public int? PerID
        {
            set { _perid = value; }
            get { return _perid; }
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
        public string ReportReason
        {
            set { _reportreason = value; }
            get { return _reportreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReportTime
        {
            set { _reporttime = value; }
            get { return _reporttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColValue
        {
            set { _colvalue = value; }
            get { return _colvalue; }
        }
        #endregion Model

    }
}

