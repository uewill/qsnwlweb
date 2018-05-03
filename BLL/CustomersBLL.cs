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
	/// ҵ���߼���CustomersBLL ��ժҪ˵����
	/// </summary>
	public class CustomersBLL
	{
		private readonly ICustomersDAL dal=DataAccess.CreateCustomersDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
		public CustomersBLL()
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
		public int  Add(TFXK.Model.Customers model)
		{
            model.loginPass = Security.EncryptPassword(model.loginPass,"MD5");
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TFXK.Model.Customers model)
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
		public TFXK.Model.Customers GetModel(int id)
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
        /// ��������
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">��ǰҳ</param>
        /// <param name="name">����</param>
        /// <param name="rowCount">���ֵ,����</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string name, out int rowCount)
        {
            name = StringUtil.CheckStr(name);
            DataSet ds = bll.GetList("[tb_customers]", PageSize, PageIndex, " loginName like '%" + name + "%' ", "id desc", out rowCount);
            return ds;
        }


        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="rowCount">������</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, out int rowCount)
        {
            DataSet ds = bll.GetList("[tb_customers]", PageSize, PageIndex, "", "id desc", out rowCount);
            return ds;
        }


		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TFXK.Model.Customers> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TFXK.Model.Customers> DataTableToList(DataTable dt)
		{
			List<TFXK.Model.Customers> modelList = new List<TFXK.Model.Customers>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TFXK.Model.Customers model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TFXK.Model.Customers();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.loginName=dt.Rows[n]["loginName"].ToString();
					model.loginPass=dt.Rows[n]["loginPass"].ToString();
					model.email=dt.Rows[n]["email"].ToString();
					model.phone=dt.Rows[n]["phone"].ToString();
					if(dt.Rows[n]["regDate"].ToString()!="")
					{
						model.regDate=DateTime.Parse(dt.Rows[n]["regDate"].ToString());
					}
					model.trueName=dt.Rows[n]["trueName"].ToString();
					if(dt.Rows[n]["userSex"].ToString()!="")
					{
						model.userSex=int.Parse(dt.Rows[n]["userSex"].ToString());
					}
					model.tel=dt.Rows[n]["tel"].ToString();
					model.address=dt.Rows[n]["address"].ToString();
					model.cardID=dt.Rows[n]["cardID"].ToString();
					model.birsday=dt.Rows[n]["birsday"].ToString();
					if(dt.Rows[n]["stateID"].ToString()!="")
					{
						model.stateID=int.Parse(dt.Rows[n]["stateID"].ToString());
					}
					if(dt.Rows[n]["orderEmail"].ToString()!="")
					{
						model.orderEmail=int.Parse(dt.Rows[n]["orderEmail"].ToString());
					}
					model.validateEmail=dt.Rows[n]["validateEmail"].ToString();
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


        #region ���ݵ绰�����Ƿ�ע���Ա

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.Customers GetModelByPhone(string phone)
        {
            return dal.GetModelByPhone(phone);
        }
        #endregion

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="isToday">�Ƿ���� 0 �� 1 ��</param>
        /// <returns></returns>
        public int GetUserCount(int isToday) {
            return dal.GetUserCount(isToday);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public string GetLoginNameByID(int uid) {
            return dal.GetLoginNameByID(uid);
        }
	}
}

