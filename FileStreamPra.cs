using System;
using System.IO;

namespace Pra
{
    class FileStreamPra
    {
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
    class FileOpen
    {
        public static void main(string[] args)
        {
            // ListFiles(new DirectoryInfo(@"C:\Users\Ted\Desktop"));
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
