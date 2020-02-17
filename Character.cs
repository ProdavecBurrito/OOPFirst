using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Character
    {
        Messages message = new Messages();
        public int x;
        public int y;
        char sym;

        public int healingElixirs = 0;

        int saveX;
        int saveY;
        public string name { get; private set; }

        public string writeName;
        public string writeCoord;
        public string writeHealth;
        public string writeHealingEl;
        public int health { get; private set; }
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
                       message.WriteStatus("Вы пошли вверх");
                    }
                    break;
                case ConsoleKey.S:
                    if (y != map.MapHight - 2)
                    {
                        y += 1;
                       message.WriteStatus("Вы пошли вниз");
                    }
                    break;
                case ConsoleKey.D:
                    if (x != map.MapWidth - 2)
                    {
                        x += 1;
                       message.WriteStatus("Вы пошли направо");
                    }
                    break;
                case ConsoleKey.A:
                    if (x != 0 + 1)
                    {
                        x -= 1;
                       message.WriteStatus("Вы пошли налево");
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (healingElixirs != 0)
                    {
                        healingElixirs -= 1;
                        Heal();
                        message.WriteStatus("Вы использовали хилку");
                    }
                    else
                    {
                        message.WriteStatus("У вас нет хилки");
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
    }
}
