using System;
namespace TFXK.Model
{
	/// <summary>
	/// ʵ����Visas ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Visas
	{
		public Visas()
		{}
		#region Model
		private int _id;
		private int? _countryid;
		private string _imgpaht;
		private string _expdate;
		private string _staydays;
		private string _usedays;
		private int? _interview;
		private string _usearea;
		private string _usedes;
		private string _des1;
		private string _des2;
		private int? _des3;
		/// <summary>
		/// ���
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ǩ֤����ID
		/// </summary>
		public int? CountryID
		{
			set{ _countryid=value;}
			get{return _countryid;}
		}
		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string imgPaht
		{
			set{ _imgpaht=value;}
			get{return _imgpaht;}
		}
		/// <summary>
		/// ��Ч��
		/// </summary>
		public string expDate
		{
			set{ _expdate=value;}
			get{return _expdate;}
		}
		/// <summary>
		/// ͣ������
		/// </summary>
		public string stayDays
		{
			set{ _staydays=value;}
			get{return _staydays;}
		}
		/// <summary>
		/// Ԥ�ƹ�����
		/// </summary>
		public string useDays
		{
			set{ _usedays=value;}
			get{return _usedays;}
		}
		/// <summary>
		/// �Ƿ���Ҫ����
		/// </summary>
		public int? interview
		{
			set{ _interview=value;}
			get{return _interview;}
		}
		/// <summary>
		/// ���÷�Χ
		/// </summary>
		public string useArea
		{
			set{ _usearea=value;}
			get{return _usearea;}
		}
		/// <summary>
		/// ǩ֤����
		/// </summary>
		public string useDes
		{
			set{ _usedes=value;}
			get{return _usedes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des1
		{
			set{ _des1=value;}
			get{return _des1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des2
		{
			set{ _des2=value;}
			get{return _des2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? des3
		{
			set{ _des3=value;}
			get{return _des3;}
		}
		#endregion Model

	}
}

