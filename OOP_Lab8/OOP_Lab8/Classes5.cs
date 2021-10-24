using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab8
{
    public interface IName
    {
        string Name { get { return Name; } set { this.Name = value; } }
    }

    public interface ICarManagement
    {
        public void StartEngine(Engine engine);
        public int Power { get; set; }
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
            this.Tires = 4;
            if (name.Length < 4) throw new NameException("Оишбка! Неверно введено название:", name);
            this.Name = name;
            if (power < 0) throw new PowerException("Ошибка! Неверно введена мощность:", power);
            this.Power = power;
        }

        public override void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Машина стартанула! Поехали!");
            else Console.WriteLine("Не заводится... Ты точно сцепление выжал?");
        }

        public override string ToString()
        {
            return "\nНазвание машины: " + Name + "\nМощность двигателя: " + Power + " л.с.";
        }
    }
}
