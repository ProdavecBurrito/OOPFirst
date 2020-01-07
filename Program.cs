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
            char[,] map;

            Map newMap = new Map();
            map = newMap.MapReader();

            Character pers = new Character(10, 5, '*');

            while (true)
            {
                newMap.MapWriter(map);
                pers.Drow();

                ConsoleKey act = Console.ReadKey().Key;
                pers.Action(act);

                Console.Clear();
            }
        }
    }
}
