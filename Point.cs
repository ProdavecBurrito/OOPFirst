using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Point
    {
        int x;
        int y;
        char sym;

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public void Drow()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Action(ConsoleKey key)
        {
            if (key == ConsoleKey.W)
            {
                if (y != 1)
                {
                    y -= 1;
                }
            }
            else if (key == ConsoleKey.S)
            {
                if (y != 20 - 2)
                {
                    y += 1;
                }
            }
            else if (key == ConsoleKey.D)
            {
                if (x != 50 - 2)
                {
                    x += 1;
                }
            }
            else if (key == ConsoleKey.A)
            {
                if (x != 0 + 1)
                {
                    x -= 1;
                }
            }
        }
    }
}
