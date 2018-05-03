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
    /// 业务逻辑类UsersBLL 的摘要说明。
    /// </summary>
    public class UsersBLL
    {
        private readonly IUsersDAL dal = DataAccess.CreateUsersDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
        public UsersBLL()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
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
        /// 是否存在name
        /// </summary>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }

        /// <summary>
        /// 增加一条数据
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
        ///  审核状态
        /// </summary>
        public void UpdateStatus(TFXK.Model.Users model)
        {
            //  dal.UpdateStatus(model);
        }

        /// <summary>
        ///  更新密码
        /// </summary>
        public void UpdatePassword(TFXK.Model.Users model)
        {
            model.password = Security.EncryptPassword(model.password, "MD5");
            dal.UpdatePassword(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Users model)
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
        public TFXK.Model.Users GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Users GetModelByUserName(string username)
        {

            return dal.GetModelByUserName(username);
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
        public List<TFXK.Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        #endregion



        #region 私有方法




        /// <summary>
        /// 姓名搜索
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="name">姓名</param>
        /// <param name="rowCount">输出值,总数</param>
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
        /// 分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="rowCount">返回数</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, out int rowCount)
        {
            DataSet ds = bll.GetList("[tb_Users]", PageSize, PageIndex, "", "id", out rowCount);
            return ds;
        }



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
            DataSet ds = bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
            return ds;
        }

        #endregion  成员方法
    }


}

