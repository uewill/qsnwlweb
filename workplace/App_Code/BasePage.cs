using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public const string DefaultThemeName = "Glass";
    public BasePage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //  

    }

    /* Page PreInit */
    protected void Page_PreInit(object sender, EventArgs e)
    {
        string themeName = DefaultThemeName;
        try
        {
            if (Page.Request.QueryString["ThemeName"] != null)
            {
                themeName = Page.Request.QueryString["ThemeName"].ToString();
                HttpCookie cookie = new HttpCookie("ThemeName", themeName);
                cookie.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else if (Page.Request.Cookies["ThemeName"] != null)
            {
                themeName = HttpUtility.UrlDecode(Page.Request.Cookies["ThemeName"].Value);
            }
        }
        catch
        { }
        finally
        {
           
            this.Page.Theme = themeName;
        }
    }

}
