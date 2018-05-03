using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类OrderProListsDAL。
    /// </summary>
    public class OrderProListsDAL : IOrderProListsDAL
    {
        public OrderProListsDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_OrderProLists");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_OrderProLists");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.OrderProLists model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_OrderProLists(");
            strSql.Append("orderID,productID,orderNum,productPrice,totalMoney)");
            strSql.Append(" values (");
            strSql.Append("@orderID,@productID,@orderNum,@productPrice,@totalMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@orderID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.Int,4),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@productPrice", SqlDbType.Decimal,9),
					new SqlParameter("@totalMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.orderID;
            parameters[1].Value = model.productID;
            parameters[2].Value = model.orderNum;
            parameters[3].Value = model.productPrice;
            parameters[4].Value = model.totalMoney;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.OrderProLists model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_OrderProLists set ");
            strSql.Append("orderID=@orderID,");
            strSql.Append("productID=@productID,");
            strSql.Append("orderNum=@orderNum,");
            strSql.Append("productPrice=@productPrice,");
            strSql.Append("totalMoney=@totalMoney");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.Int,4),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@productPrice", SqlDbType.Decimal,9),
					new SqlParameter("@totalMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.orderID;
            parameters[2].Value = model.productID;
            parameters[3].Value = model.orderNum;
            parameters[4].Value = model.productPrice;
            parameters[5].Value = model.totalMoney;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OrderProLists ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除全部 根据订单编号
        /// </summary>
        /// <param name="id"></param>
        public void DeleteByOID(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OrderProLists ");
            strSql.Append(" where orderID=@orderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@orderID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.OrderProLists GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderID,productID,orderNum,productPrice,totalMoney from tb_OrderProLists ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.OrderProLists model = new TFXK.Model.OrderProLists();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderID"].ToString() != "")
                {
                    model.orderID = int.Parse(ds.Tables[0].Rows[0]["orderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productID"].ToString() != "")
                {
                    model.productID = int.Parse(ds.Tables[0].Rows[0]["productID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderNum"].ToString() != "")
                {
                    model.orderNum = int.Parse(ds.Tables[0].Rows[0]["orderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productPrice"].ToString() != "")
                {
                    model.productPrice = decimal.Parse(ds.Tables[0].Rows[0]["productPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["totalMoney"].ToString() != "")
                {
                    model.totalMoney = decimal.Parse(ds.Tables[0].Rows[0]["totalMoney"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.OrderProLists GetModel(int pid, int oid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderID,productID,orderNum,productPrice,totalMoney from tb_OrderProLists ");
            strSql.Append(" where productID=@productID ");
            strSql.Append(" and orderID=@orderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@productID", SqlDbType.Int,4),
                    new SqlParameter("@orderID", SqlDbType.Int,4)};
            parameters[0].Value = pid;
            parameters[1].Value = oid;

            TFXK.Model.OrderProLists model = new TFXK.Model.OrderProLists();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderID"].ToString() != "")
                {
                    model.orderID = int.Parse(ds.Tables[0].Rows[0]["orderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productID"].ToString() != "")
                {
                    model.productID = int.Parse(ds.Tables[0].Rows[0]["productID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderNum"].ToString() != "")
                {
                    model.orderNum = int.Parse(ds.Tables[0].Rows[0]["orderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productPrice"].ToString() != "")
                {
                    model.productPrice = decimal.Parse(ds.Tables[0].Rows[0]["productPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["totalMoney"].ToString() != "")
                {
                    model.totalMoney = decimal.Parse(ds.Tables[0].Rows[0]["totalMoney"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderID,productID,orderNum,productPrice,totalMoney ");
            strSql.Append(" FROM tb_OrderProLists ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,orderID,productID,orderNum,productPrice,totalMoney ");
            strSql.Append(" FROM tb_OrderProLists ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_OrderProLists";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

