using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类MessagesDAL。
	/// </summary>
	public class MessagesDAL:IMessagesDAL
	{
		public MessagesDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_Messages"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Messages");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.Messages model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Messages(");
			strSql.Append("title,userNames,userEmail,msgContent,qicq,stateid,recontent,createTime)");
			strSql.Append(" values (");
			strSql.Append("@title,@userNames,@userEmail,@msgContent,@qicq,@stateid,@recontent,@createTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@userNames", SqlDbType.VarChar,50),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@msgContent", SqlDbType.Text),
					new SqlParameter("@qicq", SqlDbType.VarChar,50),
					new SqlParameter("@stateid", SqlDbType.Int,4),
					new SqlParameter("@recontent", SqlDbType.Text),
					new SqlParameter("@createTime", SqlDbType.DateTime)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.userNames;
			parameters[2].Value = model.userEmail;
			parameters[3].Value = model.msgContent;
			parameters[4].Value = model.qicq;
			parameters[5].Value = model.stateid;
			parameters[6].Value = model.recontent;
			parameters[7].Value = model.createTime;

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
		public void Update(TFXK.Model.Messages model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Messages set ");
			strSql.Append("title=@title,");
			strSql.Append("userNames=@userNames,");
			strSql.Append("userEmail=@userEmail,");
			strSql.Append("msgContent=@msgContent,");
			strSql.Append("qicq=@qicq,");
			strSql.Append("stateid=@stateid,");
			strSql.Append("recontent=@recontent,");
			strSql.Append("createTime=@createTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@userNames", SqlDbType.VarChar,50),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@msgContent", SqlDbType.Text),
					new SqlParameter("@qicq", SqlDbType.VarChar,50),
					new SqlParameter("@stateid", SqlDbType.Int,4),
					new SqlParameter("@recontent", SqlDbType.Text),
					new SqlParameter("@createTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.userNames;
			parameters[3].Value = model.userEmail;
			parameters[4].Value = model.msgContent;
			parameters[5].Value = model.qicq;
			parameters[6].Value = model.stateid;
			parameters[7].Value = model.recontent;
			parameters[8].Value = model.createTime;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Messages ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.Messages GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,userNames,userEmail,msgContent,qicq,stateid,recontent,createTime from tb_Messages ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			TFXK.Model.Messages model=new TFXK.Model.Messages();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.userNames=ds.Tables[0].Rows[0]["userNames"].ToString();
				model.userEmail=ds.Tables[0].Rows[0]["userEmail"].ToString();
				model.msgContent=ds.Tables[0].Rows[0]["msgContent"].ToString();
				model.qicq=ds.Tables[0].Rows[0]["qicq"].ToString();
				if(ds.Tables[0].Rows[0]["stateid"].ToString()!="")
				{
					model.stateid=int.Parse(ds.Tables[0].Rows[0]["stateid"].ToString());
				}
				model.recontent=ds.Tables[0].Rows[0]["recontent"].ToString();
				if(ds.Tables[0].Rows[0]["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
				}
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
			strSql.Append("select id,title,userNames,userEmail,msgContent,qicq,stateid,recontent,createTime ");
			strSql.Append(" FROM tb_Messages ");
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
			strSql.Append(" id,title,userNames,userEmail,msgContent,qicq,stateid,recontent,createTime ");
			strSql.Append(" FROM tb_Messages ");
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
			parameters[0].Value = "tb_Messages";
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

