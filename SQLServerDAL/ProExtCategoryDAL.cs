using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类ProExtCategoryDAL。
	/// </summary>
	public class ProExtCategoryDAL:IProExtCategoryDAL
	{
		public ProExtCategoryDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_ProExtCategory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_ProExtCategory");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.ProExtCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_ProExtCategory(");
			strSql.Append("productID,extCateID)");
			strSql.Append(" values (");
			strSql.Append("@productID,@extCateID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productID", SqlDbType.Int,4),
					new SqlParameter("@extCateID", SqlDbType.Int,4)};
			parameters[0].Value = model.productID;
			parameters[1].Value = model.extCateID;

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
		public void Update(TFXK.Model.ProExtCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_ProExtCategory set ");
			strSql.Append("productID=@productID,");
			strSql.Append("extCateID=@extCateID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.Int,4),
					new SqlParameter("@extCateID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.productID;
			parameters[2].Value = model.extCateID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ProExtCategory ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByPid(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ProExtCategory ");
            strSql.Append(" where productID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByPid(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,productID,extCateID ");
            strSql.Append(" FROM tb_ProExtCategory ");
            strSql.Append(" where productID="+id);
            return DbHelperSQL.Query(strSql.ToString());
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.ProExtCategory GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productID,extCateID from tb_ProExtCategory ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			TFXK.Model.ProExtCategory model=new TFXK.Model.ProExtCategory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["productID"].ToString()!="")
				{
					model.productID=int.Parse(ds.Tables[0].Rows[0]["productID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["extCateID"].ToString()!="")
				{
					model.extCateID=int.Parse(ds.Tables[0].Rows[0]["extCateID"].ToString());
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
			strSql.Append("select id,productID,extCateID ");
			strSql.Append(" FROM tb_ProExtCategory ");
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
			strSql.Append(" id,productID,extCateID ");
			strSql.Append(" FROM tb_ProExtCategory ");
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
			parameters[0].Value = "tb_ProExtCategory";
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

