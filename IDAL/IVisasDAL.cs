using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�IVisasDAL ��ժҪ˵����
	/// </summary>
	public interface IVisasDAL
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
		int Add(TFXK.Model.Visas model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Visas model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Visas GetModel(int id);
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
        TFXK.Model.Visas GetModelByCID(int id);
	}
}
