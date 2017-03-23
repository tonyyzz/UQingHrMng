using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// PostType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PostType
    {
        public PostType()
        { }
        #region Model
        private int _id;
        private string _posttypename;
        private int? _parentid;
        private int? _sort;
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
        public string PostTypeName
        {
            set { _posttypename = value; }
            get { return _posttypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
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

