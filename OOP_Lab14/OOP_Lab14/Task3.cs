using System;
using System.Xml;
using System.IO;

namespace OOP_Lab14
{
    public static class Task3
    {
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();                               
            xDoc.Load(Path.GetFullPath(CustomSerializer.path + @"out.xml"));    /// считать xml-документ из out.xml
            XmlElement xRoot = xDoc.DocumentElement;

            Console.WriteLine("\n\n\n\t\t\t  XPath for XML:\n");
            Console.WriteLine("All child nodes:");                              /// получить все дочерние записи 
            XmlNodeList childNodes = xRoot.SelectNodes("*");                    /// корневого элемента
            foreach (XmlNode n in childNodes)                                   /// и вывести их
                Console.WriteLine(n.OuterXml);

            Console.WriteLine("\nAll <Names> nodes:");                          /// вывести все записи <Name>
            XmlNodeList namesNodes = xRoot.SelectNodes("//Transformer/Name");
            foreach (XmlNode n in namesNodes)                                   /// если что, весь код спизжен с metanit:
                Console.WriteLine(n.InnerText);                                 /// https://metanit.com/sharp/tutorial/16.4.php
        }
    }
}
