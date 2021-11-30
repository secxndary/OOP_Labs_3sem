using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;

namespace OOP_Lab14
{
    public static class CustomSerializer
    {
        /// Методы для подключения FileStream для разных типов файлов
        public static FileStream UseFileStreamTXT()
        {
            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab14\OOP_Lab14\out.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }

        public static FileStream UseFileStreamXML()
        {
            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab14\OOP_Lab14\out.xml";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }

        public static FileStream UseFileStreamJSON()
        {
            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab14\OOP_Lab14\out.json";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }

        public static FileStream UseFileStreamSOAP()
        {
            string filePath = @"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab14\OOP_Lab14\out.soap";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }




        /// Сериализация и десерализация в бинарный файл
        public static void SerializeBinary(object obj)
        {
            FileStream fs = UseFileStreamTXT();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static void DeserializeBinary()
        {
            FileStream fs = UseFileStreamTXT();
            BinaryFormatter formatter = new BinaryFormatter();
            Transformer DesOpt = (Transformer)formatter.Deserialize(fs);
            Console.WriteLine("===================   Binary Serialization   ===================");
            Console.WriteLine($"Name: {DesOpt.Name}; Nickname: {DesOpt.Nickname}; " +
                $"Power: {DesOpt.Power}; Nonserialized: {DesOpt.NonSerialized}");
            fs.Close();
        }




        /// Сериализация и десерализация в JSON
        public static void SerializeJSON(Transformer obj)
        {
            FileStream fs = UseFileStreamJSON();
            JsonSerializer.SerializeAsync<Transformer>(fs, obj);
            fs.Close();
        }

        public static async void DeserializeJSON()
        {
            FileStream fs = UseFileStreamJSON();
            Transformer DesOpt = await JsonSerializer.DeserializeAsync<Transformer>(fs);
            Console.WriteLine("\n====================   JSON Serialization   ====================");
            Console.WriteLine($"Name: {DesOpt.Name}; Nickname: {DesOpt.Nickname}; " +
                        $"Power: {DesOpt.Power}; Nonserialized: {DesOpt.NonSerialized}");
            fs.Close();
        }




        /// Сериализация и десерализация в XML
        public static void SerializeXML(object obj)
        {
            FileStream fs = UseFileStreamXML();
            XmlSerializer formatter = new XmlSerializer(typeof(Transformer));
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static void DeserializeXML()
        {
            FileStream fs = UseFileStreamXML();
            XmlSerializer formatter = new XmlSerializer(typeof(Transformer));
            Transformer DesOpt = (Transformer)formatter.Deserialize(fs);

            Console.WriteLine("\n=====================   XML Serialization   ====================");
            Console.WriteLine($"Name: {DesOpt.Name}; Nickname: {DesOpt.Nickname}; " +
                $"Power: {DesOpt.Power}; Nonserialized: {DesOpt.NonSerialized}");
            fs.Close();
        }




        /// Сериализация и десерализация в SOAP
        public static void SerializeSOAP()
        {
            FileStream fs = UseFileStreamSOAP();
            //SoapFormatter formatter = new SoapFormatter();

        }
    }
}
