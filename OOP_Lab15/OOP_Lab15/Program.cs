using System;
using System.Threading;
using System.Diagnostics;

namespace OOP_Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            var allProcesses = Process.GetProcesses();
            foreach (var proc in allProcesses)
            {
                Console.WriteLine("ID: " + proc.Id);
                Console.WriteLine("Name: " + proc.ProcessName);
                Console.WriteLine();
            }
        }
    }
}
