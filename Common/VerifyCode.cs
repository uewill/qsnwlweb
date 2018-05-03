/*******************************************************************************
             ��֤����                                  
             ������Ҫʵ����֤�빦��        
             ���ߣ��촺��
             2009-5-21                 
 * *****************************************************************************/

using System;
using System.Web;
using System.IO;
using System.Drawing;

namespace TFXK.Common
{
    /// <summary>
    /// ������֤��
    /// </summary>
    /// <code>
    ///protected void Page_Load(object sender, EventArgs e)
    ///{
    ///    VerifyCode v = new VerifyCode();
    ///    string code = v.CreateVerifyCode();             //ȡ�����
    ///    v.CreateImageOnPage(code, this.Context);        // ���ͼƬ
    ///    // ʹ��Session["CheckCode"]ȡ��֤���ֵ
    ///    //Session["CheckCode"] = code.ToLower();       
    ///    // ʹ��Cookiesȡ��֤���ֵ
    ///    Response.Cookies.Add(new HttpCookie("CheckCode", code.ToLower()));
    ///}
    /// </code>
    public class VerifyCode
    {

        #region ��֤�볤��(Ĭ��4����֤��ĳ���)
        int length = 4;
        /// <summary>
        /// ��֤�볤��(Ĭ��4����֤��ĳ���)
        /// </summary>
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        #endregion

        #region ��֤�������С(Ĭ��10����)
        int fontSize = 10;
        /// <summary>
        /// ��֤�������С(Ĭ��10����)
        /// </summary>
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
        #endregion

        #region �߿�(Ĭ��1����)
        int padding = 1;
        /// <summary>
        /// �߿�(Ĭ��1����)
        /// </summary>
        public int Padding
        {
            get { return padding; }
            set { padding = value; }
        }
        #endregion

        #region �Ƿ�������(Ĭ�ϲ����)
        bool chaos = true;
        /// <summary>
        /// �Ƿ�������(Ĭ�ϲ����)
        /// </summary>
        public bool Chaos
        {
            get { return chaos; }
            set { chaos = value; }
        }
        #endregion

        #region ���������ɫ(Ĭ�ϻ�ɫ)
        Color chaosColor = Color.LightGray;
        /// <summary>
        ///  ���������ɫ(Ĭ�ϻ�ɫ)
        /// </summary>
        public Color ChaosColor
        {
            get { return chaosColor; }
            set { chaosColor = value; }
        }
        #endregion

        #region �Զ��屳��ɫ(Ĭ�ϰ�ɫ)
        Color backgroundColor = Color.White;
        /// <summary>
        /// �Զ��屳��ɫ(Ĭ�ϰ�ɫ)
        /// </summary>
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }
        #endregion

        #region �Զ��������ɫ����
        Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        /// <summary>
        /// �Զ��������ɫ����
        /// </summary>
        public Color[] Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        #endregion

        #region �Զ�����������
        string[] fonts = { "Arial", "Georgia" };
        /// <summary>
        /// �Զ�����������
        /// </summary>
        public string[] Fonts
        {
            get { return fonts; }
            set { fonts = value; }
        }
        #endregion

        #region �Զ���������ַ�������(ʹ�ö��ŷָ�)
        string codeSerial = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        /// <summary>
        /// �Զ���������ַ�������(ʹ�ö��ŷָ�)
        /// </summary>
        public string CodeSerial
        {
            get { return codeSerial; }
            set { codeSerial = value; }
        }
        #endregion

        #region ����У����ͼƬ
        /// <summary>
        /// ����У����ͼƬ
        /// </summary>
        /// <param name="code">У����</param>
        /// <returns></returns>
        public Bitmap CreateImageCode(string code)
        {
            int fSize = FontSize;
            int fWidth = fSize + Padding;

            int imageWidth = (int)(code.Length * fWidth) + 4 + Padding * 2;
            int imageHeight = fSize * 2 + Padding;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap(imageWidth, imageHeight);

            Graphics g = Graphics.FromImage(image);

            g.Clear(BackgroundColor);

            Random rand = new Random();

            //���������������ɵ����
            if (this.Chaos)
            {

                Pen pen = new Pen(ChaosColor, 0);
                int c = Length * 10;

                for (int i = 0; i < c; i++)
                {
                    int x = rand.Next(image.Width);
                    int y = rand.Next(image.Height);

                    g.DrawRectangle(pen, x, y, 1, 1);
                }
            }

            int left = 0, top = 0, top1 = 1, top2 = 1;

            int n1 = (imageHeight - FontSize - Padding * 2);
            int n2 = n1 / 4;
            top1 = n2;
            top2 = n2 * 2;

            Font f;
            Brush b;

            int cindex, findex;

            //����������ɫ����֤���ַ�
            for (int i = 0; i < code.Length; i++)
            {
                cindex = rand.Next(Colors.Length - 1);
                findex = rand.Next(Fonts.Length - 1);

                f = new System.Drawing.Font(Fonts[findex], fSize, System.Drawing.FontStyle.Bold);
                b = new System.Drawing.SolidBrush(Colors[cindex]);

                if (i % 2 == 1)
                {
                    top = top2;
                }
                else
                {
                    top = top1;
                }

                left = i * fWidth;

                g.DrawString(code.Substring(i, 1), f, b, left, top);
            }

            //��һ���߿� �߿���ɫΪColor.Gainsboro
            g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
            g.Dispose();
            return image;
        }
        #endregion

        #region �������õ�ͼƬ�����ҳ��
        /// <summary>
        /// �������õ�ͼƬ�����ҳ��
        /// </summary>
        /// <param name="code">У����</param>
        /// <param name="context">ҳ����</param>
        public void CreateImageOnPage(string code, HttpContext context)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Bitmap image = this.CreateImageCode(code);

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            context.Response.ClearContent();
            context.Response.ContentType = "image/Jpeg";
            context.Response.BinaryWrite(ms.GetBuffer());

            ms.Close();
            ms = null;
            image.Dispose();
            image = null;
        }
        #endregion

        #region ��������ַ���
        /// <summary>
        /// ��������ַ���
        /// </summary>
        /// <param name="codeLen">���ɵĳ���</param>
        /// <returns></returns>
        public string CreateVerifyCode(int codeLen)
        {
            if (codeLen == 0)
            {
                codeLen = Length;
            }

            string[] arr = CodeSerial.Split(',');

            string code = "";

            int randValue = -1;

            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);

                code += arr[randValue];
            }

            return code;
        }
        /// <summary>
        /// ��ȡ��֤��
        /// </summary>
        /// <returns></returns>

        public string CreateVerifyCode()
        {
            return CreateVerifyCode(0);
        }
        #endregion

    }
}
