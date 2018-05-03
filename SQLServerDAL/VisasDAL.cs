using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
	/// <summary>
	/// 数据访问类VisasDAL。
	/// </summary>
	public class VisasDAL:IVisasDAL
	{
		public VisasDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_visas"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_visas");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.Visas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_visas(");
			strSql.Append("CountryID,imgPaht,expDate,stayDays,useDays,interview,useArea,useDes,des1,des2,des3)");
			strSql.Append(" values (");
			strSql.Append("@CountryID,@imgPaht,@expDate,@stayDays,@useDays,@interview,@useArea,@useDes,@des1,@des2,@des3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryID", SqlDbType.Int,4),
					new SqlParameter("@imgPaht", SqlDbType.VarChar,50),
					new SqlParameter("@expDate", SqlDbType.Text),
					new SqlParameter("@stayDays", SqlDbType.VarChar,50),
					new SqlParameter("@useDays", SqlDbType.VarChar,50),
					new SqlParameter("@interview", SqlDbType.Int,4),
					new SqlParameter("@useArea", SqlDbType.Text),
					new SqlParameter("@useDes", SqlDbType.Text),
					new SqlParameter("@des1", SqlDbType.VarChar,50),
					new SqlParameter("@des2", SqlDbType.VarChar,50),
					new SqlParameter("@des3", SqlDbType.Int,4)};
			parameters[0].Value = model.CountryID;
			parameters[1].Value = model.imgPaht;
			parameters[2].Value = model.expDate;
			parameters[3].Value = model.stayDays;
			parameters[4].Value = model.useDays;
			parameters[5].Value = model.interview;
			parameters[6].Value = model.useArea;
			parameters[7].Value = model.useDes;
			parameters[8].Value = model.des1;
			parameters[9].Value = model.des2;
			parameters[10].Value = model.des3;

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
		public void Update(TFXK.Model.Visas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_visas set ");
			strSql.Append("CountryID=@CountryID,");
			strSql.Append("imgPaht=@imgPaht,");
			strSql.Append("expDate=@expDate,");
			strSql.Append("stayDays=@stayDays,");
			strSql.Append("useDays=@useDays,");
			strSql.Append("interview=@interview,");
			strSql.Append("useArea=@useArea,");
			strSql.Append("useDes=@useDes,");
			strSql.Append("des1=@des1,");
			strSql.Append("des2=@des2,");
			strSql.Append("des3=@des3");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@CountryID", SqlDbType.Int,4),
					new SqlParameter("@imgPaht", SqlDbType.VarChar,50),
					new SqlParameter("@expDate", SqlDbType.Text),
					new SqlParameter("@stayDays", SqlDbType.VarChar,50),
					new SqlParameter("@useDays", SqlDbType.VarChar,50),
					new SqlParameter("@interview", SqlDbType.Int,4),
					new SqlParameter("@useArea", SqlDbType.Text),
					new SqlParameter("@useDes", SqlDbType.Text),
					new SqlParameter("@des1", SqlDbType.VarChar,50),
					new SqlParameter("@des2", SqlDbType.VarChar,50),
					new SqlParameter("@des3", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.CountryID;
			parameters[2].Value = model.imgPaht;
			parameters[3].Value = model.expDate;
			parameters[4].Value = model.stayDays;
			parameters[5].Value = model.useDays;
			parameters[6].Value = model.interview;
			parameters[7].Value = model.useArea;
			parameters[8].Value = model.useDes;
			parameters[9].Value = model.des1;
			parameters[10].Value = model.des2;
			parameters[11].Value = model.des3;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_visas ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.Visas GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,CountryID,imgPaht,expDate,stayDays,useDays,interview,useArea,useDes,des1,des2,des3 from tb_visas ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			TFXK.Model.Visas model=new TFXK.Model.Visas();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CountryID"].ToString()!="")
				{
					model.CountryID=int.Parse(ds.Tables[0].Rows[0]["CountryID"].ToString());
				}
				model.imgPaht=ds.Tables[0].Rows[0]["imgPaht"].ToString();
				model.expDate=ds.Tables[0].Rows[0]["expDate"].ToString();
				model.stayDays=ds.Tables[0].Rows[0]["stayDays"].ToString();
				model.useDays=ds.Tables[0].Rows[0]["useDays"].ToString();
				if(ds.Tables[0].Rows[0]["interview"].ToString()!="")
				{
					model.interview=int.Parse(ds.Tables[0].Rows[0]["interview"].ToString());
				}
				model.useArea=ds.Tables[0].Rows[0]["useArea"].ToString();
				model.useDes=ds.Tables[0].Rows[0]["useDes"].ToString();
				model.des1=ds.Tables[0].Rows[0]["des1"].ToString();
				model.des2=ds.Tables[0].Rows[0]["des2"].ToString();
				if(ds.Tables[0].Rows[0]["des3"].ToString()!="")
				{
					model.des3=int.Parse(ds.Tables[0].Rows[0]["des3"].ToString());
				}
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
        public TFXK.Model.Visas GetModelByCID(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,CountryID,imgPaht,expDate,stayDays,useDays,interview,useArea,useDes,des1,des2,des3 from tb_visas ");
            strSql.Append(" where CountryID=@CountryID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CountryID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Visas model = new TFXK.Model.Visas();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CountryID"].ToString() != "")
                {
                    model.CountryID = int.Parse(ds.Tables[0].Rows[0]["CountryID"].ToString());
                }
                model.imgPaht = ds.Tables[0].Rows[0]["imgPaht"].ToString();
                model.expDate = ds.Tables[0].Rows[0]["expDate"].ToString();
                model.stayDays = ds.Tables[0].Rows[0]["stayDays"].ToString();
                model.useDays = ds.Tables[0].Rows[0]["useDays"].ToString();
                if (ds.Tables[0].Rows[0]["interview"].ToString() != "")
                {
                    model.interview = int.Parse(ds.Tables[0].Rows[0]["interview"].ToString());
                }
                model.useArea = ds.Tables[0].Rows[0]["useArea"].ToString();
                model.useDes = ds.Tables[0].Rows[0]["useDes"].ToString();
                model.des1 = ds.Tables[0].Rows[0]["des1"].ToString();
                model.des2 = ds.Tables[0].Rows[0]["des2"].ToString();
                if (ds.Tables[0].Rows[0]["des3"].ToString() != "")
                {
                    model.des3 = int.Parse(ds.Tables[0].Rows[0]["des3"].ToString());
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
			strSql.Append("select id,CountryID,imgPaht,expDate,stayDays,useDays,interview,useArea,useDes,des1,des2,des3 ");
			strSql.Append(" FROM tb_visas ");
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
			strSql.Append(" id,CountryID,imgPaht,expDate,stayDays,useDays,interview,useArea,useDes,des1,des2,des3 ");
			strSql.Append(" FROM tb_visas ");
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
			parameters[0].Value = "tb_visas";
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

