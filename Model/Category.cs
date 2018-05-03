using System;
namespace TFXK.Model
{
	/// <summary>
	/// ʵ����Category ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Category
	{
		public Category()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _codeno;
		private int _parentid;
		private string _description;
		private int _orderid;
		private string _imgpath;
		private int _stateid;
		private int _typeid;
		private string _outlink;
		private string _simpledes;
		private string _otherdes1;
		private string _otherdes2;
		/// <summary>
		/// ���
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string codeNo
		{
			set{ _codeno=value;}
			get{return _codeno;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int parentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		public int stateID
		{
			set{ _stateid=value;}
			get{return _stateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string outLink
		{
			set{ _outlink=value;}
			get{return _outlink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string simpleDes
		{
			set{ _simpledes=value;}
			get{return _simpledes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherDes1
		{
			set{ _otherdes1=value;}
			get{return _otherdes1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherDes2
		{
			set{ _otherdes2=value;}
			get{return _otherdes2;}
		}
		#endregion Model

	}
}

