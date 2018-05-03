using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using TFXK.IDAL;
using TFXK.DBUtility;//�����������
namespace TFXK.OleDbDAL
{
    /// <summary>
    /// ���ݷ�����PermissionDAL��
    /// </summary>
    public class PermissionDAL : IPermissionDAL
    {
        public PermissionDAL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Permission");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TFXK.Model.Permission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Permission(");
            strSql.Append("roleID,moduleID)");
            strSql.Append(" values (");
            strSql.Append("@roleID,@moduleID)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@roleID", OleDbType.Integer,4),
					new OleDbParameter("@moduleID", OleDbType.Integer,4)};
            parameters[0].Value = model.roleID;
            parameters[1].Value = model.moduleID;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);

            string sql = "select max(id) from [tb_Permission]";
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
        public void Update(TFXK.Model.Permission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Permission set ");
            strSql.Append("roleID=@roleID,");
            strSql.Append("moduleID=@moduleID");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					
					new OleDbParameter("@roleID", OleDbType.Integer,4),
					new OleDbParameter("@moduleID", OleDbType.Integer,4),new OleDbParameter("@id", OleDbType.Integer,4)};

            parameters[0].Value = model.roleID;
            parameters[1].Value = model.moduleID;
            parameters[2].Value = model.id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Permission ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Permission GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,roleID,moduleID from tb_Permission ");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            TFXK.Model.Permission model = new TFXK.Model.Permission();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["roleID"].ToString() != "")
                {
                    model.roleID = int.Parse(ds.Tables[0].Rows[0]["roleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["moduleID"].ToString() != "")
                {
                    model.moduleID = int.Parse(ds.Tables[0].Rows[0]["moduleID"].ToString());
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
            strSql.Append("select id,roleID,moduleID ");
            strSql.Append(" FROM tb_Permission ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "tb_Permission";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����
    }
}

