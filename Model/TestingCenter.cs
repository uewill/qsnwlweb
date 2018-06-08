using System;
namespace TFXK.Model
{
    /// <summary>
    /// TestingCenter:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TestingCenter
    {
        public TestingCenter()
        { }
        #region Model
        private int _id;
        private string _kdname;
        private string _address;
        private string _username;
        private string _userphone;
        private string _usertel;
        private string _useremail;
        private string _userpass;
        private string _idno;
        private string _kddescription;
        private string _idimage;
        private string _idimage2;
        private string _workimage;
        private string _kdlogo;
        private int? _status;
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
        public string KDName
        {
            set { _kdname = value; }
            get { return _kdname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
        public string UserPhone
        {
            set { _userphone = value; }
            get { return _userphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserTel
        {
            set { _usertel = value; }
            get { return _usertel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserPass
        {
            set { _userpass = value; }
            get { return _userpass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KDDescription
        {
            set { _kddescription = value; }
            get { return _kddescription; }
        }
        public string IDNo
        {
            set { _idno = value; }
            get { return _idno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDImage
        {
            set { _idimage = value; }
            get { return _idimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDImage2
        {
            set { _idimage2 = value; }
            get { return _idimage2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkImage
        {
            set { _workimage = value; }
            get { return _workimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KDLogo
        {
            set { _kdlogo = value; }
            get { return _kdlogo; }
        }
        /// <summary>
        /// 0待上传证件  1已上传证件待审核 2 已审核通过 3禁止登录
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
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

