using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map;

            Map newMap = new Map();
            map = newMap.MapReader();
            newMap.MapWriter(map);

            HorizontalBarrier horizontalBarrier = new HorizontalBarrier(6, 4, 3, '&');

            Point point = new Point(4, 8, '*');
            Character pers = new Character(point);

            while (pers.Alive())
            {
                pers.Draw();

                horizontalBarrier.LineDraw();

                Console.SetCursorPosition(0, 21);
                pers.Info();

                ConsoleKey act = Console.ReadKey().Key;

                Console.SetCursorPosition(0, 21);
                pers.ClearInfo();

                pers.Clear();
                pers.Action(act);
                pers.ReturnSym();

            }
            Console.Clear();
            pers.Info();
            Console.WriteLine("Вы проиграли");
            Console.ReadKey();
        }
    }
}
