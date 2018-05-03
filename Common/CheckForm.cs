/*******************************************************************************
             窗体验证类                                  
             本类主要实现验证FORM功能        
             作者：徐春建
             2009-5-21                 
 * *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Text.RegularExpressions;

namespace TFXK.Common
{
    #region 验证类型
    /// <summary>
    /// 验证类型
    /// </summary>
    public enum RegexType
    {
        /// <summary>
        /// 电子邮件
        /// </summary>
        Email,
        /// <summary>
        /// 电话号码
        /// </summary>
        Phone,
        /// <summary>
        /// 连接地址
        /// </summary>
        Url,
        /// <summary>
        /// 身份证号
        /// </summary>
        IdCart,
        /// <summary>
        /// 手机号码
        /// </summary>
        Mobile,
        /// <summary>
        /// 货币
        /// </summary>
        Currency,
        /// <summary>
        /// 数值
        /// </summary>
        Number,
        /// <summary>
        /// 邮政编码
        /// </summary>
        Zip,
        /// <summary>
        /// QQ号码
        /// </summary>
        QQ,
        /// <summary>
        /// 整数
        /// </summary>
        Integer,
        /// <summary>
        /// 双精度类型
        /// </summary>
        Double,
        /// <summary>
        /// 英文
        /// </summary>
        English,
        /// <summary>
        /// 中文
        /// </summary>
        Chinese,
        /// <summary>
        /// 特殊字符
        /// </summary>
        UnSafe
    }
    #endregion

    /// <summary>
    /// 表单验证类
    /// </summary>
    public class CheckForm
    {
        private static string emial = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private static string phone = @"(\(\d{3}\)|\d{3}-)?\d{8}";
        private static string url = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        private static string idcart = @"\d{17}[\d|X]|\d{15}";
	    private static string mobile=@"^((\(\d{3}\))|(\d{3}\-))?13\d{9}$";
        private static string currency=@"^\d+(\.\d+)?$";
        private static string number=@"^\d+$";
        private static string zip=@"^[1-9]\d{5}$";
        private static string qq=@"^[1-9]\d{4,8}$";
        private static string integer=@"^[-\+]?\d+$";
        private static string doubles=@"^[-\+]?\d+(\.\d+)?$";
        private static string english=@"^[A-Za-z]+$";
        private static string chinese=@"^[\u0391-\uFFE5]+$";
        private static string unsafes = "[~!@#$%^&*()=+[\\]{}''\";:/?.,><`|！·￥…—（）\\-、；：。，》《]";
        private static Regex reg;
        private static Cache cache = HttpRuntime.Cache; 

        /// <summary>
        /// 验证选择控件是否选中
        /// </summary>
        /// <param name="control">选择类型控件[CheckBox],[RadioButton]</param>
        /// <returns></returns>
        public static bool IsChecked(Control control)
        {
            bool isChk = false;
            if (control is CheckBox)
            {
                isChk= ((CheckBox)control).Checked;
            }
            else if(control is RadioButton)
            {
                isChk = ((RadioButton)control).Checked;
            }
            return isChk;
        }

        /// <summary>
        /// 判断是否选择了选项
        /// </summary>
        /// <param name="lstcontrol">列表类控件</param>
        /// <returns></returns>
        public static bool IsSelected(ListControl lstcontrol)
        {
            int count = 0;
            ListItemCollection lstItem = lstcontrol.Items;
            foreach (ListItem lst in lstItem)
            {
                if (lst.Selected) count++;
            }
            return count > 0;
        }

        /// <summary>
        /// 判断是否选择了第一项
        /// </summary>
        /// <param name="lstcontrol">列表类控件</param>
        /// <returns></returns>
        public static bool IsSelectFirst(ListControl lstcontrol)
        {
            return lstcontrol.SelectedIndex == 0;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="txt">要检测的值</param>
        /// <returns></returns>
        public static bool IsNull(string txt)
        {
            return txt.Length > 0;
        }

        /// <summary>
        /// 判断是否符合验证表达式
        /// </summary>
        /// <param name="regtype">验证类型</param>
        /// <param name="txt">验证值</param>
        /// <param name="isNull">是否允许为空</param>
        /// <returns></returns>
        public static bool IsMatch(RegexType regtype, string txt,bool isNull)
        {
            if (isNull && txt.Length == 0) return true;

            //如果缓存中不存在验证表达式，那就将验证表达式添加到缓存中
            try
            {
                bool checktype = bool.Parse(cache["CheckType"].ToString());
            }
            catch
            {
                cache.Insert(RegexType.Email.ToString(), emial);
                cache.Insert(RegexType.Chinese.ToString(), chinese);
                cache.Insert(RegexType.Currency.ToString(), currency);
                cache.Insert(RegexType.Double.ToString(), doubles);
                cache.Insert(RegexType.English.ToString(), english);
                cache.Insert(RegexType.IdCart.ToString(), idcart);
                cache.Insert(RegexType.Integer.ToString(), integer);
                cache.Insert(RegexType.Mobile.ToString(), mobile);
                cache.Insert(RegexType.Number.ToString(), number);
                cache.Insert(RegexType.Phone.ToString(), phone);
                cache.Insert(RegexType.QQ.ToString(), qq);
                cache.Insert(RegexType.UnSafe.ToString(), unsafes);
                cache.Insert(RegexType.Url.ToString(), url);
                cache.Insert(RegexType.Zip.ToString(), zip);
                cache.Insert("CheckType", true);
            }
            bool ismat = false;
            
            //从缓存中获取表达式
            reg = new Regex(cache[regtype.ToString()].ToString());
            ismat = reg.IsMatch(txt);
            reg = null;
            return ismat;
        }

        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="pattern">自定义验证表达式</param>
        /// <param name="txt"> 要验证的类型</param>
        /// <returns></returns>
        public static bool CustomMatch(string pattern, string txt)
        {
            bool ismat = false;
            reg = new Regex(pattern);
            ismat = reg.IsMatch(txt);
            reg = null;
            return ismat;
        }

        /// <summary> 
        /// 清空指定页面上所有的控件内容，包括TextBox，CheckBox,CheckBoxList,RadioButton,RadioButtonList。但是不清 
        /// 除如ListBox，DropDownList，因为这样的控件值对当前页面来说还可以用，一般这些控件里都是保存的字典数据。 
        /// </summary> 
        /// <param name="page"> 指定的页面</param> 
        public static void ClearAllContent(System.Web.UI.Control page)
        {
            int nPageControls = page.Controls.Count;
            for (int i = 0; i < nPageControls; i++)
            {
                foreach (System.Web.UI.Control control in page.Controls[i].Controls)
                {
                    if (control.HasControls())
                    {
                        ClearAllContent(control);
                    }
                    else
                    {
                        if (control is TextBox)
                            (control as TextBox).Text = "";

                        if (control is CheckBox)
                            (control as CheckBox).Checked = false;

                        if (control is RadioButtonList)
                            (control as RadioButtonList).SelectedIndex = -1;

                        if (control is RadioButton)
                            (control as RadioButton).Checked = false;

                        if (control is CheckBoxList)
                        {
                            foreach (ListItem item in (control as CheckBoxList).Items)
                            {
                                item.Selected = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
