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
using System.Text;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace TFXK.Common
{
    /// <summary>
    /// 常用ASP.NET函数
    /// </summary>
    public class Common
    {
        public Common() { }

        /// <summary>
        /// 显示指定长度字符串
        /// </summary>
        /// <returns></returns>
        public static string DisLength(string str, int len)
        {
            if (str.Length > len)
                return str.Substring(0, len) + "...";
            else
                return str;
        }

        /// <summary>
        /// 返回字符串真实长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串真实长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }


        /// <summary>
        /// 返回随机上传文件名称
        /// </summary>
        public static string GetRndNumber()
        {
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            return DateTime.Now.ToShortDateString().Replace("-", "") + rand.Next().ToString().Substring(0, 5);
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">路径字符串</param>
        /// <returns>当前绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else
                {
                    if (strSearch == stringArray[i])
                    {
                        return i;
                    }
                }

            }
            return -1;
        }

        /// <summary>
        /// 分割字符串，保存为数组
        /// </summary>
        /// <param name="strContent">字符串</param>
        /// <param name="strSplit">分隔字符或字符串</param>
        /// <returns>结果数组</returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                string[] tmp = { strContent };
                return tmp;
            }
            return Regex.Split(strContent, @strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 转换为简体中文
        /// </summary>
        public static string ToSChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        /// <summary>
        /// 转换为繁体中文
        /// </summary>
        public static string ToTChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        }

        /// <summary>
        /// 判断由特定字符或字符串分隔的字符串中，是否包含另一字符串
        /// </summary>
        /// <param name="str">被判断字符串</param>
        /// <param name="stringarray">可能包含被判断字符串的字符串</param>
        /// <param name="strsplit">分隔字符或字符串</param>
        /// <returns>true:包含，false:不包含</returns>
        public static bool IsCompriseStr(string str, string stringarray, string strsplit)
        {
            if (stringarray == "" || stringarray == null)
                return false;

            str = str.ToLower();
            string[] stringArray = SplitString(stringarray.ToLower(), strsplit);
            //SplintString方法参考方法4
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (str.IndexOf(stringArray[i]) > -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="filename">文件名</param>
        public static void DelFile(string filename)
        {
            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);
        }

        /// <summary>
        /// 判断文件名是否为浏览器可以直接显示的图片文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>

        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
            {
                return false;
            }
            string extname = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return (extname == "jpg" || extname == "jpeg" || extname == "png" || extname == "bmp" || extname == "gif");
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }

            return "";
        }


        /// <summary>
        /// 发送邮件可带附件，System.Net.Mail命名空间
        /// </summary>
        /// <param name="smtpName">邮件服务器地址</param>
        /// <param name="mailFrom">发件人邮箱地址</param>
        /// <param name="mailFromPwd">发件人邮箱密码</param>
        /// <param name="fromUserName">发件人名字</param>         
        /// <param name="mailTo">收件人邮箱地址</param>
        /// <param name="toUserName">收件人名字</param>
        /// <param name="mailSubject">邮件主题</param>
        /// <param name="mailBody">邮件内容</param> 
        /// <param name="strFileName">附件名</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool NetMailSend(string smtpName, string mailFrom, string mailFromPwd, string fromUserName, string mailTo, string toUserName, string mailSubject, string mailBody, string strFileName)
        {
            bool isSucceed = false;//发送邮件是否成功

            //邮件发送时请确认服务的杀毒软件因素
            SmtpClient client;
            client = new SmtpClient(smtpName);
            client.Timeout = 60000;
            //client.UseDefaultCredentials = false;

            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(mailFrom, mailFromPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.From = new MailAddress(mailFrom, fromUserName, System.Text.Encoding.UTF8);
            message.To.Add(new MailAddress(mailTo, toUserName, System.Text.Encoding.UTF8));
            message.IsBodyHtml = true;
            message.Subject = mailSubject;//邮件主题
            message.Body = mailBody;//邮件内容
            message.Priority = MailPriority.High;

            //发送附件
            if (!string.IsNullOrEmpty(strFileName))
            {
                Attachment data = new Attachment(strFileName);//附件
                message.Attachments.Add(data);
            }

            try
            {
                client.Send(message);
                isSucceed = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                isSucceed = false;
            }

            return isSucceed;
        }

        /// <summary>
        /// 去除HTML标记
        /// </summary>
        public static string ReplaceHtml(string html)
        {
            string StrNohtml = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            StrNohtml = System.Text.RegularExpressions.Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }

    }
}