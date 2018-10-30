using System;
namespace TFXK.Model
{
	/// <summary>
	/// TestingPerson:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TestingPerson
	{
		public TestingPerson()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _usernamepy;
		private string _userpassword;
		private string _sex;
		private string _phonenumber;
		private string _mingzu;
		private string _birthday;
		private string _country;
		private string _address;
		private string _homeaddress;
		private string _contactor;
		private string _contactorship;
		private string _contactorphone;
		private int? _status;
		private DateTime? _createtime;
        public string IDNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserNamePY
		{
			set{ _usernamepy=value;}
			get{return _usernamepy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhoneNumber
		{
			set{ _phonenumber=value;}
			get{return _phonenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mingzu
		{
			set{ _mingzu=value;}
			get{return _mingzu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeAddress
		{
			set{ _homeaddress=value;}
			get{return _homeaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactorShip
		{
			set{ _contactorship=value;}
			get{return _contactorship;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactorPhone
		{
			set{ _contactorphone=value;}
			get{return _contactorphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

