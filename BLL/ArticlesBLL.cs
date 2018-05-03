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
    /// 业务逻辑类ArticlesBLL 的摘要说明。
    /// </summary>
    public class ArticlesBLL
    {
        private readonly IArticlesDAL dal = DataAccess.CreateArticlesDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        private readonly CategoryBLL bllCategory = new CategoryBLL();

        public ArticlesBLL()
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
        public int Add(TFXK.Model.Articles model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Articles model)
        {
            dal.Update(model);
        }


        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        public void UpdateClick(int id)
        {
            dal.UpdateClick(id);
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
        public TFXK.Model.Articles GetModel(int id)
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
        public List<TFXK.Model.Articles> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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


        #region 自定义方法

        /// <summary>
        /// 根据分类编码分页
        /// </summary>
        /// <param name="codeNo">分类编码</param>
        /// <returns>DataSet</returns>
        public DataSet GetListByCodeNo(string codeNo)
        {
            return GetList("parentId=" + bllCategory.GetIdByCodeNo(codeNo));
        }

        /// <summary>
        /// 根据分类编码获得前几行数据
        /// </summary>
        public DataSet GetListByCodeNo(int Top, string codeNo, string filedOrder)
        {
            return dal.GetList(Top, "parentId=" + bllCategory.GetIdByCodeNo(codeNo), filedOrder);
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
            return GetList("[tb_Articles]", PageSize, PageIndex, "", "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
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
        /// 分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="codeNo">条件</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByCodeNo(int PageSize, int PageIndex, string codeNo, string strWhere, out int rowCount)
        {
            // 获取子分类编码和父分类

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
        /// 根据分类编码分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">分类编码</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string codeNo, out int rowCount)
        {
            int pid = bllCategory.GetIdByCodeNo(codeNo);
            return GetList("[tb_Articles]", PageSize, PageIndex, "parentId=" + pid, "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// 根据分类编码分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">分类编码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string codeNo, string strWhere, out int rowCount)
        {
            int pid = bllCategory.GetIdByCodeNo(codeNo);
            return GetList("[tb_Articles]", PageSize, PageIndex, "parentId=" + pid + " and " + strWhere, "orderId desc , id desc", out rowCount);
        }

        /// <summary>
        /// 根据标题和分类编号搜索
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="name">姓名</param>
        /// <param name="parentId">父类编号</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetSearchNameList(int PageSize, int PageIndex, string name, int parentId, out int rowCount)
        {
            return GetList("[tb_Articles]", PageSize, PageIndex, " title like '%" + name + "%' and parentId=" + parentId, "orderId desc, id desc", out rowCount);
        }


        /// <summary>
        /// 标题和分类搜索
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="name">姓名</param>
        /// <param name="parentId">父分类编号</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetSearchNameAndParentIdList(int PageSize, int PageIndex, string name, int parentId, out int rowCount)
        {
            return GetList("[tb_Articles]", PageSize, PageIndex, " title like '%" + name + "%'and parentId=" + parentId, "orderId desc, id desc", out rowCount);
        }

        #region 私有方法
        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="strWhere">查询条件(注意: 不要加 where)</param>
        /// <param name="strOrder">排序索引字段名</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        private DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            return bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
        }
        #endregion


        /// <summary>
        /// 前台获取分页 已审核
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
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
        /// 前台获取分页 已审核
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
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
        /// 前台获取分页 已审核
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
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
        /// 前台获取分页 已审核
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
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
        /// 获取上一条
        /// </summary>
        /// <param name="id">本条序号</param>
        /// <param name="orderid">本条排序编号</param>
        /// <param name="where">列表条件</param>
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
        /// 获取下一条
        /// </summary>
        /// <param name="id">本条序号</param>
        /// <param name="orderid">本条排序编号</param>
        /// <param name="where">列表条件</param>
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
        /// 更新排序
        /// </summary>
        /// <param name="id">序号</param>
        /// <param name="orderid">排序</param>
        public void UpdateOrders(int id, int orderid, string fildName)
        {
            dal.UpdateOrders(id, orderid, fildName);
        }
    }

}

