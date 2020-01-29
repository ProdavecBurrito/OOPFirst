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
            ClearLine(writeName);

            ClearLine(writeCoord);

            ClearLine(writeHealth);

            ClearLine(writeHealingEl);
        }

        /// <summary>
        /// Заставляет перса совершить действия
        /// </summary>
        /// <param name="key">Клавиша действия</param>
        public void Action(ConsoleKey key)
        {
            actinosCounter += 1;
            switch (key)
            {
                case ConsoleKey.W:
                    if (y != 1)
                    {
                        y -= 1;
                        WriteStatus("Вы пошли вверх");
                    }
                    break;
                case ConsoleKey.S:
                    if (y != map.MapHight - 2)
                    {
                        y += 1;
                        WriteStatus("Вы пошли вниз");
                    }
                    break;
                case ConsoleKey.D:
                    if (x != map.MapWidth - 2)
                    {
                        x += 1;
                        WriteStatus("Вы пошли направо");
                    }
                    break;
                case ConsoleKey.A:
                    if (x != 0 + 1)
                    {
                        x -= 1;
                        WriteStatus("Вы пошли налево");
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (healingElixirs != 0)
                    {
                        healingElixirs -= 1;
                        Heal();
                        WriteStatus("Вы использовали хилку");
                    }
                    else
                    {
                        WriteStatus("У вас нет хилки");
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

        /// <summary>
        /// Чистит статус
        /// </summary>
        public void ClearStatus()
        {
            Console.SetCursorPosition(52, 1);
            Console.WriteLine("                             ");
        }

        /// <summary>
        /// Чистит дополнительный статус
        /// </summary>
        public void ClearAdditionalStatus()
        {
            Console.SetCursorPosition(52, 2);
            Console.WriteLine("                             ");
        }

        /// <summary>
        /// Выводит статус
        /// </summary>
        /// <param name="status"></param>
        public void WriteStatus(string status)
        {
            Console.SetCursorPosition(52, 1);
            ClearStatus();
            Console.SetCursorPosition(52, 1);
            Console.WriteLine($"{status}");
        }

        /// <summary>
        /// Выводит дополнительный статус
        /// </summary>
        /// <param name="status"></param>
        public void WriteAdditionalStatus(string status)
        {
            Console.SetCursorPosition(52, 2);
            ClearAdditionalStatus();
            Console.SetCursorPosition(52, 2);
            Console.WriteLine($"{status}");
        }

        /// <summary>
        /// Чистит предложение
        /// </summary>
        /// <param name="word"></param>
        public void ClearLine(string word)
        {
            char[] empty = new char[word.Length];
            for (int i = 0; i < word.Length - 1; i++)
            {
                empty[i] = ' ';
            }
            empty.ToString();
            Console.WriteLine(empty);
        }
    }
}
