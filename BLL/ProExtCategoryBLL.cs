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
    /// ҵ���߼���ProExtCategoryBLL ��ժҪ˵����
    /// </summary>
    public class ProExtCategoryBLL
    {
        private readonly IProExtCategoryDAL dal = DataAccess.CreateProExtCategoryDAL();
        private readonly static CategoryBLL bllCategory = new CategoryBLL();
        public ProExtCategoryBLL()
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
        public int Add(TFXK.Model.ProExtCategory model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.ProExtCategory model)
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
        public void DeleteByPid(int id)
        {
            dal.DeleteByPid(id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetListByPid(int id)
        {
            return dal.GetListByPid(id);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.ProExtCategory GetModel(int id)
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
        public List<TFXK.Model.ProExtCategory> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.ProExtCategory> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.ProExtCategory> modelList = new List<TFXK.Model.ProExtCategory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.ProExtCategory model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.ProExtCategory();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["productID"].ToString() != "")
                    {
                        model.productID = int.Parse(dt.Rows[n]["productID"].ToString());
                    }
                    if (dt.Rows[n]["extCateID"].ToString() != "")
                    {
                        model.extCateID = int.Parse(dt.Rows[n]["extCateID"].ToString());
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

        public string GetPidByExtCode(string code)
        {
            string res = "";
            if (!string.IsNullOrEmpty(code))
            {
                int cid = bllCategory.GetIdByCodeNo(code);
                List<ProExtCategory> allList = GetModelList("extCateID=" + cid);
                if (allList != null && allList.Count > 0)
                {
                    foreach (ProExtCategory item in allList)
                    {
                        res += item.productID + ",";
                    }
                }
            }

            return res.TrimEnd(',');
        }
    }
}

