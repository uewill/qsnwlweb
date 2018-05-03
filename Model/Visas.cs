using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Visas 。(属性说明自动提取数据库字段的描述信息)
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
		/// 序号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 签证国家ID
		/// </summary>
		public int? CountryID
		{
			set{ _countryid=value;}
			get{return _countryid;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string imgPaht
		{
			set{ _imgpaht=value;}
			get{return _imgpaht;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public string expDate
		{
			set{ _expdate=value;}
			get{return _expdate;}
		}
		/// <summary>
		/// 停留天数
		/// </summary>
		public string stayDays
		{
			set{ _staydays=value;}
			get{return _staydays;}
		}
		/// <summary>
		/// 预计工作日
		/// </summary>
		public string useDays
		{
			set{ _usedays=value;}
			get{return _usedays;}
		}
		/// <summary>
		/// 是否需要面试
		/// </summary>
		public int? interview
		{
			set{ _interview=value;}
			get{return _interview;}
		}
		/// <summary>
		/// 适用范围
		/// </summary>
		public string useArea
		{
			set{ _usearea=value;}
			get{return _usearea;}
		}
		/// <summary>
		/// 签证描述
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

