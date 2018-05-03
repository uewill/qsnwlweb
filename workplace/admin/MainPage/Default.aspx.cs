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
using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;

public partial class admin_MainPage_Default : BasePage
{

    private static readonly UsersBLL bll = new UsersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckUserRole();
        }

    }
    public void CheckUserRole()
    {
        string userName = string.Empty;
        // 判断是否验证用户
        if (Context.User.Identity.IsAuthenticated)
        {
            userName = Context.User.Identity.Name.ToString(); // 获取票证
            Users Model = bll.GetModelByUserName(userName);
            if (Model != null)
            {
             //  Response.Redirect("Default.aspx", false);
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();  //将浏览器重定向到登陆页面
            }

        }
        else
        {
            FormsAuthentication.RedirectToLoginPage();  //将浏览器重定向到登陆页面
        }
    }
}
