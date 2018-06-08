﻿using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层TestingCenter
	/// </summary>
	public interface ITestingCenter
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
        bool ExistsName(string name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(TFXK.Model.TestingCenter model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(TFXK.Model.TestingCenter model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		bool DeleteList(string idlist );
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TFXK.Model.TestingCenter GetModel(int id);
        TFXK.Model.TestingCenter GetModelByName(string name);
        TFXK.Model.TestingCenter DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
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
