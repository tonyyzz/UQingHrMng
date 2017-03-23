using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// ServerUser_Message:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ServerUser_Message
    {
        public ServerUser_Message()
        { }
        #region Model
        private int _sermesid;
        private int? _seruserid;
        private int? _mestype;
        private int? _dataid;
        private string _mescon;
        private DateTime? _sendtime;
        private bool _isread;
        private DateTime? _readtime;
        private string _colvalue;
        private int? _targetid;
        /// <summary>
        /// 
        /// </summary>
        public int SerMesID
        {
            set { _sermesid = value; }
            get { return _sermesid; }
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
        /// 消息类型 0：系统消息  1：好友消息，2悬赏提醒
        /// </summary>
        public int? MesType
        {
            set { _mestype = value; }
            get { return _mestype; }
        }
        /// <summary>
        /// 来源信息ID  例如匹配悬赏时的职位ID
        /// </summary>
        public int? DataID
        {
            set { _dataid = value; }
            get { return _dataid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MesCon
        {
            set { _mescon = value; }
            get { return _mescon; }
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
        /// 
        /// </summary>
        public bool IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReadTime
        {
            set { _readtime = value; }
            get { return _readtime; }
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
        /// 目标信息ID  比如悬赏ID
        /// </summary>
        public int? TargetID
        {
            set { _targetid = value; }
            get { return _targetid; }
        }
        #endregion Model

    }
}

