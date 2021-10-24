using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Lab8
{
    class Program
    {
        static void Main(string[] args)
        {

            // =======  Создание экземпляров обработчиков ошибок в файле и в консоли  ========
            FileLogger fileLogger = new FileLogger();
            ConsoleLogger consoleLogger = new ConsoleLogger();


            try
            {
                // ================  Создание коллекций  ================
                CollectionType<int> intCollection = new CollectionType<int>();
                CollectionType<int> intCollection2 = new CollectionType<int>();
                CollectionType<int> intCollectionOut = new CollectionType<int>();

                CollectionType<string> strCollection = new CollectionType<string>();
                CollectionType<string> strCollection2 = new CollectionType<string>();
                CollectionType<string> strCollectionOut = new CollectionType<string>();

                CollectionType<Car> carCollection = new CollectionType<Car>();
                CollectionType<Car> carCollection2 = new CollectionType<Car>();
                CollectionType<Car> carCollectionOut = new CollectionType<Car>();


                // ===================  Чтение из файла ====================
                string[] lines = File.ReadAllLines(@"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab8\OOP_Lab8\in.txt");
                string[] strInt1 = lines[0].Split(' ');
                string[] strInt2 = lines[1].Split(' ');
                string[] str1 = lines[2].Split(' ');
                string[] str2 = lines[3].Split(' ');
                int[] int1 = { 0, 0, 0 };
                int[] int2 = { 0, 0, 0 };
                for (int i = 0; i < strInt1.Length; i++)
                    int1[i] = Int32.Parse(strInt1[i]);
                for (int i = 0; i < strInt2.Length; i++)
                    int2[i] = Int32.Parse(strInt2[i]);


                // ==============  Создание объектов и списков  ==============
                Car car1 = new Car("Toyota Supra", 680);
                Car car2 = new Car("Nissan 240-SX", 600);
                Car car3 = new Car("Mitsubishi Lancer Evo", 480);
                Car car4 = new Car("Nissan 350Z", 550);

                List<int> listInt = new List<int>() { int1[0], int1[1], int1[2] };
                List<int> listInt2 = new List<int>() { int2[0], int2[1], int2[2] };
                List<string> listStr = new List<string>() { str1[0], str1[1], str1[2] };
                List<string> listStr2 = new List<string>() { str2[0], str2[1], str2[2] };
                List<Car> carList = new List<Car>() { car1, car2 };
                List<Car> carList2 = new List<Car>() { car3, car4 };


                // ==================  Вывод коллекций ===================
                Console.WriteLine("\n=============  Коллекции  =============\n");
                intCollection.enterData(listInt);
                Console.WriteLine("Коллекция int #1:");
                intCollection.printData();
                intCollection2.enterData(listInt2);
                Console.WriteLine("Коллекция int #2:");
                intCollection2.printData();
                strCollection.enterData(listStr);
                Console.WriteLine("Коллекция string #1:");
                strCollection.printData();
                strCollection2.enterData(listStr2);
                Console.WriteLine("Коллекция string #2:");
                strCollection2.printData();
                carCollection.enterData(carList);
                Console.WriteLine("Коллекция Car #1:");
                carCollection.printData();
                carCollection2.enterData(carList2);
                Console.WriteLine("Коллекция Car #2:");
                carCollection2.printData();


                // ===================  Перегрузки ===================
                Console.WriteLine("\n\n\n============  Перегрузка *  ============");
                intCollectionOut = intCollection * intCollection2;
                intCollectionOut.printData();
                strCollectionOut = strCollection * strCollection2;
                strCollectionOut.printData();
                carCollectionOut = carCollection * carCollection2;
                carCollectionOut.printData();


                Console.WriteLine("\n\n============  Перегрузка >  ============\n");
                if (intCollection > intCollection2)
                    Console.WriteLine("Коллекция int #1 > Коллекция int #2");
                else
                    Console.WriteLine("Коллекция int #1 < Коллекция int #2");
                if (strCollectionOut < strCollection)
                    Console.WriteLine("Коллекция string #1 > Коллекция stringOut");
                else
                    Console.WriteLine("Коллекция string #1 < Коллекция stringOut");
                if (carCollection > carCollection2)
                    Console.WriteLine("Коллекция Car #1 > Коллекция Car #2");
                else
                    Console.WriteLine("Коллекция Car #1 < Коллекция Car #2");


                Console.WriteLine("\n\n\n\n==========  Перегрузка true  ===========\n");
                if (intCollection) Console.WriteLine("Коллекция int вернула true");
                else Console.WriteLine("Коллекция int вернула false");
                if (strCollection) Console.WriteLine("Коллекция string вернула true");
                else Console.WriteLine("Коллекция string вернула false");
                if (carCollection2) Console.WriteLine("Коллекция car вернула true");
                else Console.WriteLine("Коллекция Car вернула false");


                Console.WriteLine("\n\n\n\n===========  Перегрузка ==  ============\n");
                if (intCollection == intCollection2) Console.WriteLine("Коллекции int равны");
                else Console.WriteLine("Коллекции int не равны");
                if (strCollection == strCollection2) Console.WriteLine("Коллекции string равны");
                else Console.WriteLine("Коллекции string не равны");
                if (carCollection == carCollection2) Console.WriteLine("Коллекции Car равны");
                else Console.WriteLine("Коллекции Car не равны");
                Console.WriteLine("\n");
            }


            // ==========  Отлавливание ошибок через логгер в консоль и в файл  ============
            catch (MyException ex)
            {
                consoleLogger.WriteLog(ex);
            }
            finally { }
        }
    }
}

