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
using TFXK.Common;

public partial class admin_Codeimg : System.Web.UI.Page
{
    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        VerifyCode v = new VerifyCode();
        string code = v.CreateVerifyCode();             //取随机码
        v.CreateImageOnPage(code, this.Context);        // 输出图片
        // 使用Cookies取验证码的值
        Response.Cookies.Add(new HttpCookie("CheckCode", code.ToLower()));
    }
    #endregion
}
