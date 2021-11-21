using System;

namespace OOP_Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            VADLog.WriteLogInfo();
            VADDiskInfo.GetDiskInfo();
            VADFileInfo.GetFileInfo();
            VADDirInfo.GetDirInfo();
            VADFileManager.VADFiles();
            VADFileManager.MakeArchive();
            VADFileManager.VADInspect();
            Console.WriteLine("Логи записаны в файл vadlog.txt");
        }
    }
}
