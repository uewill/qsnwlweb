/* 
    ======================================================================== 
        File name：   	ExcelImport
        Module:                
        Author：        ldwen
        Create Time:	2018-10-22 16:10:22
        Modify By:        
        Modify Date:    
    ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFXK.Common
{
   public class ExcelImport
    {
        public static DataSet ExcelToDS(string Path)
        {
            DataSet ds = null;
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            using (OleDbConnection conn = new OleDbConnection(strConn)) { 
            conn.Open();
            string strExcel ="select * from [sheet1$]";
             OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            }
            return ds;
        }
    }
}
