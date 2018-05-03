using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类UsersDAL。
    /// </summary>
    public class UsersDAL : IUsersDAL
    {
        public UsersDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_Users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            string strWhere = " where userName=@userName ";
            if (!password.Equals(string.Empty))
            {
                strWhere += " and password=@password";
            }
            else
            {
                return false;
            }
            strSql.Append("select * from [tb_Users]");
            strSql.Append(strWhere);
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50)};
            parameters[0].Value = userName;
            parameters[1].Value = password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        /// <summary>
        /// 是否存在name
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            string strWhere = " where userName=@userName ";
            strSql.Append("select * from [tb_Users]");
            strSql.Append(strWhere);
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50)};
            parameters[0].Value = userName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Users(");
            strSql.Append("userName,password,trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description)");
            strSql.Append(" values (");
            strSql.Append("@userName,@password,@trueName,@email,@telephone,@address,@roleid,@question,@answer,@state,@regDate,@lastLoginDate,@loginCount,@description)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@trueName", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@telephone", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.Text),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@question", SqlDbType.VarChar,1000),
					new SqlParameter("@answer", SqlDbType.VarChar,1000),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@lastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@loginCount", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.Text)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.password;
            parameters[2].Value = model.trueName;
            parameters[3].Value = model.email;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.address;
            parameters[6].Value = model.roleid;
            parameters[7].Value = model.question;
            parameters[8].Value = model.answer;
            parameters[9].Value = model.state;
            parameters[10].Value = model.regDate;
            parameters[11].Value = model.lastLoginDate;
            parameters[12].Value = model.loginCount;
            parameters[13].Value = model.description;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Users set ");
            strSql.Append("userName=@userName,");
            strSql.Append("trueName=@trueName,");
            strSql.Append("email=@email,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("roleid=@roleid,");
            strSql.Append("question=@question,");
            strSql.Append("answer=@answer,");
            strSql.Append("state=@state,");
            strSql.Append("regDate=@regDate,");
            strSql.Append("lastLoginDate=@lastLoginDate,");
            strSql.Append("loginCount=@loginCount,");
            strSql.Append("description=@description");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@trueName", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@telephone", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.Text),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@question", SqlDbType.VarChar,1000),
					new SqlParameter("@answer", SqlDbType.VarChar,1000),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@lastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@loginCount", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.Text)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.trueName;
            parameters[3].Value = model.email;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.address;
            parameters[6].Value = model.roleid;
            parameters[7].Value = model.question;
            parameters[8].Value = model.answer;
            parameters[9].Value = model.state;
            parameters[10].Value = model.regDate;
            parameters[11].Value = model.lastLoginDate;
            parameters[12].Value = model.loginCount;
            parameters[13].Value = model.description;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新密码
        /// </summary>
        public void UpdatePassword(TFXK.Model.Users model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.password;

            string sql = "UPDATE [tb_users] SET [password] = @password WHERE userName=@userName";
            DbHelperSQL.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Users ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Users GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userName,password,trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description from tb_Users ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Users model = new TFXK.Model.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.trueName = ds.Tables[0].Rows[0]["trueName"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                if (ds.Tables[0].Rows[0]["roleid"].ToString() != "")
                {
                    model.roleid = int.Parse(ds.Tables[0].Rows[0]["roleid"].ToString());
                }
                model.question = ds.Tables[0].Rows[0]["question"].ToString();
                model.answer = ds.Tables[0].Rows[0]["answer"].ToString();
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lastLoginDate"].ToString() != "")
                {
                    model.lastLoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["lastLoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["loginCount"].ToString() != "")
                {
                    model.loginCount = int.Parse(ds.Tables[0].Rows[0]["loginCount"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// 根据用户名得到一个对象实体
        /// </summary>
        public TFXK.Model.Users GetModelByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from [tb_Users] ");
            strSql.Append(" where userName=@userName ");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50)};
            parameters[0].Value = userName;

            TFXK.Model.Users model = new TFXK.Model.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.trueName = ds.Tables[0].Rows[0]["trueName"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                if (ds.Tables[0].Rows[0]["roleid"].ToString() != "")
                {
                    model.roleid = int.Parse(ds.Tables[0].Rows[0]["roleid"].ToString());
                }
                model.question = ds.Tables[0].Rows[0]["question"].ToString();
                model.answer = ds.Tables[0].Rows[0]["answer"].ToString();
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lastLoginDate"].ToString() != "")
                {
                    model.lastLoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["lastLoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["loginCount"].ToString() != "")
                {
                    model.loginCount = int.Parse(ds.Tables[0].Rows[0]["loginCount"].ToString());
                }
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
            strSql.Append("select id,userName,password,trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description ");
            strSql.Append(" FROM tb_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,userName,password,trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description ");
            strSql.Append(" FROM tb_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_Users";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

