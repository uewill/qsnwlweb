using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�ICustomersDAL ��ժҪ˵����
	/// </summary>
	public interface ICustomersDAL
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(TFXK.Model.Customers model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Customers model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Customers GetModel(int id);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       TFXK.Model.Customers GetModelByPhone(string phone);
         /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="isToday">�Ƿ���� 0 �� 1 ��</param>
        /// <returns></returns>
       int GetUserCount(int isToday);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       string GetLoginNameByID(int uid);
	}
}
