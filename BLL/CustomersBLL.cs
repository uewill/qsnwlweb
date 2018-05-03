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
	/// 业务逻辑类CustomersBLL 的摘要说明。
	/// </summary>
	public class CustomersBLL
	{
		private readonly ICustomersDAL dal=DataAccess.CreateCustomersDAL();
        private readonly DataPageListBLL bll = new DataPageListBLL();
		public CustomersBLL()
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
		public int  Add(TFXK.Model.Customers model)
		{
            model.loginPass = Security.EncryptPassword(model.loginPass,"MD5");
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TFXK.Model.Customers model)
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
		public TFXK.Model.Customers GetModel(int id)
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
        /// 姓名搜索
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="name">姓名</param>
        /// <param name="rowCount">输出值,总数</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int PageSize, int PageIndex, string name, out int rowCount)
        {
            name = StringUtil.CheckStr(name);
            DataSet ds = bll.GetList("[tb_customers]", PageSize, PageIndex, " loginName like '%" + name + "%' ", "id desc", out rowCount);
            return ds;
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="rowCount">返回数</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, out int rowCount)
        {
            DataSet ds = bll.GetList("[tb_customers]", PageSize, PageIndex, "", "id desc", out rowCount);
            return ds;
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TFXK.Model.Customers> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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


        #region 根据电话查找是否注册会员

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Customers GetModelByPhone(string phone)
        {
            return dal.GetModelByPhone(phone);
        }
        #endregion

        /// <summary>
        /// 查询订单数量
        /// </summary>
        /// <param name="isToday">是否今日 0 否 1 是</param>
        /// <returns></returns>
        public int GetUserCount(int isToday) {
            return dal.GetUserCount(isToday);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetLoginNameByID(int uid) {
            return dal.GetLoginNameByID(uid);
        }
	}
}

