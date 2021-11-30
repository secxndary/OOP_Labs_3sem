using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace OOP_Lab14
{
    [Serializable]
    public class Transformer : IntelligentBeing, ICarManagement
    {
        [NonSerialized] 
        [XmlIgnore]
        public int NonSerialized = 1;
        public string Nickname { get; set; }
        public int Power { get; set; }
        public Transformer() { }
        public Transformer(string name, string nickName, int power)
        {
            Name = name;
            Nickname = nickName;
            Power = power;
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nИмя: " + Name + "\nПрозвище: " +
                Nickname + "\nМощность двигателя: " + Power + "\n" + new String('-', 50);
        }

        public void StartEngine(Engine engine)
        {
            if (engine.TryPowering())
                Console.WriteLine("Трансформер завёлся)");
            else Console.WriteLine("Трансформер слишком стар....");
        }

    }







    public interface ICarManagement
    {
        public void StartEngine(Engine engine);
        public int Power { get; set; }
    }

    public interface IName
    {
        string Name { get { return Name; } set { this.Name = value; } }
    }

    [Serializable]
    public abstract class IntelligentBeing : IName
    {
        public string Name { get; set; }
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
