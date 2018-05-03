using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.OleDbDAL
{
    /// <summary>
    /// 数据访问类PicturesDAL。
    /// </summary>
    public class PicturesDAL : IPicturesDAL
    {
        public PicturesDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Pictures");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TFXK.Model.Pictures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Pictures(");
            strSql.Append("typeID,parentID,imgPath,imgAlt)");
            strSql.Append(" values (");
            strSql.Append("@typeID,@parentID,@imgPath,@imgAlt)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@typeID", OleDbType.Integer,4),
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					new OleDbParameter("@imgPath", OleDbType.VarChar,50),
					new OleDbParameter("@imgAlt", OleDbType.VarChar,50)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.parentID;
            parameters[2].Value = model.imgPath;
            parameters[3].Value = model.imgAlt;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Pictures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Pictures set ");
            strSql.Append("typeID=@typeID,");
            strSql.Append("parentID=@parentID,");
            strSql.Append("imgPath=@imgPath,");
            strSql.Append("imgAlt=@imgAlt");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					
					new OleDbParameter("@typeID", OleDbType.Integer,4),
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					new OleDbParameter("@imgPath", OleDbType.VarChar,50),
					new OleDbParameter("@imgAlt", OleDbType.VarChar,50),
                new OleDbParameter("@id", OleDbType.Integer,4)};

            parameters[0].Value = model.typeID;
            parameters[1].Value = model.parentID;
            parameters[2].Value = model.imgPath;
            parameters[3].Value = model.imgAlt;
            parameters[4].Value = model.id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(int oPid, int oTid, int NewPid, int NewTid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Pictures set ");
            strSql.Append("typeID=@typeID,");
            strSql.Append("parentID=@parentID,");
            strSql.Append(" where typeID=@otypeID ");
            strSql.Append(" and parentID=@oparentID ");
            OleDbParameter[] parameters = {
					
					new OleDbParameter("@typeID", OleDbType.Integer,4),
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					
					new OleDbParameter("@otypeID", OleDbType.Integer,4),
					new OleDbParameter("@oparentID", OleDbType.Integer,4)
               };

            parameters[0].Value = NewTid;
            parameters[1].Value = NewPid;
            parameters[2].Value = oTid;
            parameters[3].Value = oPid;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Pictures ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int pid, int tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Pictures ");
            strSql.Append(" where parentid=@parentid ");
            strSql.Append(" and typeid=@typeid ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@parentid", OleDbType.Integer,4),
                new OleDbParameter("@typeid", OleDbType.Integer,4)
            };
            parameters[0].Value = pid;
            parameters[1].Value = tid;
            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Pictures GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,typeID,parentID,imgPath,imgAlt from tb_Pictures ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            TFXK.Model.Pictures model = new TFXK.Model.Pictures();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentID"].ToString() != "")
                {
                    model.parentID = int.Parse(ds.Tables[0].Rows[0]["parentID"].ToString());
                }
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                model.imgAlt = ds.Tables[0].Rows[0]["imgAlt"].ToString();
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
            strSql.Append("select id,typeID,parentID,imgPath,imgAlt ");
            strSql.Append(" FROM tb_Pictures ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pid, int tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,typeID,parentID,imgPath,imgAlt ");
            strSql.Append(" FROM tb_Pictures ");
            strSql.Append(" where ");
            if (pid != 0 && tid != 0)
            {
                strSql.Append(" parentid= " + pid);
                strSql.Append(" and parentid= " + pid);
            }
            else if (pid != 0)
            {
                strSql.Append(" parentid= " + pid);
            }
            else if (tid != 0)
            {
                strSql.Append(" typeid= " + tid);
            }
            else if (pid == tid && pid == 0)
            {
                strSql.Append(" 1=1");
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
            parameters[0].Value = "tb_Pictures";
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

