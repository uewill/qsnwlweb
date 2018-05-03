using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层ICustomersDAL 的摘要说明。
	/// </summary>
	public interface ICustomersDAL
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
		int Add(TFXK.Model.Customers model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(TFXK.Model.Customers model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		TFXK.Model.Customers GetModel(int id);
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
        /// 得到一个对象实体
        /// </summary>
       TFXK.Model.Customers GetModelByPhone(string phone);
         /// <summary>
        /// 查询订单数量
        /// </summary>
        /// <param name="isToday">是否今日 0 否 1 是</param>
        /// <returns></returns>
       int GetUserCount(int isToday);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       string GetLoginNameByID(int uid);
	}
}
