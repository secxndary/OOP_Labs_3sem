using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OOP_Lab11
{
    class Program
    {
        static void Main(string[] args)
        {


            // ==========================================   ЗАДАНИЕ 1   ==========================================

            string[] Months = { "January", "February", "March", "April", "May", "June", "July",
                                  "August", "September", "October", "November", "December" };


            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Месяцы, состоящие из {0} букв:", n);
            var LengthFive = from m in Months
                             where m.Length == n
                             orderby m
                             select m;
            foreach (string s in LengthFive)
                Console.WriteLine(s);


            Console.WriteLine("\nЛетние и зимние месяцы:");
            var summerWinter = from m in Months
                               where Array.IndexOf(Months, m) < 2 ||    /// выбираем вручную по индексу зимние и летние
                               (Array.IndexOf(Months, m) > 4 && Array.IndexOf(Months, m) < 8) ||
                               Array.IndexOf(Months, m) == 11
                               select m;
            foreach (string m in summerWinter)
                Console.WriteLine(m);


            Console.WriteLine("\nМесяцы в алфавитном порядке:");
            var alphabetSort = from m in Months
                               orderby m    /// сортировка
                               select m;
            foreach (string m in alphabetSort)
                Console.WriteLine(m);


            Console.WriteLine("\nМесяцы с буквой U длиной не менее 4:");
            var uLen4 = from m in Months
                        where m.Length >= 4 && Regex.IsMatch(m, "u")    /// проверяем совпадение
                        select m;
            foreach (string m in uLen4)
                Console.WriteLine(m);
            Console.WriteLine("\n");





            // ==========================================   ЗАДАНИЕ 2   ==========================================

            Console.WriteLine(new string('=', 66));
            Console.WriteLine("\n\t\t       Список книг:\n");


            Book book1 = new Book("451 по Фаренгейту", "Рэй Брэдберри", "Зарубежная классика", "Мягкий переплёт", 1976, 245, 12.80);
            Book book2 = new Book("МЫ", "Евгений Замятин", "Зарубежная классика", "Мягкий переплёт", 1940, 210, 10.99);
            Book book3 = new Book("Бойцовский клуб", "Чак Паланик", "АСТ", "Мягкий переплёт", 1995, 243, 9.50);
            Book book4 = new Book("Колыбельная", "Чак Паланик", "АСТ", "Мягкий переплёт", 1995, 298, 12.99);
            Book book5 = new Book("Берсерк", "Кэнтаро Миура", "XL медиа", "Твёрдый переплёт", 1983, 420, 26.90);
            Book book6 = new Book("Атака на Титанов", "Хадзимэ Исаяма", "Азбука", "Твёрдый переплёт", 1995, 290, 17.80);
            Book book7 = new Book("Дюна", "Фрэнк Герберг", "ЛитРес", "Твёрдый переплёт", 1967, 980, 39.90);
            Book book8 = new Book("Ведьмак", "Анджей Сапковский", "ЛитРес", "Твёрдый переплёт", 1986, 950, 42.90);


            List<Book> listBooks = new List<Book>() { book1, book2, book3, book4, book5, book6, book7, book8 };
            foreach (Book b in listBooks)
                Console.WriteLine(b.ToString());    /// через ToString выводится информация об объекте в консось


            Console.WriteLine("\n\n\n\t      Книги Чака Паланика 1995 года:\n");
            var authorYear = from b in listBooks
                             where b.Author == "Чак Паланик" && b.year == 1995
                             select b;
            foreach (Book b in authorYear)
                Console.WriteLine(b.ToString() + "Год выпуска: " + b.year);


            Console.WriteLine("\n\n\t    Книги, выпущенные после 1980 года:\n");
            var afterYear = from b in listBooks
                            where b.year > 1980
                            select b;
            foreach (Book b in afterYear)
                Console.WriteLine(b.ToString() + "Год выпуска: " + b.year);


            int minPages = listBooks.Min(a => a.pages);   /// находим минимальное кол-во страниц через лямбда-выражение
            var result = listBooks.FirstOrDefault(a => a.pages == minPages);    /// выбираем только один объект у которого
                                                                                /// поле совпадает с минимальным значением
            Console.WriteLine("\n\n\t\t   Самая тонкая книга:\n\n" + result + "Кол-во страниц: " + result.pages);


            Console.WriteLine("\n\n\t      Пять самых толстых дешёвых книг:\n");
            var fiveThickest = from b in listBooks
                               where b.price < 50 && b.pages > 250
                               select b;
            var result5 = fiveThickest.Take(5); /// берём только 5
            foreach (Book b in result5)
                Console.WriteLine("{0}Кол-во страниц: {1}; Цена: {2}", b, b.pages, b.price);


            Console.WriteLine("\n\n\t       Отсортированные по цене книги:\n");
            var sortPrice = from b in listBooks
                            orderby b.price     /// та же сортировка по цене
                            select b;
            foreach (Book b in sortPrice)
                Console.WriteLine(b + "Цена: " + b.price);


            Console.WriteLine("\n\n\t     Книги, дороже среднего значения:\n"); /// 4 задание со своим кастомным запросом
            var customLinq = from b in listBooks
                             where b.price > listBooks.Average(b => b.price)    /// берём те книги которые дороже средней цены
                             orderby b.price                                    /// сортируем по цене
                             select b;
            foreach (Book b in customLinq.Take(2))                              /// и берём только 2
                Console.WriteLine(b + "Цена: " + b.price);


            Console.WriteLine("\n\n\t    Книги определённого издетальства:\n");
            Publisher ast = new Publisher("АСТ", "Беларусь");
            Publisher LitRes = new Publisher("ЛитРес", "Россия");
            List<Publisher> publishers = new List<Publisher>() { ast, LitRes };      /// создаем список с объектами-издательствами
            var booksOfPublisher = from b in listBooks
                                   join p in publishers on b.Publisher equals p.Name /// присоединяем свойства с publisher, 
                                                                                     /// если названия издательства совпадают 
                                                                                     /// (Name в Publisher и Publisher в Book)
                                   select new { Name = b.Name, Publisher = p.Name, Country = p.Country };
                                                                                     /// создаём анонимный тип со свойствами от
                                                                                     /// Book (Name) и Publisher (Name, Country)
            foreach (var b in booksOfPublisher)
                Console.WriteLine("{0}: Издательство {1} ({2})", b.Name, b.Publisher, b.Country);
        }
    }
}
