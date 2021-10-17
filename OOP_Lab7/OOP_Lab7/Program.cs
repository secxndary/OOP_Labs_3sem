using System;

namespace OOP_Lab7
{
    class Program
    {
        static void Main()
        {
            FileLogger fileLogger = new FileLogger();
            ConsoleLogger consoleLogger = new ConsoleLogger();
            try
            {
                ArmyController army = new ArmyController();
                Transformer Optimus = new Transformer("Оптимус", "Прайм", new Date(10, 12, 1455), 8700);
                Person Antoxa = new Person("Антон", "Димитриади", new Date(15, 9, 2002));
                army.Add(Optimus);
                army.Add(Antoxa);
                army.Display();
                army.Count();
                army.SearchDate(new Date(15, 9, 2002));
                army.SearchPower(8700);
            }
            catch (MyException ex)
            {
                fileLogger.WriteLog(ex);
            }
            finally { }
        }
    }
}
