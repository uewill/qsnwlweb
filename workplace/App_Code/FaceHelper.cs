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
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
///FaceHelper 表情辅助类
///
/// </summary>
public class FaceHelper
{
    public FaceHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 获取处理后的字符串
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns>返回获取的值  -1则为无该参数或参数错误</returns>
    public static string GetHTML(string strContent)
    {
        StringBuilder builder = new StringBuilder(strContent);
       // Regex r = new Regex("[Face:" + B + "]");
        return "";


    }

    #region  普通替换字符串

    /// <summary>
    ///  普通替换字符串

    /// </summary>
    /// <param name="src">源字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="replacement">替换字符串</param>
    /// <returns>已修改的字符串</returns>
    //public static string Replace(string src, string pattern, string replacement)
    //{
    //    return Replace(src, pattern, replacement, RegexOptions.None);
    //}

    #endregion

    #region 正则替换字符串

    /// <summary>
    ///  正则替换字符串
    /// </summary>
    /// <param name="src">要修改的字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="replacement">替换字符串</param>
    /// <param name="options">匹配模式</param>
    /// <returns>已修改的字符串</returns>
    //public static string Replace(string src, string pattern, string replacement, RegexOptions options)
    //{
    //    Regex regex = new Regex(pattern, options | RegexOptions.Compiled);
    //    return regex.Replace(src, replacement);
    //}
    #endregion


}
