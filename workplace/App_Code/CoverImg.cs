using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
///picHanddler 的摘要说明
/// </summary>
public class CoverImg : IHttpHandler
{
    //数字水印路径
    private  string WATERMARK_URL = "~/Images/logo.png";
    //默认图片路径
    private  string DEFAULT_PIC = "~/Images/nopic.jpg";

    public void ProcessRequest(HttpContext context)
    {

        Image Cover;
        //判断请求的物理路径中，是否存在该文件
        if (File.Exists(context.Request.PhysicalPath))
        {
            //加载文件
            Cover = Image.FromFile(context.Request.PhysicalPath);
            //加载水印图片
            Image watermark = Image.FromFile(context.Request.MapPath(WATERMARK_URL));
            //实例化画布
            Graphics g = Graphics.FromImage(Cover);
            StringFormat fmort = new StringFormat();
            fmort.Alignment = StringAlignment.Center;
            fmort.LineAlignment = StringAlignment.Center;

            //Cover上绘制水印
            g.DrawImage(watermark, new Rectangle(Cover.Width - watermark.Width, Cover.Height - watermark.Height, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel);

            #region 文字水印
         
            //string logoText = "天府星空(http://www.tfxk.com) 版权所有 盗版必究";
            //float fontSize = 9; //字体大小 
            //float textWidth = logoText.Length * fontSize; //文本的长度 
            ////下面定义一个矩形区域，以后在这个矩形里画上白底黑字 
            //float rectX = 0;
            //float rectY = Cover.Height - 18;
            //float rectWidth = Cover.Width;
            //float rectHeight = 18;
            ////声明矩形域 
            //RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);
            //Font font = new Font("宋体", fontSize); //定义字体 
            //Brush whiteBrush = new SolidBrush(Color.White); //白笔刷，画文字用 
            //Brush blackBrush = new SolidBrush(Color.FromArgb(207, 207, 207)); //黑笔刷，画背景用 
            //g.FillRectangle(blackBrush, rectX, rectY, rectWidth, rectHeight);

            ////创建GDI+绘图图面
            //g.DrawString(logoText, font, whiteBrush, textArea, fmort);
            ////在背景图片上绘制水印文字
            //// g.DrawImage(Cover, new System.Drawing.Point(400, 300));

            #endregion

            //释放画布
            g.Dispose();
            //释放水印图片
            watermark.Dispose();
        }
        else
        {
            //加载默认图片
            Cover = Image.FromFile(context.Request.MapPath(DEFAULT_PIC));
        }
        //设置输出格式
        context.Response.ContentType = "image/jpeg";
        //将图片存入输出流
        Cover.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        //释放资源
        Cover.Dispose();
        //停止HTTP响应
        context.Response.End();
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
