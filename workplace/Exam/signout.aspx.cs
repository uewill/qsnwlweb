using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_signout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var cookie = new HttpCookie("ExamID");
        cookie.Expires = DateTime.Now.AddHours(-1);
        Response.Cookies.Add(cookie);
        Response.Redirect("Default.aspx");
    }
}