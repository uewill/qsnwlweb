using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;
using System.Collections.Generic;//�����������
namespace TFXK.OleDbDAL
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
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool ExistsCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Category");
            strSql.Append(" where codeNo=@code ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@code", OleDbType.VarChar,50)};
            parameters[0].Value = code;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@orderId", OleDbType.Integer,4),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = orderId;
            parameters[1].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@parentID", OleDbType.Integer,4),
                new OleDbParameter("@orderID", OleDbType.Integer,4)
            };
            parameters[0].Value = parentID;
            parameters[1].Value = orderID;
            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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

            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ȡ�ӷ�������
        /// </summary>
        public int GetChildNum(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from tb_Category");
            strSql.Append(" where parentID=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return int.Parse(DbHelperOleDb.GetSingle(strSql.ToString(), parameters) + "");
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TFXK.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Category(");
            strSql.Append("title,codeNo,parentID,description,orderId)");
            strSql.Append(" values (");
            strSql.Append("@title,@codeNo,@parentID,@description,@orderId)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@codeNo", OleDbType.VarChar,50),
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					new OleDbParameter("@description", OleDbType.VarChar),
					new OleDbParameter("@orderId", OleDbType.Integer,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.codeNo;
            parameters[2].Value = model.parentID;
            parameters[3].Value = model.description;
            parameters[4].Value = model.orderId;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            string sql = "select max(id) from [tb_Category]";
            try
            {
                return int.Parse(DbHelperOleDb.GetSingle(sql).ToString());
            }
            catch
            {
                return 0;
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
            strSql.Append("orderId=@orderId");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@codeNo", OleDbType.VarChar,50),
					new OleDbParameter("@parentID", OleDbType.Integer,4),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@orderId", OleDbType.Integer,4),
                new OleDbParameter("@id", OleDbType.Integer,4)
            };

            parameters[0].Value = model.title;
            parameters[1].Value = model.codeNo;
            parameters[2].Value = model.parentID;
            parameters[3].Value = model.description;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@description", OleDbType.VarChar),
                new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = content;
            parameters[1].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Category ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Category GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,codeNo,parentID,description,orderId from tb_Category ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            TFXK.Model.Category model = new TFXK.Model.Category();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
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
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Category GetModel(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,codeNo,parentID,description,orderId from tb_Category ");
            strSql.Append(" where codeNo=@code ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@code", OleDbType.VarChar,10)};
            parameters[0].Value = code;

            TFXK.Model.Category model = new TFXK.Model.Category();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
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
            strSql.Append("select id,title,codeNo,parentID,description,orderId ");
            strSql.Append(" FROM tb_Category");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by orderid asc ");
            return DbHelperOleDb.Query(strSql.ToString());
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@codeNo", OleDbType.VarChar,10)};
            parameters[0].Value = codeNo;

            int id = 0;
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
            }
            return id;
        }

        #region ���ݱ����ȡ��һ���ӷ���
        public DataSet GetNextNodeByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_Category ");
            strSql.Append(" where parentid in (");
            strSql.Append("select id from tb_Category ");
            strSql.Append(" where codeNo=@codeNo)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@codeNo", OleDbType.VarChar,10)};
            parameters[0].Value = code;
            return DbHelperOleDb.Query(strSql.ToString(), parameters);
        }

        #endregion

        #region ���ݱ�Ż�ȡ��һ���ӷ���ID����
        public string GetNextNodeByID(string PID)
        {
            string ResStr = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from tb_Category ");
            strSql.Append(" where parentid in (" + PID + ")");

            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
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
        #endregion


        #endregion  ��Ա����
    }
}

