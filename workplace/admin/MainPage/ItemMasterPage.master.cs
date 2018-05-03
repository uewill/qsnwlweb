using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;

public partial class admin_MainPage_ItemMasterPage : System.Web.UI.MasterPage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_MainPage_ItemMasterPage));
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
    }
    private void CheckLogin()
    {
        try
        {
            if (!Page.IsPostBack)
            {
                // 判断是否验证用户
                if (!Context.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();  //将浏览器重定向到登陆页面
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }

}
