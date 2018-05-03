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
    public class CategoryBLL
    {
        private readonly ICategoryDAL dal = DataAccess.CreateCategoryDAL();
        public CategoryBLL()
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
        public int Add(TFXK.Model.Category model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(TFXK.Model.Category model)
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
        public TFXK.Model.Category GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Category GetModel(string code)
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
        public List<TFXK.Model.Category> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TFXK.Model.Category> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Category> modelList = new List<TFXK.Model.Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Category model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Category();
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
        /// <summary>
        /// ���ݱ����ȡ��� ǩ֤��Ŀ��
        /// </summary>
        /// <param name="title">����</param>
        /// <returns>���</returns>
        public int GetIdByTitle(string title)
        {
            return dal.GetIdByTitle(title);
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

        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ���
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetNextNodeByCode_web(string code)
        {
            return dal.GetNextNodeByCode_web(code);
        }
        public DataSet GetNextNodeByID_web(int parId)
        {
            return dal.GetNextNodeByID_web(parId);
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


        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        public DataSet GetAllChildByCode(string code)
        {
            return dal.GetAllChildByCode(code);
        }
        #endregion


        #region ���ݱ����ȡ�����ӷ��༯�����в�����������
        public DataSet GetAllChildByCodeNoPar(string code)
        {
            return dal.GetAllChildByCodeNoPar(code);
        }
        public DataSet GetAllChildByCodeNoPar(int id)
        {
            return dal.GetAllChildByCodeNoPar(id);
        }
        #endregion

        #region ���ݱ����ȡ�����ӷ��༯�����в�����������
        public DataSet GetAllChildByCodeNoPar(string code, string where)
        {
            return dal.GetAllChildByCodeNoPar(code, where);
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
        public Category HaveChild(string code)
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
    }
}

