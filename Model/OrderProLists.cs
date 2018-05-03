using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类OrderProLists 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class OrderProLists
	{
		public OrderProLists()
		{}
		#region Model
		private int _id;
		private int? _orderid;
		private int? _productid;
		private int? _ordernum;
		private decimal? _productprice;
		private decimal? _totalmoney;
		/// <summary>
		/// 序号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? orderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 产品编号
		/// </summary>
		public int? productID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 订购数量
		/// </summary>
		public int? orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 产品单价
		/// </summary>
		public decimal? productPrice
		{
			set{ _productprice=value;}
			get{return _productprice;}
		}
		/// <summary>
		/// 小计金额
		/// </summary>
		public decimal? totalMoney
		{
			set{ _totalmoney=value;}
			get{return _totalmoney;}
		}
		#endregion Model

	}
}

