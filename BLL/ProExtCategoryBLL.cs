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
    /// 业务逻辑类ProExtCategoryBLL 的摘要说明。
    /// </summary>
    public class ProExtCategoryBLL
    {
        private readonly IProExtCategoryDAL dal = DataAccess.CreateProExtCategoryDAL();
        private readonly static CategoryBLL bllCategory = new CategoryBLL();
        public ProExtCategoryBLL()
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
        public int Add(TFXK.Model.ProExtCategory model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.ProExtCategory model)
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
        public void DeleteByPid(int id)
        {
            dal.DeleteByPid(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByPid(int id)
        {
            return dal.GetListByPid(id);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.ProExtCategory GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<TFXK.Model.ProExtCategory> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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

