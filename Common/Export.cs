using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TFXK.Common
{
    public class Export
    {
        /// <summary>  
        /// DataTable导出到Excel  
        /// </summary>  
        /// <param name="table">DataTable类型的数据源</param>  
        /// <param name="file">需要导出的文件路径</param>  
        private static void dataTableToCsv(DataTable table, string file)
        {
            string title = "";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格  
            }
            title = title.Substring(0, title.Length - 1) + "\n";
            sw.Write(title);
            foreach (DataRow row in table.Rows)
            {
                string line = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格  
                }
                line = line.Substring(0, line.Length - 1) + "\n";
                sw.Write(line);
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>  
        /// DataTable导出到Excel  
        /// </summary>  
        /// <param name="dt">DataTable类型的数据源</param>  
        /// <param name="FileType">文件类型</param>  
        /// <param name="FileName">文件名</param>  
        public static void CreateExcel(HttpContext context, DataTable dt, string FileName)
        {
            string FileType = "application/ms-excel";
            context.Response.Clear();
            context.Response.Charset = "UTF-8";
            context.Response.Buffer = true;
            context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
            context.Response.ContentType = FileType;
            string colHeaders = string.Empty;
            string ls_item = string.Empty;
            DataRow[] myRow = dt.Select();
            int i = 0;
            int cl = dt.Columns.Count;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                ls_item += dt.Columns[j].ColumnName + "\t"; //栏位：自动跳到下一单元格  
            }
            ls_item = ls_item.Substring(0, ls_item.Length - 1) + "\n";
            foreach (DataRow row in myRow)
            {
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }
                }
                context.Response.Output.Write(ls_item);
                ls_item = string.Empty;
            }
            context.Response.Output.Flush();
            context.Response.End();
        }
    }
}
