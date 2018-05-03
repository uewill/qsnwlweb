using System;
using System.Data;
using System.Collections.Generic;
using TFXK.Model;
using TFXK.DALFactory;
using TFXK.IDAL;
namespace TFXK.BLL
{
    /// <summary>
    /// 业务逻辑类CategoryBLL 的摘要说明。
    /// </summary>
    public class CategoryBLL
    {
        private readonly ICategoryDAL dal = DataAccess.CreateCategoryDAL();
        public CategoryBLL()
        { }
        #region  成员方法


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return dal.ExistsCode(code);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 含有子分类
        /// </summary>
        public bool HasChild(int id)
        {
            return dal.HasChild(id);
        }


        /// <summary>
        /// 含有子分类
        /// </summary>
        public bool HasChildByCode(string code)
        {
            return dal.HasChildByCode(code);
        }

        /// <summary>
        /// 获取子分类数量
        /// </summary>
        public int GetChildNum(int id)
        {
            return dal.GetChildNum(id);
        }

        /// <summary>
        /// 上移下移时,更新同级的排序编号
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="orderId">排序编号</param>
        public void UpdateOrderId(int id, int orderId)
        {
            dal.UpdateOrderId(id, orderId);
        }

        /// <summary>
        /// 获取上一个或者下一个的排序编号
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="orderId">排序编号</param>
        public List<int> GetUpOrDownOrderID(int id, int orderid, int isUp)
        {
            return dal.GetUpOrDownOrderID(id, orderid, isUp);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TFXK.Model.Category model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TFXK.Model.Category model)
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
        /// 删除时更新排序数据
        /// </summary>
        public void UpdateOrderByDel(int parentID, int orderID)
        {

            dal.UpdateOrderByDel(parentID, orderID);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateDes(int id, string content)
        {
            dal.UpdateDes(id, content);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Category GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TFXK.Model.Category GetModel(string code)
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
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.Category> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TFXK.Model.Category> DataTableToList(DataTable dt)
        {
            List<TFXK.Model.Category> modelList = new List<TFXK.Model.Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TFXK.Model.Category model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TFXK.Model.Category();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.codeNo = dt.Rows[n]["codeNo"].ToString();
                    if (dt.Rows[n]["parentID"].ToString() != "")
                    {
                        model.parentID = int.Parse(dt.Rows[n]["parentID"].ToString());
                    }
                    model.description = dt.Rows[n]["description"].ToString();
                    if (dt.Rows[n]["orderId"].ToString() != "")
                    {
                        model.orderId = int.Parse(dt.Rows[n]["orderId"].ToString());
                    }
                    model.imgPath = dt.Rows[n]["imgPath"].ToString();
                    if (dt.Rows[n]["stateID"].ToString() != "")
                    {
                        model.stateID = int.Parse(dt.Rows[n]["stateID"].ToString());
                    }
                    if (dt.Rows[n]["typeID"].ToString() != "")
                    {
                        model.typeID = int.Parse(dt.Rows[n]["typeID"].ToString());
                    }
                    model.outLink = dt.Rows[n]["outLink"].ToString();
                    model.simpleDes = dt.Rows[n]["simpleDes"].ToString();
                    model.otherDes1 = dt.Rows[n]["otherDes1"].ToString();
                    model.otherDes2 = dt.Rows[n]["otherDes2"].ToString();
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
        /// 更具编号获取父分类的编号
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>dataset pid</returns>
        public DataSet GetParentIdsByID(int id)
        {
            return dal.GetParentIdsByID(id);
        }


        /// <summary>
        /// 根据编码获取编号
        /// </summary>
        /// <param name="codeNo">编码</param>
        /// <returns>编号</returns>
        public int GetIdByCodeNo(string codeNo)
        {
            return dal.GetIdByCodeNo(codeNo);
        }
        /// <summary>
        /// 根据标题获取编号 签证栏目下
        /// </summary>
        /// <param name="title">标题</param>
        /// <returns>编号</returns>
        public int GetIdByTitle(string title)
        {
            return dal.GetIdByTitle(title);
        }

        #region 根据编码获取下一级子分类
        /// <summary>
        /// 根据编码获取下一级子分类
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetNextNodeByCode(string code)
        {
            return dal.GetNextNodeByCode(code);
        }

        /// <summary>
        /// 根据编码获取下一级子分类
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetNextNodeByCode_web(string code)
        {
            return dal.GetNextNodeByCode_web(code);
        }
        public DataSet GetNextNodeByID_web(int parId)
        {
            return dal.GetNextNodeByID_web(parId);
        }
        
        #endregion

        #region 根据编号获取下一级子分类ID集合
        /// <summary>
        ///  根据编号获取下一级子分类ID集合
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public string GetNextNodeByID(string PID)
        {
            return dal.GetNextNodeByID(PID);
        }
        #endregion

        #region 根据编码获取所有子分类ID集合如( 1,2,3)其中包含父分类
        /// <summary>
        /// 根据编码获取所有子分类ID集合如( 1,2,3)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetAllChildIDByCode(string code)
        {
            return dal.GetAllChildIDByCode(code);
        }
        #endregion


        #region 根据编码获取所有子分类集合其中包含父分类
        public DataSet GetAllChildByCode(string code)
        {
            return dal.GetAllChildByCode(code);
        }
        #endregion


        #region 根据编码获取所有子分类集合其中不包含父分类
        public DataSet GetAllChildByCodeNoPar(string code)
        {
            return dal.GetAllChildByCodeNoPar(code);
        }
        public DataSet GetAllChildByCodeNoPar(int id)
        {
            return dal.GetAllChildByCodeNoPar(id);
        }
        #endregion

        #region 根据编码获取所有子分类集合其中不包含父分类
        public DataSet GetAllChildByCodeNoPar(string code, string where)
        {
            return dal.GetAllChildByCodeNoPar(code, where);
        }
        #endregion


        #region 根据编码获取所有子分类集合若为空 则返回 父分类
        public DataSet GetListIsNullReturnPar(string code)
        {
            DataSet ds = dal.GetAllChildByCodeNoPar(code);
            if (ds == null || ds.Tables[0] == null && ds.Tables[0].Rows.Count == 0)
            {
                ds = dal.GetAllChildByCode(code);
            };
            return ds;
        }
        #endregion


        /// <summary>
        /// 判断是否有下一级 若有返回第一个子类  若无返回Null
        /// </summary>
        public Category HaveChild(string code)
        {
            DataSet ds = dal.GetNextNodeByCode(code);
            try
            {
                return DataTableToList(ds.Tables[0])[0];
            }
            catch
            {
                return null;
            }
        }


        #region 根据编码获取下一级子分类的前几条
        /// <summary>
        /// 根据编码获取下一级子分类的前几条
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetTopNextNodeByCode(int top, string code)
        {
            return dal.GetTopNextNodeByCode(top, code);
        }

        #endregion
        #endregion  成员方法
    }
}

