using System;
using System.Text;
using System.Linq;

namespace OOP_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 1
            int pInt = 42;
            double pDouble = 32.498;
            bool pBool = false;
            byte pByte = 255;
            ulong pUnLong = 0xFFF;
            Console.WriteLine("Task 1:");
            Console.WriteLine("pInt = {0}", pInt);
            Console.WriteLine("pDouble = {0}", pDouble);
            Console.WriteLine("pBool = {0}", pBool);
            Console.WriteLine("pByte = {0}", pByte);
            Console.WriteLine("pUnLOng = {0}", pUnLong);
            //task 2
            int Not1 = pByte;
            long Not2 = pInt;
            byte Inp1 = (byte)pDouble;
            short Inp2 = (short)pUnLong;
            bool Inp3 = Convert.ToBoolean(pInt);
            Console.WriteLine("\nTask 2:");
            Console.WriteLine("Not1 = {0} [{1}]", Not1, pByte);
            Console.WriteLine("Not2 = {0} [{1}]", Not2, pInt);
            Console.WriteLine("Inp1 = {0} [{1}]", Inp1, pDouble);
            Console.WriteLine("Inp2 = {0} [{1}]", Inp2, pUnLong);
            Console.WriteLine("Inp3 = {0} [{1}]", Inp3, pInt);
            //task 3
            object ob1 = pInt;
            int obInt = (int)ob1;
            Console.WriteLine("\nTask 3:");
            Console.WriteLine("ob1 =  {0}; obInt = {1}", ob1, obInt);
            //task 4
            var notType = 12;
            Console.WriteLine("\nTask 4:");
            Console.WriteLine("notType = {0}", notType);
            //task 5
            int? nullable = null;
            Console.WriteLine("\nTask 5:");
            Console.WriteLine("nullable = {0} (null)\nnullable.HasValue = {1}", nullable, nullable.HasValue);
            //task 6: error bc v6 equals int
            //var v6 = 214;
            //v6 = 21.52;

            //task 7
            string str1 = "hello";
            string str2 = "bye";
            string str3 = "world of c#";
            Console.WriteLine("\nTask 7:");
            Console.WriteLine("is str1 & str2 equal? {0}", String.Compare(str1, str2));
            Console.WriteLine("str1 + str2 = {0}", String.Concat(str1, str2));
            Console.WriteLine("str3 copy: {0}", String.Copy(str3)); //str2 = str3
            Console.WriteLine("str3 on words:");
            foreach (var sub in str3.Split(' '))
            {
                Console.WriteLine($"{sub}");
            }
            Console.WriteLine("substring of str1: {0}", str1.Substring(0,4));
            Console.WriteLine("input substring: " + str3.Substring(0, 6) + str1);
            Console.WriteLine("remove substring: " + str3.Remove(2, 4));
            Console.WriteLine($"interpolation: {str3}");
            //task 8
            string str4 = "";
            string str5 = null;
            Console.WriteLine("\nTask 8:");
            Console.WriteLine("is str4 null? " + string.IsNullOrEmpty(str4));
            Console.WriteLine("is str5 null? " + string.IsNullOrEmpty(str5));
            //task 9
            Console.WriteLine("\nTask 9:");
            StringBuilder sb = new StringBuilder(str3);
            sb.Remove(9, 2);
            Console.WriteLine("remove: " + sb);
            sb.Append("pain");
            Console.WriteLine("append: " + sb);
            sb.Insert(0, "i live in a ");
            Console.WriteLine("insert: " + sb);
            //task 10
            Console.WriteLine("\nTask 10:");
            int[,] array = { { 0, 5, 2, }, { 7, 9, 5 }, { 4, 9, 2 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < array.Length / 3; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            //task 11
            Console.WriteLine("\nTask 11:");
            string[] arrS = { "emae", "krytaya", "laba" };
            foreach (string k in arrS)
                Console.Write($"{k} ");
            Console.WriteLine("length = " + arrS.Length);
            arrS[0] = "blin";
            foreach (string k in arrS)
                Console.Write($"{k} ");
            //task 12
            Console.WriteLine("\n\nTask 12:");
            int[][] arrSt = new int[3][];
            arrSt[0] = new int[2];
            arrSt[1] = new int[3];
            arrSt[2] = new int[4];

            for (int i = 0; i < 2; i++)
            {
                arrSt[0][i] = i + 2;
                Console.Write(arrSt[0][i] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                arrSt[1][i] = i + 9;
                Console.Write(arrSt[1][i] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                arrSt[2][i] = i + 5;
                Console.Write(arrSt[2][i] + "  ");
            }
            //task 13
            var nArr = array;
            var nStr = str3;
            Console.WriteLine("\n\nTask 13:\nnot tip string: " + nStr);
            //task 14
            (int, string, char, string, ulong) cort = (18, "sanya", ')', "secxndary", 16);
            Console.WriteLine("\nTask 14:\n" + cort.Item2 + cort.Item3);
            (var varA, var varB) = (1, "okok"); //raspakovka
            Console.WriteLine(varA);
            Console.WriteLine(varB);
            (int k, byte l) cmpC1 = (12, 43);
            (long z, uint d) cmpC2 = (12, 43);
            Console.WriteLine("is cmpC1 == cmpC2? " + (cmpC1 == cmpC2));
            //task 15
            Console.WriteLine("\nTask 15:");
            void func(int[] arr, string s)
            {
                int max, min, sum;
                char firstC;
                max = arr.Max<int>();
                min = arr.Min<int>();
                sum = arr.Sum();
                firstC = s[0];
                var T = Tuple.Create(max, min, sum, firstC);
                Console.WriteLine(T);
            }
            string strF = "kanye genius";
            int[] arrF = { 1, 2, 3, 4, 5 };
            func(arrF, strF);
            //task 16
            Console.WriteLine("\nTask 16:");
            //checked
            //{
            //    int ch = 2147483647; //max int
            //    Console.WriteLine(ch + 1);
            //}
            unchecked
            {
                int unch = 2147483647; //max int
                Console.WriteLine(unch + 1);
            }
        }
    }
}
