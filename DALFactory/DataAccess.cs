using System;
using System.Reflection;
using System.Configuration;
namespace TFXK.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion




        /// <summary>
        /// 创建CategoryDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.ICategoryDAL CreateCategoryDAL()
        {

            string ClassNamespace = AssemblyPath + ".CategoryDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ICategoryDAL)objType;
        }


        /// <summary>
        /// 创建TourCategoryDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.ITourCategoryDAL CreateTourCategoryDAL()
        {

            string ClassNamespace = AssemblyPath + ".TourCategoryDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITourCategoryDAL)objType;
        }


        /// <summary>
        /// 创建UsersDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IUsersDAL CreateUsersDAL()
        {

            string ClassNamespace = AssemblyPath + ".UsersDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IUsersDAL)objType;
        }


        /// <summary>
        /// 创建DataPageListDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IDataPageListDAL CreateDataPageListDAL()
        {

            string ClassNamespace = AssemblyPath + ".DataPageListDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IDataPageListDAL)objType;
        }
        /// <summary>
        /// 创建LinkDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.ILinkDAL CreateLinkDAL()
        {

            string ClassNamespace = AssemblyPath + ".LinkDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ILinkDAL)objType;
        }





        /// <summary>
        /// 创建Ads数据层接口
        /// </summary>
        public static TFXK.IDAL.IAdsDAL CreateAdsDAL()
        {

            string ClassNamespace = AssemblyPath + ".AdsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IAdsDAL)objType;
        }

        /// <summary>

        /// <summary>
        /// 创建ArticlesDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IArticlesDAL CreateArticlesDAL()
        {

            string ClassNamespace = AssemblyPath + ".ArticlesDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IArticlesDAL)objType;
        }


    

        /// <summary>
        /// 创建CustomersDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.ICustomersDAL CreateCustomersDAL()
        {

            string ClassNamespace = AssemblyPath + ".CustomersDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ICustomersDAL)objType;
        }
        /// <summary>
        /// 创建PicturesDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IPicturesDAL CreatePicturesDAL()
        {

            string ClassNamespace = AssemblyPath + ".PicturesDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IPicturesDAL)objType;
        }



        /// <summary>
        /// 创建OrderProListsDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IOrderProListsDAL CreateOrderProListsDAL()
        {

            string ClassNamespace = AssemblyPath + ".OrderProListsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IOrderProListsDAL)objType;
        }



        /// <summary>
        /// 创建SiteConfigDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.ISiteConfigDAL CreateSiteConfigDAL()
        {

            string ClassNamespace = AssemblyPath + ".SiteConfigDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ISiteConfigDAL)objType;
        }


        /// <summary>
        /// 创建ProExtCategoryDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IProExtCategoryDAL CreateProExtCategoryDAL()
        {

            string ClassNamespace = AssemblyPath + ".ProExtCategoryDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IProExtCategoryDAL)objType;
        }


        /// <summary>
        /// 创建ProductsDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IProductsDAL CreateProductsDAL()
        {

            string ClassNamespace = AssemblyPath + ".ProductsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IProductsDAL)objType;
        }

        /// <summary>
        /// 创建MessagesDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IMessagesDAL CreateMessagesDAL()
        {

            string ClassNamespace = AssemblyPath + ".MessagesDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IMessagesDAL)objType;
        }


        /// <summary>
        /// 创建UserOrdersDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IUserOrdersDAL CreateUserOrdersDAL()
        {

            string ClassNamespace = AssemblyPath + ".UserOrdersDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IUserOrdersDAL)objType;
        }   
        /// <summary>
        /// 创建UserOrdersDAL数据层接口
        /// </summary>
        public static TFXK.IDAL.IUserJiamenDAL CreateUserJiamenDAL()
        {

            string ClassNamespace = AssemblyPath + ".UserJiamenDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IUserJiamenDAL)objType;
        }


        /// <summary>
        /// 创建TestingCenter数据层接口。
        /// </summary>
        public static TFXK.IDAL.ITestingCenter CreateTestingCenter()
        {

            string ClassNamespace = AssemblyPath + ".TestingCenter";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingCenter)objType;
        }


        /// <summary>
        /// 创建TestingPlan数据层接口。
        /// </summary>
        public static TFXK.IDAL.ITestingPlan CreateTestingPlan()
        {

            string ClassNamespace = AssemblyPath + ".TestingPlan";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPlan)objType;
        }


        /// <summary>
        /// 创建TestingStudent数据层接口。
        /// </summary>
        public static TFXK.IDAL.ITestingStudent CreateTestingStudent()
        {

            string ClassNamespace = AssemblyPath + ".TestingStudent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingStudent)objType;
        }
        /// <summary>
        /// 创建TestingPerson数据层接口。
        /// </summary>
        public static TFXK.IDAL.ITestingPerson CreateTestingPerson()
        {

            string ClassNamespace = AssemblyPath + ".TestingPerson";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPerson)objType;
        }


        /// <summary>
        /// 创建TestingPersonExam数据层接口。
        /// </summary>
        public static TFXK.IDAL.ITestingPersonExam CreateTestingPersonExam()
        {

            string ClassNamespace = AssemblyPath + ".TestingPersonExam";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPersonExam)objType;
        }

        /// <summary>
        /// 创建TestingPersonPlan数据层接口。
        /// </summary>
        public static TFXK.IDAL.ITestingPersonPlan CreateTestingPersonPlan()
        {

            string ClassNamespace = AssemblyPath + ".TestingPersonPlan";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPersonPlan)objType;
        }
    }
}