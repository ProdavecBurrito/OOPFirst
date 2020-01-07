using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Character : Point
    {
        string name;
        int health;
        int x;
        int y;
        char sym;

        public Character(string _name, int _health, int _x, int _y, char _sym) : base(_x, _y, _sym)
        {
            name = _name;
            health = _health;
            x = _x;
            y = _y;
            sym = _sym;
        }

        public void Heal()
        {
            if (health != 10)
            {
                health += 1;
            }
        }

        public void Dmg()
        {
            if (health > 0)
            {
                health -= 1;
            }
        }

        public void Info()
        {
            Console.WriteLine($"Персонаж {name}");
            Console.WriteLine($"Координаты {x}x{y}");
            Console.WriteLine($"Колл-во жизней {health}");
        }

        public void Action(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.W:
                    if (y != 1)
                    {
                        y -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (y != 20 - 2)
                    {
                        y += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (x != 50 - 2)
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
                    Heal();
                    break;
                case ConsoleKey.Enter:
                    Dmg();
                    break;
            }
        }

        public new void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

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
    }
}
