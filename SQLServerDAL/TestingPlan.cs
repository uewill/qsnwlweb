using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//Please add references
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:TestingPlan
    /// </summary>
    public partial class TestingPlan : ITestingPlan
    {
        public TestingPlan()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_TestingPlan");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestingPlan");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TFXK.Model.TestingPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestingPlan(");
            strSql.Append("CenterID,TestingTime,TestTimeStart,TestTimeEnd,TestingClass,Address,AddresDes,Contactor,Description,Status,CreateTime,AuditTime,AuditDescription,NoticeConfirm,NoticeAddress,NoticeGetUser,NoticeGetPhone,NoticeTime,NoticeConfirmTime,NoticeDescription)");
            strSql.Append(" values (");
            strSql.Append("@CenterID,@TestingTime,@TestTimeStart,@TestTimeEnd,@TestingClass,@Address,@AddresDes,@Contactor,@Description,@Status,@CreateTime,@AuditTime,@AuditDescription,@NoticeConfirm,@NoticeAddress,@NoticeGetUser,@NoticeGetPhone,@NoticeTime,@NoticeConfirmTime,@NoticeDescription)");
            SqlParameter[] parameters = {
                    new SqlParameter("@CenterID", SqlDbType.Int,4),
                    new SqlParameter("@TestingTime", SqlDbType.VarChar,100),
                    new SqlParameter("@TestTimeStart", SqlDbType.DateTime),
                    new SqlParameter("@TestTimeEnd", SqlDbType.DateTime),
                    new SqlParameter("@TestingClass", SqlDbType.VarChar,100),
                    new SqlParameter("@Address", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddresDes", SqlDbType.NVarChar,500),
                    new SqlParameter("@Contactor", SqlDbType.NVarChar,100),
                    new SqlParameter("@Description", SqlDbType.Text),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@AuditTime", SqlDbType.DateTime),
                    new SqlParameter("@AuditDescription", SqlDbType.Text),
                    new SqlParameter("@NoticeConfirm", SqlDbType.Int,4),
                    new SqlParameter("@NoticeAddress", SqlDbType.VarChar,500),
                    new SqlParameter("@NoticeGetUser", SqlDbType.VarChar,100),
                    new SqlParameter("@NoticeGetPhone", SqlDbType.VarChar,100),
                    new SqlParameter("@NoticeTime", SqlDbType.DateTime),
                    new SqlParameter("@NoticeConfirmTime", SqlDbType.DateTime),
                    new SqlParameter("@NoticeDescription", SqlDbType.Text)

            };
            parameters[0].Value = model.CenterID;
            parameters[1].Value = model.TestingTime;
            parameters[2].Value = model.TestTimeStart;
            parameters[3].Value = model.TestTimeEnd;
            parameters[4].Value = model.TestingClass;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.AddresDes;
            parameters[7].Value = model.Contactor;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.AuditTime;
            parameters[12].Value = model.AuditDescription;
            parameters[13].Value = model.NoticeConfirm;
            parameters[14].Value = model.NoticeAddress;
            parameters[15].Value = model.NoticeGetUser;
            parameters[16].Value = model.NoticeGetPhone;
            parameters[17].Value = model.NoticeTime;
            parameters[18].Value = model.NoticeConfirmTime;
            parameters[19].Value = model.NoticeDescription;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(TFXK.Model.TestingPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestingPlan set ");
            strSql.Append("TestingTime=@TestingTime,");
            strSql.Append("TestTimeStart=@TestTimeStart,");
            strSql.Append("TestTimeEnd=@TestTimeEnd,");
            strSql.Append("TestingClass=@TestingClass,");
            strSql.Append("Address=@Address,");
            strSql.Append("AddresDes=@AddresDes,");
            strSql.Append("Contactor=@Contactor,");
            strSql.Append("Description=@Description,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("AuditTime=@AuditTime,");
            strSql.Append("AuditDescription=@AuditDescription,");
            strSql.Append("NoticeConfirm=@NoticeConfirm,");
            strSql.Append("NoticeAddress=@NoticeAddress,");
            strSql.Append("NoticeGetUser=@NoticeGetUser,");
            strSql.Append("NoticeGetPhone=@NoticeGetPhone,");
            strSql.Append("NoticeTime=@NoticeTime,");
            strSql.Append("NoticeConfirmTime=@NoticeConfirmTime,");
            strSql.Append("NoticeDescription=@NoticeDescription");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TestingTime", SqlDbType.VarChar,100),
                    new SqlParameter("@TestTimeStart", SqlDbType.DateTime),
                    new SqlParameter("@TestTimeEnd", SqlDbType.DateTime),
                    new SqlParameter("@TestingClass", SqlDbType.VarChar,100),
                    new SqlParameter("@Address", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddresDes", SqlDbType.NVarChar,500),
                    new SqlParameter("@Contactor", SqlDbType.NVarChar,100),
                    new SqlParameter("@Description", SqlDbType.Text),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@AuditTime", SqlDbType.DateTime),
                    new SqlParameter("@AuditDescription", SqlDbType.Text),
                    new SqlParameter("@NoticeConfirm", SqlDbType.Int,4),
                    new SqlParameter("@NoticeAddress", SqlDbType.VarChar,500),
                    new SqlParameter("@NoticeGetUser", SqlDbType.VarChar,100),
                    new SqlParameter("@NoticeGetPhone", SqlDbType.VarChar,100),
                    new SqlParameter("@NoticeTime", SqlDbType.DateTime),
                    new SqlParameter("@NoticeConfirmTime", SqlDbType.DateTime),
                    new SqlParameter("@NoticeDescription", SqlDbType.Text),


                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.TestingTime;
            parameters[1].Value = model.TestTimeStart;
            parameters[2].Value = model.TestTimeEnd;
            parameters[3].Value = model.TestingClass;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.AddresDes;
            parameters[6].Value = model.Contactor;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.AuditTime;
            parameters[11].Value = model.AuditDescription;
            parameters[12].Value = model.NoticeConfirm;
            parameters[13].Value = model.NoticeAddress;
            parameters[14].Value = model.NoticeGetUser;
            parameters[15].Value = model.NoticeGetPhone;
            parameters[16].Value = model.NoticeTime;
            parameters[17].Value = model.NoticeConfirmTime;
            parameters[18].Value = model.NoticeDescription;
            parameters[19].Value = model.id;

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
            strSql.Append("delete from tb_TestingPlan ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)            };
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
            strSql.Append("delete from tb_TestingPlan ");
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
        public TFXK.Model.TestingPlan GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,CenterID,TestingTime,TestTimeStart,TestTimeEnd,TestingClass,Address,AddresDes,Contactor,Description,Status,CreateTime,AuditTime,AuditDescription,NoticeConfirm,NoticeAddress,NoticeGetUser,NoticeGetPhone,NoticeTime,NoticeConfirmTime,NoticeDescription from tb_TestingPlan ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)            };
            parameters[0].Value = id;

            TFXK.Model.TestingPlan model = new TFXK.Model.TestingPlan();
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
        public TFXK.Model.TestingPlan DataRowToModel(DataRow row)
        {
            TFXK.Model.TestingPlan model = new TFXK.Model.TestingPlan();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["CenterID"] != null && row["CenterID"].ToString() != "")
                {
                    model.CenterID = int.Parse(row["CenterID"].ToString());
                }


                if (row["TestingTime"] != null)
                {
                    model.TestingTime = row["TestingTime"].ToString();
                }
                if (row["TestTimeStart"] != null && row["TestTimeStart"].ToString() != "")
                {
                    model.TestTimeStart = DateTime.Parse(row["TestTimeStart"].ToString());
                }
                if (row["TestTimeEnd"] != null && row["TestTimeEnd"].ToString() != "")
                {
                    model.TestTimeEnd = DateTime.Parse(row["TestTimeEnd"].ToString());
                }
                if (row["TestingClass"] != null)
                {
                    model.TestingClass = row["TestingClass"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["AddresDes"] != null)
                {
                    model.AddresDes = row["AddresDes"].ToString();
                }
                if (row["Contactor"] != null)
                {
                    model.Contactor = row["Contactor"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["AuditTime"] != null && row["AuditTime"].ToString() != "")
                {
                    model.AuditTime = DateTime.Parse(row["AuditTime"].ToString());
                }
                if (row["AuditDescription"] != null)
                {
                    model.AuditDescription = row["AuditDescription"].ToString();
                }
                if (row["NoticeConfirm"] != null && row["NoticeConfirm"].ToString() != "")
                {
                    model.NoticeConfirm = int.Parse(row["NoticeConfirm"].ToString());
                }
                if (row["NoticeAddress"] != null)
                {
                    model.NoticeAddress = row["NoticeAddress"].ToString();
                }
                if (row["NoticeGetUser"] != null)
                {
                    model.NoticeGetUser = row["NoticeGetUser"].ToString();
                }
                if (row["NoticeGetPhone"] != null)
                {
                    model.NoticeGetPhone = row["NoticeGetPhone"].ToString();
                }
                if (row["NoticeTime"] != null && row["NoticeTime"].ToString() != "")
                {
                    model.NoticeTime = DateTime.Parse(row["NoticeTime"].ToString());
                }
                if (row["NoticeConfirmTime"] != null && row["NoticeConfirmTime"].ToString() != "")
                {
                    model.NoticeConfirmTime = DateTime.Parse(row["NoticeConfirmTime"].ToString());
                }
                if (row["NoticeDescription"] != null)
                {
                    model.NoticeDescription = row["NoticeDescription"].ToString();
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
            strSql.Append("select id,CenterID,TestingTime,TestTimeStart,TestTimeEnd,TestingClass,Address,AddresDes,Contactor,Description,Status,CreateTime,AuditTime,AuditDescription,NoticeConfirm,NoticeAddress,NoticeGetUser,NoticeGetPhone,NoticeTime,NoticeConfirmTime,NoticeDescription ");
            strSql.Append(" FROM tb_TestingPlan ");
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
            strSql.Append(" id,CenterID,TestingTime,TestTimeStart,TestTimeEnd,TestingClass,Address,AddresDes,Contactor,Description,Status,CreateTime,AuditTime,AuditDescription,NoticeConfirm,NoticeAddress,NoticeGetUser,NoticeGetPhone,NoticeTime,NoticeConfirmTime,NoticeDescription ");
            strSql.Append(" FROM tb_TestingPlan ");
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
            strSql.Append("select count(1) FROM tb_TestingPlan ");
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
            strSql.Append(")AS Row, T.*  from tb_TestingPlan T ");
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
			parameters[0].Value = "tb_TestingPlan";
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

