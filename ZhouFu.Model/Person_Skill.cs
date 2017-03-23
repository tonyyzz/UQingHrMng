using System;
namespace ZhongLi.Model
{
    /// <summary>
    /// Person_Skill:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Person_Skill
    {
        public Person_Skill()
        { }
        #region Model
        private int _perskillid;
        private int? _perid;
        private string _skillname;
        private string _masterdegree;
        private DateTime? _createtime;
        private string _colvalue;
        /// <summary>
        /// 
        /// </summary>
        public int PerSkillID
        {
            set { _perskillid = value; }
            get { return _perskillid; }
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
        /// 技能名称
        /// </summary>
        public string SkillName
        {
            set { _skillname = value; }
            get { return _skillname; }
        }
        /// <summary>
        /// 掌握程度
        /// </summary>
        public string MasterDegree
        {
            set { _masterdegree = value; }
            get { return _masterdegree; }
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
        #endregion Model

    }
}

