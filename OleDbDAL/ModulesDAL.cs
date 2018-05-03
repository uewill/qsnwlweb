using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
{
	/// <summary>
	/// 数据访问类ModulesDAL。
	/// </summary>
	public class ModulesDAL:IModulesDAL
	{
		public ModulesDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Modules");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.Modules model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Modules(");
			strSql.Append("parentID,title,pageUrl,description)");
			strSql.Append(" values (");
			strSql.Append("@parentID,@title,@pageUrl,@description)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@pageUrl", OleDbType.VarChar,255),
					new OleDbParameter("@description", OleDbType.VarChar,200)};
			parameters[0].Value = model.parentID;
			parameters[1].Value = model.title;
			parameters[2].Value = model.pageUrl;
			parameters[3].Value = model.description;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);

            string sql = "select max(id) from [tb_Modules]";
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
		public void Update(TFXK.Model.Modules model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Modules set ");
			strSql.Append("parentID=@parentID,");
			strSql.Append("title=@title,");
			strSql.Append("pageUrl=@pageUrl,");
			strSql.Append("description=@description");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@pageUrl", OleDbType.VarChar,255),
					new OleDbParameter("@description", OleDbType.VarChar,200),
                new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.parentID;
			parameters[1].Value = model.title;
			parameters[2].Value = model.pageUrl;
			parameters[3].Value = model.description;
            parameters[4].Value = model.id;
			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Modules ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.Modules GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,parentID,title,pageUrl,description from tb_Modules ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			TFXK.Model.Modules model=new TFXK.Model.Modules();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentID"].ToString()!="")
				{
					model.parentID=int.Parse(ds.Tables[0].Rows[0]["parentID"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.pageUrl=ds.Tables[0].Rows[0]["pageUrl"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
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
			strSql.Append("select id,parentID,title,pageUrl,description ");
			strSql.Append(" FROM tb_Modules ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "tb_Modules";
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

