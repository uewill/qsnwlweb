/*******************************************************************************
             ������֤��                                  
             ������Ҫʵ����֤FORM����        
             ���ߣ��촺��
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
    #region ��֤����
    /// <summary>
    /// ��֤����
    /// </summary>
    public enum RegexType
    {
        /// <summary>
        /// �����ʼ�
        /// </summary>
        Email,
        /// <summary>
        /// �绰����
        /// </summary>
        Phone,
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        Url,
        /// <summary>
        /// ���֤��
        /// </summary>
        IdCart,
        /// <summary>
        /// �ֻ�����
        /// </summary>
        Mobile,
        /// <summary>
        /// ����
        /// </summary>
        Currency,
        /// <summary>
        /// ��ֵ
        /// </summary>
        Number,
        /// <summary>
        /// ��������
        /// </summary>
        Zip,
        /// <summary>
        /// QQ����
        /// </summary>
        QQ,
        /// <summary>
        /// ����
        /// </summary>
        Integer,
        /// <summary>
        /// ˫��������
        /// </summary>
        Double,
        /// <summary>
        /// Ӣ��
        /// </summary>
        English,
        /// <summary>
        /// ����
        /// </summary>
        Chinese,
        /// <summary>
        /// �����ַ�
        /// </summary>
        UnSafe
    }
    #endregion

    /// <summary>
    /// ����֤��
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
        private static string unsafes = "[~!@#$%^&*()=+[\\]{}''\";:/?.,><`|��������������\\-��������������]";
        private static Regex reg;
        private static Cache cache = HttpRuntime.Cache; 

        /// <summary>
        /// ��֤ѡ��ؼ��Ƿ�ѡ��
        /// </summary>
        /// <param name="control">ѡ�����Ϳؼ�[CheckBox],[RadioButton]</param>
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
        /// �ж��Ƿ�ѡ����ѡ��
        /// </summary>
        /// <param name="lstcontrol">�б���ؼ�</param>
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
        /// �ж��Ƿ�ѡ���˵�һ��
        /// </summary>
        /// <param name="lstcontrol">�б���ؼ�</param>
        /// <returns></returns>
        public static bool IsSelectFirst(ListControl lstcontrol)
        {
            return lstcontrol.SelectedIndex == 0;
        }

        /// <summary>
        /// �Ƿ�Ϊ��
        /// </summary>
        /// <param name="txt">Ҫ����ֵ</param>
        /// <returns></returns>
        public static bool IsNull(string txt)
        {
            return txt.Length > 0;
        }

        /// <summary>
        /// �ж��Ƿ������֤���ʽ
        /// </summary>
        /// <param name="regtype">��֤����</param>
        /// <param name="txt">��ֵ֤</param>
        /// <param name="isNull">�Ƿ�����Ϊ��</param>
        /// <returns></returns>
        public static bool IsMatch(RegexType regtype, string txt,bool isNull)
        {
            if (isNull && txt.Length == 0) return true;

            //��������в�������֤���ʽ���Ǿͽ���֤���ʽ��ӵ�������
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
            
            //�ӻ����л�ȡ���ʽ
            reg = new Regex(cache[regtype.ToString()].ToString());
            ismat = reg.IsMatch(txt);
            reg = null;
            return ismat;
        }

        /// <summary>
        /// �Զ�����֤
        /// </summary>
        /// <param name="pattern">�Զ�����֤���ʽ</param>
        /// <param name="txt"> Ҫ��֤������</param>
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
        /// ���ָ��ҳ�������еĿؼ����ݣ�����TextBox��CheckBox,CheckBoxList,RadioButton,RadioButtonList�����ǲ��� 
        /// ����ListBox��DropDownList����Ϊ�����Ŀؼ�ֵ�Ե�ǰҳ����˵�������ã�һ����Щ�ؼ��ﶼ�Ǳ�����ֵ����ݡ� 
        /// </summary> 
        /// <param name="page"> ָ����ҳ��</param> 
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
