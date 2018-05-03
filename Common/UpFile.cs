/*******************************************************************************
             �ļ��ϴ���                                  
             ������Ҫʵ���ļ��ϴ�����             
             ���ߣ��촺��
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
    /// �ļ��ϴ���
    /// </summary>
    public class UpFile
    {
        /// <summary>
        /// ���ļ��ϴ�
        /// </summary>
        /// <param name="file">�ļ��ϴ��ؼ�</param>
        /// <param name="filetype">�ļ��������� ����new string[]{"image/gif","image/pjpeg"}</param>
        /// <param name="fileLength">�ļ���С����[KB]</param>
        /// <param name="fullPath">�ļ�Ҫ�ϴ������ļ���[ȫ·��,��Ҫ��ĩβ��"\"] ����Server.MapPath("../uploads")</param>
        /// <returns>�ϴ�����ļ���</returns>
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
                return "����:���ϴ����ļ��ǲ����������";
            }
            else
            {
                if (file.PostedFile.ContentLength > fileLength * 1024)
                {
                    return "����:�ļ�������С����!";
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
        /// ���ļ��ϴ�
        /// </summary>
        /// <param name="file">�ļ��ϴ��ؼ�</param>
        /// <param name="filetype">�ļ��������� ����new string[]{"image/gif","image/pjpeg"}</param>
        /// <param name="fileLength">�ļ���С����[KB]</param>
        /// <param name="fullPath">�ļ�Ҫ�ϴ������ļ���[ȫ·��,��Ҫ��ĩβ��"\"] ����Server.MapPath("../uploads")</param>
        /// <returns>�ϴ�����ļ���</returns>
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
                return "����:���ϴ����ļ��ǲ����������";
            }
            else
            {
                if (file.PostedFile.ContentLength > fileLength * 1024)
                {
                    return "����:�ļ�������С����!";
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
        /// ���ļ��ϴ�,�����һ���ļ����ͻ��С�������ƣ������ļ������ϴ�
        /// </summary>
        /// <param name="files">�ϴ��ļ����,һ��Ϊ HttpContext.Current.Request.Files</param>
        /// <param name="filetype">�ļ��������� ����new string[]{"image/gif","image/pjpeg"}</param>
        /// <param name="fileLength">�ļ���С����[KB]</param>
        /// <param name="fullPath">�ļ�Ҫ�ϴ������ļ���[ȫ·��,��Ҫ��ĩβ��"\"] ����Server.MapPath("../uploads")</param>
        /// <returns>�ϴ�����ļ���</returns>
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
                        if (filename.Substring(0, 2) != "����")
                            DelFile(filename);
                        filenames.Add("����:�ļ��д��ڲ������ϴ�������!");
                    }
                    break;
                }
                else
                {
                    if (file.ContentLength > 1024 * filelength)
                    {
                        foreach (string filename in filenames)
                        {
                            if (filename.Substring(0, 2) != "����")
                                DelFile(filename);
                        }
                        filenames.Add("����:" + file.FileName + "�ļ���С��������!");
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
        /// ɾ���ļ�
        /// </summary>
        /// <param name="filePath"></param>
        static public void DelFile(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }

}
