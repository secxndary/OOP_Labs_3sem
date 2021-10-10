using System;

namespace OOP_Lab6
{
    class Program
    {
        static void Main()
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
    }
}
