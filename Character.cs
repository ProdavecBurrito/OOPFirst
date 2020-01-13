using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Character
    {
        public int x;
        public int y;
        char sym;

        public int healingElixirs = 0;

        int saveX;
        int saveY;
        string name;

        string writeName;
        string writeCoord;
        string writeHealth;
        string writeHealingEl;
        int health;
        char saveSym;
        Map map = new Map();

        public int actinosCounter;

        public Character(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
            saveSym = p.sym;
        }

        /// <summary>
        /// Лечит персонажа
        /// </summary>
        public void Heal()
        {
            if (health != 10)
            {
                health += 1;
            }
        }

        /// <summary>
        /// Наносит урон персонажу
        /// </summary>
        public void Dmg()
        {
            if (health > 0)
            {
                health -= 1;
            }
        }

        /// <summary>
        /// Выводит информацию о персонаже
        /// </summary>
        public void Info()
        {
            writeName = ($"Персонаж {name}");
            Console.WriteLine(writeName);

            writeCoord = ($"Координаты {x}х{y}");
            Console.WriteLine(writeCoord);

            writeHealth = ($"Колл-во жизней {health}");
            Console.WriteLine(writeHealth);

            writeHealingEl = ($"Колл-во хилок {healingElixirs}");
            Console.WriteLine(writeHealingEl);
        }

        /// <summary>
        /// Чистит информацию о персонаже
        /// </summary>
        public void ClearInfo()
        {
            char [] empty = new char[writeName.Length];
            for (int i = 0; i < writeName.Length - 1; i++)
            {
                empty[i] = ' ';
            }
            empty.ToString();
            Console.WriteLine(empty);

            empty = new char[writeCoord.Length];
            for (int i = 0; i < writeCoord.Length - 1; i++)
            {
                empty[i] = ' ';
            }
            empty.ToString();
            Console.WriteLine(empty);

            empty = new char[writeHealth.Length];
            for (int i = 0; i < writeHealth.Length - 1; i++)
            {
                empty[i] = ' ';
            }
            empty.ToString();
            Console.WriteLine(empty);

            empty = new char[writeHealingEl.Length];
            for (int i = 0; i < writeHealingEl.Length - 1; i++)
            {
                empty[i] = ' ';
            }
            empty.ToString();
            Console.WriteLine(empty);
        }

        /// <summary>
        /// Заставляет перса совершить действия
        /// </summary>
        /// <param name="key">Клавиша действия</param>
        public void Action(ConsoleKey key)
        {
            actinosCounter += 1;
            switch(key)
            {
                case ConsoleKey.W:
                    if (y != 1)
                    {
                        y -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (y != map.MapHight - 2)
                    {
                        y += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (x != map.MapWidth - 2)
                    {
                        x += 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (x != 0 + 1)
                    {
                        x -= 1;
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (healingElixirs != 0)
                    {
                        healingElixirs -= 1;
                        Heal();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 21);
                        Console.WriteLine("У вас нет хилок");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 21);
                        Console.WriteLine("               ");
                    }
                    break;
                case ConsoleKey.Enter:
                    Dmg();
                    break;
            }
        }

        /// <summary>
        /// Проверка перса на то, жив ли он
        /// </summary>
        /// <returns></returns>
        public bool Alive()
        {
            if (health != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Чистит символ, а затем выводит пробел
        /// </summary>
        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        /// <summary>
        /// Выводит символ
        /// </summary>
        public void WriteSym()
        {
            sym = saveSym;
            Draw();
        }

        /// <summary>
        /// Задает имя перса
        /// </summary>
        /// <param name="_name"></param>
        public void SetName(string _name)
        {
            name = _name;
        }

        /// <summary>
        /// задает хп перса
        /// </summary>
        /// <param name="_health"></param>
        public void SetHealth(int _health)
        {
            health = _health;
        }

        /// <summary>
        /// Созраняет последнюю безопасную позицию
        /// </summary>
        public void SaveLastPosition()
        {
            saveX = this.x;
            saveY = this.y;
        }

        /// <summary>
        /// Перемещает персонажа в последнюю безопасную позицию
        /// </summary>
        public void ReturnLastPosition()
        {
            this.x = saveX;
            this.y = saveY;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        /// <summary>
        /// Выводит победное сообщение
        /// </summary>
        public void WinningMessege()
        {
            Console.Clear();
            Console.WriteLine($"Поздравляем, Вы победили! Вы прошли за {actinosCounter} ход(ов)");
            Console.WriteLine();
            Info();
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит сообщение проиграша
        /// </summary>
        public void LosingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Вы погибли. Сделанно {actinosCounter} ход(ов)");
            Console.WriteLine();
            Info();
            Console.ReadKey();
        }
    }
}
