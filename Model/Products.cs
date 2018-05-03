using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Products 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Products
	{
		public Products()
		{}
		#region Model
		private int _id;
		private int _parentid;
		private string _title;
		private string _codeno;
		private int? _brandid;
		private string _brandname;
		private string _danwei;
		private decimal _saleprice;
		private decimal _cusprice;
		private string _mianliao;
		private string _colorname;
		private string _cpdes;
		private string _fzccdes;
		private string _xdbxdes;
		private string _shfwdes;
		private string _admindes;
		private int _clicks;
		private int _orderid;
		private int _ishot;
		private int _istuijian;
		private int? _desfild1;
		private string _desfild2;
		private string _desfild3;
		private string _desfild4;
		private int? _typeid;
		private string _imgpath;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 栏目编号
		/// </summary>
		public int parentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 产品编号
		/// </summary>
		public string codeNo
		{
			set{ _codeno=value;}
			get{return _codeno;}
		}
		/// <summary>
		/// 品牌ID
		/// </summary>
		public int? brandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 品牌
		/// </summary>
		public string brandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string danwei
		{
			set{ _danwei=value;}
			get{return _danwei;}
		}
		/// <summary>
		/// 市场价
		/// </summary>
		public decimal salePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 会员价
		/// </summary>
		public decimal cusPrice
		{
			set{ _cusprice=value;}
			get{return _cusprice;}
		}
		/// <summary>
		/// 面料
		/// </summary>
		public string mianliao
		{
			set{ _mianliao=value;}
			get{return _mianliao;}
		}
		/// <summary>
		/// 色系
		/// </summary>
		public string colorname
		{
			set{ _colorname=value;}
			get{return _colorname;}
		}
		/// <summary>
		/// 产品描述
		/// </summary>
		public string cpdes
		{
			set{ _cpdes=value;}
			get{return _cpdes;}
		}
		/// <summary>
		/// 服装尺寸
		/// </summary>
		public string fzccdes
		{
			set{ _fzccdes=value;}
			get{return _fzccdes;}
		}
		/// <summary>
		/// 洗涤说明
		/// </summary>
		public string xdbxdes
		{
			set{ _xdbxdes=value;}
			get{return _xdbxdes;}
		}
		/// <summary>
		/// 售后服务
		/// </summary>
		public string shfwdes
		{
			set{ _shfwdes=value;}
			get{return _shfwdes;}
		}
		/// <summary>
		/// 管理员备注
		/// </summary>
		public string admindes
		{
			set{ _admindes=value;}
			get{return _admindes;}
		}
		/// <summary>
		/// 人气
		/// </summary>
		public int clicks
		{
			set{ _clicks=value;}
			get{return _clicks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int orderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 是否热门
		/// </summary>
		public int isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int isTuijian
		{
			set{ _istuijian=value;}
			get{return _istuijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? desFild1
		{
			set{ _desfild1=value;}
			get{return _desfild1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string desFild2
		{
			set{ _desfild2=value;}
			get{return _desfild2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string desFild3
		{
			set{ _desfild3=value;}
			get{return _desfild3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string desFild4
		{
			set{ _desfild4=value;}
			get{return _desfild4;}
		}
		/// <summary>
		/// 0产品/ 1样品
		/// </summary>
		public int? typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgPath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		#endregion Model

	}
}

