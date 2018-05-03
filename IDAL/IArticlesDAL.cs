using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层INewsDAL 的摘要说明。
	/// </summary>
    public interface IArticlesDAL
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(TFXK.Model.Articles model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(TFXK.Model.Articles model);
          /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="id">编号</param>
        void UpdateClick(int id);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		TFXK.Model.Articles GetModel(int id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
        /// <summary>
        /// 根据父类编码获取所有子类数据
        /// </summary>
        /// <param name="codeNo">父类编码</param>
        /// <returns>数据集</returns>
        DataSet GetTopListByCodeNo(int Top, string codeNo, string orderId);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		#endregion  成员方法

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="id">序号</param>
        /// <param name="orderid">排序</param>
        void UpdateOrders(int id, int orderid, string fildName);
	}
}
