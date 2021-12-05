using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace OOP_Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1. Процессы и информация о них
            var allProcesses = Process.GetProcesses();
            Console.WriteLine("Информация о процессах:");
            Console.Write("{0,-20}", "ID:");
            Console.Write("{0,-70}", "Process Name:");
            Console.Write("{0,-20}", "Priority:\n");
            foreach (Process process in allProcesses)
            {
                Console.Write("{0,-20}", $"{process.Id}");
                Console.Write("{0,-70}", $"{process.ProcessName}");
                Console.Write("{0,-20}", $"{process.BasePriority}");
                Console.WriteLine();
            }



            // Задание 2. Исследование текущего домена
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("\n\n\n\nТекущий домен:         " + domain.FriendlyName);
            Console.WriteLine("Базовый каталог:       " + domain.BaseDirectory);
            Console.WriteLine("Детали конфигурации:   " + domain.SetupInformation);
            Console.WriteLine("Все сборки в домене:\n");
            foreach (Assembly ass in domain.GetAssemblies())
                Console.WriteLine(ass.GetName().Name);



            // Задание 3. Вывод простых чисел от 1 до n
            Thread simpleThread = new Thread(SimpleNumbers);
            simpleThread.Start();
            Console.WriteLine("\n\n\nИнформация о потоке:");
            Console.WriteLine("Выполняется ли поток: " + simpleThread.IsAlive);
            Console.WriteLine("Приоритет потока: " + simpleThread.Priority);
            Console.WriteLine("Идентификатор: " + simpleThread.ManagedThreadId);
            simpleThread.Join();


            // Задание 4. Два потока четных и нечетных чисел
            Console.WriteLine("\n\n\nЧётные числа:");
            Thread evenThread = new Thread(EvenNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;
            evenThread.Start();
            evenThread.Join();

            Console.WriteLine("\nНечётные числа:");
            Thread oddThread = new Thread(OddNumbers);
            oddThread.Priority = ThreadPriority.BelowNormal;
            oddThread.Start();
            oddThread.Join();

            
        }




        public static void SimpleNumbers()
        {
            Thread.Sleep(1);
            Console.WriteLine("\nВведите n: ");
            int n = int.Parse(Console.ReadLine());
            for (var i = 1; i <= n; i++)
            {
                var isSimple = true;
                for (var j = 2; j <= i / 2; j++)
                    if (i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }

                if (isSimple)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }

        public static void EvenNumbers()
        {
            for (int i = 0; i <= 19; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }

        

        public static void OddNumbers()
        {
            for (int i = 0; i <= 19; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
