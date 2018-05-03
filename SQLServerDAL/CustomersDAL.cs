using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CustomersDAL。
    /// </summary>
    public class CustomersDAL : ICustomersDAL
    {
        public CustomersDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_customers");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_customers");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_customers(");
            strSql.Append("loginName,loginPass,email,phone,regDate,trueName,userSex,tel,address,cardID,birsday,stateID,orderEmail,validateEmail)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@loginPass,@email,@phone,@regDate,@trueName,@userSex,@tel,@address,@cardID,@birsday,@stateID,@orderEmail,@validateEmail)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@loginPass", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@phone", SqlDbType.VarChar,100),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@trueName", SqlDbType.VarChar,100),
					new SqlParameter("@userSex", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,500),
					new SqlParameter("@cardID", SqlDbType.VarChar,50),
					new SqlParameter("@birsday", SqlDbType.VarChar,50),
					new SqlParameter("@stateID", SqlDbType.Int,4),
					new SqlParameter("@orderEmail", SqlDbType.Int,4),
					new SqlParameter("@validateEmail", SqlDbType.VarChar,50)};
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.loginPass;
            parameters[2].Value = model.email;
            parameters[3].Value = model.phone;
            parameters[4].Value = model.regDate;
            parameters[5].Value = model.trueName;
            parameters[6].Value = model.userSex;
            parameters[7].Value = model.tel;
            parameters[8].Value = model.address;
            parameters[9].Value = model.cardID;
            parameters[10].Value = model.birsday;
            parameters[11].Value = model.stateID;
            parameters[12].Value = model.orderEmail;
            parameters[13].Value = model.validateEmail;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_customers set ");
            strSql.Append("loginName=@loginName,");
            strSql.Append("loginPass=@loginPass,");
            strSql.Append("email=@email,");
            strSql.Append("phone=@phone,");
            strSql.Append("regDate=@regDate,");
            strSql.Append("trueName=@trueName,");
            strSql.Append("userSex=@userSex,");
            strSql.Append("tel=@tel,");
            strSql.Append("address=@address,");
            strSql.Append("cardID=@cardID,");
            strSql.Append("birsday=@birsday,");
            strSql.Append("stateID=@stateID,");
            strSql.Append("orderEmail=@orderEmail,");
            strSql.Append("validateEmail=@validateEmail");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@loginPass", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@phone", SqlDbType.VarChar,100),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@trueName", SqlDbType.VarChar,100),
					new SqlParameter("@userSex", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,500),
					new SqlParameter("@cardID", SqlDbType.VarChar,50),
					new SqlParameter("@birsday", SqlDbType.VarChar,50),
					new SqlParameter("@stateID", SqlDbType.Int,4),
					new SqlParameter("@orderEmail", SqlDbType.Int,4),
					new SqlParameter("@validateEmail", SqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.loginName;
            parameters[2].Value = model.loginPass;
            parameters[3].Value = model.email;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.regDate;
            parameters[6].Value = model.trueName;
            parameters[7].Value = model.userSex;
            parameters[8].Value = model.tel;
            parameters[9].Value = model.address;
            parameters[10].Value = model.cardID;
            parameters[11].Value = model.birsday;
            parameters[12].Value = model.stateID;
            parameters[13].Value = model.orderEmail;
            parameters[14].Value = model.validateEmail;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_customers ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Customers GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,loginName,loginPass,email,phone,regDate,trueName,userSex,tel,address,cardID,birsday,stateID,orderEmail,validateEmail from tb_customers ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Customers model = new TFXK.Model.Customers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.loginPass = ds.Tables[0].Rows[0]["loginPass"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                model.trueName = ds.Tables[0].Rows[0]["trueName"].ToString();
                if (ds.Tables[0].Rows[0]["userSex"].ToString() != "")
                {
                    model.userSex = int.Parse(ds.Tables[0].Rows[0]["userSex"].ToString());
                }
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.cardID = ds.Tables[0].Rows[0]["cardID"].ToString();
                model.birsday = ds.Tables[0].Rows[0]["birsday"].ToString();
                if (ds.Tables[0].Rows[0]["stateID"].ToString() != "")
                {
                    model.stateID = int.Parse(ds.Tables[0].Rows[0]["stateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderEmail"].ToString() != "")
                {
                    model.orderEmail = int.Parse(ds.Tables[0].Rows[0]["orderEmail"].ToString());
                }
                model.validateEmail = ds.Tables[0].Rows[0]["validateEmail"].ToString();
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
            strSql.Append("select id,loginName,loginPass,email,phone,regDate,trueName,userSex,tel,address,cardID,birsday,stateID,orderEmail,validateEmail ");
            strSql.Append(" FROM tb_customers ");
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
            strSql.Append(" id,loginName,loginPass,email,phone,regDate,trueName,userSex,tel,address,cardID,birsday,stateID,orderEmail,validateEmail ");
            strSql.Append(" FROM tb_customers ");
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
            parameters[0].Value = "tb_customers";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Customers GetModelByPhone(string phone)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,loginName,loginPass,email,phone,regDate,trueName,userSex,tel,address,cardID,birsday,stateID,orderEmail,validateEmail from tb_customers ");
            strSql.Append(" where phone=@phone ");
            SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.VarChar,50)};
            parameters[0].Value = phone;

            TFXK.Model.Customers model = new TFXK.Model.Customers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.loginPass = ds.Tables[0].Rows[0]["loginPass"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                model.trueName = ds.Tables[0].Rows[0]["trueName"].ToString();
                if (ds.Tables[0].Rows[0]["userSex"].ToString() != "")
                {
                    model.userSex = int.Parse(ds.Tables[0].Rows[0]["userSex"].ToString());
                }
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.cardID = ds.Tables[0].Rows[0]["cardID"].ToString();
                model.birsday = ds.Tables[0].Rows[0]["birsday"].ToString();
                if (ds.Tables[0].Rows[0]["stateID"].ToString() != "")
                {
                    model.stateID = int.Parse(ds.Tables[0].Rows[0]["stateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderEmail"].ToString() != "")
                {
                    model.orderEmail = int.Parse(ds.Tables[0].Rows[0]["orderEmail"].ToString());
                }
                model.validateEmail = ds.Tables[0].Rows[0]["validateEmail"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetLoginNameByID(int uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 loginName from tb_customers ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = uid;
            return DbHelperSQL.GetSingle(strSql.ToString(), parameters)+"";
        }



        /// <summary>
        /// 查询订单数量
        /// </summary>
        /// <param name="isToday">是否今日 0 否 1 是</param>
        /// <returns></returns>
        public int GetUserCount(int isToday)
        {

            StringBuilder whereStr = new StringBuilder();
            if (isToday == 1)
            {
                whereStr.Append(" datediff(day,regdate,getdate())=0 ");
            }
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select count(id) from tb_customers");
            if (!string.IsNullOrEmpty(whereStr.ToString()))
            {
                strSql.Append(" where ");
                strSql.Append(whereStr.ToString());
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            try
            {
                return int.Parse(obj.ToString());
            }
            catch
            {
                return 0;
            }
        }
    }
}

