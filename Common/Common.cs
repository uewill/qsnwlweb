/*******************************************************************************
             ��Ϣ��ʾ��                                  
             ������ҪMessageBox��ʾ����        
             ���ߣ��촺��
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
    /// ����ASP.NET����
    /// </summary>
    public class Common
    {
        public Common() { }

        /// <summary>
        /// ��ʾָ�������ַ���
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
        /// �����ַ�����ʵ����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>�ַ�����ʵ����</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }


        /// <summary>
        /// ��������ϴ��ļ�����
        /// </summary>
        public static string GetRndNumber()
        {
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            return DateTime.Now.ToShortDateString().Replace("-", "") + rand.Next().ToString().Substring(0, 5);
        }

        /// <summary>
        /// ��õ�ǰ����·��
        /// </summary>
        /// <param name="strPath">·���ַ���</param>
        /// <returns>��ǰ����·��</returns>
        public static string GetMapPath(string strPath)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        /// <summary>
        /// �ж�ָ���ַ�����ָ���ַ��������е�λ��
        /// </summary>
        /// <param name="strSearch">�ַ���</param>
        /// <param name="stringArray">�ַ�������</param>
        /// <param name="caseInsensetive">�Ƿ����ִ�Сд, trueΪ������, falseΪ����</param>
        /// <returns>�ַ�����ָ���ַ��������е�λ��, �粻�����򷵻�-1</returns>
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
        /// �ָ��ַ���������Ϊ����
        /// </summary>
        /// <param name="strContent">�ַ���</param>
        /// <param name="strSplit">�ָ��ַ����ַ���</param>
        /// <returns>�������</returns>
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
        /// ת��Ϊ��������
        /// </summary>
        public static string ToSChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        /// <summary>
        /// ת��Ϊ��������
        /// </summary>
        public static string ToTChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        }

        /// <summary>
        /// �ж����ض��ַ����ַ����ָ����ַ����У��Ƿ������һ�ַ���
        /// </summary>
        /// <param name="str">���ж��ַ���</param>
        /// <param name="stringarray">���ܰ������ж��ַ������ַ���</param>
        /// <param name="strsplit">�ָ��ַ����ַ���</param>
        /// <returns>true:������false:������</returns>
        public static bool IsCompriseStr(string str, string stringarray, string strsplit)
        {
            if (stringarray == "" || stringarray == null)
                return false;

            str = str.ToLower();
            string[] stringArray = SplitString(stringarray.ToLower(), strsplit);
            //SplintString�����ο�����4
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
        /// ɾ��ָ���ļ�
        /// </summary>
        /// <param name="filename">�ļ���</param>
        public static void DelFile(string filename)
        {
            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);
        }

        /// <summary>
        /// �ж��ļ����Ƿ�Ϊ���������ֱ����ʾ��ͼƬ�ļ���
        /// </summary>
        /// <param name="filename">�ļ���</param>
        /// <returns>�Ƿ����ֱ����ʾ</returns>

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
        /// �Ƿ�Ϊip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// дcookieֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="strValue">ֵ</param>
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
        /// дcookieֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="strValue">ֵ</param>
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
        /// ��cookieֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>cookieֵ</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }

            return "";
        }


        /// <summary>
        /// �����ʼ��ɴ�������System.Net.Mail�����ռ�
        /// </summary>
        /// <param name="smtpName">�ʼ���������ַ</param>
        /// <param name="mailFrom">�����������ַ</param>
        /// <param name="mailFromPwd">��������������</param>
        /// <param name="fromUserName">����������</param>         
        /// <param name="mailTo">�ռ��������ַ</param>
        /// <param name="toUserName">�ռ�������</param>
        /// <param name="mailSubject">�ʼ�����</param>
        /// <param name="mailBody">�ʼ�����</param> 
        /// <param name="strFileName">������</param>
        /// <returns>�ɹ�����true�����򷵻�false</returns>
        public static bool NetMailSend(string smtpName, string mailFrom, string mailFromPwd, string fromUserName, string mailTo, string toUserName, string mailSubject, string mailBody, string strFileName)
        {
            bool isSucceed = false;//�����ʼ��Ƿ�ɹ�

            //�ʼ�����ʱ��ȷ�Ϸ����ɱ���������
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
            message.Subject = mailSubject;//�ʼ�����
            message.Body = mailBody;//�ʼ�����
            message.Priority = MailPriority.High;

            //���͸���
            if (!string.IsNullOrEmpty(strFileName))
            {
                Attachment data = new Attachment(strFileName);//����
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
        /// ȥ��HTML���
        /// </summary>
        public static string ReplaceHtml(string html)
        {
            string StrNohtml = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            StrNohtml = System.Text.RegularExpressions.Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }

    }
}