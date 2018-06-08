using System;
namespace TFXK.Model
{
    /// <summary>
    /// TestingPlan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TestingPlan
    {
        public TestingPlan()
        { }
        #region Model
        private int _id;
        private string _testingtime;
        private DateTime? _testtimestart;
        private DateTime? _testtimeend;
        private string _testingclass;
        private string _address;
        private string _addresdes;
        private string _contactor;
        private string _description;
        private int? _status;
        private DateTime? _createtime;
        private DateTime? _audittime;
        private string _auditdescription;
        private int? _noticeconfirm;
        private string _noticeaddress;
        private string _noticegetuser;
        private string _noticegetphone;
        private DateTime? _noticetime;
        private DateTime? _noticeconfirmtime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int CenterID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TestingTime
        {
            set { _testingtime = value; }
            get { return _testingtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TestTimeStart
        {
            set { _testtimestart = value; }
            get { return _testtimestart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TestTimeEnd
        {
            set { _testtimeend = value; }
            get { return _testtimeend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestingClass
        {
            set { _testingclass = value; }
            get { return _testingclass; }
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
        public string AddresDes
        {
            set { _addresdes = value; }
            get { return _addresdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Contactor
        {
            set { _contactor = value; }
            get { return _contactor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 0 待审核  1已审核 待支付  2已支付待领证通知 3、已通知领证
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
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditTime
        {
            set { _audittime = value; }
            get { return _audittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditDescription
        {
            set { _auditdescription = value; }
            get { return _auditdescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? NoticeConfirm
        {
            set { _noticeconfirm = value; }
            get { return _noticeconfirm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoticeAddress
        {
            set { _noticeaddress = value; }
            get { return _noticeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoticeGetUser
        {
            set { _noticegetuser = value; }
            get { return _noticegetuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoticeGetPhone
        {
            set { _noticegetphone = value; }
            get { return _noticegetphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? NoticeTime
        {
            set { _noticetime = value; }
            get { return _noticetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? NoticeConfirmTime
        {
            set { _noticeconfirmtime = value; }
            get { return _noticeconfirmtime; }
        }
        public string NoticeDescription { get; set; }
        #endregion Model

    }
}

