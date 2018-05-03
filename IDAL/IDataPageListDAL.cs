using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TFXK.IDAL
{
    public interface IDataPageListDAL
    {
        #region  成员方法

        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="sPkey">主键</param>
        /// <param name="sFild">查询的列名</param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序索引字段名和排序方式如（orderBy desc,id asc）支持多列排序方式</param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        DataSet GetList(string tblName, string sPkey, string sFild, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount);

        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        /// <param name="clicks">点击数</param>
        void Update(string table, int id);

          /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="ids">编号</param>
        int DeleteByIDS(string table, string ids);
        #endregion  成员方法
    }
}
