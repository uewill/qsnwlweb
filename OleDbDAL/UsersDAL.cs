using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,50),
					new OleDbParameter("@password", OleDbType.VarChar,50)};
            parameters[0].Value = userName;
            parameters[1].Value = password;

            object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
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
            strSql.Append("userName,[password],trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description)");
            strSql.Append(" values (");
            strSql.Append("@userName,@password,@trueName,@email,@telephone,@address,@roleid,@question,@answer,@state,@regDate,@lastLoginDate,@loginCount,@description)");
            OleDbParameter[] parameters = {
	
					new OleDbParameter("@userName", OleDbType.VarChar,50),
					new OleDbParameter("@password", OleDbType.VarChar,50),
					new OleDbParameter("@trueName", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@telephone", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,200),
					new OleDbParameter("@roleid", OleDbType.Integer,4),
					new OleDbParameter("@question", OleDbType.VarChar,50),
					new OleDbParameter("@answer", OleDbType.VarChar,50),
					new OleDbParameter("@state", OleDbType.Integer,4),
					new OleDbParameter("@regDate", OleDbType.DBDate),
					new OleDbParameter("@lastLoginDate",OleDbType.DBDate ),
					new OleDbParameter("@loginCount", OleDbType.Integer,4),
					new OleDbParameter("@description", OleDbType.VarChar)};
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

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);

            string sql = "select max(id) from [tb_Users]";
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
        public void Update(TFXK.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Users set ");
            strSql.Append("userName=@userName,");
            strSql.Append("[password]=@password,");
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,50),
					new OleDbParameter("@password", OleDbType.VarChar,50),
					new OleDbParameter("@trueName", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@telephone", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,200),
					new OleDbParameter("@roleid", OleDbType.Integer,4),
					new OleDbParameter("@question", OleDbType.VarChar,50),
					new OleDbParameter("@answer", OleDbType.VarChar,50),
					new OleDbParameter("@state", OleDbType.Integer,4),
					new OleDbParameter("@regDate", OleDbType.Date),
					new OleDbParameter("@lastLoginDate", OleDbType.Date),
					new OleDbParameter("@loginCount", OleDbType.Integer,4),
					new OleDbParameter("@description", OleDbType.VarChar,0),
                new OleDbParameter("@id", OleDbType.Integer,4)};

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
            parameters[14].Value = model.id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        ///  更新密码
        /// </summary>
        public void UpdatePassword(TFXK.Model.Users model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,50),
					new OleDbParameter("@password", OleDbType.VarChar,50)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.password;

            string sql = "UPDATE [tb_users] SET [password] = @password WHERE userName=@userName";
            DbHelperOleDb.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Users ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Users GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,userName,password,trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description from tb_Users ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            TFXK.Model.Users model = new TFXK.Model.Users();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
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
            strSql.Append("select id,userName,password,trueName,email,telephone,address,roleid,question,answer,state,regDate,lastLoginDate,loginCount,description from tb_Users ");
            strSql.Append(" where userName=@userName ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,50)};
            parameters[0].Value = userName;

            TFXK.Model.Users model = new TFXK.Model.Users();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
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
            parameters[0].Value = "tb_Users";
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

