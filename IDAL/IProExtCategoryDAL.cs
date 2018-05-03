using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层IProExtCategoryDAL 的摘要说明。
	/// </summary>
	public interface IProExtCategoryDAL
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
		int Add(TFXK.Model.ProExtCategory model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(TFXK.Model.ProExtCategory model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteByPid(int id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetListByPid(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		TFXK.Model.ProExtCategory GetModel(int id);
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
	}
}
