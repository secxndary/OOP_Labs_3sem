using System;
using System.IO;

namespace OOP_Lab13
{
    public static class VADLog
    {
        public static void WriteLogInfo()               /// запись в файл лога инфы о работе самого логгера
        {
            string logPath = Path.GetFullPath(@"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt");
            using (StreamWriter sw = new StreamWriter(logPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("\n===========================================   VADLog   ===================================================\n");
                sw.WriteLine("Имя файла лога:           " + Path.GetFileName(logPath));
                sw.WriteLine("Полный путь лога:         " + logPath);
                sw.WriteLine("Время записи лога:        " + DateTime.Now);
            }

        }


        public static void WriteInLog(string message)   /// запись в файл лога инфы из остальных классов
        {
            string logPath = Path.GetFullPath(@"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt");
            using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
                sw.WriteLine(message);
        }



        public static string ReadLog()
        {
            string logPath = Path.GetFullPath(@"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt");
            StreamReader sr = new StreamReader(logPath);
            return sr.ReadToEnd();
        }


        public static void SearchLog()
        {
            string logPath = Path.GetFullPath(@"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt");
            string logFile = VADLog.ReadLog();                                  /// string с самим логом полностью
            FileInfo logFileInfo = new FileInfo(logPath);
            DateTime lastHour = DateTime.Now;
            lastHour.AddHours(-1);                                              /// записи за последний час

            if (logFileInfo.LastWriteTime < lastHour)                           /// выводим только записи за час
            {
                string writes = "\n=";                                          /// подстрока, считающая кол-во записей
                int i = 0, j = -1, count = -1;
                while (i != -1)                                                 /// механизм подсчета вхождений подстроки
                {
                    i = logFile.IndexOf(writes, j + 1);
                    j = i;
                    count++;
                }

                Console.WriteLine("Записей за текущий час: " + (count - 1));    /// -1 т.к. в конце есть еще одна "\n="
                Console.WriteLine("Вывод этих записей: ");
                Console.WriteLine(logFile);
            }
        }

    }
}
