using System;
namespace TFXK.Model
{
    /// <summary>
    /// TestingStudent:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TestingStudent
    {
        public TestingStudent()
        { }
        #region Model
        private int _id;
        private int? _planid;
        private int? _classid;
        private string _orglevel;
        private string _username;
        private string _usernamepinyin;
        private string _idnumber;
        private int? _sex;
        private string _country;
        private string _ethnicgroup;
        private DateTime? _birthday;
        private string _userheadimage;
        private string _userworkimage;
        private int? _ispass;
        private decimal? _score;
        private DateTime? _createtime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PlanID
        {
            set { _planid = value; }
            get { return _planid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        public string LevelNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrgLevel
        {
            set { _orglevel = value; }
            get { return _orglevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNamePinyin
        {
            set { _usernamepinyin = value; }
            get { return _usernamepinyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDNumber
        {
            set { _idnumber = value; }
            get { return _idnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EthnicGroup
        {
            set { _ethnicgroup = value; }
            get { return _ethnicgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserHeadImage
        {
            set { _userheadimage = value; }
            get { return _userheadimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserWorkImage
        {
            set { _userworkimage = value; }
            get { return _userworkimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsPass
        {
            set { _ispass = value; }
            get { return _ispass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

