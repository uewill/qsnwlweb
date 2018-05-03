using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层IProductsDAL 的摘要说明。
	/// </summary>
	public interface IProductsDAL
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(TFXK.Model.Products model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(TFXK.Model.Products model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		TFXK.Model.Products GetModel(int id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="id">序号</param>
        /// <param name="orderid">排序</param>
       void UpdateOrders(int id, int orderid, string fildName);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="tid">属性ID</param>
       /// <param name="typeid">0为推荐 1为热门</param>
      void Update(int id, int tid, int typeid);
          /// <summary>
        /// 得到一个对象实体 id,title,codeNo有效
        /// </summary>
      TFXK.Model.Products GetSimpleModel(string codeNo);
	}
}
