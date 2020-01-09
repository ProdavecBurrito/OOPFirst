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
        string writeName;
        string writeCoord;
        string writeHealth;
        int health;
        char saveSym;
        Map map = new Map();

        public Character(string _name, int _health, int _x, int _y, char _sym) : base(_x, _y, _sym)
        {
            name = _name;
            health = _health;
            x = _x;
            y = _y;
            sym = _sym;
            saveSym = _sym;
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
            writeName = ($"Персонаж {name}");
            Console.WriteLine(writeName);

            writeCoord = ($"Координаты {x}х{y}");
            Console.WriteLine(writeCoord);

            writeHealth = ($"Колл-во жизней {health}");
            Console.WriteLine(writeHealth);
        }

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
                    Heal();
                    break;
                case ConsoleKey.Enter:
                    Dmg();
                    break;
            }
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

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public void ReturnSym()
        {
            sym = saveSym;
            Draw();
        }
    }
}
