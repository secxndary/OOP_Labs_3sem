using System;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            // События для класса Воин
            Warrior warrior = new Warrior(100);
            Console.WriteLine("Класс Воин\nКол-во здоровья: " + warrior.Health);
            warrior.Notify += DisplayMessage;
            warrior.Heal(20);
            Console.WriteLine("Кол-во здоровья: " + warrior.Health);
            warrior.Damage(70);
            Console.WriteLine("Кол-во здоровья: " + warrior.Health);
            warrior.Damage(150);
            Console.WriteLine("Кол-во здоровья: " + warrior.Health);


            // События для класса Некромант
            Necromancer necromancer = new Necromancer(80);
            Console.WriteLine("===================================================");
            Console.WriteLine("Класс Некромант\nКол-во здоровья: " + necromancer.Health);
            necromancer.Notify += DisplayMessage;
            necromancer.Damage(40);
            Console.WriteLine("Кол-во здоровья: " + necromancer.Health);
            necromancer.Heal(100);
            Console.WriteLine("Кол-во здоровья: " + necromancer.Health);
            necromancer.Heal(90);
            Console.WriteLine("Кол-во здоровья: " + necromancer.Health);


            // Методы для строк
            Console.WriteLine("===================================================");
            Console.WriteLine("Обработка методов строк");
            Func<string, string> funcStr;
            string str = "B  . e!  ,  b,    ,r  .  a";
            
            Console.WriteLine($"Исходная строка:        {str}");
            funcStr = StringHandler.RemoveS;
            Console.WriteLine($"Без знаков препинания:  {str = funcStr(str)}");
            funcStr = StringHandler.RemoveSpase;
            Console.WriteLine($"Без пробелов:           {str = funcStr(str)}");
            funcStr = StringHandler.Upper;
            Console.WriteLine($"Заглавными буквами:     {str = funcStr(str)}");
            funcStr = StringHandler.Lower;
            Console.WriteLine($"Строчными буквами:      {str = funcStr(str)}");
            funcStr = StringHandler.AddToString;
            Console.WriteLine($"С добавлением символа:  {str = funcStr(str)}");
        }

        // Обработчик события (вывод в консоль)
        private static void DisplayMessage(object sender, GameEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
