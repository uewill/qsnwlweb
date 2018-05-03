using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Common;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
    /// <summary>
    /// 业务逻辑类OrderProListsBLL 的摘要说明。
    /// </summary>
    public class OrderProListsBLL
    {
        private readonly IOrderProListsDAL dal = DataAccess.CreateOrderProListsDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public OrderProListsBLL()
        { }
        #region  成员方法

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
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.OrderProLists model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.OrderProLists model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByOID(int id)
        {

            dal.DeleteByOID(id);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.OrderProLists GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.OrderProLists GetModel(int pid, int oid)
        {

            return dal.GetModel(pid, oid);

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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.OrderProLists> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.OrderProLists> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.OrderProLists> modelList = new List<TFXK.Model.OrderProLists>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.OrderProLists model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.OrderProLists();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["orderID"].ToString() != "")
                    {
                        model.orderID = int.Parse(dt.Rows[n]["orderID"].ToString());
                    }
                    if (dt.Rows[n]["productID"].ToString() != "")
                    {
                        model.productID = int.Parse(dt.Rows[n]["productID"].ToString());
                    }
                    if (dt.Rows[n]["orderNum"].ToString() != "")
                    {
                        model.orderNum = int.Parse(dt.Rows[n]["orderNum"].ToString());
                    }
                    if (dt.Rows[n]["productPrice"].ToString() != "")
                    {
                        model.productPrice = decimal.Parse(dt.Rows[n]["productPrice"].ToString());
                    }
                    if (dt.Rows[n]["totalMoney"].ToString() != "")
                    {
                        model.totalMoney = decimal.Parse(dt.Rows[n]["totalMoney"].ToString());
                    }
                    modelList.Add(model);
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="codeNo">条件</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByOID(int PageSize, int PageIndex, int orderid, out int rowCount)
        {
            return bll.GetList("[tb_OrderProLists] as a left join [tb_ExtProducts] as b on a.productID=b.id", "a.id", "a.id,a.orderid,a.productid,a.ordernum,a.productprice,a.totalmoney,b.proTitle", PageSize, PageIndex, " a.orderID=" + orderid, "a.id asc", out rowCount);
        }
    }
}

