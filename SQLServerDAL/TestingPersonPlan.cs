using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//Please add references
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:TestingPersonPlan
    /// </summary>
    public partial class TestingPersonPlan : ITestingPersonPlan
    {
        public TestingPersonPlan()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_TestingPersonPlan");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestingPersonPlan");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.TestingPersonPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestingPersonPlan(");
            strSql.Append("TestingTitle,TestTimeAMStart,TestTimeAMEnd,TestTimePMStart,TestTimePMEnd,TestingClass,TestingSubClass,Address,AddresDes,Contactor,Description,TotalCount,Status,OrderNum,CreateTime,NumberPrefx,NumberStart,NumberIndex)");
            strSql.Append(" values (");
            strSql.Append("@TestingTitle,@TestTimeAMStart,@TestTimeAMEnd,@TestTimePMStart,@TestTimePMEnd,@TestingClass,@TestingSubClass,@Address,@AddresDes,@Contactor,@Description,@TotalCount,@Status,@OrderNum,@CreateTime,@NumberPrefx,@NumberStart,@NumberIndex)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@TestingTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@TestTimeAMStart", SqlDbType.DateTime),
                    new SqlParameter("@TestTimeAMEnd", SqlDbType.DateTime),
                    new SqlParameter("@TestTimePMStart", SqlDbType.DateTime),
                    new SqlParameter("@TestTimePMEnd", SqlDbType.DateTime),
                    new SqlParameter("@TestingClass", SqlDbType.VarChar,500),
                    new SqlParameter("@TestingSubClass", SqlDbType.VarChar,500),
                    new SqlParameter("@Address", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddresDes", SqlDbType.NVarChar,500),
                    new SqlParameter("@Contactor", SqlDbType.NVarChar,100),
                    new SqlParameter("@Description", SqlDbType.Text),
                    new SqlParameter("@TotalCount", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@OrderNum", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@NumberPrefx",SqlDbType.VarChar,100),
                    new SqlParameter("@NumberStart",SqlDbType.VarChar,100),
                    new SqlParameter("@NumberIndex", SqlDbType.Int)};
            parameters[0].Value = model.TestingTitle;
            parameters[1].Value = model.TestTimeAMStart;
            parameters[2].Value = model.TestTimeAMEnd;
            parameters[3].Value = model.TestTimePMStart;
            parameters[4].Value = model.TestTimePMEnd;
            parameters[5].Value = model.TestingClass;
            parameters[6].Value = model.TestingSubClass;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.AddresDes;
            parameters[9].Value = model.Contactor;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.TotalCount;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.OrderNum;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.NumberPrefx;
            parameters[16].Value = model.NumberStart;
            parameters[17].Value = model.NumberIndex;

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
        public bool Update(TFXK.Model.TestingPersonPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestingPersonPlan set ");
            strSql.Append("TestingTitle=@TestingTitle,");
            strSql.Append("TestTimeAMStart=@TestTimeAMStart,");
            strSql.Append("TestTimeAMEnd=@TestTimeAMEnd,");
            strSql.Append("TestTimePMStart=@TestTimePMStart,");
            strSql.Append("TestTimePMEnd=@TestTimePMEnd,");
            strSql.Append("TestingClass=@TestingClass,");
            strSql.Append("TestingSubClass=@TestingSubClass,");
            strSql.Append("Address=@Address,");
            strSql.Append("AddresDes=@AddresDes,");
            strSql.Append("Contactor=@Contactor,");
            strSql.Append("Description=@Description,");
            strSql.Append("TotalCount=@TotalCount,");
            strSql.Append("Status=@Status,");
            strSql.Append("OrderNum=@OrderNum,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("NumberPrefx=@NumberPrefx,");
            strSql.Append("NumberStart=@NumberStart,");
            strSql.Append("NumberIndex=@NumberIndex");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@TestingTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@TestTimeAMStart", SqlDbType.DateTime),
                    new SqlParameter("@TestTimeAMEnd", SqlDbType.DateTime),
                    new SqlParameter("@TestTimePMStart", SqlDbType.DateTime),
                    new SqlParameter("@TestTimePMEnd", SqlDbType.DateTime),
                    new SqlParameter("@TestingClass", SqlDbType.VarChar,500),
                    new SqlParameter("@TestingSubClass", SqlDbType.VarChar,500),
                    new SqlParameter("@Address", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddresDes", SqlDbType.NVarChar,500),
                    new SqlParameter("@Contactor", SqlDbType.NVarChar,100),
                    new SqlParameter("@Description", SqlDbType.Text),
                    new SqlParameter("@TotalCount", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@OrderNum", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@NumberPrefx", SqlDbType.VarChar,100),
                    new SqlParameter("@NumberStart", SqlDbType.VarChar,100),
                    new SqlParameter("@NumberIndex", SqlDbType.Int,4),};
            parameters[0].Value = model.TestingTitle;
            parameters[1].Value = model.TestTimeAMStart;
            parameters[2].Value = model.TestTimeAMEnd;
            parameters[3].Value = model.TestTimePMStart;
            parameters[4].Value = model.TestTimePMEnd;
            parameters[5].Value = model.TestingClass;
            parameters[6].Value = model.TestingSubClass;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.AddresDes;
            parameters[9].Value = model.Contactor;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.TotalCount;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.OrderNum;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.id;
            parameters[16].Value = model.NumberPrefx;
            parameters[17].Value = model.NumberStart;
            parameters[18].Value = model.NumberIndex;

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
            strSql.Append("delete from tb_TestingPersonPlan ");
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
            strSql.Append("delete from tb_TestingPersonPlan ");
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
        public TFXK.Model.TestingPersonPlan GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,TestingTitle,TestTimeAMStart,TestTimeAMEnd,TestTimePMStart,TestTimePMEnd,TestingClass,TestingSubClass,Address,AddresDes,Contactor,Description,TotalCount,Status,OrderNum,CreateTime,NumberPrefx,NumberStart,NumberIndex from tb_TestingPersonPlan ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            TFXK.Model.TestingPersonPlan model = new TFXK.Model.TestingPersonPlan();
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
        public TFXK.Model.TestingPersonPlan DataRowToModel(DataRow row)
        {
            TFXK.Model.TestingPersonPlan model = new TFXK.Model.TestingPersonPlan();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["TestingTitle"] != null)
                {
                    model.TestingTitle = row["TestingTitle"].ToString();
                }
                if (row["TestTimeAMStart"] != null && row["TestTimeAMStart"].ToString() != "")
                {
                    model.TestTimeAMStart = DateTime.Parse(row["TestTimeAMStart"].ToString());
                }
                if (row["TestTimeAMEnd"] != null && row["TestTimeAMEnd"].ToString() != "")
                {
                    model.TestTimeAMEnd = DateTime.Parse(row["TestTimeAMEnd"].ToString());
                }
                if (row["TestTimePMStart"] != null && row["TestTimePMStart"].ToString() != "")
                {
                    model.TestTimePMStart = DateTime.Parse(row["TestTimePMStart"].ToString());
                }
                if (row["TestTimePMEnd"] != null && row["TestTimePMEnd"].ToString() != "")
                {
                    model.TestTimePMEnd = DateTime.Parse(row["TestTimePMEnd"].ToString());
                }
                if (row["TestingClass"] != null)
                {
                    model.TestingClass = row["TestingClass"].ToString();
                }
                if (row["TestingSubClass"] != null)
                {
                    model.TestingSubClass = row["TestingSubClass"].ToString();
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
                if (row["TotalCount"] != null && row["TotalCount"].ToString() != "")
                {
                    model.TotalCount = int.Parse(row["TotalCount"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["OrderNum"] != null && row["OrderNum"].ToString() != "")
                {
                    model.OrderNum = int.Parse(row["OrderNum"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }

                if (row["NumberPrefx"] != null)
                {
                    model.NumberPrefx = row["NumberPrefx"].ToString();
                }
                if (row["NumberStart"] != null)
                {
                    model.NumberStart = row["NumberStart"].ToString();
                }
                if (row["NumberIndex"] != null && row["NumberIndex"].ToString() != "")
                {
                    model.NumberIndex = int.Parse(row["NumberIndex"].ToString());
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
            strSql.Append("select id,TestingTitle,TestTimeAMStart,TestTimeAMEnd,TestTimePMStart,TestTimePMEnd,TestingClass,TestingSubClass,Address,AddresDes,Contactor,Description,TotalCount,Status,OrderNum,CreateTime ");
            strSql.Append(" FROM tb_TestingPersonPlan ");
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
            strSql.Append(" id,TestingTitle,TestTimeAMStart,TestTimeAMEnd,TestTimePMStart,TestTimePMEnd,TestingClass,TestingSubClass,Address,AddresDes,Contactor,Description,TotalCount,Status,OrderNum,CreateTime,NumberPrefx,NumberStart,NumberIndex ");
            strSql.Append(" FROM tb_TestingPersonPlan ");
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
            strSql.Append("select count(1) FROM tb_TestingPersonPlan ");
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
            strSql.Append(")AS Row, T.*  from tb_TestingPersonPlan T ");
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
			parameters[0].Value = "tb_TestingPersonPlan";
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
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="id">序号</param>
        /// <param name="orderid">排序</param>
        public void UpdateOrders(int id, int orderid, string fildName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestingPersonPlan set ");
            strSql.Append(fildName + "=@orderID");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@orderID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = orderid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

