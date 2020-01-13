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

        public bool ReachBy(Character character)
        {
            if (character.x == x && character.y == y)
            {
                Console.Clear();
                Console.WriteLine($"Поздравляем! Вы прошли за {character.actinosCounter} ход(ов)");
                Console.WriteLine();
                character.Info();
                Console.ReadKey();
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
