using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFXK.Common;

/// <summary>
/// ExamAuthHelper 的摘要说明
/// </summary>
public class ExamAuthHelper
{
    private static TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
    public static TFXK.Model.TestingCenter GetAuthData(HttpContext context)
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        var exidcookie = context.Request.Cookies.Get("ExamID");
        string exidcookievalue = string.Empty;
        int examid = 0;
        if (exidcookie != null && !string.IsNullOrEmpty(exidcookie.Value))
        {
            exidcookievalue = Security.DecryptDES(exidcookie.Value, "UEMASTER");
        }
        if (exidcookie == null || !int.TryParse(exidcookievalue, out examid) || examid <= 0)
        {
            context.Response.Redirect("/Exam/Login.aspx");
            return null;
        }
        else
        {
            return testingCenterBLL.GetModel(examid);
        }
    }
    public static int GetAuthCenterID(HttpContext context) {
        var exidcookie = context.Request.Cookies.Get("ExamID");
        string exidcookievalue = string.Empty;
        int examid = 0;
        if (exidcookie != null && !string.IsNullOrEmpty(exidcookie.Value))
        {
            exidcookievalue = Security.DecryptDES(exidcookie.Value, "UEMASTER");
        }
        if (exidcookie == null || !int.TryParse(exidcookievalue, out examid) || examid <= 0)
        {
            context.Response.Redirect("/Exam/Login.aspx");
            return 0;
        }
        else
        {
            return examid;
        }
    }
}