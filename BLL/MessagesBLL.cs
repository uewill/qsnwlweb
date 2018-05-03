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
    /// 业务逻辑类MessagesBLL 的摘要说明。
    /// </summary>
    public class MessagesBLL
    {
        private readonly IMessagesDAL dal = DataAccess.CreateMessagesDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public MessagesBLL()
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
        public int Add(TFXK.Model.Messages model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Messages model)
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
        public TFXK.Model.Messages GetModel(int id)
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
        public List<TFXK.Model.Messages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        public DataSet GetList_Web(int PageSize, int PageIndex, out int rowCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("stateid=1");
            return GetList("[tb_Messages]", PageSize, PageIndex, strSql.ToString(), "id desc", out rowCount);
        }


        /// <summary>
        /// 前台获取分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string where, out int rowCount)
        {
            return GetList("[tb_Messages]", PageSize, PageIndex, where, "id desc", out rowCount);
        }

        /// <summary>
        /// 前台获取分页
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="codeNo">编码</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, int pid, out int rowCount)
        {
            string where = "qicq='" + pid + "' and stateid=1";
            return GetList("[tb_Messages]", PageSize, PageIndex, where, "id desc", out rowCount);
        }
    }
}

