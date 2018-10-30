using System;
using System.Data;
using System.Collections.Generic;
namespace TFXK.IDAL
{
    /// <summary>
    /// �ӿڲ�ICategoryDAL ��ժҪ˵����
    /// </summary>
    public interface ICategoryDAL
    {
        #region  ��Ա����
        ///// <summary>
        ///// �õ����ID
        ///// </summary>
        //int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int id);

        /// <summary>
        /// �����ӷ���
        /// </summary>
        bool HasChild(int id);
           /// <summary>
        /// �����ӷ���
        /// </summary>
        bool HasChildByCode(string code);
        /// <summary>
        /// ��ȡ�ӷ�������
        /// </summary>
        int GetChildNum(int id);

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool ExistsCode(string code);


        /// <summary>
        /// ��������ʱ,����ͬ����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderId">������</param>
        void UpdateOrderId(int id, int orderId);

        /// <summary>
        /// ��ȡ��һ��������һ����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderId">������</param>
        List<int> GetUpOrDownOrderID(int id, int orderid, int isUp);


        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(TFXK.Model.Category model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(TFXK.Model.Category model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// ɾ��ʱ������������
        /// </summary>
        void UpdateOrderByDel(int parentID, int orderID);

          /// <summary>
        /// ����һ������
        /// </summary>
        void UpdateDes(int id, string content);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        TFXK.Model.Category GetModel(int id);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        TFXK.Model.Category GetModel(string code);
        TFXK.Model.Category GetModelByName(string title);

        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���߱�Ż�ȡ������ı��
        /// </summary>
        /// <param name="id">���</param>
        /// <returns>dataset pid</returns>
        DataSet GetParentIdsByID(int id);

        /// <summary>
        /// ���ݱ����ȡ���
        /// </summary>
        /// <param name="codeNo">����</param>
        /// <returns>���</returns>
        int GetIdByCodeNo(string codeNo);

           /// ���ݱ����ȡ���
        /// </summary>
        /// <param name="title">����</param>
        /// <returns>���</returns>
        int GetIdByTitle(string title);
        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ���
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        DataSet GetNextNodeByCode(string code);
        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ���
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        DataSet GetNextNodeByCode_web(string code);
        DataSet GetNextNodeByID_web(int parId);

        /// <summary>
        /// ���ݱ����ȡ��һ���ӷ����ǰ����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        DataSet GetTopNextNodeByCode(int top, string code);
        

        /// <summary>
        /// ���ݱ�Ż�ȡ��һ���ӷ���ID����
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        string GetNextNodeByID(string PID);

        /// <summary>
        /// ���ݱ����ȡ�����ӷ���ID������( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetAllChildIDByCode(string code);

        
        #region ���ݱ����ȡ�����ӷ��༯�����а���������
        DataSet GetAllChildByCode(string code);
        #endregion

        #region ���ݱ����ȡ�����ӷ��༯�����в�����������
        DataSet GetAllChildByCodeNoPar(string code);
        DataSet GetAllChildByCodeNoPar(int id);
        DataSet GetAllChildByCodeNoPar(string code, string where);
 #endregion
        #endregion
    }
}
