using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//Please add references
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:TestingPersonExam
    /// </summary>
    public partial class TestingPersonExam : ITestingPersonExam
    {
        public TestingPersonExam()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_TestingPersonExam");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int planid, string idNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestingPersonExam");
            strSql.Append(" where typeid=@id and IDNumber=@IDNumber");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@IDNumber", SqlDbType.VarChar,50)
            };
            parameters[0].Value = planid;
            parameters[1].Value = idNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.TestingPersonExam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestingPersonExam(");
            strSql.Append("PersonID,UserName,UserNamePY,Sex,PhoneNumber,Mingzu,Birthday,Country,Address,HomeAddress,Contactor,ContactorShip,ContactorPhone,Status,TypeID,ClassID,ClassLevel,Heading,HaveMaxLevel,MaxLevelNo,CreateTime,postno,zhidao,ExamNumber,IDNumber)");
            strSql.Append(" values (");
            strSql.Append("@PersonID,@UserName,@UserNamePY,@Sex,@PhoneNumber,@Mingzu,@Birthday,@Country,@Address,@HomeAddress,@Contactor,@ContactorShip,@ContactorPhone,@Status,@TypeID,@ClassID,@ClassLevel,@Heading,@HaveMaxLevel,@MaxLevelNo,@CreateTime,@postno,@zhidao,@ExamNumber,@IDNumber)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PersonID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,120),
                    new SqlParameter("@UserNamePY", SqlDbType.VarChar,120),
                    new SqlParameter("@Sex", SqlDbType.VarChar,120),
                    new SqlParameter("@PhoneNumber", SqlDbType.VarChar,120),
                    new SqlParameter("@Mingzu", SqlDbType.VarChar,120),
                    new SqlParameter("@Birthday", SqlDbType.VarChar,120),
                    new SqlParameter("@Country", SqlDbType.VarChar,120),
                    new SqlParameter("@Address", SqlDbType.VarChar,120),
                    new SqlParameter("@HomeAddress", SqlDbType.VarChar,120),
                    new SqlParameter("@Contactor", SqlDbType.VarChar,120),
                    new SqlParameter("@ContactorShip", SqlDbType.VarChar,120),
                    new SqlParameter("@ContactorPhone", SqlDbType.VarChar,120),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@ClassID", SqlDbType.VarChar,120),
                    new SqlParameter("@ClassLevel", SqlDbType.VarChar,50),
                    new SqlParameter("@Heading", SqlDbType.VarChar,150),
                    new SqlParameter("@HaveMaxLevel", SqlDbType.VarChar,50),
                    new SqlParameter("@MaxLevelNo", SqlDbType.VarChar,100),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@postno", SqlDbType.VarChar,100),
                    new SqlParameter("@zhidao", SqlDbType.VarChar,50),
                    new SqlParameter("@ExamNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@IDNumber", SqlDbType.VarChar,50),
            };
            parameters[0].Value = model.PersonID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserNamePY;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.PhoneNumber;
            parameters[5].Value = model.Mingzu;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.Country;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.HomeAddress;
            parameters[10].Value = model.Contactor;
            parameters[11].Value = model.ContactorShip;
            parameters[12].Value = model.ContactorPhone;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.TypeID;
            parameters[15].Value = model.ClassID;
            parameters[16].Value = model.ClassLevel;
            parameters[17].Value = model.Heading;
            parameters[18].Value = model.HaveMaxLevel;
            parameters[19].Value = model.MaxLevelNo;
            parameters[20].Value = model.CreateTime;
            parameters[21].Value = model.PostNo;
            parameters[22].Value = model.Zhidao;
            parameters[23].Value = model.ExamNumber;
            parameters[24].Value = model.IDNumber;

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
        public bool Update(TFXK.Model.TestingPersonExam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestingPersonExam set ");
            strSql.Append("PersonID=@PersonID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserNamePY=@UserNamePY,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("PhoneNumber=@PhoneNumber,");
            strSql.Append("Mingzu=@Mingzu,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Country=@Country,");
            strSql.Append("Address=@Address,");
            strSql.Append("HomeAddress=@HomeAddress,");
            strSql.Append("Contactor=@Contactor,");
            strSql.Append("ContactorShip=@ContactorShip,");
            strSql.Append("ContactorPhone=@ContactorPhone,");
            strSql.Append("Status=@Status,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("ClassID=@ClassID,");
            strSql.Append("ClassLevel=@ClassLevel,");
            strSql.Append("Heading=@Heading,");
            strSql.Append("HaveMaxLevel=@HaveMaxLevel,");
            strSql.Append("MaxLevelNo=@MaxLevelNo,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("PostNo=@PostNo,");
            strSql.Append("zhidao=@zhidao,");
            strSql.Append("ExamNumber=@ExamNumber,");
            strSql.Append("IDNumber=@IDNumber");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@PersonID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,120),
                    new SqlParameter("@UserNamePY", SqlDbType.VarChar,120),
                    new SqlParameter("@Sex", SqlDbType.VarChar,120),
                    new SqlParameter("@PhoneNumber", SqlDbType.VarChar,120),
                    new SqlParameter("@Mingzu", SqlDbType.VarChar,120),
                    new SqlParameter("@Birthday", SqlDbType.VarChar,120),
                    new SqlParameter("@Country", SqlDbType.VarChar,120),
                    new SqlParameter("@Address", SqlDbType.VarChar,120),
                    new SqlParameter("@HomeAddress", SqlDbType.VarChar,120),
                    new SqlParameter("@Contactor", SqlDbType.VarChar,120),
                    new SqlParameter("@ContactorShip", SqlDbType.VarChar,120),
                    new SqlParameter("@ContactorPhone", SqlDbType.VarChar,120),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@ClassID",SqlDbType.VarChar,120),
                    new SqlParameter("@ClassLevel", SqlDbType.VarChar,50),
                    new SqlParameter("@Heading", SqlDbType.VarChar,150),
                    new SqlParameter("@HaveMaxLevel", SqlDbType.VarChar,50),
                    new SqlParameter("@MaxLevelNo", SqlDbType.VarChar,100),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@PostNo", SqlDbType.VarChar,100),
                    new SqlParameter("@zhidao", SqlDbType.VarChar,50),
                    new SqlParameter("@ExamNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@IDNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.PersonID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserNamePY;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.PhoneNumber;
            parameters[5].Value = model.Mingzu;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.Country;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.HomeAddress;
            parameters[10].Value = model.Contactor;
            parameters[11].Value = model.ContactorShip;
            parameters[12].Value = model.ContactorPhone;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.TypeID;
            parameters[15].Value = model.ClassID;
            parameters[16].Value = model.ClassLevel;
            parameters[17].Value = model.Heading;
            parameters[18].Value = model.HaveMaxLevel;
            parameters[19].Value = model.MaxLevelNo;
            parameters[20].Value = model.CreateTime;
            parameters[21].Value = model.PostNo;
            parameters[22].Value = model.Zhidao;
            parameters[23].Value = model.ExamNumber;
            parameters[24].Value = model.IDNumber;
            parameters[25].Value = model.id;

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
            strSql.Append("delete from tb_TestingPersonExam ");
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
            strSql.Append("delete from tb_TestingPersonExam ");
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
        public TFXK.Model.TestingPersonExam GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,PersonID,UserName,UserNamePY,Sex,PhoneNumber,Mingzu,Birthday,Country,Address,HomeAddress,Contactor,ContactorShip,ContactorPhone,Status,TypeID,ClassID,ClassLevel,Heading,HaveMaxLevel,MaxLevelNo,CreateTime,PostNo,zhidao,ExamNumber,IDNumber from tb_TestingPersonExam ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            TFXK.Model.TestingPersonExam model = new TFXK.Model.TestingPersonExam();
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
        public TFXK.Model.TestingPersonExam DataRowToModel(DataRow row)
        {
            TFXK.Model.TestingPersonExam model = new TFXK.Model.TestingPersonExam();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["PersonID"] != null && row["PersonID"].ToString() != "")
                {
                    model.PersonID = int.Parse(row["PersonID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserNamePY"] != null)
                {
                    model.UserNamePY = row["UserNamePY"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["PhoneNumber"] != null)
                {
                    model.PhoneNumber = row["PhoneNumber"].ToString();
                }
                if (row["Mingzu"] != null)
                {
                    model.Mingzu = row["Mingzu"].ToString();
                }
                if (row["Birthday"] != null)
                {
                    model.Birthday = row["Birthday"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["HomeAddress"] != null)
                {
                    model.HomeAddress = row["HomeAddress"].ToString();
                }
                if (row["Contactor"] != null)
                {
                    model.Contactor = row["Contactor"].ToString();
                }
                if (row["ContactorShip"] != null)
                {
                    model.ContactorShip = row["ContactorShip"].ToString();
                }
                if (row["ContactorPhone"] != null)
                {
                    model.ContactorPhone = row["ContactorPhone"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["ClassID"] != null && row["ClassID"].ToString() != "")
                {
                    model.ClassID = row["ClassID"].ToString();
                }
                if (row["ClassLevel"] != null)
                {
                    model.ClassLevel = row["ClassLevel"].ToString();
                }
                if (row["Heading"] != null)
                {
                    model.Heading = row["Heading"].ToString();
                }
                if (row["HaveMaxLevel"] != null)
                {
                    model.HaveMaxLevel = row["HaveMaxLevel"].ToString();
                }
                if (row["MaxLevelNo"] != null)
                {
                    model.MaxLevelNo = row["MaxLevelNo"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["PostNo"] != null)
                {
                    model.PostNo = row["PostNo"].ToString();
                }
                if (row["zhidao"] != null)
                {
                    model.Zhidao = row["zhidao"].ToString();
                }
                if (row["ExamNumber"] != null)
                {
                    model.ExamNumber = row["ExamNumber"].ToString();
                }
                if (row["IDNumber"] != null)
                {
                    model.IDNumber = row["IDNumber"].ToString();
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
            strSql.Append("select id,PersonID,UserName,UserNamePY,Sex,PhoneNumber,Mingzu,Birthday,Country,Address,HomeAddress,Contactor,ContactorShip,ContactorPhone,Status,TypeID,ClassID,ClassLevel,Heading,HaveMaxLevel,MaxLevelNo,CreateTime,PostNo,zhidao,ExamNumber,IDNumber ");
            strSql.Append(" FROM tb_TestingPersonExam ");
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
            strSql.Append(" id,PersonID,UserName,UserNamePY,Sex,PhoneNumber,Mingzu,Birthday,Country,Address,HomeAddress,Contactor,ContactorShip,ContactorPhone,Status,TypeID,ClassID,ClassLevel,Heading,HaveMaxLevel,MaxLevelNo,CreateTime,PostNo,zhidao,ExamNumber,IDNumber ");
            strSql.Append(" FROM tb_TestingPersonExam ");
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
            strSql.Append("select count(1) FROM tb_TestingPersonExam ");
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
            strSql.Append(")AS Row, T.*  from tb_TestingPersonExam T ");
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
			parameters[0].Value = "tb_TestingPersonExam";
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

