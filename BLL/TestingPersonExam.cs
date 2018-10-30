﻿using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Common;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
	/// <summary>
	/// TestingPersonExam
	/// </summary>
	public partial class TestingPersonExam
	{
		private readonly ITestingPersonExam dal=DataAccess.CreateTestingPersonExam();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public TestingPersonExam()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int planid,string idNumber)
		{
			return dal.Exists(planid,idNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TFXK.Model.TestingPersonExam model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TFXK.Model.TestingPersonExam model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.TestingPersonExam GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TFXK.Model.TestingPersonExam> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TFXK.Model.TestingPersonExam> DataTableToList(DataTable dt)
		{
			List<TFXK.Model.TestingPersonExam> modelList = new List<TFXK.Model.TestingPersonExam>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TFXK.Model.TestingPersonExam model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string where, out int rowCount)
        {
            return GetList("[tb_TestingPersonExam]", PageSize, PageIndex, where, "id desc", out rowCount);
        }

        public DataSet GetListFull(int PageSize, int PageIndex, string where, out int rowCount)
        {
            DataSet ds = bll.GetList("[tb_TestingPersonExam]", "id", "*", PageSize, PageIndex, where, "id desc", out rowCount);
            return ds;
        }

        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="strWhere">查询条件(注意: 不要加 where)</param>
        /// <param name="strOrder">排序索引字段名和排序方式如（orderBy desc,id asc）支持多列排序方式</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        private DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            DataSet ds = bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
            return ds;
        }
        #endregion  ExtensionMethod
    }
}
