using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类SiteConfigDAL。
	/// </summary>
	public class SiteConfigDAL:ISiteConfigDAL
	{
		public SiteConfigDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_SiteConfig"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_SiteConfig");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.SiteConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_SiteConfig(");
			strSql.Append("codeNo,title,description,mata,footer,des1,des2,des3)");
			strSql.Append(" values (");
			strSql.Append("@codeNo,@title,@description,@mata,@footer,@des1,@des2,@des3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@description", SqlDbType.VarChar,1000),
					new SqlParameter("@mata", SqlDbType.VarChar,1000),
					new SqlParameter("@footer", SqlDbType.Text),
					new SqlParameter("@des1", SqlDbType.Text),
					new SqlParameter("@des2", SqlDbType.VarChar,500),
					new SqlParameter("@des3", SqlDbType.VarChar,500)};
			parameters[0].Value = model.codeNo;
			parameters[1].Value = model.title;
			parameters[2].Value = model.description;
			parameters[3].Value = model.mata;
			parameters[4].Value = model.footer;
			parameters[5].Value = model.des1;
			parameters[6].Value = model.des2;
			parameters[7].Value = model.des3;

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
		public void Update(TFXK.Model.SiteConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_SiteConfig set ");
			strSql.Append("codeNo=@codeNo,");
			strSql.Append("title=@title,");
			strSql.Append("description=@description,");
			strSql.Append("mata=@mata,");
			strSql.Append("footer=@footer,");
			strSql.Append("des1=@des1,");
			strSql.Append("des2=@des2,");
			strSql.Append("des3=@des3");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@codeNo", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@description", SqlDbType.VarChar,1000),
					new SqlParameter("@mata", SqlDbType.VarChar,1000),
					new SqlParameter("@footer", SqlDbType.Text),
					new SqlParameter("@des1", SqlDbType.Text),
					new SqlParameter("@des2", SqlDbType.VarChar,500),
					new SqlParameter("@des3", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.codeNo;
			parameters[2].Value = model.title;
			parameters[3].Value = model.description;
			parameters[4].Value = model.mata;
			parameters[5].Value = model.footer;
			parameters[6].Value = model.des1;
			parameters[7].Value = model.des2;
			parameters[8].Value = model.des3;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_SiteConfig ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.SiteConfig GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,codeNo,title,description,mata,footer,des1,des2,des3 from tb_SiteConfig ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			TFXK.Model.SiteConfig model=new TFXK.Model.SiteConfig();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.codeNo=ds.Tables[0].Rows[0]["codeNo"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
				model.mata=ds.Tables[0].Rows[0]["mata"].ToString();
				model.footer=ds.Tables[0].Rows[0]["footer"].ToString();
				model.des1=ds.Tables[0].Rows[0]["des1"].ToString();
				model.des2=ds.Tables[0].Rows[0]["des2"].ToString();
				model.des3=ds.Tables[0].Rows[0]["des3"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.SiteConfig GetModel(string codeNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,codeNo,title,description,mata,footer,des1,des2,des3 from tb_SiteConfig ");
            strSql.Append(" where codeNo=@codeNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = codeNo;

            TFXK.Model.SiteConfig model = new TFXK.Model.SiteConfig();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.codeNo = ds.Tables[0].Rows[0]["codeNo"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.mata = ds.Tables[0].Rows[0]["mata"].ToString();
                model.footer = ds.Tables[0].Rows[0]["footer"].ToString();
                model.des1 = ds.Tables[0].Rows[0]["des1"].ToString();
                model.des2 = ds.Tables[0].Rows[0]["des2"].ToString();
                model.des3 = ds.Tables[0].Rows[0]["des3"].ToString();
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
			strSql.Append("select id,codeNo,title,description,mata,footer,des1,des2,des3 ");
			strSql.Append(" FROM tb_SiteConfig ");
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
			strSql.Append(" id,codeNo,title,description,mata,footer,des1,des2,des3 ");
			strSql.Append(" FROM tb_SiteConfig ");
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
			parameters[0].Value = "tb_SiteConfig";
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

