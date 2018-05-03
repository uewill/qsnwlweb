using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// 数据访问类ProductsDAL。
    /// </summary>
    public class ProductsDAL : IProductsDAL
    {
        public ProductsDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_Products");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Products");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Products(");
            strSql.Append("parentID,title,codeNo,brandID,brandName,danwei,salePrice,cusPrice,mianliao,colorname,cpdes,fzccdes,xdbxdes,shfwdes,admindes,clicks,orderID,isHot,isTuijian,desFild1,desFild2,desFild3,desFild4,typeID,imgPath)");
            strSql.Append(" values (");
            strSql.Append("@parentID,@title,@codeNo,@brandID,@brandName,@danwei,@salePrice,@cusPrice,@mianliao,@colorname,@cpdes,@fzccdes,@xdbxdes,@shfwdes,@admindes,@clicks,@orderID,@isHot,@isTuijian,@desFild1,@desFild2,@desFild3,@desFild4,@typeID,@imgPath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@codeNo", SqlDbType.VarChar,100),
					new SqlParameter("@brandID", SqlDbType.Int,4),
					new SqlParameter("@brandName", SqlDbType.VarChar,100),
					new SqlParameter("@danwei", SqlDbType.VarChar,50),
					new SqlParameter("@salePrice", SqlDbType.Decimal,9),
					new SqlParameter("@cusPrice", SqlDbType.Decimal,9),
					new SqlParameter("@mianliao", SqlDbType.VarChar,100),
					new SqlParameter("@colorname", SqlDbType.VarChar,50),
					new SqlParameter("@cpdes", SqlDbType.Text),
					new SqlParameter("@fzccdes", SqlDbType.Text),
					new SqlParameter("@xdbxdes", SqlDbType.Text),
					new SqlParameter("@shfwdes", SqlDbType.Text),
					new SqlParameter("@admindes", SqlDbType.Text),
					new SqlParameter("@clicks", SqlDbType.Int,4),
					new SqlParameter("@orderID", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTuijian", SqlDbType.Int,4),
					new SqlParameter("@desFild1", SqlDbType.Int,4),
					new SqlParameter("@desFild2", SqlDbType.VarChar,50),
					new SqlParameter("@desFild3", SqlDbType.Text),
					new SqlParameter("@desFild4", SqlDbType.VarChar,50),
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,50)};
            parameters[0].Value = model.parentID;
            parameters[1].Value = model.title;
            parameters[2].Value = model.codeNo;
            parameters[3].Value = model.brandID;
            parameters[4].Value = model.brandName;
            parameters[5].Value = model.danwei;
            parameters[6].Value = model.salePrice;
            parameters[7].Value = model.cusPrice;
            parameters[8].Value = model.mianliao;
            parameters[9].Value = model.colorname;
            parameters[10].Value = model.cpdes;
            parameters[11].Value = model.fzccdes;
            parameters[12].Value = model.xdbxdes;
            parameters[13].Value = model.shfwdes;
            parameters[14].Value = model.admindes;
            parameters[15].Value = model.clicks;
            parameters[16].Value = model.orderID;
            parameters[17].Value = model.isHot;
            parameters[18].Value = model.isTuijian;
            parameters[19].Value = model.desFild1;
            parameters[20].Value = model.desFild2;
            parameters[21].Value = model.desFild3;
            parameters[22].Value = model.desFild4;
            parameters[23].Value = model.typeID;
            parameters[24].Value = model.imgPath;

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
        public void Update(TFXK.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Products set ");
            strSql.Append("parentID=@parentID,");
            strSql.Append("title=@title,");
            strSql.Append("codeNo=@codeNo,");
            strSql.Append("brandID=@brandID,");
            strSql.Append("brandName=@brandName,");
            strSql.Append("danwei=@danwei,");
            strSql.Append("salePrice=@salePrice,");
            strSql.Append("cusPrice=@cusPrice,");
            strSql.Append("mianliao=@mianliao,");
            strSql.Append("colorname=@colorname,");
            strSql.Append("cpdes=@cpdes,");
            strSql.Append("fzccdes=@fzccdes,");
            strSql.Append("xdbxdes=@xdbxdes,");
            strSql.Append("shfwdes=@shfwdes,");
            strSql.Append("admindes=@admindes,");
            strSql.Append("clicks=@clicks,");
            strSql.Append("orderID=@orderID,");
            strSql.Append("isHot=@isHot,");
            strSql.Append("isTuijian=@isTuijian,");
            strSql.Append("desFild1=@desFild1,");
            strSql.Append("desFild2=@desFild2,");
            strSql.Append("desFild3=@desFild3,");
            strSql.Append("desFild4=@desFild4,");
            strSql.Append("typeID=@typeID,");
            strSql.Append("imgPath=@imgPath");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@codeNo", SqlDbType.VarChar,100),
					new SqlParameter("@brandID", SqlDbType.Int,4),
					new SqlParameter("@brandName", SqlDbType.VarChar,100),
					new SqlParameter("@danwei", SqlDbType.VarChar,50),
					new SqlParameter("@salePrice", SqlDbType.Decimal,9),
					new SqlParameter("@cusPrice", SqlDbType.Decimal,9),
					new SqlParameter("@mianliao", SqlDbType.VarChar,100),
					new SqlParameter("@colorname", SqlDbType.VarChar,50),
					new SqlParameter("@cpdes", SqlDbType.Text),
					new SqlParameter("@fzccdes", SqlDbType.Text),
					new SqlParameter("@xdbxdes", SqlDbType.Text),
					new SqlParameter("@shfwdes", SqlDbType.Text),
					new SqlParameter("@admindes", SqlDbType.Text),
					new SqlParameter("@clicks", SqlDbType.Int,4),
					new SqlParameter("@orderID", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTuijian", SqlDbType.Int,4),
					new SqlParameter("@desFild1", SqlDbType.Int,4),
					new SqlParameter("@desFild2", SqlDbType.VarChar,50),
					new SqlParameter("@desFild3", SqlDbType.Text),
					new SqlParameter("@desFild4", SqlDbType.VarChar,50),
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.parentID;
            parameters[2].Value = model.title;
            parameters[3].Value = model.codeNo;
            parameters[4].Value = model.brandID;
            parameters[5].Value = model.brandName;
            parameters[6].Value = model.danwei;
            parameters[7].Value = model.salePrice;
            parameters[8].Value = model.cusPrice;
            parameters[9].Value = model.mianliao;
            parameters[10].Value = model.colorname;
            parameters[11].Value = model.cpdes;
            parameters[12].Value = model.fzccdes;
            parameters[13].Value = model.xdbxdes;
            parameters[14].Value = model.shfwdes;
            parameters[15].Value = model.admindes;
            parameters[16].Value = model.clicks;
            parameters[17].Value = model.orderID;
            parameters[18].Value = model.isHot;
            parameters[19].Value = model.isTuijian;
            parameters[20].Value = model.desFild1;
            parameters[21].Value = model.desFild2;
            parameters[22].Value = model.desFild3;
            parameters[23].Value = model.desFild4;
            parameters[24].Value = model.typeID;
            parameters[25].Value = model.imgPath;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Products ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Products GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,parentID,title,codeNo,brandID,brandName,danwei,salePrice,cusPrice,mianliao,colorname,cpdes,fzccdes,xdbxdes,shfwdes,admindes,clicks,orderID,isHot,isTuijian,desFild1,desFild2,desFild3,desFild4,typeID,imgPath from tb_Products ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Products model = new TFXK.Model.Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentID"].ToString() != "")
                {
                    model.parentID = int.Parse(ds.Tables[0].Rows[0]["parentID"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.codeNo = ds.Tables[0].Rows[0]["codeNo"].ToString();
                if (ds.Tables[0].Rows[0]["brandID"].ToString() != "")
                {
                    model.brandID = int.Parse(ds.Tables[0].Rows[0]["brandID"].ToString());
                }
                model.brandName = ds.Tables[0].Rows[0]["brandName"].ToString();
                model.danwei = ds.Tables[0].Rows[0]["danwei"].ToString();
                if (ds.Tables[0].Rows[0]["salePrice"].ToString() != "")
                {
                    model.salePrice = decimal.Parse(ds.Tables[0].Rows[0]["salePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusPrice"].ToString() != "")
                {
                    model.cusPrice = decimal.Parse(ds.Tables[0].Rows[0]["cusPrice"].ToString());
                }
                model.mianliao = ds.Tables[0].Rows[0]["mianliao"].ToString();
                model.colorname = ds.Tables[0].Rows[0]["colorname"].ToString();
                model.cpdes = ds.Tables[0].Rows[0]["cpdes"].ToString();
                model.fzccdes = ds.Tables[0].Rows[0]["fzccdes"].ToString();
                model.xdbxdes = ds.Tables[0].Rows[0]["xdbxdes"].ToString();
                model.shfwdes = ds.Tables[0].Rows[0]["shfwdes"].ToString();
                model.admindes = ds.Tables[0].Rows[0]["admindes"].ToString();
                if (ds.Tables[0].Rows[0]["clicks"].ToString() != "")
                {
                    model.clicks = int.Parse(ds.Tables[0].Rows[0]["clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderID"].ToString() != "")
                {
                    model.orderID = int.Parse(ds.Tables[0].Rows[0]["orderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isHot"].ToString() != "")
                {
                    model.isHot = int.Parse(ds.Tables[0].Rows[0]["isHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isTuijian"].ToString() != "")
                {
                    model.isTuijian = int.Parse(ds.Tables[0].Rows[0]["isTuijian"].ToString());
                }
                if (ds.Tables[0].Rows[0]["desFild1"].ToString() != "")
                {
                    model.desFild1 = int.Parse(ds.Tables[0].Rows[0]["desFild1"].ToString());
                }
                model.desFild2 = ds.Tables[0].Rows[0]["desFild2"].ToString();
                model.desFild3 = ds.Tables[0].Rows[0]["desFild3"].ToString();
                model.desFild4 = ds.Tables[0].Rows[0]["desFild4"].ToString();
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体 id,title,codeNo有效
        /// </summary>
        public TFXK.Model.Products GetSimpleModel(string codeNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,codeNo from tb_Products ");
            strSql.Append(" where codeNo=@codeNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = codeNo;

            TFXK.Model.Products model = new TFXK.Model.Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.codeNo = ds.Tables[0].Rows[0]["codeNo"].ToString();
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
            strSql.Append("select id,parentID,title,codeNo,brandID,brandName,danwei,salePrice,cusPrice,mianliao,colorname,cpdes,fzccdes,xdbxdes,shfwdes,admindes,clicks,orderID,isHot,isTuijian,desFild1,desFild2,desFild3,desFild4,typeID,imgPath ");
            strSql.Append(" FROM tb_Products ");
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
            strSql.Append(" id,parentID,title,codeNo,brandID,brandName,danwei,salePrice,cusPrice,mianliao,colorname,cpdes,fzccdes,xdbxdes,shfwdes,admindes,clicks,orderID,isHot,isTuijian,desFild1,desFild2,desFild3,desFild4,typeID,imgPath ");
            strSql.Append(" FROM tb_Products ");
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
            parameters[0].Value = "tb_Products";
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
        /// 更新排序
        /// </summary>
        /// <param name="id">序号</param>
        /// <param name="orderid">排序</param>
        public void UpdateOrders(int id, int orderid, string fildName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Products set ");
            strSql.Append(fildName + "=@orderID");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = orderid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tid">属性ID</param>
        /// <param name="typeid">0为推荐 1为热门</param>
        public void Update(int id, int tid, int typeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Products set ");
            if (typeid == 1)
            {
                strSql.Append("isHot=" + tid);
            }
            else if (typeid == 0)
            {
                strSql.Append("isTuijian=" + tid);
            }
            else if (typeid == 2)
            {
                strSql.Append("desfild1=" + tid);
            }
            strSql.Append(" where id= " + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
    }
}

