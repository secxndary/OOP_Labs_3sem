using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_Lab10
{
    public class Car : IComparable<Car>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(Car obj)
        {
            return Price.CompareTo(obj);
        }

        public void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Машина стартанула! Поехали!");
            else Console.WriteLine("Не заводится... Ты точно сцепление выжал?");
        }
    }


    public class CarDictionary
    {
        public Dictionary<int, Car> list { get; set; }
        public CarDictionary()
        {
            list = new Dictionary<int, Car>();
        }
        public void Print()
        {
            foreach (KeyValuePair<int, Car> item in list)
                Console.WriteLine("{0}. {1} – {2}$", item.Key, item.Value.Name, item.Value.Price);
        }
        public void Add(int key, Car value)
        {
            list.Add(key, value);
        }
        public void Delete(int key)
        {
            list.Remove(key);
        }
        public int Search(Car carSearch)
        {
            var myKey = list.FirstOrDefault(x => x.Value == carSearch).Key;
            return myKey;
        }
    }




    public class Engine
    {
        public bool TryPowering()
        {
            var rand = new Random();
            bool result = rand.Next(2) == 1;
            Console.WriteLine("Попытка завести двигатель: " + result);
            return result;
        }
    }
}
