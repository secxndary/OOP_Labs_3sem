using System;

//                Вариант 6:
//  Создать класс Book: id, Название, Автор (ы), 
//  Издательство, Год издания, Количество страниц, Цена, 
//  Тип переплета. Свойства и конструкторы должны
//  обеспечивать проверку корректности. 
//
//  Создать массив объектов. Вывести:
//  a) список книг заданного автора;
//  b) список книг, выпущенных после заданного года.


namespace OOP_Lab3
{
    partial class Book          // ПОЛЯ И КОНСТРУКТОРЫ
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
        static Book()
        {
            Console.WriteLine("  Создана первая книга. Кол-во книг: " + numberOfBooks);
        }

    }




    class Class1
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            Console.WriteLine("\n\n  Объект, созданный конструктором по умолчанию:");
            book1.PrintInfo();


            Book book2 = new Book("МЫ", "Евгений Замятин", 14.99, 1956);
            Console.WriteLine("\n\n  Объект, созданный вторым конструктором:");
            book2.PrintInfo();


            Book book3 = new Book("Бойцовский клуб", "Чак Паланик", "АСТ", "Мягкий переплёт", 1995, 243, 9.50);
            Console.WriteLine("\n\n  Объект, созданный полным конструктором:");
            book3.PrintInfo();


            Book book4 = new Book("Колыбельная", "Чак Паланик", "АСТ", "Мягкий переплёт", 2003, 298, 12.99);
            Console.WriteLine("\n\n\t   Четвёртый объект:");
            book4.PrintInfo();


            Book.TypeOfClass();


            Console.WriteLine("\n\n  Всего " + Book.numberOfBooks + " книги.");


            Book book5 = new Book("Колыбельная", "Чак Паланик", "АСТ", "Мягкий переплёт", 2003, 298, 12.99);
            Console.WriteLine("\n\n   В продаже появилась еще одна книга " + book5.Name + "!");
            int sale = -3;
            Console.WriteLine("   Скидка 3 рубля на классику автора " + book5.Author+ "!");
            book5.ChangePrice(ref sale);
            book5.PrintInfo();

            sale = -9999;
            Console.WriteLine("\n\n   Скидка 9999 рублей на книгу " + book4.Name + "!");
            book5.ChangePrice(ref sale);


            if (book4.Equals(book5))
                Console.WriteLine("\n\n   4-ая и 5-ая книги одинаковые.");
            else
                Console.WriteLine("\n\n   4-ая и 5-ая книги не одинаковые.");


            //Console.WriteLine(book5.ToString());


            Book[] arrBooks = new Book[5];
            arrBooks[0] = book1;
            arrBooks[1] = book2;
            arrBooks[2] = book3;
            arrBooks[3] = book4;
            arrBooks[4] = book5;

            Console.WriteLine("\n\n   Введите имя автора, книги которого вы хотите найти:");
            string searchAuthor = Console.ReadLine();
            short counter = 0;
            for (short i = 0; i < arrBooks.Length; i++)
            {
                if (arrBooks[i].Author == searchAuthor)
                {
                    Console.WriteLine(arrBooks[i].Name);
                    counter++;
                }
            }
            if (counter == 0)
                Console.WriteLine("Ничего не найдено!");

            Console.WriteLine("\n\n   Введите год, после которого искать книги:");
            int searchYear = Convert.ToInt32(Console.ReadLine());
            short counter2 = 0;
            for (short i = 0; i < arrBooks.Length; i++)
            {
                if (arrBooks[i].year > searchYear)
                {
                    Console.WriteLine(arrBooks[i].Name + ", " + arrBooks[i].Author + ", " + arrBooks[i].year);
                    counter2++;
                }
            }
            if (counter2 == 0)
                Console.WriteLine("Ничего не найдено!");


            var AnonymBook = new { Name = "Так говорил Заратустра", Author = "Фридрих Ницше", Year = 1883};
            Console.WriteLine("\n\n   Новая книга! " + AnonymBook.Name + " от " + AnonymBook.Author + " (" + AnonymBook.Year + ")\n");
        }
    }
}
