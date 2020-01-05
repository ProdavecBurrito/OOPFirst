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
            newMap.MapWriter(map);

            Point pers = new Point(2, 5, '*');
            pers.Drow();


            Console.ReadLine();
        }
    }
}
