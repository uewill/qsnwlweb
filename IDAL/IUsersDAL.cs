using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�IUsersDAL ��ժҪ˵����
	/// </summary>
	public interface IUsersDAL
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(string uerName,string pass);
         /// <summary>
        /// �Ƿ����name
        /// </summary>
        bool Exists(string userName);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(TFXK.Model.Users model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Users model);
        /// <summary>
        ///  ��������
        /// </summary>
        void UpdatePassword(TFXK.Model.Users model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Users GetModel(int id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        TFXK.Model.Users GetModelByUserName(string username);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);

		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
