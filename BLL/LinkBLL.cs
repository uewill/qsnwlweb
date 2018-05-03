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
    /// ҵ���߼���LinkBLL ��ժҪ˵����
    /// </summary>
    public class LinkBLL
    {
        private readonly ILinkDAL dal = DataAccess.CreateLinkDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();

        public LinkBLL()
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
        public int Add(TFXK.Model.Link model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Link model)
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
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Link GetModel(int id)
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
        public DataSet GetListByIsPictureOn(int top, string strWhere)
        {
            return GetList(top, "IsPictureOn='" + strWhere + "'", "orderId, id");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetParentListByIsPictureOn(string isPictureOn, string parentId)
        {
            return GetList("IsPictureOn='" + isPictureOn + "' and parentId=" + parentId);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Link> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Link> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Link> modelList = new List<TFXK.Model.Link>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Link model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Link();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.linkUrl = dt.Rows[n]["linkUrl"].ToString();
                    model.logo = dt.Rows[n]["logo"].ToString();
                    model.isPictureOn = dt.Rows[n]["isPictureOn"].ToString();
                    if (dt.Rows[n]["orderId"].ToString() != "")
                    {
                        model.orderId = int.Parse(dt.Rows[n]["orderId"].ToString());
                    }
                    model.description = dt.Rows[n]["description"].ToString();
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
        /// ���������õ�������
        /// </summary>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ���������õ�������
        /// </summary>
        /// <returns></returns>
        public int GetCountByIsPictureOn(string strWhere)
        {
            return GetCount("IsPictureOn=" + strWhere);
        }

        /// <summary>
        /// ������ʵ��ʽ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="isPictureOn">0:��������, 1: ͼƬ����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string isPictureOn, out int rowCount)
        {
            return GetList("[tb_Link]", PageSize, PageIndex, "isPictureOn='" + isPictureOn + "'", "orderId desc, id desc", out rowCount);
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
            return GetList("[tb_Link]", PageSize, PageIndex, "", "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="name">����</param>
        /// <param name="isPictureOn">0:��������, 1: ͼƬ����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetSearchNameList(int PageSize, int PageIndex, string name,  out int rowCount)
        {
            return GetList("[tb_Link]", PageSize, PageIndex, " title like '%" + name + "%'", "orderId desc, id desc", out rowCount);
        }

        #region ˽�з���
        /// <summary>
        /// �洢���̷�ҳ
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="strWhere">��ѯ����(ע��: ��Ҫ�� where)</param>
        /// <param name="strOrder">���������ֶ���������ʽ�磨orderBy desc,id asc��֧�ֶ�������ʽ</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        private DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            DataSet ds = bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
            return ds;
        }
        #endregion

        #endregion  ��Ա����
    }
}

