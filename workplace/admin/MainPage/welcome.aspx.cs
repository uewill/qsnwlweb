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

public partial class admin_MainPage_welcome : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /// <summary>
        /// 取应用程序路径
        /// </summary>
        try
        {
            lbIp.Text = Request.ServerVariables["LOCAl_ADDR"];
            lbDomain.Text = Request.ServerVariables["SERVER_NAME"].ToString();
            lbPort.Text = Request.ServerVariables["Server_Port"].ToString();
            lbIISVer.Text = Request.ServerVariables["Server_SoftWare"].ToString();
            lbPhPath.Text = Request.PhysicalApplicationPath;
            lbOperat.Text = Environment.OSVersion.ToString();
        }
        catch
        {

        }
    }
}
