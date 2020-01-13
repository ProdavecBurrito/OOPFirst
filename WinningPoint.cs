using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class WinningPoint
    {
        int x;
        int y;
        char sym;
        public WinningPoint(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        /// <summary>
        /// Проверка, достиг ли персонаж победной точки
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool ReachBy(Character character)
        {
            if (character.x == x && character.y == y)
            {
                return true;
            }
            return false;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
