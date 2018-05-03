using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
    /// <summary>
    /// 业务逻辑类PicturesBLL 的摘要说明。
    /// </summary>
    public class PicturesBLL
    {
        private readonly IPicturesDAL dal = DataAccess.CreatePicturesDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public PicturesBLL()
        { }
        #region  成员方法
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
        public int Add(TFXK.Model.Pictures model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Pictures model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByPath(string imgPath)
        {
            dal.DeleteByPath(imgPath);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Pictures GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Pictures GetModel(int pid, int tid)
        {

            try
            {
                DataSet ds = dal.GetList(pid, tid);
                Pictures model = DataTableToList(ds.Tables[0])[0];
                return model;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.Pictures> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.Pictures> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Pictures> modelList = new List<TFXK.Model.Pictures>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Pictures model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Pictures();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["typeID"].ToString() != "")
                    {
                        model.typeID = int.Parse(dt.Rows[n]["typeID"].ToString());
                    }
                    if (dt.Rows[n]["parentID"].ToString() != "")
                    {
                        model.parentID = int.Parse(dt.Rows[n]["parentID"].ToString());
                    }
                    model.imgPath = dt.Rows[n]["imgPath"].ToString();
                    model.imgAlt = dt.Rows[n]["imgAlt"].ToString();
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
        /// 更新一条数据
        /// </summary>
        public void Update(int oPid, int oTid, int NewPid, int NewTid)
        {
            dal.Update(oPid, oTid, NewPid, NewTid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int pid, int tid)
        {
            dal.Delete(pid, tid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pid, int tid)
        {
            return dal.GetList(pid, tid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTopThreeList(int pid, int tid)
        {
            return dal.GetTopThreeList(pid, tid);

        }
        public DataSet GetList(int size, int PageIndex, string where, out int count)
        {
            return bll.GetList("[tb_Pictures]", size, PageIndex, where, "id", out count);
        }

        #endregion  成员方法

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdatePid(int id, int parentid) {
            dal.UpdatePid(id, parentid);
        }
    }
}

