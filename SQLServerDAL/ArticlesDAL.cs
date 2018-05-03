using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类ArticlesDAL。
    /// </summary>
    public class ArticlesDAL : IArticlesDAL
    {
        public ArticlesDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Articles");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Articles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Articles(");
            strSql.Append("parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId,imgPath,outLinkPath,fysmDes,wxtsDes,ydxzDes)");
            strSql.Append(" values (");
            strSql.Append("@parentId,@title,@source,@publisher,@createTime,@description,@isOutlLink,@isSlideOn,@state,@clicks,@orderId,@imgPath,@outLinkPath,@fysmDes,@wxtsDes,@ydxzDes)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@source", SqlDbType.VarChar,500),
					new SqlParameter("@publisher", SqlDbType.VarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@isOutlLink", SqlDbType.Int,4),
					new SqlParameter("@isSlideOn", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@clicks", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,100),
					new SqlParameter("@outLinkPath", SqlDbType.VarChar,100),
            new SqlParameter("@fysmDes", SqlDbType.Text),
					new SqlParameter("@wxtsDes", SqlDbType.Text),
            new SqlParameter("@ydxzDes", SqlDbType.Text)};
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
            parameters[11].Value = model.imgPath;
            parameters[12].Value = model.outLinkPath;
            parameters[13].Value = model.fysmDes;
            parameters[14].Value = model.wxtsDes;
            parameters[15].Value = model.ydxzDes;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(TFXK.Model.Articles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Articles set ");
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
            strSql.Append("orderId=@orderId,");
            strSql.Append("imgPath=@imgPath,");
            strSql.Append("outLinkPath=@outLinkPath,fysmDes=@fysmDes,wxtsDes=@wxtsDes,ydxzDes=@ydxzDes");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@source", SqlDbType.VarChar,500),
					new SqlParameter("@publisher", SqlDbType.VarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@isOutlLink", SqlDbType.Int,4),
					new SqlParameter("@isSlideOn", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@clicks", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,100),
					new SqlParameter("@outLinkPath", SqlDbType.VarChar,100),
					new SqlParameter("@fysmDes", SqlDbType.Text),
					new SqlParameter("@wxtsDes", SqlDbType.Text),
					new SqlParameter("@ydxzDes", SqlDbType.Text)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.parentId;
            parameters[2].Value = model.title;
            parameters[3].Value = model.source;
            parameters[4].Value = model.publisher;
            parameters[5].Value = model.createTime;
            parameters[6].Value = model.description;
            parameters[7].Value = model.isOutlLink;
            parameters[8].Value = model.isSlideOn;
            parameters[9].Value = model.state;
            parameters[10].Value = model.clicks;
            parameters[11].Value = model.orderId;
            parameters[12].Value = model.imgPath;
            parameters[13].Value = model.outLinkPath;
            parameters[14].Value = model.fysmDes;
            parameters[15].Value = model.wxtsDes;
            parameters[16].Value = model.ydxzDes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="id">编号</param>
        public void UpdateClick(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Articles");
            strSql.Append(" set ");
            strSql.Append("clicks=clicks+1 ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Articles ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Articles GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId,imgPath,outLinkPath,fysmDes,wxtsDes,ydxzDes from tb_Articles ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Articles model = new TFXK.Model.Articles();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
                if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["isOutlLink"].ToString() != "")
                {
                    model.isOutlLink = int.Parse(ds.Tables[0].Rows[0]["isOutlLink"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isSlideOn"].ToString() != "")
                {
                    model.isSlideOn = int.Parse(ds.Tables[0].Rows[0]["isSlideOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["clicks"].ToString() != "")
                {
                    model.clicks = int.Parse(ds.Tables[0].Rows[0]["clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                }
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                model.outLinkPath = ds.Tables[0].Rows[0]["outLinkPath"].ToString();
                model.fysmDes = ds.Tables[0].Rows[0]["fysmDes"].ToString();
                model.wxtsDes = ds.Tables[0].Rows[0]["wxtsDes"].ToString();
                model.ydxzDes = ds.Tables[0].Rows[0]["ydxzDes"].ToString();

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
            strSql.Append("select id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId,imgPath,outLinkPath,fysmDes,wxtsDes,ydxzDes  ");
            strSql.Append(" FROM tb_Articles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("  order by orderid desc, id desc ");
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
            strSql.Append(" id,parentId,title,source,publisher,createTime,description,isOutlLink,isSlideOn,state,clicks,orderId,imgPath,outLinkPath,fysmDes,wxtsDes,ydxzDes  ");
            strSql.Append(" FROM tb_Articles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "tb_Articles";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法


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
            strSql.Append(" * ");
            strSql.Append(" FROM tb_Articles ");
            strSql.Append(" where parentId in ");
            strSql.Append(" ( ");
            strSql.Append(childNodeid);
            strSql.Append(" ) ");
            strSql.Append(" order by " + orderId.ToString() + " desc");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="id">序号</param>
        /// <param name="orderid">排序</param>
        public void UpdateOrders(int id, int orderid, string fildName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Articles set ");
            strSql.Append(fildName + "=@orderID");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = orderid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

    }
}

