using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using TFXK.DBUtility;
public partial class admin_MainPage_GetDESString : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(DESEncrypt.Encrypt("server=sql.cd134.vhostgo.com;database=innly;uid=innly;pwd=ghghfg3tfg"));
    }
}
