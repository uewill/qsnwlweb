using System;
namespace TFXK.Model
{
	/// <summary>
	/// 实体类Link 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Link
	{
		public Link()
		{}
		#region Model
		private int _id;
		private string _title = "";
		private string _linkurl = "";
		private string _logo = "";
		private string _ispictureon = "";
		private int? _orderid = 0;
        private int _parentId = 0;
        private string _description = "";
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
		/// <summary>
		/// 网站名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 页面链接
		/// </summary>
		public string linkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 网站Logo
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 是否图片显示
		/// </summary>
		public string isPictureOn
		{
			set{ _ispictureon=value;}
			get{return _ispictureon;}
		}
		/// <summary>
		/// 排序编号
		/// </summary>
		public int? orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
        }
        /// <summary>
        /// 父编号
        /// </summary>
        public int parentId
        {
            set { _parentId = value; }
            get { return _parentId; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
		#endregion Model

	}
}

