using System;
namespace TFXK.Model
{
	/// <summary>
	/// TestingPersonPlan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TestingPersonPlan
	{
		public TestingPersonPlan()
		{}
		#region Model
		private int _id;
		private string _testingtitle;
		private DateTime? _testtimeamstart;
		private DateTime? _testtimeamend;
		private DateTime? _testtimepmstart;
		private DateTime? _testtimepmend;
        private string _testingclass;
        private string _testingsubclass;
        private string _address;
		private string _addresdes;
		private string _contactor;
		private string _description;
		private int? _totalcount;
		private int? _status;
		private int? _ordernum;
		private DateTime? _createtime;
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
		public string TestingTitle
		{
			set{ _testingtitle=value;}
			get{return _testingtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TestTimeAMStart
		{
			set{ _testtimeamstart=value;}
			get{return _testtimeamstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TestTimeAMEnd
		{
			set{ _testtimeamend=value;}
			get{return _testtimeamend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TestTimePMStart
		{
			set{ _testtimepmstart=value;}
			get{return _testtimepmstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TestTimePMEnd
		{
			set{ _testtimepmend=value;}
			get{return _testtimepmend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestingClass
		{
			set{ _testingclass=value;}
			get{return _testingclass;}
		}
        public string TestingSubClass
        {
            set { _testingsubclass = value; }
            get { return _testingsubclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddresDes
		{
			set{ _addresdes=value;}
			get{return _addresdes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TotalCount
		{
			set{ _totalcount=value;}
			get{return _totalcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}

        public string NumberPrefx { get; set; }
        public string NumberStart { get; set; }
        public int NumberIndex { get; set; }
        #endregion Model

    }
}

