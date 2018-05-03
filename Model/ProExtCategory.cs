using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类ProExtCategory 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProExtCategory
	{
		public ProExtCategory()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _extcateid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 产品编号
		/// </summary>
		public int productID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 附属分类编号
		/// </summary>
		public int extCateID
		{
			set{ _extcateid=value;}
			get{return _extcateid;}
		}
		#endregion Model

	}
}

