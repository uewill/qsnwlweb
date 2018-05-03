using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类SiteConfig 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SiteConfig
	{
		public SiteConfig()
		{}
		#region Model
		private int _id;
		private string _codeno;
		private string _title;
		private string _description;
		private string _mata;
		private string _footer;
		private string _des1;
		private string _des2;
		private string _des3;
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
		public string codeNo
		{
			set{ _codeno=value;}
			get{return _codeno;}
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
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mata
		{
			set{ _mata=value;}
			get{return _mata;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string footer
		{
			set{ _footer=value;}
			get{return _footer;}
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
		#endregion Model

	}
}

