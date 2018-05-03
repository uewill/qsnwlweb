
using System;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

/// <summary>
///ImgWater 的摘要说明
/// </summary>
public class ImgWater
{
    public ImgWater()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    ///  <summary> 
    /// 在图片上增加文字水印 
    ///  </summary> 
    ///  <param name="Path">原服务器图片路径 </param> 
    ///  <param name="Path_sy">生成的带文字水印的图片路径 </param> 
    public static void AddWater(string Path, string Path_sy)
    {
        string addText = "文字水印";
        Image image = Image.FromFile(Path);
        Graphics g = Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        Font f = new Font("Verdana", 60);
        Brush b = new SolidBrush(Color.Green);

        g.DrawString(addText, f, b, 35, 35);
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }

    ///  <summary> 
    /// 在图片上生成图片水印 
    ///  </summary> 
    ///  <param name="Path">原服务器图片路径 </param> 
    ///  <param name="Path_syp">生成的带图片水印的图片路径 </param> 
    ///  <param name="Path_sypf">水印图片路径 </param> 
    public static void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        Image image = Image.FromFile(Path);
        Image copyImage = Image.FromFile(Path_sypf);
        Graphics g = Graphics.FromImage(image);
        Rectangle rect = new Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height);
        g.DrawImage(copyImage, rect, 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
        g.Dispose();
        image.Save(Path_syp);
        image.Dispose();
    }

}
