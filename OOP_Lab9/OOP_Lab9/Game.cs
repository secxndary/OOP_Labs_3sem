using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    // Класс для обработки событий
    public class GameEventArgs
    {
        // Сообщение
        public string Message { get; }
        // Кол-во здоровья
        public int Health { get; }
        public GameEventArgs(string mes, int num)
        {
            Message = mes;
            Health = num;
        }
    }

    // Делегат
    public delegate void GameHandler(object sender, GameEventArgs e);

    // Класс воина
    class Warrior
    {
        public event GameHandler Notify;
        public Warrior(int num)
        {
            Health = num;
        }
        public int Health { get; private set; }
        public void Heal(int num)
        {
            Health += num;
            Notify?.Invoke(this, new GameEventArgs($"Вылечено {num} хп", num));
        }
        public void Damage(int num)
        {
            if (Health >= num)
            {
                Health -= num;
                Notify?.Invoke(this, new GameEventArgs($"Нанесено {num} урона", num));
            }
            else
            {
                Health = 0;
                Notify?.Invoke(this, new GameEventArgs($"Нанесено {num} урона. Воин повержен", num)); ;
            }
        }
    }

    // Класс некроманта
    class Necromancer
    {
        public event GameHandler Notify;
        public Necromancer(int num)
        {
            Health = num;
        }
        public int Health { get; private set; }
        public void Heal(int num)
        {
            if ((num / 2) <= Health)
            {
                Health -= (num / 2);
                Notify?.Invoke(this, new GameEventArgs($"Нанесено {num / 2} урона от лечения", num));
            }
            else
            {
                Health = 0;
                Notify?.Invoke(this, new GameEventArgs($"Нанесено {num / 2} урона от лечения. Некромант повержен", num));
            }
        }
        public void Damage(int num)
        {
            if (Health >= num)
            {
                Health += (num / 3);
                Notify?.Invoke(this, new GameEventArgs($"Вылечено {num / 3} здоровья от атаки", num));
            }
            else
            {
                Notify?.Invoke(this, new GameEventArgs("Нет здоровья", num)); ;
            }
        }
    }
}
