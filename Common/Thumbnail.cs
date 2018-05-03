/*******************************************************************************
             ����ͼ������                                  
             ������Ҫʵ����������ͼ����        
             ���ߣ��촺��
             2009-5-21                 
 * *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace TFXK.Common
{
    /// <summary>
    /// ��������ͼ
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="NewWidth">����ͼ���</param>
        /// <param name="NewHeight">����ͼ���</param>
        /// <param name="OldPath">ԭʼͼ���ַ</param>
        /// <param name="NewPath">����ͼ���ַ</param>
        /// <returns></returns>
        public static void CreateThumbnail(int newWidth, int newHeight, string OldPath, string NewPath)
        {
           Image img = System.Drawing.Image.FromFile(OldPath);
            int iWidth = img.Width;
            int iHeight = img.Height;
            //�����͸߶������������
            if (iWidth > newWidth && iHeight > newHeight)
            {
                //�ж����ǿ�������Ǹ߸������Ա���������׼
                if ((double)iHeight / (double)iWidth > (double)newHeight / (double)newWidth)
                {
                    //����Ǹ߸��������ø�Ϊ�������ֵ����ȱ�����С
                    newWidth = (int)((double)iWidth / (double)iHeight * newHeight);
                }
                else
                {
                    //����ǿ���������ÿ�Ϊ�������ֵ���ߵȱ�����С
                    newHeight = (int)((double)iHeight / (double)iWidth * newWidth);
                }
            }
            else if (iWidth > newWidth && iHeight <= newHeight)
            {
                //���ֻ�ǿ������ƣ����ÿ�Ϊ���ֵ���ߵȱ�����С
                newHeight = (int)((double)iHeight / (double)iWidth * newWidth);
            }
            else if (iWidth <= newWidth && iHeight > newHeight)
            {
                //���ֻ�Ǹ߳������ƣ����ø�Ϊ���ֵ����ȱ�����С
                newWidth = (int)((double)iWidth / (double)iHeight * newHeight);
            }
            else
            {
                //�����û����������ԭ���Ĵ�С
                newWidth = iWidth;
                newHeight = iHeight;
            }
            //�½�һ��bmpͼƬ
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            //�½�һ������
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //���ø�������ֵ��
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //���ø�����,���ٶȳ���ƽ���̶�
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //��ջ�������͸������ɫ���
            g.Clear(Color.Transparent);
            //��ָ����С����ԭͼƬ
            g.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight));

            try
            {
                //��jpg��ʽ��������ͼ��ͼƬ��������
                bitmap.Save(NewPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                img.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

        }

    }
}
