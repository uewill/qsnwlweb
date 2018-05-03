<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;

public class UploadHandler : IHttpHandler
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UploadHandler));
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

        //上传至文件夹（uploads）
        string toFolder = context.Request.QueryString["toFolder"] + "";
        if (!string.IsNullOrEmpty(toFolder))
        {
            toFolder = toFolder + "/";
        }
        //是否生成缩略图
        string isCreate = context.Request.QueryString["isCreate"] + "";
        //缩略图宽度
        string width = context.Request.QueryString["width"] + "";
        //缩略图高度
        string height = context.Request.QueryString["height"] + "";

        if (file != null)
        {
            try
            {
                System.Web.UI.Page pageDoc = new System.Web.UI.Page();
                string saveDir = "../../uploads/" + toFolder; //文件保存文件夹
                string serverFile = pageDoc.Server.MapPath(saveDir);
                string imgExt = file.FileName.Substring(file.FileName.IndexOf('.'));
                string saveName = DateTime.Now.ToString("yyyyMMddhhmmss") + imgExt;
                file.SaveAs(serverFile + saveName);
                try
                {
                    string oldfullpath = pageDoc.Server.MapPath("../../uploads/" + toFolder + oldPath);
                    System.IO.File.Delete(oldfullpath);

                }
                catch { }

                try
                {
                    CrateThumPic(serverFile + saveName, 158, 115);
                }
                catch
                {
                }

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

    #region 生成缩略图
    public void CrateThumPic(string fromPath, int width, int height)
    {
        TFXK.Common.Thumbnail.CreateThumbnail(width, height, fromPath, fromPath.Replace("uploads", "uploads_thum"));
        TFXK.Common.Thumbnail.CreateThumbnail(135, 99, fromPath, fromPath.Replace("uploads", "uploads_thum2"));
        TFXK.Common.Thumbnail.CreateThumbnail(78, 57, fromPath, fromPath.Replace("uploads", "uploads_thum3"));
    }
    #endregion

}