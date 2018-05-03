<%@ WebHandler Language="C#" Class="ImgDelHand" %>

using System;
using System.Web;
using TFXK.BLL;

public class ImgDelHand : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 200;

        // 判断是否验证用户
        if (context.User.Identity.IsAuthenticated)
        {
            try
            {


                int id = QueryStringHelper.GetInt_POST("id");
                if (id > 0)
                {
                    Delete(id);
                    context.Response.StatusCode = 200;
                }
                else
                {
                    context.Response.StatusCode = 500;
                }
            }
            catch
            {
                context.Response.StatusCode = 500;
            }
        }
        else
        {

            context.Response.StatusCode = 500;
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public void Delete(int id)
    {

        PicturesBLL pbll = new PicturesBLL();
        try
        {
            System.Web.UI.Page xx = new System.Web.UI.Page();
            string fullpath = xx.Server.MapPath("../../uploads/" + pbll.GetModel(id).imgPath);
            System.IO.File.Delete(fullpath);
        }
        catch { }
        pbll.Delete(id);
    }

}