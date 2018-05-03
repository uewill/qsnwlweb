using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
{
	/// <summary>
	/// 数据访问类MessageDAL。
	/// </summary>
	public class MessageDAL:IMessageDAL
	{
		public MessageDAL()
		{}
		#region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "tb_Message");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Message");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Message(");
			strSql.Append("userId,title,name,email,telephone,createTime,description,reply,state,parentId)");
			strSql.Append(" values (");
			strSql.Append("@userId,@title,@name,@email,@telephone,@createTime,@description,@reply,@state,@parentId)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@userId", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@telephone", OleDbType.VarChar,50),
					new OleDbParameter("@createTime", OleDbType.VarChar,19),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@reply", OleDbType.VarChar,0),
					new OleDbParameter("@state", OleDbType.VarChar,10),
					new OleDbParameter("@parentId", OleDbType.Integer,4)};
            parameters[0].Value = model.userId;
            parameters[1].Value = model.title;
            parameters[2].Value = model.name;
            parameters[3].Value = model.email;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.createTime;
            parameters[6].Value = model.description;
            parameters[7].Value = model.reply;
            parameters[8].Value = model.state;
            parameters[9].Value = model.parentId;

            object obj = DbHelperOleDb.GetScalar(strSql.ToString(), parameters);
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
		public void Update(TFXK.Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Message set ");
			strSql.Append("userId=@userId,");
			strSql.Append("title=@title,");
			strSql.Append("name=@name,");
			strSql.Append("email=@email,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("createTime=@createTime,");
			strSql.Append("description=@description,");
			strSql.Append("reply=@reply,");
			strSql.Append("state=@state,");
			strSql.Append("parentId=@parentId");
            strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@userId", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@telephone", OleDbType.VarChar,50),
					new OleDbParameter("@createTime", OleDbType.VarChar,19),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@reply", OleDbType.VarChar,0),
					new OleDbParameter("@state", OleDbType.VarChar,10),
					new OleDbParameter("@parentId", OleDbType.Integer,4),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.title;
			parameters[2].Value = model.name;
			parameters[3].Value = model.email;
			parameters[4].Value = model.telephone;
			parameters[5].Value = model.createTime;
			parameters[6].Value = model.description;
			parameters[7].Value = model.reply;
			parameters[8].Value = model.state;
            parameters[9].Value = model.parentId;
            parameters[10].Value = model.id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from tb_Message ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public TFXK.Model.Message GetModel(int id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,userId,title,name,email,telephone,createTime,description,reply,state,parentId from tb_Message ");

            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

			TFXK.Model.Message model=new TFXK.Model.Message();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["userId"].ToString()!="")
				{
					model.userId=int.Parse(ds.Tables[0].Rows[0]["userId"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.email=ds.Tables[0].Rows[0]["email"].ToString();
				model.telephone=ds.Tables[0].Rows[0]["telephone"].ToString();
				model.createTime=ds.Tables[0].Rows[0]["createTime"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
				model.reply=ds.Tables[0].Rows[0]["reply"].ToString();
				model.state=ds.Tables[0].Rows[0]["state"].ToString();
				if(ds.Tables[0].Rows[0]["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
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
			strSql.Append("select id,userId,title,name,email,telephone,createTime,description,reply,state,parentId ");
			strSql.Append(" FROM tb_Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
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
            strSql.Append(" id,userId,title,name,email,telephone,createTime,description,reply,state,parentId ");
            strSql.Append(" FROM tb_Message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "Message";
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

