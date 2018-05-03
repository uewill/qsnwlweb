using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Pictures 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Pictures
	{
		public Pictures()
		{}
		#region Model
		private int? _id;
		private int _typeid;
		private int _parentid;
		private string _imgpath;
		private string _imgalt;
		/// <summary>
		/// 
		/// </summary>
		public int? id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 1 景点   2 线路
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgPath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgAlt
		{
			set{ _imgalt=value;}
			get{return _imgalt;}
		}
		#endregion Model

	}
}

