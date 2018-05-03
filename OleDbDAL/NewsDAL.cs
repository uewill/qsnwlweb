using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
{
    /// <summary>
    /// 数据访问类NewsDAL。
    /// </summary>
    public class NewsDAL : INewsDAL
    {
        public NewsDAL()
        { }
        #region  成员方法


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "tb_News");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_News");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_News(");
            strSql.Append("parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId)");
            strSql.Append(" values (");
            strSql.Append("@parentId,@title,@source,@publisher,@createTime,@description,@isOutlLink,@isSlideOn,@state,@clicks,@orderId)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@parentId", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@source", OleDbType.VarChar,5000),
					new OleDbParameter("@publisher", OleDbType.VarChar,50),
					new OleDbParameter("@createTime", OleDbType.VarChar,19),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@isOutlLink", OleDbType.VarChar,50),
					new OleDbParameter("@isSlideOn", OleDbType.VarChar,50),
					new OleDbParameter("@state", OleDbType.VarChar,50),
					new OleDbParameter("@clicks", OleDbType.Integer,4),
					new OleDbParameter("@orderId", OleDbType.Integer,4)};
            parameters[0].Value = model.parentId;
            parameters[1].Value = model.title;
            parameters[2].Value = model.source;
            parameters[3].Value = model.publisher;
            parameters[4].Value = model.createTime;
            parameters[5].Value = model.description;
            parameters[6].Value = model.isOutlLink;
            parameters[7].Value = model.isSlideOn;
            parameters[8].Value = model.state;
            parameters[9].Value = model.clicks;
            parameters[10].Value = model.orderId;

            DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
            return GetMaxId() - 1;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_News set ");
            strSql.Append("parentId=@parentId,");
            strSql.Append("title=@title,");
            strSql.Append("source=@source,");
            strSql.Append("publisher=@publisher,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("description=@description,");
            strSql.Append("isOutlLink=@isOutlLink,");
            strSql.Append("isSlideOn=@isSlideOn,");
            strSql.Append("state=@state,");
            strSql.Append("clicks=@clicks,");
            strSql.Append("orderId=@orderId");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@parentId", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@source", OleDbType.VarChar,5000),
					new OleDbParameter("@publisher", OleDbType.VarChar,50),
					new OleDbParameter("@createTime", OleDbType.VarChar,19),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@isOutlLink", OleDbType.VarChar,50),
					new OleDbParameter("@isSlideOn", OleDbType.VarChar,50),
					new OleDbParameter("@state", OleDbType.VarChar,50),
					new OleDbParameter("@clicks", OleDbType.Integer,4),
					new OleDbParameter("@orderId", OleDbType.Integer,4),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.parentId;
            parameters[1].Value = model.title;
            parameters[2].Value = model.source;
            parameters[3].Value = model.publisher;
            parameters[4].Value = model.createTime;
            parameters[5].Value = model.description;
            parameters[6].Value = model.isOutlLink;
            parameters[7].Value = model.isSlideOn;
            parameters[8].Value = model.state;
            parameters[9].Value = model.clicks;
            parameters[10].Value = model.orderId;
            parameters[11].Value = model.id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        public void UpdateClick(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_News");
            strSql.Append(" set ");
            strSql.Append("clicks=clicks+1 ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_News ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.News GetModel(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId from tb_News ");

            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            TFXK.Model.News model = new TFXK.Model.News();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentId"].ToString() != "")
                {
                    model.parentId = int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.source = ds.Tables[0].Rows[0]["source"].ToString();
                model.publisher = ds.Tables[0].Rows[0]["publisher"].ToString();
                model.createTime = ds.Tables[0].Rows[0]["createTime"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.isOutlLink = ds.Tables[0].Rows[0]["isOutlLink"].ToString();
                model.isSlideOn = ds.Tables[0].Rows[0]["isSlideOn"].ToString();
                model.state = ds.Tables[0].Rows[0]["state"].ToString();
                if (ds.Tables[0].Rows[0]["clicks"].ToString() != "")
                {
                    model.clicks = int.Parse(ds.Tables[0].Rows[0]["clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId ");
            strSql.Append(" FROM tb_News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据父类编码获取所有子类数据
        /// </summary>
        /// <param name="Top">前几行</param>
        /// <param name="codeNo">父类编码</param>
        /// <returns>数据集</returns>
        public DataSet GetTopListByCodeNo(int Top, string codeNo, string orderId)
        {
            // 获取子分类编码和父分类
            CategoryDAL cdal = new CategoryDAL();
            string childNodeid = cdal.GetAllChildIDByCode(codeNo);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId ");
            strSql.Append(" FROM tb_News ");
            strSql.Append(" where parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" ) ");
            strSql.Append(" order by " + orderId.ToString() + " desc");

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
            strSql.Append(" id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId ");
            strSql.Append(" FROM tb_News ");
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
            parameters[0].Value = "News";
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

