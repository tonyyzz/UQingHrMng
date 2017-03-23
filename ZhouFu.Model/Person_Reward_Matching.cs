using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// Person_Reward_Matching:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Person_Reward_Matching
    {
        public Person_Reward_Matching()
        { }
        #region Model
        private int _perrewmatid;
        private int? _orderid;
        private int? _perid;
        private int? _perrewid;
        private int? _seruserid;
        private int? _serpostid;
        private DateTime? _matchingtime;
        private int? _state;
        private DateTime? _reftime;
        private int? _isdelete;
        /// <summary>
        /// 
        /// </summary>
        public int PerRewMatID
        {
            set { _perrewmatid = value; }
            get { return _perrewmatid; }
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
        /// 用户ID
        /// </summary>
        public int? PerID
        {
            set { _perid = value; }
            get { return _perid; }
        }
        /// <summary>
        /// 悬赏ID
        /// </summary>
        public int? PerRewID
        {
            set { _perrewid = value; }
            get { return _perrewid; }
        }
        /// <summary>
        /// 职业介绍人ID
        /// </summary>
        public int? SerUserID
        {
            set { _seruserid = value; }
            get { return _seruserid; }
        }
        /// <summary>
        /// 职业介绍人匹配的职位ID
        /// </summary>
        public int? SerPostID
        {
            set { _serpostid = value; }
            get { return _serpostid; }
        }
        /// <summary>
        /// 匹配时间
        /// </summary>
        public DateTime? MatchingTime
        {
            set { _matchingtime = value; }
            get { return _matchingtime; }
        }
        /// <summary>
        /// 匹配状态 0待确认  1 匹配成功 2 拒绝
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 求职者回复时间
        /// </summary>
        public DateTime? RefTime
        {
            set { _reftime = value; }
            get { return _reftime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

