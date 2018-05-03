using System;
using System.Data;
using System.Collections.Generic;
namespace TFXK.IDAL
{
    /// <summary>
    /// 接口层ITourCategoryDAL 的摘要说明。
    /// </summary>
    public interface ITourCategoryDAL
    {
        #region  成员方法
        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int id);

        /// <summary>
        /// 含有子分类
        /// </summary>
        bool HasChild(int id);
           /// <summary>
        /// 含有子分类
        /// </summary>
        bool HasChildByCode(string code);
        /// <summary>
        /// 获取子分类数量
        /// </summary>
        int GetChildNum(int id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsCode(string code);


        /// <summary>
        /// 上移下移时,更新同级的排序编号
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="orderId">排序编号</param>
        void UpdateOrderId(int id, int orderId);

        /// <summary>
        /// 获取上一个或者下一个的排序编号
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="orderId">排序编号</param>
        List<int> GetUpOrDownOrderID(int id, int orderid, int isUp);


        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(TFXK.Model.TourCategory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TFXK.Model.TourCategory model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// 删除时更新排序数据
        /// </summary>
        void UpdateOrderByDel(int parentID, int orderID);

          /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateDes(int id, string content);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TFXK.Model.TourCategory GetModel(int id);
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       TFXK.Model.TourCategory GetModelByTitle(string title,string where);

          /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TFXK.Model.TourCategory GetModel(string code);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 更具编号获取父分类的编号
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>dataset pid</returns>
        DataSet GetParentIdsByID(int id);

        /// <summary>
        /// 根据编码获取编号
        /// </summary>
        /// <param name="codeNo">编码</param>
        /// <returns>编号</returns>
        int GetIdByCodeNo(string codeNo);


        /// <summary>
        /// 根据编码获取下一级子分类
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        DataSet GetNextNodeByCode(string code);
        DataSet GetNextNodeByCode_web(string code, string where);
        DataSet GetNextNodeByCode_web(int top,string code, string where);

         /// <summary>
        /// 根据编码获取下一级子分类的前几条
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        DataSet GetTopNextNodeByCode(int top, string code);

        /// <summary>
        /// 根据编号获取下一级子分类ID集合
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        string GetNextNodeByID(string PID);

        /// <summary>
        /// 根据编码获取所有子分类ID集合如( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetAllChildIDByCode(string code);
        string GetAllChildIDByCode(string code, string where);
        DataSet GetAllChildByCode_web(int top, string code, string where);

        /// <summary>
        /// 根据编码获取所有子分类ID集合如( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetAllChildIDByCode_web(string code);
        
        #region 根据编码获取所有子分类集合其中包含父分类
        DataSet GetAllChildByCode(string code);
        #endregion

        #region 根据编码获取所有子分类集合其中包含父分类
        DataSet GetAllChildByCode_web(string code);
        #endregion

        #region 根据编码获取所有子分类集合其中包含父分类
        DataSet GetAllChildByCode_web(string code,string where);
        #endregion


          #region 根据编码获取所有子分类集合其中不包含父分类
        DataSet GetAllChildByCodeNoPar(string code);
 #endregion
        #endregion
    }
}
