using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Messages 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Messages
	{
		public Messages()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _usernames;
		private string _useremail;
		private string _msgcontent;
		private string _qicq;
		private int? _stateid;
		private string _recontent;
		private DateTime? _createtime;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userNames
		{
			set{ _usernames=value;}
			get{return _usernames;}
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
		public string msgContent
		{
			set{ _msgcontent=value;}
			get{return _msgcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qicq
		{
			set{ _qicq=value;}
			get{return _qicq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? stateid
		{
			set{ _stateid=value;}
			get{return _stateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recontent
		{
			set{ _recontent=value;}
			get{return _recontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

