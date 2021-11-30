using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Transformer opt = new Transformer("Optimus", "Prime", 8640);

            CustomSerializer.SerializeBinary(opt);
            CustomSerializer.DeserializeBinary();

            CustomSerializer.SerializeJSON(opt);
            CustomSerializer.DeserializeJSON();

            CustomSerializer.SerializeXML(opt);
            CustomSerializer.DeserializeXML();


        }
    }
}
