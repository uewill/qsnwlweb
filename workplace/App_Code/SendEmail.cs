using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Net;
using System.Net.Mail;

/// <summary>
///SendEmail 发送邮件类
/// </summary>
public class SendEmail
{
    public SendEmail()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static int SendRegMail(string userID, string userName, string email, string vcode)
    {
        StringBuilder EmailBody = new StringBuilder();
        EmailBody.AppendLine("<div style=\"margin: 0pt auto; width: 600px;\">");
        EmailBody.AppendLine("<table style=\"font: 13px Arial;\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"600\">");

        EmailBody.AppendLine("<tbody><tr>");
        EmailBody.AppendLine("<td>");
        EmailBody.AppendLine("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">");

        EmailBody.AppendLine("<tbody><tr>");
        EmailBody.AppendLine("<td width=\"165\"><a href=\"http://517scyts.gotoip3.com\" target=\"_blank\"><img src=\"http://517scyts.gotoip3.com/images/elogo.jpg\" border=\"0\"></a></td>");
        EmailBody.AppendLine("<td width=\"295\"></td>");
        EmailBody.AppendLine("<td width=\"190\" align=\"right\"><img src=\"http://517scyts.gotoip3.com/images/phone.jpg\" border=\"0\"><br>");
        EmailBody.AppendLine("<span style=\"font-size: 28px; color: #cc3300;\">400-0000-998</span></td>");
        EmailBody.AppendLine("</tr>");

        EmailBody.AppendLine("</tbody></table>");
        EmailBody.AppendLine("</td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("<tr>");
        EmailBody.AppendLine("<td>");
        EmailBody.AppendLine("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">");

        EmailBody.AppendLine("<tbody><tr>");
        EmailBody.AppendLine("<td width=\"180\" height=\"3\" bgcolor=\"#4E9700\"></td>");
        EmailBody.AppendLine("<td width=\"420\" bgcolor=\"#F68B33\"></td>");
        EmailBody.AppendLine("</tr>");

        EmailBody.AppendLine("</tbody></table>");
        EmailBody.AppendLine("</td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("<tr>");
        EmailBody.AppendLine("<td style=\"font: 13px Arial; color: #333; line-height: 18px;\" height=\"50\" valign=\"top\">");
        EmailBody.AppendLine("<table border=\"0\" cellspacing=\"10\" cellpadding=\"0\" width=\"100%\">");

        EmailBody.AppendLine("<tbody><tr>");
        EmailBody.AppendLine("<td style=\"font-size: 14px; color: #f60; font-weight: bold;\" align=\"center\">欢迎加入猪猪福旅游网</td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("<tr>");
        EmailBody.AppendLine("<td style=\"font-size: 13px; line-height: 18px;\">");
        EmailBody.AppendLine("<p>您好！欢迎成为猪猪福旅游网会员。</p>");
        EmailBody.AppendLine("<p>您的猪猪福会员卡号：<strong>" + userID + "</strong></p>");
        EmailBody.AppendLine("<p>您的注册邮箱为：<strong>" + email + "</strong></p>");
        EmailBody.AppendLine("<p>您可以使用<strong>会员卡号/手机号/邮箱</strong>登录猪猪福旅游网，享受我们为您带来的各类最便捷、最实惠的旅游产品预订服务。</p>");
        EmailBody.AppendLine("<p>请点击下面的链接完成邮箱验证：<br>");
        EmailBody.AppendLine("<a href=\"http://517scyts.gotoip3.com/vuser.aspx?code=" + vcode + "\" target=\"_blank\">http://www.zzfu.cn/vuser.aspx?code=" + vcode+"&ancode="+TFXK.Common.Security.EncryptPassword(DateTime.Now.ToString("yyyyMMddHHmmss"),"SHA1")+ "</a></p>");
        EmailBody.AppendLine("<p>如果该链接无法点击，请将其复制到浏览器地址栏中直接打开。</p>");
        EmailBody.AppendLine("</td>");
        EmailBody.AppendLine("</tr>");

        EmailBody.AppendLine("</tbody></table>");
        EmailBody.AppendLine("</td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("<tr>");
        EmailBody.AppendLine("<td style=\"font: 13px Arial; color: #333; line-height: 18px; padding: 10px;\" align=\"right\">猪猪福旅游网<br>");
        EmailBody.AppendLine(" " + DateTime.Now.ToString("yyyy年MM月dd日") + "</td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("<tr>");
        EmailBody.AppendLine("<td style=\"font: 13px Arial; color: #333; line-height: 18px;\" align=\"right\" valign=\"top\">&nbsp;</td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("<tr>");
        EmailBody.AppendLine("<td style=\"border-top: 1px solid #dddddd; color: #666666;\" height=\"30\" align=\"center\">Copyright © 2010-2011 猪猪福旅游网 <a style=\"color: #666666;\" href=\"http://www.zzfu.com\" target=\"_blank\">zzfu.com</a></td>");
        EmailBody.AppendLine("</tr>");
        EmailBody.AppendLine("</tbody></table>");
        EmailBody.AppendLine("</div>");

        bool flag = SendMail(email, userName, "欢迎加入猪猪福旅游网", EmailBody.ToString());
        if (flag)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private static bool SendMail(string toMail, string toName, string title, string bodyHTML)
    {
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
        /// 
        string smtpName = ConfigurationManager.AppSettings["smtpName"];
        string mailFrom = ConfigurationManager.AppSettings["mailFrom"];
        string mailFromPwd = ConfigurationManager.AppSettings["mailFromPwd"];
        string fromUserName = ConfigurationManager.AppSettings["fromUserName"];
        string mailTo = toMail;
        string toUserName = toName;
        string mailSubject = title;
        string mailBody = bodyHTML;
        string strFileName = "";
        return NetMailSend(smtpName, mailFrom, mailFromPwd, fromUserName, mailTo, toUserName, mailSubject, mailBody, strFileName);
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
    private static bool NetMailSend(string smtpName, string mailFrom, string mailFromPwd, string fromUserName, string mailTo, string toUserName, string mailSubject, string mailBody, string strFileName)
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

        //try
        //{
            client.Send(message);
            isSucceed = true;
        //}
        //catch(Exception ex)
        //{
        //    isSucceed = false;
        //}

        return isSucceed;
    }

}
