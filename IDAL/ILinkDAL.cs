using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�ILinkDAL ��ժҪ˵����
	/// </summary>
	public interface ILinkDAL
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
		int Add(TFXK.Model.Link model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Link model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Link GetModel(int id);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        /// <summary>
        /// ���������õ�������
        /// </summary>
        /// <returns></returns>
        int GetCount(string strWhere);
		#endregion  ��Ա����
	}
}
