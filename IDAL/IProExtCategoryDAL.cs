using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�IProExtCategoryDAL ��ժҪ˵����
	/// </summary>
	public interface IProExtCategoryDAL
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
		int Add(TFXK.Model.ProExtCategory model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.ProExtCategory model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void DeleteByPid(int id);

        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetListByPid(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.ProExtCategory GetModel(int id);
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
