using System;
using System.Collections.Generic;
using System.Text;

using TFXK.DALFactory;
using TFXK.IDAL;
using System.Data;

namespace TFXK.BLL
{
    /// <summary>
    /// 分页类
    /// </summary>
    public class DataPageListBLL
    {
        private readonly IDataPageListDAL dal = DataAccess.CreateDataPageListDAL();

        public DataPageListBLL()
        {

        }

        /// <summary>
        /// 查询内容
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="sPkey">主键</param>
        /// <param name="sFild">查询的列</param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序索引字段名和排序方式如（orderBy desc,id asc）支持多列排序方式</param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public DataSet GetList(string tblName, string sPkey, string sFild, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            return dal.GetList(tblName, sPkey, sFild, PageSize, PageIndex, strWhere, strOrder, out rowCount);
        }


        /// <summary>
        /// 单表查询所有内容
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序索引字段名和排序方式如（orderBy desc,id asc）支持多列排序方式</param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            return dal.GetList(tblName, "id", "*", PageSize, PageIndex, strWhere, strOrder, out rowCount);
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        /// <param name="clicks">点击数</param>
        public void Update(string table, int id)
        {
            dal.Update(table, id);
        }
        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名不加tb_</param>
        /// <param name="id">编号</param>
        public int DeleteByIDS(string table, string ids)
        {
            return dal.DeleteByIDS("tb_"+table, ids);
        }
    }
}
