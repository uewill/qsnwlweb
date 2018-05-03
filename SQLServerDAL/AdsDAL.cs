using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类Ads。
	/// </summary>
    public class AdsDAL : IAdsDAL
	{
		public AdsDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_Ads"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Ads");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.Ads model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Ads(");
			strSql.Append("title,typeid,linkUrl,linkImage,linkdes,orderid)");
			strSql.Append(" values (");
			strSql.Append("@title,@typeid,@linkUrl,@linkImage,@linkdes,@orderid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,500),
					new SqlParameter("@linkImage", SqlDbType.VarChar,500),
					new SqlParameter("@linkdes", SqlDbType.Text),
					new SqlParameter("@orderid", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.typeid;
			parameters[2].Value = model.linkUrl;
			parameters[3].Value = model.linkImage;
			parameters[4].Value = model.linkdes;
			parameters[5].Value = model.orderid;

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
		public void Update(TFXK.Model.Ads model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Ads set ");
			strSql.Append("title=@title,");
			strSql.Append("typeid=@typeid,");
			strSql.Append("linkUrl=@linkUrl,");
			strSql.Append("linkImage=@linkImage,");
			strSql.Append("linkdes=@linkdes,");
			strSql.Append("orderid=@orderid");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,500),
					new SqlParameter("@linkImage", SqlDbType.VarChar,500),
					new SqlParameter("@linkdes", SqlDbType.Text),
					new SqlParameter("@orderid", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.typeid;
			parameters[3].Value = model.linkUrl;
			parameters[4].Value = model.linkImage;
			parameters[5].Value = model.linkdes;
			parameters[6].Value = model.orderid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Ads ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.Ads GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,typeid,linkUrl,linkImage,linkdes,orderid from tb_Ads ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			TFXK.Model.Ads model=new TFXK.Model.Ads();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				if(ds.Tables[0].Rows[0]["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(ds.Tables[0].Rows[0]["typeid"].ToString());
				}
				model.linkUrl=ds.Tables[0].Rows[0]["linkUrl"].ToString();
				model.linkImage=ds.Tables[0].Rows[0]["linkImage"].ToString();
				model.linkdes=ds.Tables[0].Rows[0]["linkdes"].ToString();
				if(ds.Tables[0].Rows[0]["orderid"].ToString()!="")
				{
					model.orderid=int.Parse(ds.Tables[0].Rows[0]["orderid"].ToString());
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
			strSql.Append("select id,title,typeid,linkUrl,linkImage,linkdes,orderid ");
			strSql.Append(" FROM tb_Ads ");
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
			strSql.Append(" id,title,typeid,linkUrl,linkImage,linkdes,orderid ");
			strSql.Append(" FROM tb_Ads ");
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
			parameters[0].Value = "tb_Ads";
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

