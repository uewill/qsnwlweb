using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类UserOrders 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class UserOrders
	{
		public UserOrders()
		{}
		#region Model
		private int _id;
		private string _typeid;
		private string _jijie;
		private string _chkordernum;
		private int _ordernum;
		private string _hopeprice;
		private string _procode;
		private string _otherdes;
		private string _filepaths;
		private string _contactusername;
		private int _usersex;
		private string _usertel;
		private string _userphone;
		private string _useremail;
		private string _companyname;
		private string _companyaddress;
		private int _stateid;
		private string _des1;
		private string _des2;
		private string _des3;
		private string _des4;
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
		public string typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Jijie
		{
			set{ _jijie=value;}
			get{return _jijie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chkOrderNum
		{
			set{ _chkordernum=value;}
			get{return _chkordernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hopePrice
		{
			set{ _hopeprice=value;}
			get{return _hopeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proCode
		{
			set{ _procode=value;}
			get{return _procode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherDes
		{
			set{ _otherdes=value;}
			get{return _otherdes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filePaths
		{
			set{ _filepaths=value;}
			get{return _filepaths;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contactUserName
		{
			set{ _contactusername=value;}
			get{return _contactusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userSex
		{
			set{ _usersex=value;}
			get{return _usersex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userTel
		{
			set{ _usertel=value;}
			get{return _usertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userPhone
		{
			set{ _userphone=value;}
			get{return _userphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyAddress
		{
			set{ _companyaddress=value;}
			get{return _companyaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int stateID
		{
			set{ _stateid=value;}
			get{return _stateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des1
		{
			set{ _des1=value;}
			get{return _des1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des2
		{
			set{ _des2=value;}
			get{return _des2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des3
		{
			set{ _des3=value;}
			get{return _des3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des4
		{
			set{ _des4=value;}
			get{return _des4;}
		}
		#endregion Model

	}
}

