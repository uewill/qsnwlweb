<%@ WebHandler Language="C#" Class="DeleteByID" %>

using System;
using System.Web;
using TFXK.BLL;
using TFXK.Common;
public class DeleteByID : IHttpHandler
{
    DataPageListBLL bllDelete = new DataPageListBLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (context.User.Identity.IsAuthenticated)
        {
            string ids = context.Request.QueryString["ids"].ToString();
            string tabName = context.Request.QueryString["tabName"].ToString();
            ids = StringUtil.HtmlEncode(ids);
            tabName = StringUtil.HtmlEncode(tabName);
            DoDelete(context, tabName, ids);
        }
        else
        {
            context.Response.Redirect("../login.aspx", true);
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public void DoDelete(HttpContext context, string tableName, string ids)
    {
        try
        {
            int rowCount = bllDelete.DeleteByIDS(tableName, ids);
            context.Response.StatusCode = 200;
            context.Response.Write(rowCount);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.Write(ex);
        }
    }

}