using System;
using System.IO;

namespace FIleWriteAndRead
{
    class Program
    {
        static void Main(string[] args)
        {
            LogToFiles("wo wo wow", true, true);
            Console.ReadKey() ;
        }

        public static string logName = @"E:\desktop\aaa.txt";

        public static void LogToFiles(string sth, bool IfWriteTime, bool IfChangeLine)
        {
            if (sth == null)
                return;

            try
            {
                StreamWriter writeLog = new StreamWriter(logName, true, System.Text.Encoding.Default);
                //GBK国标编码包含所有中文字符、每个字符2个字节，UTF-8国际编码包含全世界所有国家字符、每个英文只一个字节
                if (IfWriteTime == true)
                    writeLog.WriteLine("\r\b\r\n-----" + DateTime.Now + "-----" +DateTime.Now.ToString());
                if (IfChangeLine == true)
                    writeLog.WriteLine(sth);
                else
                    writeLog.Write(sth);

                writeLog.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }


}
