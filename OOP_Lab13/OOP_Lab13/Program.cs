using System;

namespace OOP_Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                VADLog.WriteLogInfo();
                VADDiskInfo.GetDiskInfo();
                VADFileInfo.GetFileInfo();
                VADDirInfo.GetDirInfo();
                VADFileManager.VADFiles();
                VADFileManager.MakeArchive();
                VADFileManager.VADInspect();

                VADLog.ReadLog();
                VADLog.SearchLog();
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Ошибка! Директорий не найден.\n" + e.Message + 
                                  "\nОбратиться за помощью: vk.com/cyberbastardim");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Ошибка! Файл уже существует или используется другим процессом.\n" +
                                  e.Message + "\nОбратиться за помощью: vk.com/cyberbastardim");
            }
            catch (Exception e)
            {
                Console.WriteLine("Непредвиденная ошибка!\n" + e.Message + 
                                  "\nОбратиться за помощью: vk.com/cyberbastardim");
            }
        }
    }
}
