using System;
namespace TFXK.Model
{
	/// <summary>
	/// ʵ����Link ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
		/// <summary>
		/// ��վ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ҳ������
		/// </summary>
		public string linkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// ��վLogo
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// �Ƿ�ͼƬ��ʾ
		/// </summary>
		public string isPictureOn
		{
			set{ _ispictureon=value;}
			get{return _ispictureon;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int? orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
        }
        /// <summary>
        /// �����
        /// </summary>
        public int parentId
        {
            set { _parentId = value; }
            get { return _parentId; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
		#endregion Model

	}
}

