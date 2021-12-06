using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace OOP_Lab15
{
    public static class Methods
    {
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



        public static void Task5(object obj)
        {
            Console.WriteLine("\nздарова заебал");
        }
    }
}
