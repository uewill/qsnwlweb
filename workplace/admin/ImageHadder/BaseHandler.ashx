<%@ WebHandler Language="C#" Class="BaseHandler" %>

using System;
using System.Web;

/// <summary>
/// 验证是否登录
/// </summary>
public class BaseHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        ChekIsLogin(context);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public void ChekIsLogin(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            
        }
        else {
            context.Response.Redirect("../login.aspx", true);
        }
    
    }

}