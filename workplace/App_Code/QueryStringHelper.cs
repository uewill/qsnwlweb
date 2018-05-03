using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using TFXK.BLL;
using TFXK.Common;

/// <summary>
///QueryStringHelper 参数获取类
///
/// </summary>
public class QueryStringHelper
{
    public QueryStringHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 获取整数值
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns>返回获取的值  -1则为无该参数或参数错误</returns>
    public static int GetInt(string strKey)
    {
        string ResStr = HttpContext.Current.Request.QueryString[strKey] + "";
        if (!string.IsNullOrEmpty(ResStr))
        {
            try
            {
                return int.Parse(ResStr);
            }
            catch { }
        }
        return -1;
    }

    /// <summary>
    /// 获取整数值
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns>返回获取的值  null则为无该参数或参数错误</returns>
    public static string GetString(string strKey)
    {
        string ResStr = HttpContext.Current.Request.QueryString[strKey] + "";
        if (!string.IsNullOrEmpty(ResStr))
        {
            return StringUtil.HtmlEncode(ResStr);
        }
        return ResStr;
    }

    /// <summary>
    /// 获取整数值
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns>返回获取的值  -1则为无该参数或参数错误</returns>
    public static int GetInt_POST(string strKey)
    {
        string ResStr = HttpContext.Current.Request.Form[strKey] + "";
        if (!string.IsNullOrEmpty(ResStr))
        {
            try
            {
                return int.Parse(ResStr);
            }
            catch { }
        }
        return -1;
    }

    /// <summary>
    /// 获取整数值
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns>返回获取的值  null则为无该参数或参数错误</returns>
    public static string GetString_POST(string strKey)
    {
        string ResStr = HttpContext.Current.Request.Form[strKey] + "";
        if (!string.IsNullOrEmpty(ResStr))
        {
            return StringUtil.HtmlEncode(ResStr);
        }
        return ResStr;
    }

}
