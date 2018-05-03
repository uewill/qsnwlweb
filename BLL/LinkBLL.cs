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
    /// 业务逻辑类LinkBLL 的摘要说明。
    /// </summary>
    public class LinkBLL
    {
        private readonly ILinkDAL dal = DataAccess.CreateLinkDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();

        public LinkBLL()
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
        public int Add(TFXK.Model.Link model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Link model)
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
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Link GetModel(int id)
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
        public DataSet GetListByIsPictureOn(int top, string strWhere)
        {
            return GetList(top, "IsPictureOn='" + strWhere + "'", "orderId, id");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetParentListByIsPictureOn(string isPictureOn, string parentId)
        {
            return GetList("IsPictureOn='" + isPictureOn + "' and parentId=" + parentId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.Link> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 根据条件得到总条数
        /// </summary>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 根据条件得到总条数
        /// </summary>
        /// <returns></returns>
        public int GetCountByIsPictureOn(string strWhere)
        {
            return GetCount("IsPictureOn=" + strWhere);
        }

        /// <summary>
        /// 根据现实方式分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="isPictureOn">0:文字链接, 1: 图片链接</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string isPictureOn, out int rowCount)
        {
            return GetList("[tb_Link]", PageSize, PageIndex, "isPictureOn='" + isPictureOn + "'", "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, out int rowCount)
        {
            return GetList("[tb_Link]", PageSize, PageIndex, "", "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// 姓名搜索
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="name">姓名</param>
        /// <param name="isPictureOn">0:文字链接, 1: 图片链接</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetSearchNameList(int PageSize, int PageIndex, string name,  out int rowCount)
        {
            return GetList("[tb_Link]", PageSize, PageIndex, " title like '%" + name + "%'", "orderId desc, id desc", out rowCount);
        }

        #region 私有方法
        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="strWhere">查询条件(注意: 不要加 where)</param>
        /// <param name="strOrder">排序索引字段名和排序方式如（orderBy desc,id asc）支持多列排序方式</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        private DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            DataSet ds = bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
            return ds;
        }
        #endregion

        #endregion  成员方法
    }
}

