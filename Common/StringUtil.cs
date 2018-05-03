
using System;
using System.Drawing;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Web.Security;

namespace TFXK.Common
{
    public class StringUtil
    {
        private static string passWord;	//加密字符串

        /// <summary>
        /// 判断输入是否数字
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <returns></returns>
        static public bool VldInt(string num)
        {
            #region
            try
            {
                Convert.ToInt32(num);
                return true;
            }
            catch { return false; }
            #endregion
        }


        /// <summary>
        /// 修改特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        static public string CheckStr(string str)
        {
            #region
            return str.Replace("<br />\r\n", "\r\n").Replace("&", "&amp;").Replace("'", "&apos;").Replace(@"""", "&quot;").Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(" ", "&nbsp;").Replace(" where ", " wh&#101;re ").
                Replace(" select ", " sel&#101;ct ").Replace(" insert ", " ins&#101;rt ").Replace(" create ", " cr&#101;ate ").Replace(" drop ", " dro&#112 ").
                Replace(" alter ", " alt&#101;r ").Replace(" delete ", " del&#101;te ").Replace(" update ", " up&#100;ate ").Replace(" or ", " o&#114; ").Replace("\"", @"&#34;").
                Replace("\r\n", "<br />\r\n");
            #endregion
        }

        /// <summary>
        /// 恢复特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        static public string UnCheckStr(string str)
        {
            #region
            return str.Replace("&amp;", "&").Replace("&apos;", "'").Replace("&quot;", @"""").Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ").Replace(" wh&#101;re ", " where ").
                Replace(" sel&#101;ct ", " select ").Replace(" ins&#101;rt ", " insert ").Replace(" cr&#101;ate ", " create ").Replace(" dro&#112 ", " drop ").
                Replace(" alt&#101;r ", " alter ").Replace(" del&#101;te ", " delete ").Replace(" up&#100;ate ", " update ").Replace(" o&#114; ", " or ").Replace(@"&#34;", "\"");
            #endregion
        }



        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取字符串的长度</param>
        /// <returns></returns>
        static public string GetSubString(string str, int num)
        {
            #region
            return (str.Length > num) ? str.Substring(0, num) : str;
            #endregion
        }

        /// <summary>
        /// 过滤输入信息
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        public static string InputText(string text, int maxLength)
        {
            #region
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
            #endregion
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        static public string GenerateCheckCode()
        {
            #region
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }

            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));

            return checkCode;
            #endregion
        }

        /// <summary>
        /// 获取汉字第一个拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string getSpells(string input)
        {
            #region
            int len = input.Length;
            string reVal = "";
            for (int i = 0; i < len; i++)
            {
                reVal += getSpell(input.Substring(i, 1));
            }
            return reVal;
            #endregion
        }

        /// <summary>
        /// 汉字编码转换,解决IE地址栏中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string Strencode(string input)
        {
            #region
            return System.Web.HttpUtility.UrlEncode(InputText(input, 100));
            #endregion
        }

        static public string getSpell(string cn)
        {
            #region
            byte[] arrCN = Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
            #endregion
        }


        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="BJstr"></param>
        /// <returns></returns>
        static public string GetQuanJiao(string BJstr)
        {
            #region
            char[] c = BJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 0)
                    {
                        b[0] = (byte)(b[0] - 32);
                        b[1] = 255;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }

            string strNew = new string(c);
            return strNew;

            #endregion
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="QJstr"></param>
        /// <returns></returns>
        static public string GetBanJiao(string QJstr)
        {
            #region
            char[] c = QJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            string strNew = new string(c);
            return strNew;
            #endregion
        }

        #region 加密的类型
        /// <summary>
        /// 加密的类型
        /// </summary>
        public enum PasswordType
        {
            SHA1,
            MD5
        }
        #endregion


        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="PasswordString">要加密的字符串</param>
        /// <param name="PasswordFormat">要加密的类别</param>
        /// <returns></returns>
        static public string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            #region
            switch (PasswordFormat)
            {
                case "SHA1":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
                        break;
                    }
                case "MD5":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        break;
                    }
                default:
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        break;
                    }
            }
            return passWord;
            #endregion
        }
        static public string FormartDateTime(object obj)
        {
            return ((DateTime)obj).ToString("yyyy-MM-dd");//'yyyy-mm-dd hh24:mi
        }
        static public string FormartDateTimeTwo(object obj)
        {
            return ((DateTime)obj).ToString("yyyy-mm-dd hh:m");//'
        }
        /// <summary>
        /// 说明:过滤危险字符
        /// 返回值：处理后的这符串。
        /// 参数：	str原字符串。
        /// 创建日期：2006-02-22
        /// 创建人：张耀庭
        /// </summary>
        static public string HtmlEncode(string str)
        {
            //str = str.Replace("&", "&amp;");
            //str = str.Replace("<", "&lt;");
            //str = str.Replace(">", "&gt");
            //str = str.Replace("'", "''");
            //str = str.Replace("*", "");
            //str = str.Replace("\n", "<br/>");
            //str = str.Replace("\r\n", "<br/>");
            //str = str.Replace("?","");
            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("update", "");
            str = str.Replace("delete", "");
            str = str.Replace("create", "");
            str = str.Replace("drop", "");
            str = str.Replace("delcare", "");
            if (str.Trim().ToString() == "") { str = ""; }
            return str.Trim();
        }
        /// <summary>
        /// 去除HTML代码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string StripHtmlXmlTags(string content)
        {
            return Regex.Replace(content, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public static string StripAllTags(string stringToStrip)
        {

            stringToStrip = Regex.Replace(stringToStrip, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "<br(?:\\s*)/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = StripHtmlXmlTags(stringToStrip);
            return stringToStrip;

        }
    }
}
