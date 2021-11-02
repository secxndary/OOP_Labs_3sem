using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace OOP_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            /// ===============  Инициализация экземпляров Car =================
            Car Lancer = new Car("Mitsubishi Lancer Evo X", 4800);
            Car Nissan350Z = new Car("Nissan 350Z", 19000);
            Car Polo = new Car("Volkswagen Polo", 3900);
            Car MarkII = new Car("Toyota Mark II", 16500);


            /// =========  Методы для работы с коллекцией (словарём)  ==========
            CarDictionary showRoom = new CarDictionary();
            showRoom.Add(1, Lancer);
            showRoom.Add(2, Nissan350Z);
            showRoom.Add(3, Polo);
            showRoom.Add(4, MarkII);
            showRoom.Delete(3);
            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n\t\t     Создание объектов:\n");
            showRoom.Print();
            Console.WriteLine("Автомобиль {0} присутствует в словаре под ключом {1}\n", Nissan350Z.Name, showRoom.Search(Nissan350Z));


            /// ================  Создание обобщённого словаря  ================
            Dictionary<int, int> genDictionary = new Dictionary<int, int>();
            for (int i = 0; i < 8; i++)
                genDictionary.Add(i, i);
            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n\t\tРабота с обощённым словарём:\n");
            Console.WriteLine("Коллекция int в словаре:");
            foreach (KeyValuePair<int, int> item in genDictionary)
                Console.WriteLine("{0}. {1}", item.Key, item.Value);

            Console.WriteLine("\nУдалить n элементов:");
            for (int i = 3; i < 6; i++) 
                genDictionary.Remove(i);
            foreach (KeyValuePair<int, int> item in genDictionary)
                Console.WriteLine("{0}. {1}", item.Key, item.Value);

            Console.WriteLine("\nСловарь, преобразованный в список:");
            List<int> listOfDic = genDictionary.Values.ToList();
            foreach (int item in listOfDic)
                Console.WriteLine(item);

            Console.WriteLine("\nНайти в списке элемент 2:");
            foreach (int item in listOfDic)
                if (item == 2)
                    Console.WriteLine("В списке есть элемент 2\n");


            /// ==============  Создание наблюдаемой коллекции  ================
            ObservableCollection<Car> obsCars = new ObservableCollection<Car>
            {
                new Car("Toyota Corolla", 3800),
                new Car("Nissan 240-SX", 12400),
                new Car("Toyota Supra", 19000)
            };

            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n\t\tСобытия обозреваемой коллекции:\n");

            obsCars.CollectionChanged += Cars_CollectionChanged;

            obsCars.Add(new Car("Mazda RX-8", 4200));
            obsCars.RemoveAt(1);
            obsCars[0] = new Car("Subaru Imprezza", 6400);

            Console.WriteLine("\nИтоговый список:");
            foreach (Car user in obsCars)
                Console.WriteLine(user.Name);

            Console.WriteLine();
            Console.WriteLine(new String('=', 60));
            Console.WriteLine();
        }


        /// =====================  Обработчик события  =========================
        private static void Cars_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Car newCar = e.NewItems[0] as Car;
                    Console.WriteLine($"Добавлен новый объект: {newCar.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Car oldCar = e.OldItems[0] as Car;
                    Console.WriteLine($"Удален объект: {oldCar.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Car replacedCar = e.OldItems[0] as Car;
                    Car replacingCar = e.NewItems[0] as Car;
                    Console.WriteLine($"Объект {replacedCar.Name} заменен объектом {replacingCar.Name}");
                    break;
            }
        }
    }
}

