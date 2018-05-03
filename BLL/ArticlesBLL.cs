using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Common;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
using System.Text;
namespace TFXK.BLL
{
    /// <summary>
    /// ҵ���߼���ArticlesBLL ��ժҪ˵����
    /// </summary>
    public class ArticlesBLL
    {
        private readonly IArticlesDAL dal = DataAccess.CreateArticlesDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        private readonly CategoryBLL bllCategory = new CategoryBLL();

        public ArticlesBLL()
        { }
        #region  ��Ա����
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
        public int Add(TFXK.Model.Articles model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Articles model)
        {
            dal.Update(model);
        }


        /// <summary>
        /// ���µ����
        /// </summary>
        /// <param name="table">����</param>
        /// <param name="id">���</param>
        public void UpdateClick(int id)
        {
            dal.UpdateClick(id);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Articles GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<TFXK.Model.Articles> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Articles> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Articles> modelList = new List<TFXK.Model.Articles>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Articles model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Articles();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["parentId"].ToString() != "")
                    {
                        model.parentId = int.Parse(dt.Rows[n]["parentId"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.source = dt.Rows[n]["source"].ToString();
                    model.publisher = dt.Rows[n]["publisher"].ToString();
                    if (dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
                    }
                    model.description = dt.Rows[n]["description"].ToString();
                    if (dt.Rows[n]["isOutlLink"].ToString() != "")
                    {
                        model.isOutlLink = int.Parse(dt.Rows[n]["isOutlLink"].ToString());
                    }
                    if (dt.Rows[n]["isSlideOn"].ToString() != "")
                    {
                        model.isSlideOn = int.Parse(dt.Rows[n]["isSlideOn"].ToString());
                    }
                    if (dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["clicks"].ToString() != "")
                    {
                        model.clicks = int.Parse(dt.Rows[n]["clicks"].ToString());
                    }
                    if (dt.Rows[n]["orderId"].ToString() != "")
                    {
                        model.orderId = int.Parse(dt.Rows[n]["orderId"].ToString());
                    }
                    model.imgPath = dt.Rows[n]["imgPath"].ToString();
                    model.outLinkPath = dt.Rows[n]["outLinkPath"].ToString();
                    model.fysmDes = dt.Rows[n]["fysmDes"].ToString();
                    model.wxtsDes = dt.Rows[n]["wxtsDes"].ToString();
                    model.ydxzDes = dt.Rows[n]["ydxzDes"].ToString();
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


        #region �Զ��巽��

        /// <summary>
        /// ���ݷ�������ҳ
        /// </summary>
        /// <param name="codeNo">�������</param>
        /// <returns>DataSet</returns>
        public DataSet GetListByCodeNo(string codeNo)
        {
            return GetList("parentId=" + bllCategory.GetIdByCodeNo(codeNo));
        }

        /// <summary>
        /// ���ݷ��������ǰ��������
        /// </summary>
        public DataSet GetListByCodeNo(int Top, string codeNo, string filedOrder)
        {
            return dal.GetList(Top, "parentId=" + bllCategory.GetIdByCodeNo(codeNo), filedOrder);
        }


        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, out int rowCount)
        {
            return GetList("[tb_Articles]", PageSize, PageIndex, "", "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByCodeNo(int PageSize, int PageIndex, string codeNo, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
            strSql.Append("  parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" ) ");
            return GetList("[tb_Articles]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
        }


        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByCodeNo(int PageSize, int PageIndex, string codeNo, string strWhere, out int rowCount)
        {
            // ��ȡ�ӷ������͸�����

            string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  (parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" )) ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" and " + strWhere);
            }
            return GetList("[tb_Articles]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
        }


        /// <summary>
        /// ���ݷ�������ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">�������</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string codeNo, out int rowCount)
        {
            int pid = bllCategory.GetIdByCodeNo(codeNo);
            return GetList("[tb_Articles]", PageSize, PageIndex, "parentId=" + pid, "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// ���ݷ�������ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">�������</param>
        /// <param name="strWhere">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string codeNo, string strWhere, out int rowCount)
        {
            int pid = bllCategory.GetIdByCodeNo(codeNo);
            return GetList("[tb_Articles]", PageSize, PageIndex, "parentId=" + pid + " and " + strWhere, "orderId desc , id desc", out rowCount);
        }

        /// <summary>
        /// ���ݱ���ͷ���������
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="name">����</param>
        /// <param name="parentId">������</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetSearchNameList(int PageSize, int PageIndex, string name, int parentId, out int rowCount)
        {
            return GetList("[tb_Articles]", PageSize, PageIndex, " title like '%" + name + "%' and parentId=" + parentId, "orderId desc, id desc", out rowCount);
        }


        /// <summary>
        /// ����ͷ�������
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="name">����</param>
        /// <param name="parentId">��������</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetSearchNameAndParentIdList(int PageSize, int PageIndex, string name, int parentId, out int rowCount)
        {
            return GetList("[tb_Articles]", PageSize, PageIndex, " title like '%" + name + "%'and parentId=" + parentId, "orderId desc, id desc", out rowCount);
        }

        #region ˽�з���
        /// <summary>
        /// �洢���̷�ҳ
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="strWhere">��ѯ����(ע��: ��Ҫ�� where)</param>
        /// <param name="strOrder">���������ֶ���</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        private DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            return bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
        }
        #endregion


        /// <summary>
        /// ǰ̨��ȡ��ҳ �����
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByCodeNo_Web(int PageSize, int PageIndex, string codeNo, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
            strSql.Append("  parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" ) ");
            strSql.Append(" and state='1'");
            return GetList("[tb_Articles]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
        }


        /// <summary>
        /// ǰ̨��ȡ��ҳ �����
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByCodeNo_Web(int PageSize, int PageIndex, string codeNo, string where, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(codeNo))
            {
                string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
                strSql.Append(" parentId in ");
                strSql.Append(" ( ");
                strSql.Append(childNodeid);
                strSql.Append(" ) ");
            }
            else
            {
                strSql.Append("1=1");
            }
            strSql.Append(" and state='1'");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" and " + where);
            }
            return GetList("[tb_Articles]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
        }



        /// <summary>
        /// ǰ̨��ȡ��ҳ �����
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListWithCateNameByCodeNo_Web(int PageSize, int PageIndex, string codeNo, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
            //strSql.Append("  parentId in ");
            //strSql.Append(" ( ");
            //strSql.Append(childNodeid);
            //strSql.Append(" ) ");
            //strSql.Append(" and state='1'");
            //return GetList("[tb_Articles]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);

            strSql.Append("  a.parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" ) ");
            strSql.Append(" and a.state='1'");
            string searFild = "a.id,a.parentId,a.title,a.source,a.publisher,a.createTime,a.description,a.isOutlLink,a.isSlideOn,a.state,a.clicks,a.orderId,a.imgPath,a.outLinkPath,a.fysmDes,a.wxtsDes,a.ydxzDes,b.title as CategoryName,b.codeNo as codeNo,b.typeid";
            return bll.GetList("[tb_Articles] as a left join [tb_category] as b on a.parentid=b.id","a.id",searFild, PageSize, PageIndex, strSql.ToString(), "a.orderId desc, a.id desc", out rowCount);

        }


        /// <summary>
        /// ǰ̨��ȡ��ҳ �����
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListWithCateNameByCodeNo_Web(int PageSize, int PageIndex, string codeNo, string where, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(codeNo))
            {
                string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
                strSql.Append(" a.parentId in ");
                strSql.Append(" ( ");
                strSql.Append(childNodeid);
                strSql.Append(" ) ");
            }
            else
            {
                strSql.Append("1=1");
            }
            strSql.Append(" and a.state='1'");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" and " + where);
            }
            string searFild = "a.id,a.parentId,a.title,a.source,a.publisher,a.createTime,a.description,a.isOutlLink,a.isSlideOn,a.state,a.clicks,a.orderId,a.imgPath,a.outLinkPath,a.fysmDes,a.wxtsDes,a.ydxzDes,b.title as CategoryName,b.codeNo as codeNo,b.typeid";
            return bll.GetList("[tb_Articles] as a left join [tb_category] as b on a.parentid=b.id", "a.id", searFild, PageSize, PageIndex, strSql.ToString(), "a.orderId desc, a.id desc", out rowCount);
        }


        /// <summary>
        /// ��ȡ��һ��
        /// </summary>
        /// <param name="id">�������</param>
        /// <param name="orderid">����������</param>
        /// <param name="where">�б�����</param>
        /// <returns></returns>
        public Articles GetUpNews(int id, int orderid, string where)
        {
            DataSet ds = new DataSet();
            int rowCount = 0;
            if (!string.IsNullOrEmpty(where))
            {
                where += " and (orderid>" + orderid + " or (id>" + id + " and orderid>=" + orderid + ")) ";
            }
            else
            {
                where = "orderid>" + orderid + " or (id>" + id + " and orderid>=" + orderid + ") ";
            }

            ds = GetList("tb_Articles", 1, 1, where, "orderid asc,id asc", out rowCount);
            try
            {
                return DataTableToList(ds.Tables[0])[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ��ȡ��һ��
        /// </summary>
        /// <param name="id">�������</param>
        /// <param name="orderid">����������</param>
        /// <param name="where">�б�����</param>
        /// <returns></returns>
        public Articles GetDownNews(int id, int orderid, string where)
        {
            DataSet ds = new DataSet();
            int rowCount = 0;
            if (!string.IsNullOrEmpty(where))
            {
                where += " and (orderid<" + orderid + " or (id<" + id + " and orderid<=" + orderid + ")) ";
            }
            else
            {
                where = "orderid<" + orderid + " or (id<" + id + " and orderid<=" + orderid + ") ";
            }

            ds = GetList("tb_Articles", 1, 1, where, "orderid desc,id desc", out rowCount);
            try
            {
                return DataTableToList(ds.Tables[0])[0];
            }
            catch
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderid">����</param>
        public void UpdateOrders(int id, int orderid, string fildName)
        {
            dal.UpdateOrders(id, orderid, fildName);
        }
    }

}

