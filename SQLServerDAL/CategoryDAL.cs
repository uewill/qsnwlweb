using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TFXK.IDAL;
using TFXK.DBUtility;
using TFXK.Model;
using System.Collections.Generic;//�����������
namespace TFXK.SQLServerDAL
{
    /// <summary>
    /// ���ݷ�����CategoryDAL��
    /// </summary>
    public class CategoryDAL : ICategoryDAL
    {
        public CategoryDAL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_Category");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool ExistsCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where codeNo=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.VarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Category GetModel(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,codeNo,parentID,description,orderId,imgPath,stateID,typeID,outLink from tb_Category ");
            strSql.Append(" where codeNo=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.VarChar,50)};
            parameters[0].Value = code;

            TFXK.Model.Category model = new TFXK.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.codeNo = ds.Tables[0].Rows[0]["codeNo"].ToString();
                if (ds.Tables[0].Rows[0]["parentID"].ToString() != "")
                {
                    model.parentID = int.Parse(ds.Tables[0].Rows[0]["parentID"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                }
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                if (ds.Tables[0].Rows[0]["stateID"].ToString() != "")
                {
                    model.stateID = int.Parse(ds.Tables[0].Rows[0]["stateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                model.outLink = ds.Tables[0].Rows[0]["outLink"].ToString();
                return model;
            }
            else
            {
                return null;
            }

        }

        public TFXK.Model.Category GetModelByName(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,codeNo,parentID,description,orderId,imgPath,stateID,typeID,outLink from tb_Category ");
            strSql.Append(" where title=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.VarChar,50)};
            parameters[0].Value = code;

            TFXK.Model.Category model = new TFXK.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.codeNo = ds.Tables[0].Rows[0]["codeNo"].ToString();
                if (ds.Tables[0].Rows[0]["parentID"].ToString() != "")
                {
                    model.parentID = int.Parse(ds.Tables[0].Rows[0]["parentID"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                }
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                if (ds.Tables[0].Rows[0]["stateID"].ToString() != "")
                {
                    model.stateID = int.Parse(ds.Tables[0].Rows[0]["stateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                model.outLink = ds.Tables[0].Rows[0]["outLink"].ToString();
                return model;
            }
            else
            {
                return null;
            }

        }

        

        /// <summary>
        /// ��������ʱ,����ͬ����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderId">������</param>
        public void UpdateOrderId(int id, int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Category set ");
            strSql.Append("orderId=@orderId");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = orderId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void UpdateDes(int id, string content)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Category set ");
            strSql.Append("description=@description ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@description", SqlDbType.Text),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = content;
            parameters[1].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ��ȡ��һ��������һ����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderId">������</param>
        public List<int> GetUpOrDownOrderID(int id, int orderid, int isUp)
        {
            List<int> orders = new List<int>();
            string dayu = ">" + orderid + " order by orderid asc";
            if (isUp == 1)
            {
                dayu = "<" + orderid + " order by orderid desc";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 orderid,id from tb_category where parentid in (select parentid from tb_category where id=" + id + " )and orderid " + dayu);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            try
            {
                if (ds != null && ds.Tables[0] != null)
                {
                    orders.Add(int.Parse(ds.Tables[0].Rows[0][0] + ""));
                    orders.Add(int.Parse(ds.Tables[0].Rows[0][1] + ""));
                    return orders;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// �����ӷ���
        /// </summary>
        public bool HasChild(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where parentID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// �����ӷ���
        /// </summary>
        public bool HasChildByCode(string code)
        {
            int id = GetIdByCodeNo(code);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where parentid=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ȡ�ӷ�������
        /// </summary>
        public int GetChildNum(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from tb_Category");
            strSql.Append(" where parentID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return int.Parse(DbHelperSQL.GetSingle(strSql.ToString(), parameters) + "");
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TFXK.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Category(");
            strSql.Append("title,codeNo,parentID,description,orderId,imgPath,stateID,typeID,outLink,simpleDes,otherDes1,otherDes2)");
            strSql.Append(" values (");
            strSql.Append("@title,@codeNo,@parentID,@description,@orderId,@imgPath,@stateID,@typeID,@outLink,@simpleDes,@otherDes1,@otherDes2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@codeNo", SqlDbType.VarChar,50),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,50),
					new SqlParameter("@stateID", SqlDbType.Int,4),
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@outLink", SqlDbType.VarChar,100),
					new SqlParameter("@simpleDes", SqlDbType.VarChar,5000),
					new SqlParameter("@otherDes1", SqlDbType.VarChar,50),
					new SqlParameter("@otherDes2", SqlDbType.VarChar,50)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.codeNo;
            parameters[2].Value = model.parentID;
            parameters[3].Value = model.description;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.imgPath;
            parameters[6].Value = model.stateID;
            parameters[7].Value = model.typeID;
            parameters[8].Value = model.outLink;
            parameters[9].Value = model.simpleDes;
            parameters[10].Value = model.otherDes1;
            parameters[11].Value = model.otherDes2;
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
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Category set ");
            strSql.Append("title=@title,");
            strSql.Append("codeNo=@codeNo,");
            strSql.Append("parentID=@parentID,");
            strSql.Append("description=@description,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("imgPath=@imgPath,");
            strSql.Append("stateID=@stateID,");
            strSql.Append("typeID=@typeID,");
            strSql.Append("outLink=@outLink,");
            strSql.Append("simpleDes=@simpleDes,");
            strSql.Append("otherDes1=@otherDes1,");
            strSql.Append("otherDes2=@otherDes2");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@codeNo", SqlDbType.VarChar,50),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@imgPath", SqlDbType.VarChar,50),
					new SqlParameter("@stateID", SqlDbType.Int,4),
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@outLink", SqlDbType.VarChar,100),
					new SqlParameter("@simpleDes", SqlDbType.VarChar,5000),
					new SqlParameter("@otherDes1", SqlDbType.VarChar,50),
					new SqlParameter("@otherDes2", SqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.codeNo;
            parameters[3].Value = model.parentID;
            parameters[4].Value = model.description;
            parameters[5].Value = model.orderId;
            parameters[6].Value = model.imgPath;
            parameters[7].Value = model.stateID;
            parameters[8].Value = model.typeID;
            parameters[9].Value = model.outLink;
            parameters[10].Value = model.simpleDes;
            parameters[11].Value = model.otherDes1;
            parameters[12].Value = model.otherDes2;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Category ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��ʱ������������
        /// </summary>
        public void UpdateOrderByDel(int parentID, int orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Category set ");
            strSql.Append("orderId=orderId-1");
            strSql.Append(" where parentID=@parentID ");
            strSql.Append("and orderID>@orderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.Int,4),
                new SqlParameter("@orderID", SqlDbType.Int,4)
            };
            parameters[0].Value = parentID;
            parameters[1].Value = orderID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Category GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,codeNo,parentID,description,orderId,imgPath,stateID,typeID,outLink,simpleDes,otherDes1,otherDes2 from tb_Category ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            TFXK.Model.Category model = new TFXK.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.codeNo = ds.Tables[0].Rows[0]["codeNo"].ToString();
                if (ds.Tables[0].Rows[0]["parentID"].ToString() != "")
                {
                    model.parentID = int.Parse(ds.Tables[0].Rows[0]["parentID"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                }
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                if (ds.Tables[0].Rows[0]["stateID"].ToString() != "")
                {
                    model.stateID = int.Parse(ds.Tables[0].Rows[0]["stateID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                model.outLink = ds.Tables[0].Rows[0]["outLink"].ToString();
                model.simpleDes = ds.Tables[0].Rows[0]["simpleDes"].ToString();
                model.otherDes1 = ds.Tables[0].Rows[0]["otherDes1"].ToString();
                model.otherDes2 = ds.Tables[0].Rows[0]["otherDes2"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,codeNo,parentID,description,orderId,imgPath,stateID,typeID,outLink,simpleDes,otherDes1,otherDes2 ");
            strSql.Append(" FROM tb_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by orderId,id");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,codeNo,parentID,description,orderId,imgPath,stateID,typeID,outLink,simpleDes,otherDes1,otherDes2 ");
            strSql.Append(" FROM tb_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// ���߱�Ż�ȡ������ı��
        /// </summary>
        /// <param name="id">���</param>
        /// <returns>dataset pid</returns>
        public DataSet GetParentIdsByID(int id)
        {
            Model.Category model = new TFXK.Model.Category();
            model.parentID = id;
            DataTable dt = new DataTable();
            dt.Columns.Add("pid");
            while (model != null && model.parentID != 0)
            {
                model = GetParentID(model.parentID);
                DataRow dr = dt.NewRow();
                dr["pid"] = model.parentID;
                dt.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        private Model.Category GetParentID(int id)
        {
            try
            {
                return GetModel(id);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// ���ݱ����ȡ���
        /// </summary>
        /// <param name="codeNo">����</param>
        /// <returns>���</returns>
        public int GetIdByCodeNo(string codeNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id from tb_Category ");
            strSql.Append(" where codeNo=@codeNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = codeNo;

            int id = 0;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
            }
            return id;
        }


        /// <summary>
        /// ���ݱ����ȡ��� ǩ֤��Ŀ��
        /// </summary>
        /// <param name="codeNo">����</param>
        /// <returns>���</returns>
        public int GetIdByTitle(string codeNo)
        {
            //
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id from tb_Category ");
            strSql.Append(" where title=@codeNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = codeNo;

            int id = 0;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
            }
            if (id > 0)
            {
                strSql = new StringBuilder();
                string ids = GetAllChildIDByCode("qzbl");
                strSql.Append("select  top 1 id from tb_Category where id=" + id + " and parentid in(" + ids + ")");

                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                    {
                        id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                    }
                }
                else
                {
                    id = 0;//ǩ֤����û����Ӧ��Ϣ
                }
            }
            return id;
        }


        #endregion  ��Ա����


        #region ���ݱ����ȡ��һ���ӷ���
        public DataSet GetNextNodeByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_Category ");
            strSql.Append(" where parentid in (");
            strSql.Append("select id from tb_Category ");
            strSql.Append(" where codeNo=@codeNo) order by orderid,id");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        public DataSet GetNextNodeByCode_web(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_Category ");
            strSql.Append(" where parentid in (");
            strSql.Append("select id from tb_Category ");
            strSql.Append(" where codeNo=@codeNo) and stateid=1 order by orderid,id");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetNextNodeByID_web(int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_Category ");
            strSql.Append(" where parentid =@id and stateid=1 order by orderid,id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,8)};
            parameters[0].Value = parentID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region ���ݱ�Ż�ȡ��һ���ӷ���ID����
        public string GetNextNodeByID(string PID)
        {
            string ResStr = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from tb_Category ");
            strSql.Append(" where parentid in (" + PID + ")");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null)
            {
                DataTable dttemp = ds.Tables[0];
                foreach (DataRow dr in dttemp.Rows)
                {
                    ResStr += dr["id"] + ",";
                }
            }
            if (!string.IsNullOrEmpty(ResStr))
            {
                ResStr = ResStr.Substring(0, ResStr.Length - 1);
            }
            return ResStr;
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ���ID������( 1,2,3)���а���������
        public string GetAllChildIDByCode(string code)
        {
            string AllRes = string.Empty;
            string pid = GetIdByCodeNo(code) + "";
            if (!string.IsNullOrEmpty(pid))
            {
                AllRes = pid + ",";
            }
            while (!string.IsNullOrEmpty(pid))
            {
                pid = GetNextNodeByID(pid);
                if (!string.IsNullOrEmpty(pid))
                {
                    AllRes += pid + ",";
                }
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                AllRes = AllRes.Substring(0, AllRes.Length - 1);
            }
            return AllRes;
        }
        #endregion


        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        public DataSet GetAllChildByCode(string code)
        {
            string AllRes = string.Empty;
            string pid = GetIdByCodeNo(code) + "";
            if (!string.IsNullOrEmpty(pid))
            {
                AllRes = pid + ",";
            }
            while (!string.IsNullOrEmpty(pid))
            {
                pid = GetNextNodeByID(pid);
                if (!string.IsNullOrEmpty(pid))
                {
                    AllRes += pid + ",";
                }
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                AllRes = AllRes.Substring(0, AllRes.Length - 1);
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                return GetList(" id in(" + AllRes + ")");
            }
            return null;
        }
        #endregion

        public DataSet GetAllChildByCodeNoPar(string code, string where)
        {
            string AllRes = string.Empty;
            string pid = GetIdByCodeNo(code) + "";
            while (!string.IsNullOrEmpty(pid))
            {
                pid = GetNextNodeByID(pid);
                if (!string.IsNullOrEmpty(pid))
                {
                    AllRes += pid + ",";
                }
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                AllRes = AllRes.Substring(0, AllRes.Length - 1);
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                if (!string.IsNullOrEmpty(where))
                {
                    return GetList(" id in(" + AllRes + ") and " + where);
                }
                else
                {
                    return GetList(" id in(" + AllRes + ")");
                }
            }
            return null;
        }

        #region ���ݱ����ȡ�����ӷ��༯�����в�����������
        public DataSet GetAllChildByCodeNoPar(string code)
        {
            string AllRes = string.Empty;
            string pid = GetIdByCodeNo(code) + "";
            while (!string.IsNullOrEmpty(pid))
            {
                pid = GetNextNodeByID(pid);
                if (!string.IsNullOrEmpty(pid))
                {
                    AllRes += pid + ",";
                }
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                AllRes = AllRes.Substring(0, AllRes.Length - 1);
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                return GetList(" id in(" + AllRes + ")");
            }
            return null;
        }

        public DataSet GetAllChildByCodeNoPar(int id)
        {
            string AllRes = string.Empty;
            string pid = id + "";
            while (!string.IsNullOrEmpty(pid))
            {
                pid = GetNextNodeByID(pid);
                if (!string.IsNullOrEmpty(pid))
                {
                    AllRes += pid + ",";
                }
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                AllRes = AllRes.Substring(0, AllRes.Length - 1);
            }
            if (!string.IsNullOrEmpty(AllRes))
            {
                return GetList(" id in(" + AllRes + ")");
            }
            return null;
        }
        #endregion


        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ����ǰ����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetTopNextNodeByCode(int top, string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * from tb_Category ");
            strSql.Append(" where parentid in (");
            strSql.Append("select id from tb_Category ");
            strSql.Append(" where codeNo=@codeNo) order by orderid,id");
            SqlParameter[] parameters = {
					new SqlParameter("@codeNo", SqlDbType.VarChar,50)};
            parameters[0].Value = code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

    }
}

