using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// �ӿڲ�IProductsDAL ��ժҪ˵����
	/// </summary>
	public interface IProductsDAL
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
		int Add(TFXK.Model.Products model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(TFXK.Model.Products model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		TFXK.Model.Products GetModel(int id);
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
        /// ��������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="orderid">����</param>
       void UpdateOrders(int id, int orderid, string fildName);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="tid">����ID</param>
       /// <param name="typeid">0Ϊ�Ƽ� 1Ϊ����</param>
      void Update(int id, int tid, int typeid);
          /// <summary>
        /// �õ�һ������ʵ�� id,title,codeNo��Ч
        /// </summary>
      TFXK.Model.Products GetSimpleModel(string codeNo);
	}
}
