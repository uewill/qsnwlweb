using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;//请先添加引用
namespace TFXK.SQLServerDAL
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
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Pictures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Pictures(");
            strSql.Append("typeID,parentID,imgPath,imgAlt)");
            strSql.Append(" values (");
            strSql.Append("@typeID,@parentID,@imgPath,@imgAlt)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,50),
					new SqlParameter("@imgAlt", SqlDbType.VarChar,50)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.parentID;
            parameters[2].Value = model.imgPath;
            parameters[3].Value = model.imgAlt;


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
        public void Update(TFXK.Model.Pictures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Pictures set ");
            strSql.Append("typeID=@typeID,");
            strSql.Append("parentID=@parentID,");
            strSql.Append("imgPath=@imgPath,");
            strSql.Append("imgAlt=@imgAlt");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,50),
					new SqlParameter("@imgAlt", SqlDbType.VarChar,50),
                new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = model.typeID;
            parameters[1].Value = model.parentID;
            parameters[2].Value = model.imgPath;
            parameters[3].Value = model.imgAlt;
            parameters[4].Value = model.id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            SqlParameter[] parameters = {
					
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					
					new SqlParameter("@otypeID", SqlDbType.Int,4),
					new SqlParameter("@oparentID", SqlDbType.Int,4)
               };

            parameters[0].Value = NewTid;
            parameters[1].Value = NewPid;
            parameters[2].Value = oTid;
            parameters[3].Value = oPid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdatePid(int id, int parentid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Pictures set ");
            strSql.Append("parentID=@parentID");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)
               };

            parameters[0].Value = parentid;
            parameters[1].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Pictures ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByPath(string imgPath)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Pictures ");
            strSql.Append(" where imgPath=@imgPath ");
            SqlParameter[] parameters = {
					new SqlParameter("@imgPath", SqlDbType.VarChar,50)};
            parameters[0].Value = imgPath;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
                new SqlParameter("@typeid", SqlDbType.Int,4)
            };
            parameters[0].Value = pid;
            parameters[1].Value = tid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Pictures GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,typeID,parentID,imgPath,imgAlt from tb_Pictures ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Pictures model = new TFXK.Model.Pictures();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
            return DbHelperSQL.Query(strSql.ToString());
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
                strSql.Append(" and typeid= " + tid);
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


            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTopThreeList(int pid, int tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 3 id,typeID,parentID,imgPath,imgAlt ");
            strSql.Append(" FROM tb_Pictures ");
            strSql.Append(" where ");
            if (pid != 0 && tid != 0)
            {
                strSql.Append(" parentid= " + pid);
                strSql.Append(" and typeid= " + tid);
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
            parameters[0].Value = "tb_Pictures";
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

