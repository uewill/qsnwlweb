using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类LinkDAL。
    /// </summary>
    public class LinkDAL : ILinkDAL
    {
        public LinkDAL()
        { }
        #region  成员方法


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_Link");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Link");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Link model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Link(");
            strSql.Append("title,linkUrl,logo,isPictureOn,orderId,parentId,description)");
            strSql.Append(" values (");
            strSql.Append("@title,@linkUrl,@logo,@isPictureOn,@orderId,@parentId,@description)");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@logo", SqlDbType.VarChar,50),
					new SqlParameter("@isPictureOn", SqlDbType.VarChar,10),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),new SqlParameter("@description", SqlDbType.VarChar,500)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.linkUrl;
            parameters[2].Value = model.logo;
            parameters[3].Value = model.isPictureOn;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.parentId;
            parameters[6].Value = model.description;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Link set ");
            strSql.Append("title=@title,");
            strSql.Append("linkUrl=@linkUrl,");
            strSql.Append("logo=@logo,");
            strSql.Append("isPictureOn=@isPictureOn,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("parentId=@parentId,");
            strSql.Append("description=@description");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@logo", SqlDbType.VarChar,100),
					new SqlParameter("@isPictureOn", SqlDbType.VarChar,10),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
                      new SqlParameter("@description", SqlDbType.VarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.title;
            parameters[1].Value = model.linkUrl;
            parameters[2].Value = model.logo;
            parameters[3].Value = model.isPictureOn;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.parentId;
            parameters[6].Value = model.description;
            parameters[7].Value = model.id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Link ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Link GetModel(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,linkUrl,logo,isPictureOn,orderId,parentId,description from tb_Link ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Link model = new TFXK.Model.Link();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.linkUrl = ds.Tables[0].Rows[0]["linkUrl"].ToString();
                model.logo = ds.Tables[0].Rows[0]["logo"].ToString();
                model.isPictureOn = ds.Tables[0].Rows[0]["isPictureOn"].ToString();
                if (ds.Tables[0].Rows[0]["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentId"].ToString() != "")
                {
                    model.parentId = int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();



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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,linkUrl,logo,isPictureOn,orderId,parentId,description ");
            strSql.Append(" FROM tb_Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" id,title,linkUrl,logo,isPictureOn,orderId,parentId,description ");
            strSql.Append(" FROM tb_Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_Link";
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

