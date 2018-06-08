using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//Please add references
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:TestingCenter
    /// </summary>
    public partial class TestingCenter : ITestingCenter
    {
        public TestingCenter()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_TestingCenter");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestingCenter");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestingCenter");
            strSql.Append(" where KDName=@KDName");
            SqlParameter[] parameters = {
                    new SqlParameter("@KDName", SqlDbType.VarChar,100)
            };
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.TestingCenter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestingCenter(");
            strSql.Append("KDName,Address,UserName,UserPhone,UserTel,UserEmail,UserPass,KDDescription,IDNo,IDImage,IDImage2,WorkImage,KDLogo,Status,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@KDName,@Address,@UserName,@UserPhone,@UserTel,@UserEmail,@UserPass,@KDDescription,@IDNo,@IDImage,@IDImage2,@WorkImage,@KDLogo,@Status,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@KDName", SqlDbType.VarChar,100),
                    new SqlParameter("@Address", SqlDbType.VarChar,100),
                    new SqlParameter("@UserName", SqlDbType.VarChar,100),
                    new SqlParameter("@UserPhone", SqlDbType.VarChar,100),
                    new SqlParameter("@UserTel", SqlDbType.VarChar,100),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,100),
                    new SqlParameter("@UserPass", SqlDbType.VarChar,100),
                    new SqlParameter("@KDDescription", SqlDbType.Text),
                    new SqlParameter("@IDNo", SqlDbType.VarChar,50),
                    new SqlParameter("@IDImage", SqlDbType.VarChar,100),
                    new SqlParameter("@IDImage2", SqlDbType.VarChar,100),
                    new SqlParameter("@WorkImage", SqlDbType.VarChar,100),
                    new SqlParameter("@KDLogo", SqlDbType.VarChar,100),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.KDName;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserPhone;
            parameters[4].Value = model.UserTel;
            parameters[5].Value = model.UserEmail;
            parameters[6].Value = model.UserPass;
            parameters[7].Value = model.KDDescription;
            parameters[8].Value = model.IDNo;
            parameters[9].Value = model.IDImage;
            parameters[10].Value = model.IDImage2;
            parameters[11].Value = model.WorkImage;
            parameters[12].Value = model.KDLogo;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.CreateTime;

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
        public bool Update(TFXK.Model.TestingCenter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestingCenter set ");
            strSql.Append("KDName=@KDName,");
            strSql.Append("Address=@Address,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserPhone=@UserPhone,");
            strSql.Append("UserTel=@UserTel,");
            strSql.Append("UserEmail=@UserEmail,");
            strSql.Append("UserPass=@UserPass,");
            strSql.Append("KDDescription=@KDDescription,");
            strSql.Append("IDImage=@IDImage,");
            strSql.Append("IDImage2=@IDImage2,");
            strSql.Append("WorkImage=@WorkImage,");
            strSql.Append("KDLogo=@KDLogo,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("IDNo=@IDNo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@KDName", SqlDbType.VarChar,100),
                    new SqlParameter("@Address", SqlDbType.VarChar,100),
                    new SqlParameter("@UserName", SqlDbType.VarChar,100),
                    new SqlParameter("@UserPhone", SqlDbType.VarChar,100),
                    new SqlParameter("@UserTel", SqlDbType.VarChar,100),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,100),
                    new SqlParameter("@UserPass", SqlDbType.VarChar,100),
                    new SqlParameter("@KDDescription", SqlDbType.Text),
                    new SqlParameter("@IDImage", SqlDbType.VarChar,100),
                    new SqlParameter("@IDImage2", SqlDbType.VarChar,100),
                    new SqlParameter("@WorkImage", SqlDbType.VarChar,100),
                    new SqlParameter("@KDLogo", SqlDbType.VarChar,100),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IDNo", SqlDbType.VarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.KDName;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserPhone;
            parameters[4].Value = model.UserTel;
            parameters[5].Value = model.UserEmail;
            parameters[6].Value = model.UserPass;
            parameters[7].Value = model.KDDescription;
            parameters[8].Value = model.IDImage;
            parameters[9].Value = model.IDImage2;
            parameters[10].Value = model.WorkImage;
            parameters[11].Value = model.KDLogo;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.IDNo;
            parameters[15].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestingCenter ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestingCenter ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.TestingCenter GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,KDName,Address,UserName,UserPhone,UserTel,UserEmail,UserPass,KDDescription,IDNo,IDImage,IDImage2,WorkImage,KDLogo,Status,CreateTime from tb_TestingCenter ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            TFXK.Model.TestingCenter model = new TFXK.Model.TestingCenter();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public TFXK.Model.TestingCenter GetModelByName(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,KDName,Address,UserName,UserPhone,UserTel,UserEmail,UserPass,KDDescription,IDNo,IDImage,IDImage2,WorkImage,KDLogo,Status,CreateTime from tb_TestingCenter ");
            strSql.Append(" where KDName=@KDName");
            SqlParameter[] parameters = {
                    new SqlParameter("@KDName", SqlDbType.VarChar,100)
            };
            parameters[0].Value = name;

            TFXK.Model.TestingCenter model = new TFXK.Model.TestingCenter();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.TestingCenter DataRowToModel(DataRow row)
        {
            TFXK.Model.TestingCenter model = new TFXK.Model.TestingCenter();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["KDName"] != null)
                {
                    model.KDName = row["KDName"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPhone"] != null)
                {
                    model.UserPhone = row["UserPhone"].ToString();
                }
                if (row["UserTel"] != null)
                {
                    model.UserTel = row["UserTel"].ToString();
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
                }
                if (row["UserPass"] != null)
                {
                    model.UserPass = row["UserPass"].ToString();
                }
                if (row["KDDescription"] != null)
                {
                    model.KDDescription = row["KDDescription"].ToString();
                }
                if (row["IDNo"] != null)
                {
                    model.IDNo = row["IDNo"].ToString();
                }

                if (row["IDImage"] != null)
                {
                    model.IDImage = row["IDImage"].ToString();
                }
                if (row["IDImage2"] != null)
                {
                    model.IDImage2 = row["IDImage2"].ToString();
                }
                if (row["WorkImage"] != null)
                {
                    model.WorkImage = row["WorkImage"].ToString();
                }
                if (row["KDLogo"] != null)
                {
                    model.KDLogo = row["KDLogo"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,KDName,Address,UserName,UserPhone,UserTel,UserEmail,UserPass,KDDescription,IDNo,IDImage,IDImage2,WorkImage,KDLogo,Status,CreateTime ");
            strSql.Append(" FROM tb_TestingCenter ");
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
            strSql.Append(" id,KDName,Address,UserName,UserPhone,UserTel,UserEmail,UserPass,KDDescription,IDNo,IDImage,IDImage2,WorkImage,KDLogo,Status,CreateTime ");
            strSql.Append(" FROM tb_TestingCenter ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_TestingCenter ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_TestingCenter T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "tb_TestingCenter";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

