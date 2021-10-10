using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6
{

    public abstract class IntelligentBeing : IName
    {
        public string Name { get; set; }
        public Date Date;
    }

    public class Person : IntelligentBeing, IDrive
    {
        public string LastName { get; set; }

        public Person(string name, string lastName, Date date)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Date = date;
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nИмя: " + Name + "\nФамилия: " + LastName + "\nДата рождения: " + Date + "\n" + new String('-', 50);
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
        public Transformer(string name, string nickName, Date date, int power)
        {
            this.Name = name;
            this.Nickname = nickName;
            this.Date = date;
            this.Power = power;
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nИмя: " + Name + "\nПрозвище: " + Nickname + "\nДата создания: " + Date + "\nМощность двигателя: " + Power + "\n" + new String('-', 50);
        }
        public void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Трансформер завёлся)");
            else Console.WriteLine("Трансформер слишком стар....");
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
            this.Name = name;
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
            return "Тип объекта: " + GetType().Name + "\nНазвание машины: " + Name + "\nМощность двигателя: " + Power + "\nКол-во колёс: " + Tires + "\n" + new String('-', 50);
        }
    }

    public class Tank : Vehicle, IName
    {
        public string Name { get; set; }

        public Tank(string name, int power)
        {
            this.Tires = 16;
            this.Name = name;
            this.Power = power;
        }
        public override void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("ТАНК ЗАВЕЛСЯ ВСЕМ ПИЗДА");
            else Console.WriteLine("С танком проблемы. Может попробовать завести трансформера)?");
        }
        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание танка: " + Name + "\nМощность двигателя: " + Power + "\nКол-во колёс: " + Tires + "\n" + new String('-', 50);
        }
    }

    public class Bike : Car, IName
    {
        public string Company { get; set; }
        public Bike(string name, int power, string company) : base(name, power)
        {
            this.Tires = 2;
            this.Company = company;
        }
    }


    public class Printer
    {
        public string IAmPrinting(Vehicle obj)
        {
            if (obj is Car)
            {
                Car c = (Car)obj;
                return "Тип объекта: " + c.GetType().Name + "\nНазвание машины: " + c.Name + "\nМощность двигателя: " + c.Power + "\nКол-во колёс: " + c.Tires + "\n" + new String('-', 50);
            }
            if (obj is Tank)
            {
                Tank t = (Tank)obj;
                return "Тип объекта: " + t.GetType().Name + "\nНазвание танка: " + t.Name + "\nМощность двигателя: " + t.Power + "\nКол-во колёс: " + t.Tires + "\n" + new String('-', 50);
            }
            if (obj is Bike)
            {
                Bike b = (Bike)obj;
                return "Тип объекта: " + b.GetType().Name + "\nНазвание байка: " + b.Name + "\nМощность двигателя: " + b.Power + "\nКол-во колёс: " + b.Tires + "\n" + new String('-', 50);
            }
            return "Объект не соответствует необходимому типу объекта.";
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
