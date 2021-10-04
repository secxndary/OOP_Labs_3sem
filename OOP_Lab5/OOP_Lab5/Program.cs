using System;

namespace OOP_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Валера", "Холера");
            p.showInfo();
            Transformer trans = new Transformer("Оптимус", "Прайм", 8777);
            Car c = new Car("Supra", 780);
            Car c1 = new Car("Nissan 240-SX", 630);
            ICarManagement[] vehicle = { trans, c, c1 };
            foreach (ICarManagement item in vehicle)
            {
                p.Drive(item);
            }
        }
    }
}
