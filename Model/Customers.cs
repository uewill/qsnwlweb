using System;
namespace TFXK.Model
{
    /// <summary>
    /// 实体类Customers 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Customers
    {
        public Customers()
        { }
        #region Model
        private int _id;
        private string _loginname;
        private string _loginpass;
        private string _email;
        private string _phone;
        private DateTime? _regdate;
        private string _truename;
        private int? _usersex;
        private string _tel;
        private string _address;
        private string _cardid;
        private string _birsday;
        private int? _stateid;
        private int? _orderemail;
        private string _validateemail;
        /// <summary>
        /// 序号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string loginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string loginPass
        {
            set { _loginpass = value; }
            get { return _loginpass; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? regDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string trueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? userSex
        {
            set { _usersex = value; }
            get { return _usersex; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string cardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public string birsday
        {
            set { _birsday = value; }
            get { return _birsday; }
        }
        /// <summary>
        /// 状态 1已审核 0已禁用
        /// </summary>
        public int? stateID
        {
            set { _stateid = value; }
            get { return _stateid; }
        }
        /// <summary>
        /// 是否订阅邮件
        /// </summary>
        public int? orderEmail
        {
            set { _orderemail = value; }
            get { return _orderemail; }
        }
        /// <summary>
        /// 邮箱验证Code
        /// </summary>
        public string validateEmail
        {
            set { _validateemail = value; }
            get { return _validateemail; }
        }
        #endregion Model

    }
}

