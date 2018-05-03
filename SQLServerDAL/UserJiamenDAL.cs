using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类UserJiamenDAL。
	/// </summary>
    public class UserJiamenDAL : IUserJiamenDAL
	{
        public UserJiamenDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_UserJiamen"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_UserJiamen");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.UserJiamen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_UserJiamen(");
			strSql.Append("typeID,Jijie,chkOrderNum,orderNum,hopePrice,proCode,otherDes,filePaths,contactUserName,userSex,userTel,userPhone,userEmail,companyName,companyAddress,stateID,des1,des2,des3,des4)");
			strSql.Append(" values (");
			strSql.Append("@typeID,@Jijie,@chkOrderNum,@orderNum,@hopePrice,@proCode,@otherDes,@filePaths,@contactUserName,@userSex,@userTel,@userPhone,@userEmail,@companyName,@companyAddress,@stateID,@des1,@des2,@des3,@des4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.VarChar,50),
					new SqlParameter("@Jijie", SqlDbType.VarChar,50),
					new SqlParameter("@chkOrderNum", SqlDbType.VarChar,50),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@hopePrice", SqlDbType.VarChar,50),
					new SqlParameter("@proCode", SqlDbType.VarChar,50),
					new SqlParameter("@otherDes", SqlDbType.Text),
					new SqlParameter("@filePaths", SqlDbType.VarChar,50),
					new SqlParameter("@contactUserName", SqlDbType.VarChar,50),
					new SqlParameter("@userSex", SqlDbType.Int,4),
					new SqlParameter("@userTel", SqlDbType.VarChar,50),
					new SqlParameter("@userPhone", SqlDbType.VarChar,50),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@companyName", SqlDbType.VarChar,1000),
					new SqlParameter("@companyAddress", SqlDbType.VarChar,1000),
					new SqlParameter("@stateID", SqlDbType.Int,4),
					new SqlParameter("@des1", SqlDbType.VarChar,50),
					new SqlParameter("@des2", SqlDbType.VarChar,50),
					new SqlParameter("@des3", SqlDbType.Text),
					new SqlParameter("@des4", SqlDbType.Text)};
			parameters[0].Value = model.typeID;
			parameters[1].Value = model.Jijie;
			parameters[2].Value = model.chkOrderNum;
			parameters[3].Value = model.orderNum;
			parameters[4].Value = model.hopePrice;
			parameters[5].Value = model.proCode;
			parameters[6].Value = model.otherDes;
			parameters[7].Value = model.filePaths;
			parameters[8].Value = model.contactUserName;
			parameters[9].Value = model.userSex;
			parameters[10].Value = model.userTel;
			parameters[11].Value = model.userPhone;
			parameters[12].Value = model.userEmail;
			parameters[13].Value = model.companyName;
			parameters[14].Value = model.companyAddress;
			parameters[15].Value = model.stateID;
			parameters[16].Value = model.des1;
			parameters[17].Value = model.des2;
			parameters[18].Value = model.des3;
			parameters[19].Value = model.des4;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public void Update(TFXK.Model.UserJiamen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_UserJiamen set ");
			strSql.Append("typeID=@typeID,");
			strSql.Append("Jijie=@Jijie,");
			strSql.Append("chkOrderNum=@chkOrderNum,");
			strSql.Append("orderNum=@orderNum,");
			strSql.Append("hopePrice=@hopePrice,");
			strSql.Append("proCode=@proCode,");
			strSql.Append("otherDes=@otherDes,");
			strSql.Append("filePaths=@filePaths,");
			strSql.Append("contactUserName=@contactUserName,");
			strSql.Append("userSex=@userSex,");
			strSql.Append("userTel=@userTel,");
			strSql.Append("userPhone=@userPhone,");
			strSql.Append("userEmail=@userEmail,");
			strSql.Append("companyName=@companyName,");
			strSql.Append("companyAddress=@companyAddress,");
			strSql.Append("stateID=@stateID,");
			strSql.Append("des1=@des1,");
			strSql.Append("des2=@des2,");
			strSql.Append("des3=@des3,");
			strSql.Append("des4=@des4");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@typeID", SqlDbType.VarChar,50),
					new SqlParameter("@Jijie", SqlDbType.VarChar,50),
					new SqlParameter("@chkOrderNum", SqlDbType.VarChar,50),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@hopePrice", SqlDbType.VarChar,50),
					new SqlParameter("@proCode", SqlDbType.VarChar,50),
					new SqlParameter("@otherDes", SqlDbType.Text),
					new SqlParameter("@filePaths", SqlDbType.VarChar,50),
					new SqlParameter("@contactUserName", SqlDbType.VarChar,50),
					new SqlParameter("@userSex", SqlDbType.Int,4),
					new SqlParameter("@userTel", SqlDbType.VarChar,50),
					new SqlParameter("@userPhone", SqlDbType.VarChar,50),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@companyName", SqlDbType.VarChar,1000),
					new SqlParameter("@companyAddress", SqlDbType.VarChar,1000),
					new SqlParameter("@stateID", SqlDbType.Int,4),
					new SqlParameter("@des1", SqlDbType.VarChar,50),
					new SqlParameter("@des2", SqlDbType.VarChar,50),
					new SqlParameter("@des3", SqlDbType.Text),
					new SqlParameter("@des4", SqlDbType.Text)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.typeID;
			parameters[2].Value = model.Jijie;
			parameters[3].Value = model.chkOrderNum;
			parameters[4].Value = model.orderNum;
			parameters[5].Value = model.hopePrice;
			parameters[6].Value = model.proCode;
			parameters[7].Value = model.otherDes;
			parameters[8].Value = model.filePaths;
			parameters[9].Value = model.contactUserName;
			parameters[10].Value = model.userSex;
			parameters[11].Value = model.userTel;
			parameters[12].Value = model.userPhone;
			parameters[13].Value = model.userEmail;
			parameters[14].Value = model.companyName;
			parameters[15].Value = model.companyAddress;
			parameters[16].Value = model.stateID;
			parameters[17].Value = model.des1;
			parameters[18].Value = model.des2;
			parameters[19].Value = model.des3;
			parameters[20].Value = model.des4;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_UserJiamen ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.UserJiamen GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeID,Jijie,chkOrderNum,orderNum,hopePrice,proCode,otherDes,filePaths,contactUserName,userSex,userTel,userPhone,userEmail,companyName,companyAddress,stateID,des1,des2,des3,des4 from tb_UserJiamen ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			TFXK.Model.UserJiamen model=new TFXK.Model.UserJiamen();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.typeID=ds.Tables[0].Rows[0]["typeID"].ToString();
				model.Jijie=ds.Tables[0].Rows[0]["Jijie"].ToString();
				model.chkOrderNum=ds.Tables[0].Rows[0]["chkOrderNum"].ToString();
				if(ds.Tables[0].Rows[0]["orderNum"].ToString()!="")
				{
					model.orderNum=int.Parse(ds.Tables[0].Rows[0]["orderNum"].ToString());
				}
				model.hopePrice=ds.Tables[0].Rows[0]["hopePrice"].ToString();
				model.proCode=ds.Tables[0].Rows[0]["proCode"].ToString();
				model.otherDes=ds.Tables[0].Rows[0]["otherDes"].ToString();
				model.filePaths=ds.Tables[0].Rows[0]["filePaths"].ToString();
				model.contactUserName=ds.Tables[0].Rows[0]["contactUserName"].ToString();
				if(ds.Tables[0].Rows[0]["userSex"].ToString()!="")
				{
					model.userSex=int.Parse(ds.Tables[0].Rows[0]["userSex"].ToString());
				}
				model.userTel=ds.Tables[0].Rows[0]["userTel"].ToString();
				model.userPhone=ds.Tables[0].Rows[0]["userPhone"].ToString();
				model.userEmail=ds.Tables[0].Rows[0]["userEmail"].ToString();
				model.companyName=ds.Tables[0].Rows[0]["companyName"].ToString();
				model.companyAddress=ds.Tables[0].Rows[0]["companyAddress"].ToString();
				if(ds.Tables[0].Rows[0]["stateID"].ToString()!="")
				{
					model.stateID=int.Parse(ds.Tables[0].Rows[0]["stateID"].ToString());
				}
				model.des1=ds.Tables[0].Rows[0]["des1"].ToString();
				model.des2=ds.Tables[0].Rows[0]["des2"].ToString();
				model.des3=ds.Tables[0].Rows[0]["des3"].ToString();
				model.des4=ds.Tables[0].Rows[0]["des4"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,typeID,Jijie,chkOrderNum,orderNum,hopePrice,proCode,otherDes,filePaths,contactUserName,userSex,userTel,userPhone,userEmail,companyName,companyAddress,stateID,des1,des2,des3,des4 ");
			strSql.Append(" FROM tb_UserJiamen ");
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
			strSql.Append(" id,typeID,Jijie,chkOrderNum,orderNum,hopePrice,proCode,otherDes,filePaths,contactUserName,userSex,userTel,userPhone,userEmail,companyName,companyAddress,stateID,des1,des2,des3,des4 ");
			strSql.Append(" FROM tb_UserJiamen ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "tb_UserJiamen";
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

