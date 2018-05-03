using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
{
    /// <summary>
    /// 数据访问类RoleDAL。
    /// </summary>
    public class RoleDAL : IRoleDAL
    {
        public RoleDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Role");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Role(");
            strSql.Append("title,description)");
            strSql.Append(" values (");
            strSql.Append("@title,@description)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@description", OleDbType.VarChar,200)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.description;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            string sql = "select max(id) from [tb_Role]";
            try
            {
                return int.Parse(DbHelperOleDb.GetSingle(sql).ToString());
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Role set ");
            strSql.Append("title=@title,");
            strSql.Append("description=@description");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@description", OleDbType.VarChar,200),new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.description;
            parameters[2].Value = model.id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Role ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Role GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,description from tb_Role ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            TFXK.Model.Role model = new TFXK.Model.Role();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,description ");
            strSql.Append(" FROM tb_Role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            OleDbParameter[] parameters = {
                    new OleDbParameter("@tblName", OleDbType.VarChar, 255),
                    new OleDbParameter("@fldName", OleDbType.VarChar, 255),
                    new OleDbParameter("@PageSize", OleDbType.Integer),
                    new OleDbParameter("@PageIndex", OleDbType.Integer),
                    new OleDbParameter("@IsReCount", OleDbType.Bit),
                    new OleDbParameter("@OrderType", OleDbType.Bit),
                    new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_Role";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

