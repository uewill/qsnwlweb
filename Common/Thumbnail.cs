/*******************************************************************************
             缩略图生成类                                  
             本类主要实现生成缩略图功能        
             作者：徐春建
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
    /// 生成缩略图
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="NewWidth">缩略图宽度</param>
        /// <param name="NewHeight">缩略图宽度</param>
        /// <param name="OldPath">原始图像地址</param>
        /// <param name="NewPath">保存图像地址</param>
        /// <returns></returns>
        public static void CreateThumbnail(int newWidth, int newHeight, string OldPath, string NewPath)
        {
           Image img = System.Drawing.Image.FromFile(OldPath);
            int iWidth = img.Width;
            int iHeight = img.Height;
            //如果宽和高都超过最大限制
            if (iWidth > newWidth && iHeight > newHeight)
            {
                //判断下是宽更长还是高更长，以便以它做标准
                if ((double)iHeight / (double)iWidth > (double)newHeight / (double)newWidth)
                {
                    //如果是高更长，设置高为最大限制值，宽等比例缩小
                    newWidth = (int)((double)iWidth / (double)iHeight * newHeight);
                }
                else
                {
                    //如果是宽更长，设置宽为最大限制值，高等比例缩小
                    newHeight = (int)((double)iHeight / (double)iWidth * newWidth);
                }
            }
            else if (iWidth > newWidth && iHeight <= newHeight)
            {
                //如果只是宽超过限制，设置宽为最大值，高等比例缩小
                newHeight = (int)((double)iHeight / (double)iWidth * newWidth);
            }
            else if (iWidth <= newWidth && iHeight > newHeight)
            {
                //如果只是高超过限制，设置高为最大值，宽等比例缩小
                newWidth = (int)((double)iWidth / (double)iHeight * newHeight);
            }
            else
            {
                //如果都没超过现在用原来的大小
                newWidth = iWidth;
                newHeight = iHeight;
            }
            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //按指定大小绘制原图片
            g.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight));

            try
            {
                //以jpg格式保存缩略图，图片质量更高
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
