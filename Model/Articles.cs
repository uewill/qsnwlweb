using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Articles 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Articles
	{
		public Articles()
		{}
		#region Model
		private int _id;
		private int _parentid;
		private string _title;
		private string _source;
		private string _publisher;
		private DateTime? _createtime;
		private string _description;
		private int? _isoutllink;
		private int? _isslideon;
		private int? _state;
		private int? _clicks;
		private int? _orderid;
		private string _imgpath;
		private string _outlinkpath;
        private string _fysmDes;
        private string _wxtsDes;
        private string _ydxzDes;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string publisher
		{
			set{ _publisher=value;}
			get{return _publisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isOutlLink
		{
			set{ _isoutllink=value;}
			get{return _isoutllink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isSlideOn
		{
			set{ _isslideon=value;}
			get{return _isslideon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? clicks
		{
			set{ _clicks=value;}
			get{return _clicks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? orderId
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
		public string outLinkPath
		{
			set{ _outlinkpath=value;}
			get{return _outlinkpath;}
		}

        /// <summary>
        /// 费用说明
        /// </summary>
        public string fysmDes
        {
            set { _fysmDes = value; }
            get { return _fysmDes; }
        }
        /// <summary>
        /// 温馨提示
        /// </summary>
        public string wxtsDes
        {
            set { _wxtsDes = value; }
            get { return _wxtsDes; }
        }

        /// <summary>
        /// 预定须知
        /// </summary>
        public string ydxzDes
        {
            set { _ydxzDes = value; }
            get { return _ydxzDes; }
        }
		#endregion Model

	}
}

