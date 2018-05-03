using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�IPicturesDAL ��ժҪ˵����
	/// </summary>
	public interface IPicturesDAL
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(TFXK.Model.Pictures model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Pictures model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);

           /// <summary>
        /// ɾ��һ������
        /// </summary>
        void DeleteByPath(string imgPath);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Pictures GetModel(int id);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);


        
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(int oPid, int oTid, int NewPid, int NewTid);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
         void Delete(int pid, int tid);
          /// <summary>
        /// ��������б�
        /// </summary>
         DataSet GetList(int pid, int tid);
         /// <summary>
        /// ��������б�
        /// </summary>
         DataSet GetTopThreeList(int pid, int tid);
        
        /// <summary>
        /// ����һ������
        /// </summary>
         void UpdatePid(int id, int parentid);
		#endregion  ��Ա����
	}
}
