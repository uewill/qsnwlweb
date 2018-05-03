using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
using TFXK.Common;
namespace TFXK.BLL
{
    /// <summary>
    /// ҵ���߼���UsersBLL ��ժҪ˵����
    /// </summary>
    public class UsersBLL
    {
        private readonly IUsersDAL dal = DataAccess.CreateUsersDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public UsersBLL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string userName, string password)
        {
            if (password != string.Empty && password != null)
            {
                password = Security.EncryptPassword(password, "MD5");
            }
            return dal.Exists(userName, password);
        }

        /// <summary>
        /// �Ƿ����name
        /// </summary>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TFXK.Model.Users model)
        {
            int row = 0;
            if (!Exists(model.userName, ""))
            {
                model.password = Security.EncryptPassword(model.password, "MD5");
                row = dal.Add(model);
            }
            else
            {
                row = -1;
            }

            return row;
        }

        /// <summary>
        ///  ���״̬
        /// </summary>
        public void UpdateStatus(TFXK.Model.Users model)
        {
            //  dal.UpdateStatus(model);
        }

        /// <summary>
        ///  ��������
        /// </summary>
        public void UpdatePassword(TFXK.Model.Users model)
        {
            model.password = Security.EncryptPassword(model.password, "MD5");
            dal.UpdatePassword(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Users model)
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
        public TFXK.Model.Users GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Users GetModelByUserName(string username)
        {

            return dal.GetModelByUserName(username);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Users> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Users> modelList = new List<TFXK.Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Users();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.userName = dt.Rows[n]["userName"].ToString();
                    model.password = dt.Rows[n]["password"].ToString();
                    model.trueName = dt.Rows[n]["trueName"].ToString();
                    model.email = dt.Rows[n]["email"].ToString();
                    model.telephone = dt.Rows[n]["telephone"].ToString();
                    model.address = dt.Rows[n]["address"].ToString();
                    if (dt.Rows[n]["roleid"].ToString() != "")
                    {
                        model.roleid = int.Parse(dt.Rows[n]["roleid"].ToString());
                    }
                    model.question = dt.Rows[n]["question"].ToString();
                    model.answer = dt.Rows[n]["answer"].ToString();
                    if (dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["regDate"].ToString() != "")
                    {
                        model.regDate = DateTime.Parse(dt.Rows[n]["regDate"].ToString());
                    }
                    if (dt.Rows[n]["lastLoginDate"].ToString() != "")
                    {
                        model.lastLoginDate = DateTime.Parse(dt.Rows[n]["lastLoginDate"].ToString());
                    }
                    if (dt.Rows[n]["loginCount"].ToString() != "")
                    {
                        model.loginCount = int.Parse(dt.Rows[n]["loginCount"].ToString());
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

        #endregion



        #region ˽�з���




        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="name">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string name, int bumen, out int rowCount)
        {
            name = StringUtil.CheckStr(name);
            string where = string.Empty;
            if (bumen > 0)
            {
                where = " and question='" + bumen + "'";
            }
            DataSet ds = bll.GetList("[tb_Users]", PageSize, PageIndex, " trueName like '%" + name + "%' " + where, "id", out rowCount);
            return ds;
        }


        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="rowCount">������</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, out int rowCount)
        {
            DataSet ds = bll.GetList("[tb_Users]", PageSize, PageIndex, "", "id", out rowCount);
            return ds;
        }



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

        #endregion  ��Ա����
    }


}

