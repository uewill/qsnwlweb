using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Common;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
	/// <summary>
	/// ҵ���߼���UserOrdersBLL ��ժҪ˵����
	/// </summary>
	public class UserOrdersBLL
	{
		private readonly IUserOrdersDAL dal=DataAccess.CreateUserOrdersDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
		public UserOrdersBLL()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TFXK.Model.UserOrders model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TFXK.Model.UserOrders model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public TFXK.Model.UserOrders GetModel(int id)
		{
			
			return dal.GetModel(id);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TFXK.Model.UserOrders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TFXK.Model.UserOrders> DataTableToList(DataTable dt)
		{
			List<TFXK.Model.UserOrders> modelList = new List<TFXK.Model.UserOrders>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TFXK.Model.UserOrders model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TFXK.Model.UserOrders();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.typeID=dt.Rows[n]["typeID"].ToString();
					model.Jijie=dt.Rows[n]["Jijie"].ToString();
					model.chkOrderNum=dt.Rows[n]["chkOrderNum"].ToString();
					if(dt.Rows[n]["orderNum"].ToString()!="")
					{
						model.orderNum=int.Parse(dt.Rows[n]["orderNum"].ToString());
					}
					model.hopePrice=dt.Rows[n]["hopePrice"].ToString();
					model.proCode=dt.Rows[n]["proCode"].ToString();
					model.otherDes=dt.Rows[n]["otherDes"].ToString();
					model.filePaths=dt.Rows[n]["filePaths"].ToString();
					model.contactUserName=dt.Rows[n]["contactUserName"].ToString();
					if(dt.Rows[n]["userSex"].ToString()!="")
					{
						model.userSex=int.Parse(dt.Rows[n]["userSex"].ToString());
					}
					model.userTel=dt.Rows[n]["userTel"].ToString();
					model.userPhone=dt.Rows[n]["userPhone"].ToString();
					model.userEmail=dt.Rows[n]["userEmail"].ToString();
					model.companyName=dt.Rows[n]["companyName"].ToString();
					model.companyAddress=dt.Rows[n]["companyAddress"].ToString();
					if(dt.Rows[n]["stateID"].ToString()!="")
					{
						model.stateID=int.Parse(dt.Rows[n]["stateID"].ToString());
					}
					model.des1=dt.Rows[n]["des1"].ToString();
					model.des2=dt.Rows[n]["des2"].ToString();
					model.des3=dt.Rows[n]["des3"].ToString();
					model.des4=dt.Rows[n]["des4"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����

        #region ˽�з���
        /// <summary>
        /// �洢���̷�ҳ
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="strWhere">��ѯ����(ע��: ��Ҫ�� where)</param>
        /// <param name="strOrder">���������ֶ���</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        private DataSet GetList(string tblName, int PageSize, int PageIndex, string strWhere, string strOrder, out int rowCount)
        {
            return bll.GetList(tblName, PageSize, PageIndex, strWhere, strOrder, out rowCount);
        }
        #endregion



        public DataSet GetList(int PageSize, int PageIndex, string strWhere, out int rowCount)
        {
            return bll.GetList("tb_UserOrders", PageSize, PageIndex, strWhere, "id desc", out rowCount);
        }


	}
}

