using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6
{
    public class ArmyContainer
    {
        public List<IntelligentBeing> Armiya;
        public ArmyContainer()
        {
            Armiya = new List<IntelligentBeing>();
        }
        public void Delete(int index)
        {
            Armiya.RemoveAt(index);
        }
        public void Add(IntelligentBeing item)
        {
            Armiya.Add(item);
        }
        public void Display()
        {
            foreach (IntelligentBeing item in Armiya)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }


    public class ArmyController: ArmyContainer
    {
        public void SearchDate(Date date)
        {
            int flagSearch = 0;
            Console.WriteLine("\nПоиск даты {0}.{1}.{2}", date.Day, date.Month, date.Year);
            foreach (IntelligentBeing item in Armiya)
            {
                if (item.Date.Equals(date))
                {
                    Console.WriteLine("Дату рождения {0}.{1}.{2} имеет {3}", date.Day, date.Month, date.Year, item.Name);
                    flagSearch++;
                }
                else if (flagSearch != 0)
                    Console.WriteLine("Дата не найдена.");
            }
        }
        public int Count()
        {
            Console.WriteLine("\nКол-во боевых единиц армии: " + Armiya.Count);
            return Armiya.Count;
        }
        public void SearchPower(int power)
        {
            for (int i = 0; i < Armiya.Count; i++)
            {
                if (Armiya[i] is Transformer)
                {
                    Console.WriteLine("\nМощность " + power + " имеет " + Armiya[i].Name);
                }
            }
        }
    }


    public struct Date
    {
        public int Day;
        public int Month;
        public int Year;
        public Date(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
    }

    enum Operations
    {
        Add = 1,
        Delete,
        Display,
        SearchDate,
        SearchPower,
        Count
    }
}
