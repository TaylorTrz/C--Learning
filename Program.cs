using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;

namespace OpenExcel
{
    class program
    {
        static void Main(string[] args)
        {
            //OleDb
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = E:\Desktop\6种调整模式.xlsx; Extended Properties= 'Excel 12.0; HDR=NO; IMEX=0' ";
            string sql = "Select count(*) from [平面非均质$]";
            OleDbConnection con = new OleDbConnection(conString);

            try
            {
               con.Open();
               Console.WriteLine("数据库连接成功");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            OleDbCommand com = new OleDbCommand(sql, con);
            int i = Convert.ToInt32(com.ExecuteScalar());
            Console.WriteLine("{0}", i);
            Console.ReadKey();
            con.Close();
        }
    }
}