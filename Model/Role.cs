using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Role 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Role
	{
		public Role()
		{}
		#region Model
		private int _id;
		private string _title;
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
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

