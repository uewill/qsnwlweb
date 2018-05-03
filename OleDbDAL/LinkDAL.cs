using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
{
	/// <summary>
	/// 数据访问类LinkDAL。
	/// </summary>
	public class LinkDAL:ILinkDAL
	{
		public LinkDAL()
		{}
		#region  成员方法


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "tb_Link");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Link");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TFXK.Model.Link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Link(");
			strSql.Append("title,linkUrl,logo,isPictureOn,orderId,parentId)");
			strSql.Append(" values (");
			strSql.Append("@title,@linkUrl,@logo,@isPictureOn,@orderId,@parentId)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@linkUrl", OleDbType.VarChar,100),
					new OleDbParameter("@logo", OleDbType.VarChar,50),
					new OleDbParameter("@isPictureOn", OleDbType.VarChar,10),
					new OleDbParameter("@orderId", OleDbType.Integer,4),
					new OleDbParameter("@parentId", OleDbType.Integer,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.linkUrl;
            parameters[2].Value = model.logo;
            parameters[3].Value = model.isPictureOn;
            parameters[4].Value = model.orderId;
			parameters[5].Value = model.parentId;

            object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
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
		public void Update(TFXK.Model.Link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Link set ");
			strSql.Append("title=@title,");
			strSql.Append("linkUrl=@linkUrl,");
			strSql.Append("logo=@logo,");
			strSql.Append("isPictureOn=@isPictureOn,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("parentId=@parentId");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@linkUrl", OleDbType.VarChar,100),
					new OleDbParameter("@logo", OleDbType.VarChar,100),
					new OleDbParameter("@isPictureOn", OleDbType.VarChar,10),
					new OleDbParameter("@orderId", OleDbType.Integer,4),
					new OleDbParameter("@parentId", OleDbType.Integer,4),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.linkUrl;
			parameters[2].Value = model.logo;
			parameters[3].Value = model.isPictureOn;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.parentId;
            parameters[6].Value = model.id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Link ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public TFXK.Model.Link GetModel(int id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,title,linkUrl,logo,isPictureOn,orderId,parentId from tb_Link ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

			TFXK.Model.Link model=new TFXK.Model.Link();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.linkUrl=ds.Tables[0].Rows[0]["linkUrl"].ToString();
				model.logo=ds.Tables[0].Rows[0]["logo"].ToString();
				model.isPictureOn=ds.Tables[0].Rows[0]["isPictureOn"].ToString();
				if(ds.Tables[0].Rows[0]["orderId"].ToString()!="")
				{
					model.orderId=int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
				}
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
			strSql.Append("select id,title,linkUrl,logo,isPictureOn,orderId,parentId ");
			strSql.Append(" FROM tb_Link ");
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
            strSql.Append(" id,title,linkUrl,logo,isPictureOn,orderId,parentId ");
            strSql.Append(" FROM tb_Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件得到总条数
        /// </summary>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(id) ");
            strSql.Append(" FROM tb_Link ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOleDb.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
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
			parameters[0].Value = "tb_Link";
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

