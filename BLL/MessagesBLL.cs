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
    /// ҵ���߼���MessagesBLL ��ժҪ˵����
    /// </summary>
    public class MessagesBLL
    {
        private readonly IMessagesDAL dal = DataAccess.CreateMessagesDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public MessagesBLL()
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
        public int Add(TFXK.Model.Messages model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Messages model)
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
        public TFXK.Model.Messages GetModel(int id)
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
        public List<TFXK.Model.Messages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Messages> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Messages> modelList = new List<TFXK.Model.Messages>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Messages model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Messages();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.userNames = dt.Rows[n]["userNames"].ToString();
                    model.userEmail = dt.Rows[n]["userEmail"].ToString();
                    model.msgContent = dt.Rows[n]["msgContent"].ToString();
                    model.qicq = dt.Rows[n]["qicq"].ToString();
                    if (dt.Rows[n]["stateid"].ToString() != "")
                    {
                        model.stateid = int.Parse(dt.Rows[n]["stateid"].ToString());
                    }
                    model.recontent = dt.Rows[n]["recontent"].ToString();
                    if (dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
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
        public DataSet GetList_Web(int PageSize, int PageIndex, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("stateid=1");
            return GetList("[tb_Messages]", PageSize, PageIndex, strSql.ToString(), "id desc", out rowCount);
        }


        /// <summary>
        /// ǰ̨��ȡ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string where, out int rowCount)
        {
            return GetList("[tb_Messages]", PageSize, PageIndex, where, "id desc", out rowCount);
        }

        /// <summary>
        /// ǰ̨��ȡ��ҳ
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="codeNo">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, int pid, out int rowCount)
        {
            string where = "qicq='" + pid + "' and stateid=1";
            return GetList("[tb_Messages]", PageSize, PageIndex, where, "id desc", out rowCount);
        }
    }
}

