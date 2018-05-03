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
    /// 业务逻辑类ProductsBLL 的摘要说明。
    /// </summary>
    public class ProductsBLL
    {
        private readonly IProductsDAL dal = DataAccess.CreateProductsDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        private readonly CategoryBLL bllCategory = new CategoryBLL();

        public ProductsBLL()
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
        public int Add(TFXK.Model.Products model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Products model)
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
        public TFXK.Model.Products GetModel(int id)
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
        public List<TFXK.Model.Products> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.Products> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Products> modelList = new List<TFXK.Model.Products>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Products model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Products();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["parentID"].ToString() != "")
                    {
                        model.parentID = int.Parse(dt.Rows[n]["parentID"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.codeNo = dt.Rows[n]["codeNo"].ToString();
                    if (dt.Rows[n]["brandID"].ToString() != "")
                    {
                        model.brandID = int.Parse(dt.Rows[n]["brandID"].ToString());
                    }
                    model.brandName = dt.Rows[n]["brandName"].ToString();
                    model.danwei = dt.Rows[n]["danwei"].ToString();
                    if (dt.Rows[n]["salePrice"].ToString() != "")
                    {
                        model.salePrice = decimal.Parse(dt.Rows[n]["salePrice"].ToString());
                    }
                    if (dt.Rows[n]["cusPrice"].ToString() != "")
                    {
                        model.cusPrice = decimal.Parse(dt.Rows[n]["cusPrice"].ToString());
                    }
                    model.mianliao = dt.Rows[n]["mianliao"].ToString();
                    model.colorname = dt.Rows[n]["colorname"].ToString();
                    model.cpdes = dt.Rows[n]["cpdes"].ToString();
                    model.fzccdes = dt.Rows[n]["fzccdes"].ToString();
                    model.xdbxdes = dt.Rows[n]["xdbxdes"].ToString();
                    model.shfwdes = dt.Rows[n]["shfwdes"].ToString();
                    model.admindes = dt.Rows[n]["admindes"].ToString();
                    if (dt.Rows[n]["clicks"].ToString() != "")
                    {
                        model.clicks = int.Parse(dt.Rows[n]["clicks"].ToString());
                    }
                    if (dt.Rows[n]["orderID"].ToString() != "")
                    {
                        model.orderID = int.Parse(dt.Rows[n]["orderID"].ToString());
                    }
                    if (dt.Rows[n]["isHot"].ToString() != "")
                    {
                        model.isHot = int.Parse(dt.Rows[n]["isHot"].ToString());
                    }
                    if (dt.Rows[n]["isTuijian"].ToString() != "")
                    {
                        model.isTuijian = int.Parse(dt.Rows[n]["isTuijian"].ToString());
                    }
                    if (dt.Rows[n]["desFild1"].ToString() != "")
                    {
                        model.desFild1 = int.Parse(dt.Rows[n]["desFild1"].ToString());
                    }
                    model.desFild2 = dt.Rows[n]["desFild2"].ToString();
                    model.desFild3 = dt.Rows[n]["desFild3"].ToString();
                    model.desFild4 = dt.Rows[n]["desFild4"].ToString();
                    if (dt.Rows[n]["typeID"].ToString() != "")
                    {
                        model.typeID = int.Parse(dt.Rows[n]["typeID"].ToString());
                    }
                    model.imgPath = dt.Rows[n]["imgPath"].ToString();
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
            return GetList("[tb_Products]", PageSize, PageIndex, "", "orderId desc, id desc", out rowCount);
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
            return GetList("[tb_Products]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllListByCodeNoAndExtCode(int PageSize, int PageIndex, string codeNo, string extCode, string words, string wheres, out int rowCount)
        {
            string orderBys = "orderId desc, id desc";
            StringBuilder strSql = new StringBuilder();
            string childNodeid = bllCategory.GetAllChildIDByCode(codeNo);
            strSql.Append("  parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" ) ");

            string extIDS = string.Empty;
            if (!string.IsNullOrEmpty(extCode))
            {
                ProExtCategoryBLL bllProext = new ProExtCategoryBLL();
                extIDS = bllProext.GetPidByExtCode(extCode);

                if (!string.IsNullOrEmpty(extIDS))
                {
                    strSql.Append(" and id in(" + extIDS + ") ");
                }
                else
                {
                    rowCount = 0;
                    return null;
                }
            }
            if (!string.IsNullOrEmpty(words))
            {
                strSql.Append(" and title like '%" + words + "%'");
            }

            if (!string.IsNullOrEmpty(wheres))
            {
                strSql.Append(" and " + wheres);
                if(wheres.Contains("hot"))
                {
                    orderBys="clicks desc,orderId desc, id desc";
                }
            }

            return GetList("[tb_Products]", PageSize, PageIndex, strSql.ToString(),orderBys , out rowCount);
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
            return GetList("[tb_Products]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
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
        public DataSet GetAllListByCodeNo(int PageSize, int PageIndex, string codeNo, string strWhere, string orderBy, out int rowCount)
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
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "orderId desc, id desc";
            }
            return GetList("[tb_Products]", PageSize, PageIndex, strSql.ToString(), orderBy, out rowCount);
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
            return GetList("[tb_Products]", PageSize, PageIndex, "parentId=" + pid, "orderId desc, id desc", out rowCount);
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
            return GetList("[tb_Products]", PageSize, PageIndex, "parentId=" + pid + " and " + strWhere, "orderId desc , id desc", out rowCount);
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
        public DataSet GetSearchNameList(int PageSize, int PageIndex, string name, int parentId, string where, out int rowCount)
        {
            if (!string.IsNullOrEmpty(where))
            {
                where = " and " + where;
            }
            return GetList("[tb_Products]", PageSize, PageIndex, " title like '%" + name + "%' and parentId=" + parentId + where, "orderId desc, id desc", out rowCount);
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
            return GetList("[tb_Products]", PageSize, PageIndex, " title like '%" + name + "%'and parentId=" + parentId, "orderId desc, id desc", out rowCount);
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
            strSql.Append(" and desFild1=1");
            return GetList("[tb_Products]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
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
            strSql.Append(" and desFild1=1");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" and " + where);
            }
            return GetList("[tb_Products]", PageSize, PageIndex, strSql.ToString(), "orderId desc, id desc", out rowCount);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tid">属性ID</param>
        /// <param name="typeid">0为推荐 1为热门 2活动促销</param>
        public void Update(int id, int tid, int typeid)
        {
            dal.Update(id, tid, typeid);
        }
        /// <summary>
        /// 得到一个对象实体 id,title,codeNo有效
        /// </summary>
        public TFXK.Model.Products GetSimpleModel(string codeNo)
        {
            return dal.GetSimpleModel(codeNo);
        }

    }
}

