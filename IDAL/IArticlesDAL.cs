using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�INewsDAL ��ժҪ˵����
	/// </summary>
    public interface IArticlesDAL
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(TFXK.Model.Articles model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Articles model);
          /// <summary>
        /// ���µ����
        /// </summary>
        /// <param name="id">���</param>
        void UpdateClick(int id);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Articles GetModel(int id);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
        /// <summary>
        /// ���ݸ�������ȡ������������
        /// </summary>
        /// <param name="codeNo">�������</param>
        /// <returns>���ݼ�</returns>
        DataSet GetTopListByCodeNo(int Top, string codeNo, string orderId);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		#endregion  ��Ա����

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderid">����</param>
        void UpdateOrders(int id, int orderid, string fildName);
	}
}
