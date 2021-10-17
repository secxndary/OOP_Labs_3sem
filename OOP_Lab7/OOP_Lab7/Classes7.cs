using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab7
{
    public class MyException : System.Exception
    {
        public string ErrorClass { get; set; }
        public MyException(string message, string errorClass)
            : base(message)  // наследуем message от System.Exception
        {
            this.ErrorClass = errorClass;
        }
    }

    public class DateException : MyException
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateException(string message, int errorDay, int errorMonth, int errorYear)
            : base(message, "Error code 1: Uncorrect date.\n")  // наследуем message и errorClass от MyException
        {
            this.Day = errorDay;
            this.Month = errorMonth;
            this.Year = errorYear;
        }
    }

    public class PowerException : MyException
    {
        public int Power { get; set; }
        public PowerException(string message, int errorPower)
            : base(message, "Error code 2: Uncorrect power.\n")
        {
            this.Power = errorPower;
        }
    }

    public class SearchPowerException : MyException
    {
        public int Power { get; set; }
        public SearchPowerException(string message, int errorPower)
            : base(message, "Error code 3: Uncorrect power input for search.\n")
        {
            this.Power = errorPower;
        }
    }

    public class NameException : MyException
    {
        public string Name { get; set; }
        public NameException(string message, string errorName)
            : base(message, "Error code 4: Uncorrect name.\n")
        {
            this.Name = errorName;
        }
    }

    public class FileLogger
    {
        public FileLogger() { }
        public void WriteLog(MyException exception)
        {
            DateException DateEx = exception as DateException;
            PowerException PowerEx = exception as PowerException;
            SearchPowerException SearchEx = exception as SearchPowerException;
            NameException NameEx = exception as NameException;

            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab7\OOP_Lab7\log.txt";
            using StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default);
            streamWriter.WriteLine(DateTime.Now);
            if (DateEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}.{3}.{4}", DateEx.ErrorClass, DateEx.Message, DateEx.Day, DateEx.Month, DateEx.Year); ;
            }
            if (PowerEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", PowerEx.ErrorClass, PowerEx.Message, PowerEx.Power);
            }
            if (SearchEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", SearchEx.ErrorClass, SearchEx.Message, SearchEx.Power);
            }
            if (NameEx != null)
            {
                streamWriter.WriteLine("{0}{1} {2}", NameEx.ErrorClass, NameEx.Message, NameEx.Name);
            }
        }
    }

    public class ConsoleLogger
    {
        public ConsoleLogger() { }
        public void WriteLog(MyException exception)
        {
            DateException DateEx = exception as DateException;
            PowerException PowerEx = exception as PowerException;
            SearchPowerException SearchEx = exception as SearchPowerException;
            NameException NameEx = exception as NameException;

            Console.WriteLine("\n" + DateTime.Now);
            if (DateEx != null)
            {
                Console.WriteLine("{0}{1} {2}.{3}.{4}", DateEx.ErrorClass, DateEx.Message, DateEx.Day, DateEx.Month, DateEx.Year); ;
            }
            if (PowerEx != null)
            {
                Console.WriteLine("{0}{1} {2}", PowerEx.ErrorClass, PowerEx.Message, PowerEx.Power);
            }
            if (SearchEx != null)
            {
                Console.WriteLine("{0}{1} {2}", SearchEx.ErrorClass, SearchEx.Message, SearchEx.Power);
            }
            if (NameEx != null)
            {
                Console.WriteLine("{0}{1} {2}", NameEx.ErrorClass, NameEx.Message, NameEx.Name);
            }
        }
    }
}
