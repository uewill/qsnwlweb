using System;
using System.Data;
namespace TFXK.IDAL
{
	/// <summary>
	/// 接口层IPicturesDAL 的摘要说明。
	/// </summary>
	public interface IPicturesDAL
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(TFXK.Model.Pictures model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(TFXK.Model.Pictures model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);

           /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteByPath(string imgPath);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		TFXK.Model.Pictures GetModel(int id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);


        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(int oPid, int oTid, int NewPid, int NewTid);
        /// <summary>
        /// 删除一条数据
        /// </summary>
         void Delete(int pid, int tid);
          /// <summary>
        /// 获得数据列表
        /// </summary>
         DataSet GetList(int pid, int tid);
         /// <summary>
        /// 获得数据列表
        /// </summary>
         DataSet GetTopThreeList(int pid, int tid);
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
         void UpdatePid(int id, int parentid);
		#endregion  成员方法
	}
}
