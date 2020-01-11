using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Character : Object
    {
        int saveX;
        int saveY;
        string name;
        string writeName;
        string writeCoord;
        string writeHealth;
        int health;
        char saveSym;
        Map map = new Map();

        public Character(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
            saveSym = p.sym;
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


        public void SetName(string _name)
        {
            name = _name;
        }

        public void SetHealth(int _health)
        {
            health = _health;
        }

        public void SaveLastPosition()
        {
            saveX = this.x;
            saveY = this.y;
        }

        public void ReturnLastPosition()
        {
            this.x = saveX;
            this.y = saveY;
        }
    }
}
