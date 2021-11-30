using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace OOP_Lab14
{
    public static class Task4
    {
        public static XDocument CreateXML()
        {
            XDocument xdoc = new XDocument(new XElement("phones",                   /// создаем новый идентичный xml-документ
                new XElement("phone",
                    new XAttribute("name", "iPhone 13"),
                    new XElement("company", "Apple"),
                    new XElement("price", "1999$")),
                new XElement("phone",
                    new XAttribute("name", "Pixel 5A"),
                    new XElement("company", "Google"),
                    new XElement("price", "1499$"))));
            xdoc.Save(Path.GetFullPath(CustomSerializer.path + @"phones.xml"));     /// и сохраняем его уже в phones.xml
            return xdoc;
        }


        public static void CoutXML(XDocument xdoc)                                  /// вывести весь xml на экран
        {
            Console.WriteLine("\n\n\t\t\t   Linq to XML:");
            foreach (XElement phoneElement in xdoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
        }


        public static void LinqXML(XDocument xdoc)
        {
            var items = from xe in xdoc.Element("phones").Elements("phone")         /// linq-запрос для создания экземпляра 
                        where xe.Element("company").Value == "Google"               /// класса Phone и заполнения его 
                        select new Phone                                            /// выбранной по запросу инфой
                        {                                                           /// из phones.xml (где company = Google)
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");


            var items1 = from xe in xdoc.Element("phones").Elements("phone")        /// еще один запрос, по которому выводим
                         where xe.Element("price").Value == "1999$"                 /// телефоны с ценой 1999$ (price = 1999$)
                         select new Phone
                         {
                             Name = xe.Attribute("name").Value,
                             Price = xe.Element("price").Value
                         };

            foreach (var item in items1)                                            /// это тоже построчно спизженно с metanit:
                Console.WriteLine($"{item.Name} - {item.Price}");                   /// https://metanit.com/sharp/tutorial/16.6.php
        }
    }



    /// Класс Phone для работы Linq to XML
    public class Phone
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
