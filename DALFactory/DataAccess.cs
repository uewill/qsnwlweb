using System;
using System.Reflection;
using System.Configuration;
namespace TFXK.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL��
    /// ��������ﴴ�����󱨴�����web.config���Ƿ��޸���<add key="DAL" value="Maticsoft.SQLServerDAL" />��
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //��ʹ�û���
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// ��¼������־
                return null;
            }

        }
        //ʹ�û���
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// д�뻺��
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// ��¼������־
                }
            }
            return objType;
        }
        #endregion




        /// <summary>
        /// ����CategoryDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.ICategoryDAL CreateCategoryDAL()
        {

            string ClassNamespace = AssemblyPath + ".CategoryDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ICategoryDAL)objType;
        }


        /// <summary>
        /// ����TourCategoryDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.ITourCategoryDAL CreateTourCategoryDAL()
        {

            string ClassNamespace = AssemblyPath + ".TourCategoryDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITourCategoryDAL)objType;
        }


        /// <summary>
        /// ����UsersDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IUsersDAL CreateUsersDAL()
        {

            string ClassNamespace = AssemblyPath + ".UsersDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IUsersDAL)objType;
        }


        /// <summary>
        /// ����DataPageListDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IDataPageListDAL CreateDataPageListDAL()
        {

            string ClassNamespace = AssemblyPath + ".DataPageListDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IDataPageListDAL)objType;
        }
        /// <summary>
        /// ����LinkDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.ILinkDAL CreateLinkDAL()
        {

            string ClassNamespace = AssemblyPath + ".LinkDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ILinkDAL)objType;
        }





        /// <summary>
        /// ����Ads���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IAdsDAL CreateAdsDAL()
        {

            string ClassNamespace = AssemblyPath + ".AdsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IAdsDAL)objType;
        }

        /// <summary>

        /// <summary>
        /// ����ArticlesDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IArticlesDAL CreateArticlesDAL()
        {

            string ClassNamespace = AssemblyPath + ".ArticlesDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IArticlesDAL)objType;
        }


    

        /// <summary>
        /// ����CustomersDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.ICustomersDAL CreateCustomersDAL()
        {

            string ClassNamespace = AssemblyPath + ".CustomersDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ICustomersDAL)objType;
        }
        /// <summary>
        /// ����PicturesDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IPicturesDAL CreatePicturesDAL()
        {

            string ClassNamespace = AssemblyPath + ".PicturesDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IPicturesDAL)objType;
        }



        /// <summary>
        /// ����OrderProListsDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IOrderProListsDAL CreateOrderProListsDAL()
        {

            string ClassNamespace = AssemblyPath + ".OrderProListsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IOrderProListsDAL)objType;
        }



        /// <summary>
        /// ����SiteConfigDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.ISiteConfigDAL CreateSiteConfigDAL()
        {

            string ClassNamespace = AssemblyPath + ".SiteConfigDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ISiteConfigDAL)objType;
        }


        /// <summary>
        /// ����ProExtCategoryDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IProExtCategoryDAL CreateProExtCategoryDAL()
        {

            string ClassNamespace = AssemblyPath + ".ProExtCategoryDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IProExtCategoryDAL)objType;
        }


        /// <summary>
        /// ����ProductsDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IProductsDAL CreateProductsDAL()
        {

            string ClassNamespace = AssemblyPath + ".ProductsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IProductsDAL)objType;
        }

        /// <summary>
        /// ����MessagesDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IMessagesDAL CreateMessagesDAL()
        {

            string ClassNamespace = AssemblyPath + ".MessagesDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IMessagesDAL)objType;
        }


        /// <summary>
        /// ����UserOrdersDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IUserOrdersDAL CreateUserOrdersDAL()
        {

            string ClassNamespace = AssemblyPath + ".UserOrdersDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IUserOrdersDAL)objType;
        }   
        /// <summary>
        /// ����UserOrdersDAL���ݲ�ӿ�
        /// </summary>
        public static TFXK.IDAL.IUserJiamenDAL CreateUserJiamenDAL()
        {

            string ClassNamespace = AssemblyPath + ".UserJiamenDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.IUserJiamenDAL)objType;
        }


        /// <summary>
        /// ����TestingCenter���ݲ�ӿڡ�
        /// </summary>
        public static TFXK.IDAL.ITestingCenter CreateTestingCenter()
        {

            string ClassNamespace = AssemblyPath + ".TestingCenter";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingCenter)objType;
        }


        /// <summary>
        /// ����TestingPlan���ݲ�ӿڡ�
        /// </summary>
        public static TFXK.IDAL.ITestingPlan CreateTestingPlan()
        {

            string ClassNamespace = AssemblyPath + ".TestingPlan";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPlan)objType;
        }


        /// <summary>
        /// ����TestingStudent���ݲ�ӿڡ�
        /// </summary>
        public static TFXK.IDAL.ITestingStudent CreateTestingStudent()
        {

            string ClassNamespace = AssemblyPath + ".TestingStudent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingStudent)objType;
        }
        /// <summary>
        /// ����TestingPerson���ݲ�ӿڡ�
        /// </summary>
        public static TFXK.IDAL.ITestingPerson CreateTestingPerson()
        {

            string ClassNamespace = AssemblyPath + ".TestingPerson";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPerson)objType;
        }


        /// <summary>
        /// ����TestingPersonExam���ݲ�ӿڡ�
        /// </summary>
        public static TFXK.IDAL.ITestingPersonExam CreateTestingPersonExam()
        {

            string ClassNamespace = AssemblyPath + ".TestingPersonExam";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPersonExam)objType;
        }

        /// <summary>
        /// ����TestingPersonPlan���ݲ�ӿڡ�
        /// </summary>
        public static TFXK.IDAL.ITestingPersonPlan CreateTestingPersonPlan()
        {

            string ClassNamespace = AssemblyPath + ".TestingPersonPlan";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (TFXK.IDAL.ITestingPersonPlan)objType;
        }
    }
}