<%@ WebHandler Language="C#" Class="UploadAdsHandler" %>

using System;
using System.Web;

public class UploadAdsHandler : IHttpHandler
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UploadAdsHandler));
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        UpLoadImages(context);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    #region 图片上传
    private void UpLoadImages(HttpContext context)
    {
        HttpPostedFile file = context.Request.Files["FileData"];
        string oldPath = context.Request.QueryString["imgPaths"] + "";



        if (file != null)
        {
            try
            {
                System.Web.UI.Page pageDoc = new System.Web.UI.Page();
                string saveDir = "../../uploads_thum/"; //文件保存文件夹
                string serverFile = pageDoc.Server.MapPath(saveDir);
                string imgExt = file.FileName.Substring(file.FileName.IndexOf('.'));
                string saveName = DateTime.Now.ToString("yyyyMMddhhmmss") + imgExt;
                file.SaveAs(serverFile + saveName);
                try
                {
                    string oldfullpath = pageDoc.Server.MapPath("../../uploads_thum/" + oldPath);
                    System.IO.File.Delete(oldfullpath);

                }
                catch { }
                context.Response.StatusCode = 200;
                context.Response.Write(saveName);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("0");
            }

        }
    }
    #endregion

}