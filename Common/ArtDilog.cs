
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace TFXK.Common
{
    public class ArtDilog
    {
        /// <summary>
        /// 获取当前页面
        /// </summary>
        /// <returns></returns>
        private static Page getCurrent()
        {
            Page page = (Page)HttpContext.Current.Handler;
            return page;
        }
        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alert(string message)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "'});");
            #endregion
        }

        /// <summary>
        /// 弹出框
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="time">消失时间</param>
        public static void Alert(string message, int time)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',time:" + time + "});");
            #endregion
        }

        /// <summary>
        /// 弹出框
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="icon">图标 succeed、error、confirm</param>
        /// <param name="time">消失时间</param>
        public static void Alert(string message, string icon, int time)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',icon:'" + icon + "',time:" + time + "});");
            #endregion
        }


        /// <summary>
        /// 弹出框
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="icon">图标 succeed、error、confirm</param>
        /// <param name="time">消失时间</param>
        public static void Alert(string message, string icon, int time, bool islock)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',icon:'" + icon + "',time:" + time + ",lock:'" + islock + "', yesFn: function(){}});");
            #endregion
        }

        /// <summary>
        /// 弹出框 并且关闭父窗口
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="icon">图标 succeed、error、confirm</param>
        /// <param name="time">消失时间</param>
        public static void AlertAndCloseParent(string message, string icon, int time, bool islock)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',icon:'" + icon + "',time:" + time + ",lock:'" + islock + "', yesFn: function(){},closeFn:function(){art.dialog.close();}});");
            #endregion
        }


        /// <summary>
        /// 弹出框
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="icon">图标 succeed、error、confirm</param>
        /// <param name="time">消失时间</param>
        public static void AlertAndRedirect(string message, string icon, int time, bool islock, string url)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',icon:'" + icon + "',effect:false,time:" + time + ",lock:'" + islock + "', yesFn: function(){},closeFn:function(){art.dialog.parent.location='" + url + "';}});");
            #endregion
        }

        /// <summary>
        /// 弹出消息框并且刷新当前页面
        /// </summary>
        /// <param name="message">消息内容</param>
        public static void AlertAndRefresh(string message, int time)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',icon:'succeed',time:" + time + ",closeFn:function(){art.dialog.close();art.dialog.parent.location.reload();}});");
            #endregion


        }

        /// <summary>
        /// 弹出消息框并且刷新父页面
        /// </summary>
        /// <param name="message">消息内容</param>
        public static void AlertAndRefresh(string message, int time, string artID)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',icon:'succeed',time:" + time + ",closeFn:function(){window.top.art.dialog({id: '" + artID + "'}).close();art.dialog.parent.location.reload();}});");
            #endregion
        }


        /// <summary>
        /// 弹出消息框并且刷新父页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="time"></param>
        /// <param name="artID"></param>
        /// <param name="icon">图标 succeed、error、confirm</param>
        public static void AlertAndRefresh(string message, int time, string artID, string icon)
        {
            #region
            SysRunJS("art.dialog({content:'" + message + "',id:'" + artID + "',icon:'" + icon + "',time:" + time + ",closeFn:function(){window.top.art.dialog({id: '" + artID + "'}).close();art.dialog.parent.location.reload();}});");
            #endregion
        }

        /// <summary>
        /// 打开一个新对话框
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public static void OpenDialog(string url, string title)
        {
            #region
            SysRunJS("$.dialog.open('" + url + "',{title:'" + title + "'});");
            #endregion
        }

        /// <summary>
        /// 打开一个新对话框
        /// </summary>
        /// <param name="id">对话框ID</param>
        /// <param name="url">路径</param>
        /// <param name="title">标题</param>
        public static void OpenDialog(string id, string url, string title)
        {
            #region
            SysRunJS("$.dialog.open('" + url + "',{title:'" + title + "',id:" + id + "});");
            #endregion
        }

        /// <summary>
        /// 打开一个模式对话框
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public static void ShowModalDialogWindow(string url, string title)
        {
            #region
            SysRunJS("$.dialog.open('" + url + "',{title:'" + title + "',lock:true});");
            #endregion
        }

        /// <summary>
        /// 弹出一个模式窗口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public static void ShowModalDialogWindow(string id, string url, string title)
        {
            #region
            SysRunJS("$.dialog.open('" + url + "',{title:'" + title + "',lock:true,id:" + id + "});");
            #endregion
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public static void CloseArt()
        {
            #region
            SysRunJS("$.dialog.close();");
            #endregion
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public static void CloseArt(string artID)
        {
            #region
            SysRunJS("$.dialog({id: '" + artID + "'}).close();");
            #endregion
        }
        public static void SysRunJS(string scrString)
        {
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>" + scrString + "</script>", false);
        }

        /// <summary>
        /// 设置当前导航的样式 Now
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void SetNavNowCSS(string navID)
        {
            #region
            SysRunJS("$('#" + navID + "').addClass('now');");
            #endregion
        }

        /// <summary>
        /// 设置当前导航的样式 Now
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void SetNavNowCSS(string navID, string ClassName)
        {
            #region
            SysRunJS("$('#" + navID + "').addClass('" + ClassName + "');");
            #endregion
        }
    }
}
