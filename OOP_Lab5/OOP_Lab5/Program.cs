using System;

namespace OOP_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Валера", "Холера");
            Transformer t = new Transformer("Оптимус", "Прайм", 8777);
            Car c = new Car("Supra", 780);
            Car cClone = new Car("Supra", 780);
            Car c1 = new Car("Nissan 240-SX", 630);
            Tank t1 = new Tank("Panzerkampfwagen IV", 1200);

            Console.WriteLine(p.ToString());
            ICarManagement[] vehicle = { t, c, c1, t1 };
            foreach (ICarManagement item in vehicle)
            {
                p.Drive(item);
                Console.WriteLine(item.ToString());
            }

            object bIs = new Bike("Аист", 30, "Вепрь");
            if (bIs is Bike)
            {
                Console.WriteLine("\nОбъект преобразуем к типу Bike.");
            }
            else Console.WriteLine("Преобразование прошло не успешно.");
            Bike bAs = c as Bike;
            if (bAs == null) Console.WriteLine("Преобразование прошло не успешно.");
            else Console.WriteLine(bAs.Company);

            ICloneable user1 = new User();
            user1.DoClone();
            BaseClone user2 = new User();
            user2.DoClone(false);

            if (c.Equals(cClone))
                Console.WriteLine("\nМашины идентичны\n");
            else Console.WriteLine("\nМашины не идентичны\n");

            Printer print = new Printer();
            Console.WriteLine(print.IAmPrinting(c)); 
            Console.WriteLine(print.IAmPrinting(t1)); 
        }
    }
}
