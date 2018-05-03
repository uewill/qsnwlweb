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

namespace TFXK.Common
{
    /// <summary>
    /// �Ի�������
    /// </summary>
    public class Msg
    {
        public Msg() { }

        /// <summary>
        /// ��ȡ��ǰҳ��
        /// </summary>
        /// <returns></returns>
        private static Page getCurrent()
        {
            Page page= (Page)HttpContext.Current.Handler;
            return page;
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        public static void Show(string msg)
        {
            msg =msg.Replace("'"," ");
            msg = msg.Replace(";", " ");
            msg = msg.Replace('"', ' ');
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>alert('" + msg + "');</script>", false);
        }

        /// <summary>
        /// ��ʾYESNO�Ի���
        /// </summary>
        /// <param name="control">�ؼ�</param>
        /// <param name="msg">��Ϣ</param>
        public static void Confirm(WebControl control, string msg)
        {
            msg = msg.Replace("'", " ");
            msg = msg.Replace(";", " ");
            msg = msg.Replace('"', ' ');
            control.Attributes.Add("onclick", "return confirm('" + msg + "?')");
        }


        /// <summary>
        /// ��ʾ�Ի�����ת
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��ַ</param>
        public static void ShowAndRedirect(string msg, string url)
        {
            msg = msg.Replace("'", " ");
            msg = msg.Replace(";", " ");
            msg = msg.Replace('"', ' ');
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>alert('" + msg + "');location.href='" + url + "';</script>", false);
        }

        /// <summary>
        /// �Զ���Ի������
        /// </summary>
        /// <param name="opeastring">
        /// �Զ�������
        /// ��:alert('���');
        /// </param>
        public static void Custom(string opeastring)
        {
            opeastring = StrHelper.checkStr(opeastring);
            ScriptManager.RegisterStartupScript(getCurrent(), getCurrent().GetType(), "", "<script>" + opeastring + "</script>", false);
        }
    }
}
