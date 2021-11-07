using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab11
{
    public class Book
    {

        // Поля
        public readonly int id;
        string name;
        string author;
        string publisher;
        public string type;
        public short year;
        public short pages;
        public double price;
        public static short numberOfBooks = 0;


        // Конструкторы с проверкой правильности установленных данных
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(name))
                    name = value;
                else Console.WriteLine("Ошибка! Неверное название книги.");
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (!String.IsNullOrEmpty(author))
                    author = value;
                else Console.WriteLine("Ошибка! Неверное имя автора.");
            }
        }
        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                if (!String.IsNullOrEmpty(author))
                    publisher = value;
                else Console.WriteLine("Ошибка! Неверное название издательства.");
            }
        }


        // Конструктор по умолчанию
        public Book()
        {
            name = "Random book";
            year = 1919;
            price = 11.99;
            id = GetHashCode();
            numberOfBooks++;
        }


        // Неполный конструктор
        public Book(string aName, string aAuthor, double aPrice, short aYear)
        {
            name = aName;
            author = aAuthor;
            price = aPrice;
            year = aYear;
            id = GetHashCode();
            numberOfBooks++;
        }


        // Полный конструтор
        public Book(string aName, string aAuthor, string aPublisher, string aType, short aYear, short aPages, double aPrice)
        {
            name = aName;
            author = aAuthor;
            publisher = aPublisher;
            type = aType;
            year = aYear;
            pages = aPages;
            price = aPrice;
            id = GetHashCode();
            numberOfBooks++;
        }


        // Статический конструтор
        //static Book()
        //{
        //    Console.WriteLine("  Создана первая книга. Кол-во книг: " + numberOfBooks);
        //}


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
            return $"Название: {Name}; Автор: {Author}; ";
        }

    }



    public class Publisher
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public Publisher(string name, string country)
        {
            Name = name;
            Country = country;
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
