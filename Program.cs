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
            VerticalBerrier verticalBerrier = new VerticalBerrier(6, 8, 6, '&');

            Barrier fBarrier = new Barrier(17, 16, '&');
            Barrier sBarrier = new Barrier(40, 10, '&');
            Barrier tBarrier = new Barrier(35, 4, '&');
            Barrier foBarrier = new Barrier(25, 18, '&');
            Barrier fiBarrier = new Barrier(15, 9, '&');

            HealingElixir fElixir = new HealingElixir(5, 10, 'N');
            HealingElixir sElixir = new HealingElixir(25, 6, 'N');

            Point p = new Point(4, 8, '*');
            Character pers = new Character(p);
            pers.SetHealth(8);
            pers.SetName("Hodr");

            fElixir.Draw();
            sElixir.Draw();

            while (pers.Alive())
            {
                pers.Draw();

                horizontalBarrier.LineDraw();
                verticalBerrier.LineDraw();

                sBarrier.Draw();
                fBarrier.Draw();
                tBarrier.Draw();
                foBarrier.Draw();
                fiBarrier.Draw();


                pers.SaveLastPosition();

                Console.SetCursorPosition(0, 21);
                pers.Info();

                ConsoleKey act = Console.ReadKey().Key;

                Console.SetCursorPosition(0, 21);
                pers.ClearInfo();

                pers.Clear();

                pers.Action(act);

                pers.ReturnSym();

                fElixir.GrabBy(pers);
                sElixir.GrabBy(pers);

                horizontalBarrier.Hit(pers);
                verticalBerrier.Hit(pers);

                fBarrier.HitB(pers);
                sBarrier.HitB(pers);
                tBarrier.HitB(pers);
                foBarrier.HitB(pers);
                fiBarrier.HitB(pers);

                pers.SaveLastPosition();
            }
            Console.Clear();
            pers.Info();
            Console.WriteLine("Вы проиграли");
            Console.ReadKey();
        }
    }
}
