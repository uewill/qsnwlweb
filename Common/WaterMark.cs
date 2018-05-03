/*******************************************************************************
             ���ˮӡ��                                  
             ������Ҫʵ��ͼƬ��ˮӡ����        
             ���ߣ��촺��
             2009-5-21                 
 * *****************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
namespace TFXK.Common
{
    /// <summary>
    /// ���ˮӡ
    /// </summary>
    public class WaterMark
    {
        #region ��Ա����
        private string modifyImagePath = null;
        private string drawedImagePath = null;
        private int rightSpace;
        private int bottoamSpace;
        private int lucencyPercent = 70;
        private string outPath = null;
        #endregion

        #region ��Ա����
        /// <summary>
        /// ��ȡ������Ҫ�޸ĵ�ͼ��·��
        /// </summary>
        public string ModifyImagePath
        {
            get { return this.modifyImagePath; }
            set { this.modifyImagePath = value; }
        }
        /// <summary>
        /// ��ȡ�������ڻ���ͼƬ·��(ˮӡͼƬ)
        /// </summary>
        public string DrawedImagePath
        {
            get { return this.drawedImagePath; }
            set { this.drawedImagePath = value; }
        }
        /// <summary>
        /// ��ȡ������ˮӡ���޸�ͼƬ�е��ұ߾�
        /// </summary>
        public int RightSpace
        {
            get { return this.rightSpace; }
            set { this.rightSpace = value; }
        }
        //��ȡ������ˮӡ���޸�ͼƬ�о�ײ��ĸ߶�
        public int BottoamSpace
        {
            get { return this.bottoamSpace; }
            set { this.bottoamSpace = value; }
        }
        /// <summary>
        /// ��ȡ������Ҫ����ˮӡ��͸����,ע����ԭ��ͼƬ͸���ȵİٷֱ�
        /// </summary>
        public int LucencyPercent
        {
            get { return this.lucencyPercent; }
            set
            {
                if (value >= 0 && value <= 100)
                    this.lucencyPercent = value;
            }
        }
        /// <summary>
        /// ��ȡ������Ҫ���ͼ���·��
        /// </summary>
        public string OutPath
        {
            get { return this.outPath; }
            set { this.outPath = value; }
        }
        #endregion

        #region ��Ա����
        public WaterMark(){}

        /// <summary>
        /// ��ʼ����ˮӡ
        /// </summary>
        public void DrawImage()
        {
            Image modifyImage = null;
            Image drawedImage = null;
            Graphics g = null;
            try
            {
                //����ͼ�ζ���
                modifyImage = Image.FromFile(this.ModifyImagePath);
                drawedImage = Image.FromFile(this.DrawedImagePath);
                g = Graphics.FromImage(modifyImage);
                //��ȡҪ����ͼ������
                int x = modifyImage.Width - this.rightSpace-drawedImage.Width;
                int y = modifyImage.Height - this.BottoamSpace-drawedImage.Height;
                //������ɫ����
                float[][] matrixItems ={ 
             new float[] {1, 0, 0, 0, 0},
             new float[] {0, 1, 0, 0, 0},
             new float[] {0, 0, 1, 0, 0},
             new float[] {0, 0, 0, (float)this.LucencyPercent/100f, 0}, 
             new float[] {0, 0, 0, 0, 1}};

                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
                ImageAttributes imgAttr = new ImageAttributes();
                imgAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                //������Ӱͼ��
                g.DrawImage(
                 drawedImage,
                 new Rectangle(x, y, drawedImage.Width, drawedImage.Height),
                 0, 0, drawedImage.Width, drawedImage.Height,
                 GraphicsUnit.Pixel, imgAttr);
                //�����ļ�
                string[] allowImageType ={ ".jpg", ".gif", ".png", ".bmp", ".tiff", ".wmf", ".ico" };
                FileInfo file = new FileInfo(this.ModifyImagePath);
                ImageFormat imageType = ImageFormat.Gif;
                switch (file.Extension.ToLower())
                {
                    case ".jpg":
                        imageType = ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        imageType = ImageFormat.Gif;
                        break;
                    case ".png":
                        imageType = ImageFormat.Png;
                        break;
                    case ".bmp":
                        imageType = ImageFormat.Bmp;
                        break;
                    case ".tif":
                        imageType = ImageFormat.Tiff;
                        break;
                    case ".wmf":
                        imageType = ImageFormat.Wmf;
                        break;
                    case ".ico":
                        imageType = ImageFormat.Icon;
                        break;
                    default:
                        break;
                }
                MemoryStream ms = new MemoryStream();
                modifyImage.Save(ms, imageType);
                byte[] imgData = ms.ToArray();
                modifyImage.Dispose();
                drawedImage.Dispose();
                g.Dispose();
                FileStream fs = null;
                if (this.OutPath == null || this.OutPath == "")
                {
                    File.Delete(this.ModifyImagePath);
                    fs = new FileStream(this.ModifyImagePath, FileMode.Create, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(this.OutPath, FileMode.Create, FileAccess.Write);
                }
                if (fs != null)
                {
                    fs.Write(imgData, 0, imgData.Length);
                    fs.Close();
                }
            }
            finally
            {
                try
                {
                    drawedImage.Dispose();
                    modifyImage.Dispose();
                    g.Dispose();
                }
                catch { ;}
            }
        }
        #endregion
    }
}
