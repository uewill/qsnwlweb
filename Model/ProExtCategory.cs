using System;
namespace TFXK.Model
{
	/// <summary>
	/// ʵ����ProExtCategory ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ʒ���
		/// </summary>
		public int productID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// ����������
		/// </summary>
		public int extCateID
		{
			set{ _extcateid=value;}
			get{return _extcateid;}
		}
		#endregion Model

	}
}

