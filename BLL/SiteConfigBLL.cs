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
	/// ҵ���߼���SiteConfigBLL ��ժҪ˵����
	/// </summary>
	public class SiteConfigBLL
	{
		private readonly ISiteConfigDAL dal=DataAccess.CreateSiteConfigDAL();
		public SiteConfigBLL()
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
		public int  Add(TFXK.Model.SiteConfig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TFXK.Model.SiteConfig model)
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
		public TFXK.Model.SiteConfig GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TFXK.Model.SiteConfig GetModel(string code)
        {

            return dal.GetModel(code);
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
		public List<TFXK.Model.SiteConfig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TFXK.Model.SiteConfig> DataTableToList(DataTable dt)
		{
			List<TFXK.Model.SiteConfig> modelList = new List<TFXK.Model.SiteConfig>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TFXK.Model.SiteConfig model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TFXK.Model.SiteConfig();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.codeNo=dt.Rows[n]["codeNo"].ToString();
					model.title=dt.Rows[n]["title"].ToString();
					model.description=dt.Rows[n]["description"].ToString();
					model.mata=dt.Rows[n]["mata"].ToString();
					model.footer=dt.Rows[n]["footer"].ToString();
					model.des1=dt.Rows[n]["des1"].ToString();
					model.des2=dt.Rows[n]["des2"].ToString();
					model.des3=dt.Rows[n]["des3"].ToString();
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
	}
}

