using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//Please add references
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:TestingStudent
	/// </summary>
	public partial class TestingStudent:ITestingStudent
	{
		public TestingStudent()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_TestingStudent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_TestingStudent");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.TestingStudent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_TestingStudent(");
			strSql.Append("PlanID,ClassID,OrgLevel,UserName,UserNamePinyin,IDNumber,Sex,Country,EthnicGroup,Birthday,UserHeadImage,UserWorkImage,IsPass,Score,CreateTime,LevelNum)");
			strSql.Append(" values (");
			strSql.Append("@PlanID,@ClassID,@OrgLevel,@UserName,@UserNamePinyin,@IDNumber,@Sex,@Country,@EthnicGroup,@Birthday,@UserHeadImage,@UserWorkImage,@IsPass,@Score,@CreateTime,@LevelNum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanID", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@OrgLevel", SqlDbType.VarChar,100),
					new SqlParameter("@UserName", SqlDbType.VarChar,100),
					new SqlParameter("@UserNamePinyin", SqlDbType.VarChar,100),
					new SqlParameter("@IDNumber", SqlDbType.VarChar,100),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Country", SqlDbType.VarChar,100),
					new SqlParameter("@EthnicGroup", SqlDbType.VarChar,100),
					new SqlParameter("@Birthday", SqlDbType.Date,3),
					new SqlParameter("@UserHeadImage", SqlDbType.VarChar,100),
					new SqlParameter("@UserWorkImage", SqlDbType.VarChar,100),
					new SqlParameter("@IsPass", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Decimal,9),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@LevelNum", SqlDbType.VarChar,100)
            };
			parameters[0].Value = model.PlanID;
			parameters[1].Value = model.ClassID;
			parameters[2].Value = model.OrgLevel;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.UserNamePinyin;
			parameters[5].Value = model.IDNumber;
			parameters[6].Value = model.Sex;
			parameters[7].Value = model.Country;
			parameters[8].Value = model.EthnicGroup;
			parameters[9].Value = model.Birthday;
			parameters[10].Value = model.UserHeadImage;
			parameters[11].Value = model.UserWorkImage;
			parameters[12].Value = model.IsPass;
			parameters[13].Value = model.Score;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.LevelNum; 


            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(TFXK.Model.TestingStudent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_TestingStudent set ");
			strSql.Append("PlanID=@PlanID,");
			strSql.Append("ClassID=@ClassID,");
			strSql.Append("OrgLevel=@OrgLevel,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserNamePinyin=@UserNamePinyin,");
			strSql.Append("IDNumber=@IDNumber,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Country=@Country,");
			strSql.Append("EthnicGroup=@EthnicGroup,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("UserHeadImage=@UserHeadImage,");
			strSql.Append("UserWorkImage=@UserWorkImage,");
			strSql.Append("IsPass=@IsPass,");
			strSql.Append("Score=@Score,");
			strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("LevelNum=@LevelNum");
            strSql.Append(" where id=@id"); 
             SqlParameter[] parameters = {
					new SqlParameter("@PlanID", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@OrgLevel", SqlDbType.VarChar,100),
					new SqlParameter("@UserName", SqlDbType.VarChar,100),
					new SqlParameter("@UserNamePinyin", SqlDbType.VarChar,100),
					new SqlParameter("@IDNumber", SqlDbType.VarChar,100),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Country", SqlDbType.VarChar,100),
					new SqlParameter("@EthnicGroup", SqlDbType.VarChar,100),
					new SqlParameter("@Birthday", SqlDbType.Date,3),
					new SqlParameter("@UserHeadImage", SqlDbType.VarChar,100),
					new SqlParameter("@UserWorkImage", SqlDbType.VarChar,100),
					new SqlParameter("@IsPass", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@LevelNum", SqlDbType.VarChar,100),
                    new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.PlanID;
			parameters[1].Value = model.ClassID;
			parameters[2].Value = model.OrgLevel;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.UserNamePinyin;
			parameters[5].Value = model.IDNumber;
			parameters[6].Value = model.Sex;
			parameters[7].Value = model.Country;
			parameters[8].Value = model.EthnicGroup;
			parameters[9].Value = model.Birthday;
			parameters[10].Value = model.UserHeadImage;
			parameters[11].Value = model.UserWorkImage;
			parameters[12].Value = model.IsPass;
			parameters[13].Value = model.Score;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.LevelNum;
            parameters[16].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_TestingStudent ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_TestingStudent ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public TFXK.Model.TestingStudent GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,PlanID,ClassID,OrgLevel,UserName,UserNamePinyin,IDNumber,Sex,Country,EthnicGroup,Birthday,UserHeadImage,UserWorkImage,IsPass,Score,CreateTime,LevelNum from tb_TestingStudent ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			TFXK.Model.TestingStudent model=new TFXK.Model.TestingStudent();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public TFXK.Model.TestingStudent DataRowToModel(DataRow row)
		{
			TFXK.Model.TestingStudent model=new TFXK.Model.TestingStudent();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["PlanID"]!=null && row["PlanID"].ToString()!="")
				{
					model.PlanID=int.Parse(row["PlanID"].ToString());
				}
				if(row["ClassID"]!=null && row["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(row["ClassID"].ToString());
				}
				if(row["OrgLevel"]!=null)
				{
					model.OrgLevel=row["OrgLevel"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserNamePinyin"]!=null)
				{
					model.UserNamePinyin=row["UserNamePinyin"].ToString();
				}
				if(row["IDNumber"]!=null)
				{
					model.IDNumber=row["IDNumber"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["Country"]!=null)
				{
					model.Country=row["Country"].ToString();
				}
				if(row["EthnicGroup"]!=null)
				{
					model.EthnicGroup=row["EthnicGroup"].ToString();
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
				if(row["UserHeadImage"]!=null)
				{
					model.UserHeadImage=row["UserHeadImage"].ToString();
				}
				if(row["UserWorkImage"]!=null)
				{
					model.UserWorkImage=row["UserWorkImage"].ToString();
				}
				if(row["IsPass"]!=null && row["IsPass"].ToString()!="")
				{
					model.IsPass=int.Parse(row["IsPass"].ToString());
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=decimal.Parse(row["Score"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
                if (row["LevelNum"] != null)
                {
                    model.LevelNum = row["LevelNum"].ToString();
                }
            }
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,PlanID,ClassID,OrgLevel,UserName,UserNamePinyin,IDNumber,Sex,Country,EthnicGroup,Birthday,UserHeadImage,UserWorkImage,IsPass,Score,CreateTime,LevelNum ");
			strSql.Append(" FROM tb_TestingStudent ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,PlanID,ClassID,OrgLevel,UserName,UserNamePinyin,IDNumber,Sex,Country,EthnicGroup,Birthday,UserHeadImage,UserWorkImage,IsPass,Score,CreateTime,LevelNum ");
			strSql.Append(" FROM tb_TestingStudent ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_TestingStudent ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_TestingStudent T ");
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
			parameters[0].Value = "tb_TestingStudent";
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

