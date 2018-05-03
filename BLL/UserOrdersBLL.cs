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
	/// 业务逻辑类UserOrdersBLL 的摘要说明。
	/// </summary>
	public class UserOrdersBLL
	{
		private readonly IUserOrdersDAL dal=DataAccess.CreateUserOrdersDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
		public UserOrdersBLL()
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
		public int  Add(TFXK.Model.UserOrders model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TFXK.Model.UserOrders model)
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
		public TFXK.Model.UserOrders GetModel(int id)
		{
			
			return dal.GetModel(id);
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
		public List<TFXK.Model.UserOrders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

        #region 私有方法
        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="strWhere">查询条件(注意: 不要加 where)</param>
        /// <param name="strOrder">排序索引字段名</param>
        /// <param name="rowCount">输出值,总数</param>
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

