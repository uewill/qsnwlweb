using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Users 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Users
	{
		public Users()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
		private string _truename;
		private string _email;
		private string _telephone;
		private string _address;
		private int _roleid;
		private string _question;
		private string _answer;
		private int _state;
		private DateTime _regdate;
		private DateTime _lastlogindate;
		private int _logincount;
		private string _description;
		/// <summary>
		/// 序号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string trueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 邮件
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 角色
		/// </summary>
		public int roleid
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 部门
		/// </summary>
		public string question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 答案
		/// </summary>
		public string answer
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime regDate
		{
			set{ _regdate=value;}
			get{return _regdate;}
		}
		/// <summary>
		/// 最后登录
		/// </summary>
		public DateTime lastLoginDate
		{
			set{ _lastlogindate=value;}
			get{return _lastlogindate;}
		}
		/// <summary>
		/// 登录次数
		/// </summary>
		public int loginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

