<%@ WebHandler Language="C#" Class="CheckIsRady" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class CheckIsRady : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 200;
        DoHtml(context);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    /// <summary>
    /// 传入URL返回网页的html代码
    /// </summary>
    /// <param name="Url">URL</param>
    /// <returns></returns>
    public void DoHtml(HttpContext context)
    {
        string Url = "Http://www.zzfu.cn/Default.aspx";
        string errorMsg = "";
        string reshtml = "";
        StreamWriter sw = null;
        try
        {
            System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse wResp = wReq.GetResponse();
            Stream respStream = wResp.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8"));
            reshtml= reader.ReadToEnd();

        }
        catch (System.Exception ex)
        {
            errorMsg = ex.Message;
        }


        string htmlfilename = context.Server.MapPath("~/index.html");
        
        // 写文件
        try
        {
            sw = new StreamWriter(htmlfilename, false, System.Text.Encoding.GetEncoding("utf-8"));
            sw.Write(reshtml);
            sw.Flush();
        }
        catch (Exception ex)
        {
            errorMsg += ex.Message;
            context.Response.StatusCode = 200;

        }
        finally
        {
            sw.Close();
        }
        if (string.IsNullOrEmpty(errorMsg))
        {
            errorMsg = "首页提速成功！";
        }
        context.Response.Write(errorMsg);
        context.Response.StatusCode = 200;
    }

}