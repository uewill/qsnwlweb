/*******************************************************************************
             信息提示类                                  
             本类主要MessageBox提示功能        
             作者：徐春建
             2009-5-21                 
 * *****************************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFXK.Common
{
    /// <summary>
    /// 对话框处理类
    /// </summary>
    public class Msg
    {
        public Msg() { }

        /// <summary>
        /// 获取当前页面
        /// </summary>
        /// <returns></returns>
        private static Page getCurrent()
        {
            Page page= (Page)HttpContext.Current.Handler;
            return page;
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="msg">信息</param>
        public static void Show(string msg)
        {
            msg =msg.Replace("'"," ");
            msg = msg.Replace(";", " ");
            msg = msg.Replace('"', ' ');
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>alert('" + msg + "');</script>", false);
        }

        /// <summary>
        /// 显示YESNO对话框
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="msg">信息</param>
        public static void Confirm(WebControl control, string msg)
        {
            msg = msg.Replace("'", " ");
            msg = msg.Replace(";", " ");
            msg = msg.Replace('"', ' ');
            control.Attributes.Add("onclick", "return confirm('" + msg + "?')");
        }


        /// <summary>
        /// 显示对还框并跳转
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转地址</param>
        public static void ShowAndRedirect(string msg, string url)
        {
            msg = msg.Replace("'", " ");
            msg = msg.Replace(";", " ");
            msg = msg.Replace('"', ' ');
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>alert('" + msg + "');location.href='" + url + "';</script>", false);
        }

        /// <summary>
        /// 自定义对还框操作
        /// </summary>
        /// <param name="opeastring">
        /// 自定义内容
        /// 例:alert('你好');
        /// </param>
        public static void Custom(string opeastring)
        {
            opeastring = StrHelper.checkStr(opeastring);
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>" + opeastring + "</script>", false);
        }
    }
}
