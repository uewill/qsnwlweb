using System;
namespace TFXK.Model
{
	/// <summary>
	/// ʵ����OrderProLists ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���
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
		/// ��Ʒ���
		/// </summary>
		public int? productID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int? orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public decimal? productPrice
		{
			set{ _productprice=value;}
			get{return _productprice;}
		}
		/// <summary>
		/// С�ƽ��
		/// </summary>
		public decimal? totalMoney
		{
			set{ _totalmoney=value;}
			get{return _totalmoney;}
		}
		#endregion Model

	}
}

