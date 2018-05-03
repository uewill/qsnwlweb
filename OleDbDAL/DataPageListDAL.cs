using System;
using System.Collections.Generic;
using System.Text;
using TFXK.IDAL;
using System.Data;
using System.Data.OleDb;

using TFXK.DBUtility;

namespace TFXK.OleDbDAL
{
    /// <summary>
    /// 分页
    /// </summary>
    public class DataPageListDAL : IDataPageListDAL
    {
        public DataPageListDAL() { }

        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="strWhere">查询条件(注意: 不要加 where)</param>
        /// <param name="strOrder">排序索引字段名</param>
        /// <param name="strOrderType">设置排序类型, 非 0 值则降序</param>
        /// <param name="recordCount">输出值,总数</param>
        /// <returns></returns>
        public DataSet GetList(string TableName, int pagesize, int pageindex, string strWhere, string orderCol, int strOrderType, out int recordCount)
        {
            string orderType = " DESC";
            if (strOrderType == 0)
            {
                orderType = " ASC";
            }
            if (pageindex < 1) pageindex = 1;

            StringBuilder strCount = new StringBuilder();
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1=1 ";
            }
            strCount.AppendFormat("select count(*) from {0} where {1}", TableName, strWhere);
            object obj = DbHelperOleDb.GetSingle(strCount.ToString());
            if (obj == null)
            {
                recordCount = 0;
            }
            else
            {
                recordCount = Convert.ToInt32(obj);
            }
            int pageCount = 0;
            if ((recordCount % pagesize) > 0)
                pageCount = recordCount / pagesize + 1;
            else
                pageCount = recordCount / pagesize;

            if (pageindex > pageCount)
                pageindex = pageCount;

            StringBuilder strSql = new StringBuilder();
            if (pageindex <= 1)
            {
                strSql.AppendFormat("select top {0} * from {1} where {2}", pagesize.ToString(), TableName, strWhere);
            }
            else
            {
                strSql.AppendFormat("select top {0} * from {1} ", pagesize, TableName);
                strSql.AppendFormat(" where id not in (select top {0} id from {1} ", pagesize * (pageindex - 1), TableName);
                if (strWhere.Trim() != "")
                {
                    strSql.AppendFormat(" where {0} order by {1} {2}) and {0}", strWhere, orderCol, orderType);
                }
                else
                {
                    strSql.AppendFormat(" order by {0} {1}) ", orderCol, orderType);
                }
            }
            strSql.AppendFormat(" order by {0} {1}", orderCol, orderType);
            pageCount = Int32.Parse(recordCount.ToString());
            return DbHelperOleDb.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        public void Update(string table, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(table);
            strSql.Append(" set ");
            strSql.Append("clicks=clicks+1 ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}