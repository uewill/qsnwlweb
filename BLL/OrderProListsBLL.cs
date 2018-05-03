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
    /// ҵ���߼���OrderProListsBLL ��ժҪ˵����
    /// </summary>
    public class OrderProListsBLL
    {
        private readonly IOrderProListsDAL dal = DataAccess.CreateOrderProListsDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public OrderProListsBLL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TFXK.Model.OrderProLists model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.OrderProLists model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void DeleteByOID(int id)
        {

            dal.DeleteByOID(id);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.OrderProLists GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.OrderProLists GetModel(int pid, int oid)
        {

            return dal.GetModel(pid, oid);

        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.OrderProLists> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����


        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByOID(int PageSize, int PageIndex, int orderid, out int rowCount)
        {
            return bll.GetList("[tb_OrderProLists] as a left join [tb_ExtProducts] as b on a.productID=b.id", "a.id", "a.id,a.orderid,a.productid,a.ordernum,a.productprice,a.totalmoney,b.proTitle", PageSize, PageIndex, " a.orderID=" + orderid, "a.id asc", out rowCount);
        }
    }
}

