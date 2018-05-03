/*******************************************************************************
             文家上传类                                  
             本类主要实现文件上传功能             
             作者：徐春建
             2009-5-21                 
 * *****************************************************************************/

using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

namespace TFXK.Common
{
    /// <summary>
    /// 文件上传类
    /// </summary>
    public class UpFile
    {
        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <param name="file">文件上传控件</param>
        /// <param name="filetype">文件类型限制 例：new string[]{"image/gif","image/pjpeg"}</param>
        /// <param name="fileLength">文件大小限制[KB]</param>
        /// <param name="fullPath">文件要上传到的文件夹[全路径,不要带末尾的"\"] 例：Server.MapPath("../uploads")</param>
        /// <returns>上传后的文件名</returns>
        static public string Upload(System.Web.UI.WebControls.FileUpload file, string[] filetype, int fileLength, string fullPath)
        {
            bool checkType = false;
            foreach (string str in filetype)
            {
                if(file.PostedFile.ContentType.ToString()==str)
                {
                    checkType=true;
                    break;
                }
            }
            if (!checkType)
            {
                return "错误:您上传的文件是不允许的类型";
            }
            else
            {
                if (file.PostedFile.ContentLength > fileLength * 1024)
                {
                    return "错误:文件超出大小限制!";
                }
                else
                {
                    Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                    string extender = Path.GetExtension(file.PostedFile.FileName);
                    string filename = DateTime.Now.ToShortDateString().Replace("-", "") + rand.Next().ToString().Substring(0, 5) +  extender;
                    file.PostedFile.SaveAs(fullPath + "\\" + filename);
                    return filename;
                }
            }


        }

        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <param name="file">文件上传控件</param>
        /// <param name="filetype">文件类型限制 例：new string[]{"image/gif","image/pjpeg"}</param>
        /// <param name="fileLength">文件大小限制[KB]</param>
        /// <param name="fullPath">文件要上传到的文件夹[全路径,不要带末尾的"\"] 例：Server.MapPath("../uploads")</param>
        /// <returns>上传后的文件名</returns>
        static public string Upload(System.Web.UI.HtmlControls.HtmlInputFile file, string[] filetype, int fileLength, string fullPath)
        {
            bool checkType = false;
            foreach (string str in filetype)
            {
                if (file.PostedFile.ContentType.ToString() == str)
                {
                    checkType = true;
                    break;
                }
            }
            if (!checkType)
            {
                return "错误:您上传的文件是不允许的类型";
            }
            else
            {
                if (file.PostedFile.ContentLength > fileLength * 1024)
                {
                    return "错误:文件超出大小限制!";
                }
                else
                {
                    Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                    string extender = Path.GetExtension(file.PostedFile.FileName);
                    string filename = DateTime.Now.ToShortDateString().Replace("-", "") + rand.Next().ToString().Substring(0, 5) +extender;
                    file.PostedFile.SaveAs(fullPath + "\\" + filename);
                    return filename;
                }
            }

        }

        /// <summary>
        /// 多文件上传,如果有一个文件类型或大小超出限制，所有文件将不上传
        /// </summary>
        /// <param name="files">上传文件结合,一般为 HttpContext.Current.Request.Files</param>
        /// <param name="filetype">文件类型限制 例：new string[]{"image/gif","image/pjpeg"}</param>
        /// <param name="fileLength">文件大小限制[KB]</param>
        /// <param name="fullPath">文件要上传到的文件夹[全路径,不要带末尾的"\"] 例：Server.MapPath("../uploads")</param>
        /// <returns>上传后的文件名</returns>
        public static List<string> MutilUpload(HttpFileCollection files, string[] filetype, int filelength, string fullPath)
        {
            List<string> filenames = new List<string>();

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (file.FileName == "") continue;
                bool checkType = false;
                foreach (string str in filetype)
                {
                    if (file.ContentType.ToString()== str)
                    {
                        checkType=true;
                        break;
                    }
                }
                if (!checkType)
                {
                    foreach (string filename in filenames)
                    {
                        if (filename.Substring(0, 2) != "错误")
                            DelFile(filename);
                        filenames.Add("错误:文件中存在不允许上传的类型!");
                    }
                    break;
                }
                else
                {
                    if (file.ContentLength > 1024 * filelength)
                    {
                        foreach (string filename in filenames)
                        {
                            if (filename.Substring(0, 2) != "错误")
                                DelFile(filename);
                        }
                        filenames.Add("错误:" + file.FileName + "文件大小超出限制!");
                        break;
                    }
                    else
                    {
                        Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                        string extender = Path.GetExtension(file.FileName);
                        string filename = DateTime.Now.ToShortDateString().Replace("-", "") + rand.Next().ToString().Substring(0, 5) + extender;
                        file.SaveAs(fullPath + "\\" + filename);
                        filenames.Add(filename);
                    }
                }
            }
            return filenames;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        static public void DelFile(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }

}
