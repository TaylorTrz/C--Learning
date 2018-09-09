using System;
using System.IO;

namespace FileOpen
{
    class FileStreamPra
    {
        public static void Main(string[] args)
        {
            ListFiles(new DirectoryInfo(@"E:\Desktop"));
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }


        public static void ListFiles(FileSystemInfo info)
        {
            if (!info.Exists) return;

            DirectoryInfo dir = info as DirectoryInfo;
            if (dir == null) return;

            FileSystemInfo[] files = dir.GetFileSystemInfos(); // base of FileInfo and DirectoryInfo
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                if (file != null)
                {
                    Console.WriteLine(file.FullName + "\t" + file.Length);
                }
                else
                {
                    ListFiles(files[i]);
                }
            }
        }
    }
}
