using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab12
{
 
    public abstract class Vehicle : ICarManagement, IName
    {
        public int Tires { get; set; }
        public int Power { get; set; }

        public virtual void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Получилось! Двигатель завёлся!");
            else Console.WriteLine("Завестись не получилось...");
        }

        public override bool Equals(object obj)
        {
            if (obj is Vehicle && obj != null)
            {
                return this.GetType() == obj.GetType();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 10654;
        }

    }





    public class Car : Vehicle, IName
    {
        public string Name { get; set; }

        public Car(string name, int power)
        {
            Tires = 4;
            Name = name;
            Power = power;
        }

        public Car()
        {
            Tires = 4;
            Name = "Unknown name";
            Power = 666;
        }

        public override void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Машина стартанула! Поехали!");
            else Console.WriteLine("Не заводится... Ты точно сцепление выжал?");
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание машины: " + Name + "\nМощность двигателя: " + Power + "\nКол-во колёс: " + Tires + "\n" + new String('-', 50);
        }

        public void Lab12Method(string name, int power)
        {
            Console.WriteLine($"Название: {name}; Мощность: {power}");
        }
    }




    public class Engine
    {
        public Engine() {  }
        public bool TryPowering()
        {
            var rand = new Random();
            bool result = rand.Next(2) == 1;
            Console.WriteLine("Попытка завести двигатель: " + result);
            return result;
        }
    }


}
