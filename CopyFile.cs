using System;
using System.IO;

namespace CopyFileAndAddLineNumber
{
    public class CopyFileAndAddLineNumber
    {
        //string fiName = "CopyFile.cs";
        //string foutName = "CopyFile2.txt";
        string fiName;
        string foutName;

        public CopyFileAndAddLineNumber(string _fiName, string _foutName)
        {
            this.fiName = _fiName;
            this.foutName = _foutName;

         }

        FileStream fin = new FileStream("CopyFile.cs", FileMode.Open, FileAccess.Read);   //Error: 字段初始值设定项无法引用非静态字段、方法或属性  solution:变量或者类在定义时不能直接引用变量或者类
        FileStream fout = new FileStream("CopyFile2.txt", FileMode.Create, FileAccess.Write);

        public void CopyFile(bool reaDy)
        {
            if (!reaDy)
                return;

            StreamReader fi = new StreamReader(fin, System.Text.Encoding.Default);
            StreamWriter fo = new StreamWriter(fout, System.Text.Encoding.Default);  //GBK

            string str = fi.ReadLine();
            if (str == null)
                return;

            int lineNumber = 1;
            while (str != null)
            {
                str = DeleteComments(str);
                fo.WriteLine(lineNumber + "\t" + str);
                Console.WriteLine(lineNumber + "\t" + str);
                str = fi.ReadLine();
                lineNumber++;
            }

            fi.Close();
            fo.Close();
        }

        public string DeleteComments(string str)
        {

            int cnt = str.IndexOf("//");   //delete words behind //
            if (cnt > -1)
                return str.Substring(0, cnt);
            else
                return str;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string fiName = "CopyFile.cs";
            string foutName = "CopyFile2.txt";
            if (args.Length >= 1) fiName = args[0];
            if (args.Length >= 2) foutName = args[1];

            CopyFileAndAddLineNumber CFAALN = new CopyFileAndAddLineNumber(fiName, foutName);
            CFAALN.CopyFile(true);


            Console.ReadKey();

        }
    }
}
