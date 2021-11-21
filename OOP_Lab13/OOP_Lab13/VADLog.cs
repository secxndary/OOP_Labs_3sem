using System;
using System.IO;

namespace OOP_Lab13
{
    public static class VADLog
    {
        public static void WriteLogInfo()               /// запись в файл лога инфы о работе самого логгера
        {
            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt";
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("VADLog:\n");
                sw.WriteLine("Имя файла лога:       " + Path.GetFileName(filePath));
                sw.WriteLine("Полный путь лога:     " + filePath);
                sw.WriteLine("Время записи лога:    " + DateTime.Now);
            }

        }

        public static void WriteInLog(string message)   /// запись в файл лога инфы из остальных классов
        {
            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt";
            using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                sw.WriteLine(message);
        }



        public static void ReadLog()
        {

        }

        public static void SearchLog()
        {

        }
    }
}
