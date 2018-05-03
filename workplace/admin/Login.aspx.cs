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
using TFXK.BLL;
using TFXK.Common;
using TFXK.Model;


public partial class admin_Login : System.Web.UI.Page
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_Login));
    private static readonly UsersBLL bll = new UsersBLL();

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack) {

                if (!string.IsNullOrEmpty(Request.QueryString["signOut"] + ""))
                {
                    FormsAuthentication.SignOut();  // 从浏览器删除 Cookie
                  // FormsAuthentication.RedirectToLoginPage();  //将浏览器重定向到登陆页面
                   Response.Redirect("~/admin/login.aspx",true);
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 登陆
    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {

        try
        {
            string username = this.txtUserName.Value.Trim().ToString();
            string password = this.txtPassword.Value.Trim().ToString();
            string checkCode = this.txtCheckCode.Value.Trim().ToString();
            string code = Request.Cookies["CheckCode"].Value.ToString();   //取随机码

            if (username.Equals(""))
            {
                Msg.Show("用户名不能为空!");
                return;
            }
            if (password.Equals(""))
            {
                Msg.Show("密码不能为空!");
                return;
            }
            if (checkCode.Trim().ToLower().Equals(code))
            {
                bool flg = bll.Exists(username, password);
                if (flg)
                {
                    Users model = bll.GetModelByUserName(username);
                    // 检查审核状态
                    if (model.state == 1)
                    {
                        FormsAuthentication.RedirectFromLoginPage(username, false); //经过验证后设置cookie,重定向最初请求的页面或者默认页面
                    }
                    else
                    {
                        Msg.Show("等待管理员审核中...!");
                        this.txtCheckCode.Value = "";
                    }
                }
                else
                {
                    Msg.Show("用户名或者密码错误!");
                    this.txtCheckCode.Value = "";
                }
            }
            else
            {
                Msg.Show("验证码错误!");
                this.txtCheckCode.Value = "";
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络链接错误!" + ex.Message);
        }
    }
    #endregion
}
