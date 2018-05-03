using System;
namespace TFXK.Model
{
    /// <summary>
    /// 实体类TourCategory 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TourCategory
    {
        public TourCategory()
        { }
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
        private string _gtLink;
        private string _ylLink;
        /// <summary>
        /// 序号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string codeNo
        {
            set { _codeno = value; }
            get { return _codeno; }
        }
        /// <summary>
        /// 父编号
        /// </summary>
        public int parentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int orderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgPath
        {
            set { _imgpath = value; }
            get { return _imgpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int stateID
        {
            set { _stateid = value; }
            get { return _stateid; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 自由行链接
        /// </summary>
        public string outLink
        {
            set { _outlink = value; }
            get { return _outlink; }
        }
        /// <summary>
        /// 行前问答
        /// </summary>
        public string simpleDes
        {
            set { _simpledes = value; }
            get { return _simpledes; }
        }
        /// <summary>
        /// 温馨提示
        /// </summary>
        public string otherDes1
        {
            set { _otherdes1 = value; }
            get { return _otherdes1; }
        }
        /// <summary>
        /// 游记攻略
        /// </summary>
        public string otherDes2
        {
            set { _otherdes2 = value; }
            get { return _otherdes2; }
        }


        /// <summary>
        /// 跟团旅游
        /// </summary>
        public string gtLink
        {
            set { _gtLink = value; }
            get { return _gtLink; }
        }
        /// <summary>
        /// 游轮旅游
        /// </summary>
        public string ylLink
        {
            set { _ylLink = value; }
            get { return _ylLink; }
        }

        #endregion Model

    }
}

