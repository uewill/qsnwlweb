using System;
namespace TFXK.Model
{
	/// <summary>
	/// ʵ����Ads ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string linkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// ͼƬ
		/// </summary>
		public string linkImage
		{
			set{ _linkimage=value;}
			get{return _linkimage;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string linkdes
		{
			set{ _linkdes=value;}
			get{return _linkdes;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int? orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

