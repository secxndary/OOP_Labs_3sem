using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    static class StatisticOperations
    {
        public static int sum(this Array arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.a.Length; i++)
            {
                sum += arr.a[i];
            }
            return sum;
        }
        public static int max(this Array arr)
        {
            int max = -99999;
            foreach (int x in arr.a)
            {
                if (x > max) max = x;
            }
            return max;
        }
        public static int min(this Array arr)
        {
            int min = 999999;
            foreach (int x in arr.a)
            {
                if (x < min) min= x;
            }
            return min;
        }
        public static int delta (this Array arr)
        {
            return Math.Abs(StatisticOperations.max(arr)) - Math.Abs(StatisticOperations.min(arr));
        }
        public static int size(this Array arr)
        {
            return arr.a.Length;
        }



        public static Array nega(this Array arr)
        {
            Array newArr = new Array();
            for (int i = 0; i < arr.a.Length; i++)
            {
                if (arr.a[i] > 0)
                {
                    if (i > 0 && newArr.a[i - 1] == arr.a[i]) { }
                    else
                        newArr.a[i] = arr.a[i];
                }
                else if (arr.a[i] < 0)
                {
                    newArr.a[i] = arr.a[i + 1];
                }
            }
            return newArr;
        }
        public static void hasSymbol(this Array arr, string c)
        {
            int index = arr.str.IndexOf(c);
            if (index == -1)
                Console.WriteLine("Такого символа нет в строке!");
            else Console.WriteLine("Символ " + c + " присутсвует в строке под индексом " + index);
        }
    }
}
