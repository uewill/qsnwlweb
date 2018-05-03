using System;
using System.Collections.Generic;
using System.Text;
using TFXK.IDAL;
using System.Data;
using System.Data.SqlClient;

using TFXK.DBUtility;

namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 分页
    /// </summary>
    public class DataPageListDAL : IDataPageListDAL
    {
        public DataPageListDAL() { }

        #region 存储过程分页

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
        public DataSet GetList(string tblName, string sPkey, string sFild, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            SqlParameter[] parameters = GetParameters(tblName,sPkey,sFild, PageSize, PageIndex, strWhere, strOrder);

            DataSet ds = DbHelperSQL.RunProcedure("proc_CommonPaging", parameters, tblName);

            rowCount = Int32.Parse(parameters[7].Value.ToString());

            return ds;
        }
        #endregion

        #region 参数
        /// <summary>
        /// 存储过程分页参数
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="sPkey">主键</param>
        /// <param name="sFild">查询字段</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="strWhere">查询条件(注意: 不要加 where)</param>
        /// <param name="strOrder">排序索引字段名</param>
        /// <param name="strOrderType">设置排序类型, 非 0 值则降序</param>
        /// <returns>参数集</returns>
        private SqlParameter[] GetParameters(string tblName,string sPkey,string sFild,  int PageSize,int PageIndex, string strWhere, string strOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 5000),   //表名
					new SqlParameter("@sPkey", SqlDbType.VarChar, 50), //主表主键
					new SqlParameter("@sField", SqlDbType.VarChar,5000),  //查询字段
                    new SqlParameter("@iPageCurr", SqlDbType.Int),    //当前页数
					new SqlParameter("@iPageSize", SqlDbType.Int),   //每页记录数
					new SqlParameter("@sWhere ", SqlDbType.VarChar,5000), //条件（不需要where）
                    new SqlParameter("@sOrder", SqlDbType.VarChar,100),  //排序字段（不需要order by 需要字段和asc,desc）
					new SqlParameter("@Counts", SqlDbType.Int),  //返回总条数
                    new SqlParameter("@pageCount", SqlDbType.Int)  //返回总页数
					};
            parameters[0].Value = tblName;
            parameters[1].Value = sPkey;
            parameters[2].Value = sFild;
            parameters[3].Value = PageIndex;
            parameters[4].Value = PageSize;
            parameters[5].Value = strWhere;
            parameters[6].Value = strOrder;
            parameters[7].Direction = ParameterDirection.Output;
            parameters[8].Direction = ParameterDirection.Output;

            return parameters;
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
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        public int DeleteByIDS(string table, string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(table);
            strSql.Append(" where ");
            strSql.Append("id in("+ids+")");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
    }
}