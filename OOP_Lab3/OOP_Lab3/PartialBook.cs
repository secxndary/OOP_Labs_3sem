using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3
{
    partial class Book              // МЕТОДЫ
    {

        // Метод вывода полей
        public void PrintInfo()
        {
            Console.WriteLine("===========================================\n\tid: {0}\n\tНазвание: {1}\n\tАвтор: {2}\n\t" +
                "Издательство: {3}\n\tТип переплёта: {4}\n\tГод выпуска: {5}\n\tКол-во страниц: {6}\n\tЦена: {7} р.\n" +
                "===========================================", id, name, author, publisher, type, year, pages, price);
        }


        // Метод получения хеша + ограничение доступа к get
        public int GetHashCode()
        {
            return (int)(price * PC.HashCode());
        }


        // Статический метод вывода информации о классе
        public static void TypeOfClass()
        {
            Type tp = Type.GetType("OOP_Lab3.Book");
            Console.WriteLine("\n\n  Тип класса Book:");
            Console.WriteLine(tp.AssemblyQualifiedName);
        }


        // Метод изменения и проверки цены
        public void ChangePrice(ref int delta)
        {
            if ((price + delta) < 0)
                Console.WriteLine("   Ошибка! Цена меньше 0.");
            else if ((price + delta) > 9999)
                Console.WriteLine("   Ошибка! Неверная цена.");
            else price += delta;
        }


        // Метод сравнения объектов
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Book b = obj as Book;
            if (b == null)
                return false;
            return this.name == b.name && this.author == b.author && this.publisher == b.publisher &&
            this.type == b.type && this.year == b.year && this.price == b.price && this.pages == b.pages;
        }


        // Метод вывода строки
        public override string ToString()
        {
            return $"Название: {Name}; Автор: {Author}; Издательство: {Publisher}";
        }
    }



    // Закрытый класс
    partial class PC
    {
        private PC() { }
        public const short hash = 10564;
        public static short HashCode()
        {
            return hash;
        }

    }
}
