using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab8
{
    public class ConsoleLogger
    {
        public ConsoleLogger() { }
        public void WriteLog(MyException exception)
        {
            PowerException PowerEx = exception as PowerException;
            NameException NameEx = exception as NameException;

            Console.WriteLine("\n" + DateTime.Now);

            if (PowerEx != null)
            {
                Console.WriteLine("{0}{1} {2}", PowerEx.ErrorClass, PowerEx.Message, PowerEx.Power);
            }
            if (NameEx != null)
            {
                Console.WriteLine("{0}{1} {2}", NameEx.ErrorClass, NameEx.Message, NameEx.Name);
            }
        }
    }


    public class FileLogger
    {
        public FileLogger() { }
        public void WriteLog(MyException exception)
        {
            PowerException PowerEx = exception as PowerException;
            NameException NameEx = exception as NameException;

            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab8\OOP_Lab8\log.txt";
            using StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default);
            streamWriter.WriteLine(DateTime.Now);

            if (PowerEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", PowerEx.ErrorClass, PowerEx.Message, PowerEx.Power);
            }
            if (NameEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", NameEx.ErrorClass, NameEx.Message, NameEx.Name);
            }
        }
    }
}
