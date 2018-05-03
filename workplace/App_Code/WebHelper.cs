using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///WebHelper 的摘要说明
/// </summary>
public class WebHelper
{
    public WebHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 根据名称获取uploads下的图片文件
    /// </summary>
    /// <param name="imgName"></param>
    /// <returns></returns>
    public static string GetImg(object imgName)
    {
        if (!string.IsNullOrEmpty(imgName + ""))
        {
            return "uploads/" + imgName;
        }
        else
        {
            return "images/nopic.jpg";
        }
    }
}
