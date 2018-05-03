using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
    /// <summary>
    /// ҵ���߼���AdsBLL ��ժҪ˵����
    /// </summary>
    public class AdsBLL
    {
        private readonly IAdsDAL dal = DataAccess.CreateAdsDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public AdsBLL()
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
        public int Add(TFXK.Model.Ads model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Ads model)
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
        public TFXK.Model.Ads GetModel(int id)
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
        public List<TFXK.Model.Ads> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Ads> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Ads> modelList = new List<TFXK.Model.Ads>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Ads model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Ads();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    if (dt.Rows[n]["typeid"].ToString() != "")
                    {
                        model.typeid = int.Parse(dt.Rows[n]["typeid"].ToString());
                    }
                    model.linkUrl = dt.Rows[n]["linkUrl"].ToString();
                    model.linkImage = dt.Rows[n]["linkImage"].ToString();
                    model.linkdes = dt.Rows[n]["linkdes"].ToString();
                    if (dt.Rows[n]["orderid"].ToString() != "")
                    {
                        model.orderid = int.Parse(dt.Rows[n]["orderid"].ToString());
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
            DataSet ds = bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
            return ds;
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere, out int rowCount)
        {
           return bll.GetList("tb_Ads", PageSize, PageIndex, strWhere, "typeid,orderid desc,id desc", out rowCount);
        }
        #endregion
    }
}

