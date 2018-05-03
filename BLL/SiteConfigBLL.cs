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
	/// 业务逻辑类SiteConfigBLL 的摘要说明。
	/// </summary>
	public class SiteConfigBLL
	{
		private readonly ISiteConfigDAL dal=DataAccess.CreateSiteConfigDAL();
		public SiteConfigBLL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TFXK.Model.SiteConfig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TFXK.Model.SiteConfig model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TFXK.Model.SiteConfig GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.SiteConfig GetModel(string code)
        {

            return dal.GetModel(code);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TFXK.Model.SiteConfig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

