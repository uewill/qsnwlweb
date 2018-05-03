using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Ads 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Ads
	{
		public Ads()
		{}
		#region Model
		private int _id;
		private string _title;
		private int? _typeid;
		private string _linkurl;
		private string _linkimage;
		private string _linkdes;
		private int? _orderid;
		/// <summary>
		/// 
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
		/// 类别
		/// </summary>
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 链接
		/// </summary>
		public string linkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string linkImage
		{
			set{ _linkimage=value;}
			get{return _linkimage;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string linkdes
		{
			set{ _linkdes=value;}
			get{return _linkdes;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

