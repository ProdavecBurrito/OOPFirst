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

            Character pers = new Character("Hodr", 9, 5, 10, '*');

            while (true)
            {
                newMap.MapWriter(map);
                pers.Draw();

                Console.SetCursorPosition(0, 21);
                pers.Info();

                ConsoleKey act = Console.ReadKey().Key;
                pers.Action(act);

                Console.Clear();
            }
        }
    }
}
