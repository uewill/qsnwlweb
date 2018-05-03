using System;
namespace TFXK.Model
{
    /// <summary>
    /// ʵ����Customers ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string loginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        public string loginPass
        {
            set { _loginpass = value; }
            get { return _loginpass; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// �ֻ���
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime? regDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string trueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public int? userSex
        {
            set { _usersex = value; }
            get { return _usersex; }
        }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// ��ϵ��ַ
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// ��Ա����
        /// </summary>
        public string cardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string birsday
        {
            set { _birsday = value; }
            get { return _birsday; }
        }
        /// <summary>
        /// ״̬ 1����� 0�ѽ���
        /// </summary>
        public int? stateID
        {
            set { _stateid = value; }
            get { return _stateid; }
        }
        /// <summary>
        /// �Ƿ����ʼ�
        /// </summary>
        public int? orderEmail
        {
            set { _orderemail = value; }
            get { return _orderemail; }
        }
        /// <summary>
        /// ������֤Code
        /// </summary>
        public string validateEmail
        {
            set { _validateemail = value; }
            get { return _validateemail; }
        }
        #endregion Model

    }
}

