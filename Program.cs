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

            Character pers = new Character("Hodr", 6, 5, 10, '*');

            while (pers.Alive())
            {
                pers.Draw();

                Console.SetCursorPosition(0, 21);
                pers.Info();

                ConsoleKey act = Console.ReadKey().Key;
                pers.Clear();
                pers.Action(act);
                pers.ReturnSym();

            }
            pers.Info();
            Console.WriteLine("Вы проиграли");
            Console.ReadKey();
        }
    }
}
