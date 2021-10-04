using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5
{
    interface IName
    {
        string Name { get { return Name; } set { this.Name = value; } }
        void showInfo();
    }
    public abstract class IntelligentBeing: IName
    {
        public string Name { get; set; }
        public virtual void showInfo()
        {
            Console.WriteLine("Имя: " + Name);
        }
    }

    public class Person: IntelligentBeing, IDrive
    {
        public string LastName { get; set; }

        public Person(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }

        public override void showInfo()
        {
            Console.WriteLine("Имя: " + Name);
            Console.WriteLine("Фамилия: " + LastName);
            Console.WriteLine(new String('-', 30));
        }

        public void Drive(ICarManagement carManagement)
        {
            carManagement.StartEngine(new Engine());
        }
    }
    public class Transformer : IntelligentBeing, ICarManagement
    {
        public string Nickname { get; set; }
        public int Power { get; set; }
        public Transformer(string name, string nickName, int power)
        {
            this.Name = name;
            this.Nickname = nickName;
            this.Power = power;
        }
        public override void showInfo()
        {
            Console.WriteLine("Имя: " + Name);
            Console.WriteLine("Прозвище: " + Nickname);
            Console.WriteLine("Мощность двигателя: " + Power);
            Console.WriteLine(new String('-', 30));

        }
        public void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Трансформер завёлся)");
            else Console.WriteLine("Он слишком стар....");
        }

    }

    public interface IDrive
    {
        public void Drive(ICarManagement carManagement);
    }

    public interface ICarManagement
    {
        public void StartEngine(Engine engine);
        public int Power { get; set; }
    }

    public abstract class Vehicle: ICarManagement
    {
        public int Tires { get; set; }
        public int Power { get; set; }

        public void StartEngine(Engine engine) 
        {
            if (engine.TryPowering())
                Console.WriteLine("Получилось! Двигатель завёлся!");
            else Console.WriteLine("Завестись не получилось...");
        }
    }

    public class Car: Vehicle, IName
    {
        public string Name { get; set; }
       
        public Car(string name, int power)
        {
            this.Tires = 4;
            this.Name = name;
            this.Power = power;
        }

        public  void showInfo()
        {
            Console.WriteLine("Название машины: " + Name);
            Console.WriteLine("Мощность двигателя: " + Power);
            Console.WriteLine("Кол-во колёс: " + Tires);
            Console.WriteLine(new String('-', 30));
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
