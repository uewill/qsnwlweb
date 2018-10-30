using System;
using System.Data;
using TFXK.Model;

namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层TestingPerson
	/// </summary>
	public interface ITestingPerson
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
        bool Exists(string phoneNumber);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(TFXK.Model.TestingPerson model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(TFXK.Model.TestingPerson model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		bool DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		TFXK.Model.TestingPerson GetModel(int id);
		TFXK.Model.TestingPerson DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
        TestingPerson GetModelByPhone(string phoneNumber);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}
