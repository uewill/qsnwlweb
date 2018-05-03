using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
    /// <summary>
    /// ҵ���߼���CategoryBLL ��ժҪ˵����
    /// </summary>
    public class TourCategoryBLL
    {
        private readonly ITourCategoryDAL dal = DataAccess.CreateTourCategoryDAL();
        public TourCategoryBLL()
        { }
        #region  ��Ա����


        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool ExistsCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return dal.ExistsCode(code);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �����ӷ���
        /// </summary>
        public bool HasChild(int id)
        {
            return dal.HasChild(id);
        }


        /// <summary>
        /// �����ӷ���
        /// </summary>
        public bool HasChildByCode(string code)
        {
            return dal.HasChildByCode(code);
        }

        /// <summary>
        /// ��ȡ�ӷ�������
        /// </summary>
        public int GetChildNum(int id)
        {
            return dal.GetChildNum(id);
        }

        /// <summary>
        /// ��������ʱ,����ͬ����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderId">������</param>
        public void UpdateOrderId(int id, int orderId)
        {
            dal.UpdateOrderId(id, orderId);
        }

        /// <summary>
        /// ��ȡ��һ��������һ����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderId">������</param>
        public List<int> GetUpOrDownOrderID(int id, int orderid, int isUp)
        {
            return dal.GetUpOrDownOrderID(id, orderid, isUp);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TFXK.Model.TourCategory model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.TourCategory model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// ɾ��ʱ������������
        /// </summary>
        public void UpdateOrderByDel(int parentID, int orderID)
        {

            dal.UpdateOrderByDel(parentID, orderID);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public void UpdateDes(int id, string content)
        {
            dal.UpdateDes(id, content);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.TourCategory GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ�� 1������ 2Ϊ������ 3���� 4ʡ������ 5��������
        /// </summary>
        public TFXK.Model.TourCategory GetModelByTitle(string title, int type)
        {
            string pids = "";
            if (type == 1)
            {
                pids = GetAllChildIDByCode("cjly");
            }
            else if (type == 2)
            {
                pids = GetAllChildIDByCode("zyx");
            }
            else if (type == 3)
            {
                pids = GetAllChildIDByCode("yl");
            }
            else if (type == 4)
            {
                pids = GetAllChildIDByCode("snly");//ʡ������
            }
            else if (type == 5)
            {
                pids = GetAllChildIDByCode("gnly");//��������
            }
            return dal.GetModelByTitle(title, "parentid in(" + pids + ")");
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.TourCategory GetModel(string code)
        {
            return dal.GetModel(code);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.TourCategory> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.TourCategory> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.TourCategory> modelList = new List<TFXK.Model.TourCategory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.TourCategory model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.TourCategory();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.codeNo = dt.Rows[n]["codeNo"].ToString();
                    if (dt.Rows[n]["parentID"].ToString() != "")
                    {
                        model.parentID = int.Parse(dt.Rows[n]["parentID"].ToString());
                    }
                    model.description = dt.Rows[n]["description"].ToString();
                    if (dt.Rows[n]["orderId"].ToString() != "")
                    {
                        model.orderId = int.Parse(dt.Rows[n]["orderId"].ToString());
                    }
                    model.imgPath = dt.Rows[n]["imgPath"].ToString();
                    if (dt.Rows[n]["stateID"].ToString() != "")
                    {
                        model.stateID = int.Parse(dt.Rows[n]["stateID"].ToString());
                    }
                    if (dt.Rows[n]["typeID"].ToString() != "")
                    {
                        model.typeID = int.Parse(dt.Rows[n]["typeID"].ToString());
                    }
                    model.outLink = dt.Rows[n]["outLink"].ToString();
                    model.simpleDes = dt.Rows[n]["simpleDes"].ToString();
                    model.otherDes1 = dt.Rows[n]["otherDes1"].ToString();
                    model.otherDes2 = dt.Rows[n]["otherDes2"].ToString();
                    model.gtLink = dt.Rows[n]["gtLink"].ToString();
                    model.ylLink = dt.Rows[n]["ylLink"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ���߱�Ż�ȡ������ı��
        /// </summary>
        /// <param name="id">���</param>
        /// <returns>dataset pid</returns>
        public DataSet GetParentIdsByID(int id)
        {
            return dal.GetParentIdsByID(id);
        }


        /// <summary>
        /// ���ݱ����ȡ���
        /// </summary>
        /// <param name="codeNo">����</param>
        /// <returns>���</returns>
        public int GetIdByCodeNo(string codeNo)
        {
            return dal.GetIdByCodeNo(codeNo);
        }


        #region ���ݱ����ȡ��һ���ӷ���
        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ���
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetNextNodeByCode(string code)
        {
            return dal.GetNextNodeByCode(code);
        }
        public DataSet GetNextNodeByCode_web(string code, string where)
        {

            return dal.GetNextNodeByCode_web(code, where);
        }

        public DataSet GetNextNodeByCode_web(int top, string code, string where)
        {

            return dal.GetNextNodeByCode_web(top, code, where);
        }
        #endregion



        #region ���ݱ�Ż�ȡ��һ���ӷ���ID����
        /// <summary>
        ///  ���ݱ�Ż�ȡ��һ���ӷ���ID����
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public string GetNextNodeByID(string PID)
        {
            return dal.GetNextNodeByID(PID);
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ���ID������( 1,2,3)���а���������
        /// <summary>
        /// ���ݱ����ȡ�����ӷ���ID������( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetAllChildIDByCode(string code)
        {
            return dal.GetAllChildIDByCode(code);
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ���ID������( 1,2,3)���а���������
        /// <summary>
        /// ���ݱ����ȡ�����ӷ���ID������( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetAllChildIDByCode(string code, string where)
        {
            return dal.GetAllChildIDByCode(code, where);
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ���ID������( 1,2,3)���а���������
        /// <summary>
        /// ���ݱ����ȡ�����ӷ���ID������( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetAllChildIDByCode_web(string code)
        {
            return dal.GetAllChildIDByCode_web(code);
        }
        #endregion


        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        public DataSet GetAllChildByCode(string code)
        {
            return dal.GetAllChildByCode(code);
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        public DataSet GetAllChildByCode_web(string code)
        {
            return dal.GetAllChildByCode_web(code);
        }
        #endregion


        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        public DataSet GetAllChildByCode_web(string code, string where)
        {
            return dal.GetAllChildByCode_web(code, where);
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        public DataSet GetAllChildByCode_web(int top,string code, string where)
        {
            return dal.GetAllChildByCode_web(top,code, where);
        }
        #endregion


        #region ���ݱ����ȡ�����ӷ��༯�����в�����������
        public DataSet GetAllChildByCodeNoPar(string code)
        {
            return dal.GetAllChildByCodeNoPar(code);
        }
        #endregion

        #region ���ݱ����ȡ�¼��ӷ��༯��Ϊ���򷵻ظ�����
        public DataSet GetNextChildIsNullReturnPar_web(string code)
        {
            DataSet ds = dal.GetNextNodeByCode_web(code, "");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = dal.GetList("codeNo='" + code + "'");
            };
            return ds;
        }
        #endregion


        #region ���ݱ����ȡ�����ӷ��༯����Ϊ�� �򷵻� ������
        public DataSet GetListIsNullReturnPar(string code)
        {
            DataSet ds = dal.GetAllChildByCodeNoPar(code);
            if (ds == null || ds.Tables[0] == null && ds.Tables[0].Rows.Count == 0)
            {
                ds = dal.GetAllChildByCode(code);
            };
            return ds;
        }
        #endregion


        /// <summary>
        /// �ж��Ƿ�����һ�� ���з��ص�һ������  ���޷���Null
        /// </summary>
        public TourCategory HaveChild(string code)
        {
            DataSet ds = dal.GetNextNodeByCode(code);
            try
            {
                return DataTableToList(ds.Tables[0])[0];
            }
            catch
            {
                return null;
            }
        }


        #region ���ݱ����ȡ��һ���ӷ����ǰ����
        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ����ǰ����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetTopNextNodeByCode(int top, string code)
        {
            return dal.GetTopNextNodeByCode(top, code);
        }

        #endregion
        #endregion  ��Ա����

        /// <summary>
        /// ��֤�Ƿ�Ϊ����
        /// </summary>
        public bool isYouLun(string code)
        {
            bool flag = false;
            DataSet ds = GetAllChildByCode("yl");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["codeNo"].ToString().Equals(code))
                    {
                        flag = true;
                        break;
                    }
                }
            };
            return flag;
        }
    }
}

