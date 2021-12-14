using System;
using System.Xml.Linq;

namespace OOP_Lab14
{
    class Program
    {
        static void Main(string[] args)
        {

            // Задание 1. Сериализировать и десерализировать через txt, json и xml
            Transformer opt = new Transformer("Optimus", "Prime", 8640);
            Transformer bee = new Transformer("Bumble", "Beezy", 7540);
            Transformer[] transes = { opt, bee };
            Console.WriteLine("\n\t\t    Serializing for object opt:\n");
            CustomSerializer.SerializeAll(opt);


            // Задание 2. Бинарно сериализировать массив объектов
            Console.WriteLine("\n\n\n\t\t Serializing for array of objects:\n");
            foreach (Transformer trans in transes)
            {
                CustomSerializer.SerializeBinary(trans);
                CustomSerializer.DeserializeBinary();
                CustomSerializer.SerializeJSON(trans);
                CustomSerializer.DeserializeJSON();
            }


            // Задание 3. Написать 2 XML-селектора через XPath
            Task3.XPath();


            // Задание 4. Linq to XML
            XDocument xdoc = Task4.CreateXML();     /// создать XML-документ
            Task4.CoutXML(xdoc);                    /// вывести его в консось
            Task4.LinqXML(xdoc);                    /// 2 LINQ-запроса

        }
    }


}
