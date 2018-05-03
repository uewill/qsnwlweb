using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�IOrderProListsDAL ��ժҪ˵����
	/// </summary>
	public interface IOrderProListsDAL
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
		int Add(TFXK.Model.OrderProLists model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.OrderProLists model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
           /// <summary>
        /// ɾ��һ������
        /// </summary>
        void DeleteByOID(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.OrderProLists GetModel(int id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        TFXK.Model.OrderProLists GetModel(int pid,int oid);
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
	}
}
