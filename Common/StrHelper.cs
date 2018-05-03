
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TFXK.Common
{
    public class StrHelper
    {

        public static string CutString(string inputString, int len)
        {

            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            // 如果截过则加上半个省略号
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += "…";

            return tempString;
        }
        //生成随机数
        public static string RndNum(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });
            string VNum = "";
            int temp = -1;

            Random rand = new Random();

            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(35);
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
        //字符过滤
        public static string ReturnCNStringfromAnyTypeString(string AnyTypeString, string strReg)
        {
            Regex r = new Regex(strReg);
            string str = null;
            char[] cStr = AnyTypeString.ToCharArray();
            for (int i = 0; i < cStr.Length; i++)
            {
                str = str + r.Match(cStr[i].ToString(), 0, 1);
            }
            return str;
        }
        //是否验证通过
        public static bool IsValidString(string str, string strReg)
        {
            return Regex.IsMatch(str, strReg);
        }
        //过滤字符
        public static bool Filter(string strHtml, out string strMessage)
        {
            bool Flage = true;
            strMessage = string.Empty;
            string[] strFilter = { "假钞", "安眠药", "迷药", "春药", "仿真枪", "三唑伦", "彩信群发", "手机监听器", "三唑仑迷昏药", "麻醉钢针枪", "香港GHB迷水", "迷魂药", "强效遗忘药", "电击枪", "手机窃听器", "盐酸氯胺酮注射液", "万能钥匙", "麻醉药品", "催情迷幻药", "安眠药", "麻醉乙醚", "监控监听", "出售假币", "隐型透视眼镜", "色情电视卫星接收器", "仿真枪", "针孔偷拍机", "窃听器材", "追踪设备", "电表控制器" };
            int length = strFilter.Length;
            int htmlLength = strHtml.Length;
            for (int i = 0; i < length; i++)
            {

                if (strHtml.IndexOf(strFilter[i]) != -1)
                {
                    strMessage = strFilter[i];
                    Flage = false;
                    break;
                }
            }
            return Flage;
        }
        //过滤html
        public static string checkStr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex10 = new System.Text.RegularExpressions.Regex(@"<!-- [\s\S]+ -->", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            html = regex6.Replace(html, ""); //过滤frameset
            html = regex7.Replace(html, ""); //过滤frameset
            html = regex8.Replace(html, ""); //过滤frameset
            html = regex9.Replace(html, "");
            html = regex10.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;

        }

        /// <summary>
        /// 生成随机大些字母
        /// </summary>
        /// <param name="length">需要生成的随机字母个数</param>
        /// <returns></returns>
        public static string GetRandomUpper(int length)
        {
            char[] tempAZ = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Random MyRandom = new Random();
            string res = string.Empty;
            for (int i = 0; i < length; i++)
            {
                res += tempAZ[MyRandom.Next(25)].ToString();
            }
            return res;
        }
        /// <summary>
        /// 获取日期1990-01-01
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDate(object obj)
        {
            try
            {
                return obj.ToString().Split(' ')[0];
            }
            catch
            {
                return "";
            }
        }
    }

}
