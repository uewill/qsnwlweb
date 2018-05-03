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
using DevExpress.Web.ASPxEditors;

using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;


public partial class admin_Controls_TopControl : System.Web.UI.UserControl
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_Controls_TopControl));
    private static readonly UsersBLL bllUsers = new UsersBLL();
    string userName = string.Empty;

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                // 判断是否验证用户
                if (Context.User.Identity.IsAuthenticated)
                {
                    panlAdmin.Visible = false;
                    userName = Context.User.Identity.Name.ToString(); // 获取票证
                    //lblUserName.Text = userName;

                    Users UserModel = bllUsers.GetModelByUserName(Context.User.Identity.Name);
                    if (UserModel != null)
                    {
                        lblUserName.Text = UserModel.userName;
                        //if (UserModel.roleid == 1)
                        //{
                        //    panlAdmin.Visible = true;
                        //}
                    }


                }
                else
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
    #endregion


    #region 绑定主题下拉列表
    protected void cbSkins_DataBound(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ListEditItem item = cbSkins.Items.FindByValue(Page.Theme);
        //    if (item == null)
        //        item = cbSkins.Items.FindByValue(BasePage.DefaultThemeName);
        //    if (item != null)
        //        cbSkins.SelectedItem = item;
        //}
    }
    #endregion

    #region 更改主题时
    protected void cbSkins_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string xx = cbSkins.SelectedItem.Value.ToString();
        //Response.Redirect("~/admin/MainPage/Default.aspx?ThemeName=" + xx);

    }
    #endregion

}

