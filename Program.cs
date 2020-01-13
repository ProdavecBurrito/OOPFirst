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

            Barriers horizontalBarrier = new Barriers(6, 4, 3, '&', Direction.RIGHT);
            Barriers verticalBarrier = new Barriers(10, 7, 10, '&', Direction.DOWN);

            Barrier fBarrier = new Barrier(17, 16, '&');
            Barrier sBarrier = new Barrier(40, 10, '&');
            Barrier tBarrier = new Barrier(35, 4, '&');
            Barrier foBarrier = new Barrier(25, 18, '&');
            Barrier fiBarrier = new Barrier(15, 9, '&');

            HealingElixir fElixir = new HealingElixir(5, 10, 'N');
            HealingElixir sElixir = new HealingElixir(25, 6, 'N');

            Point p = new Point(4, 8, '*');
            Character pers = new Character(p);

            Point winP = new Point(48, 18, '%');
            WinningPoint winningPoint = new WinningPoint(winP);

            pers.SetHealth(8);
            pers.SetName("Hodr");

            fElixir.Draw();
            sElixir.Draw();

            while (pers.Alive() && winningPoint.ReachBy(pers) != true)
            {
                pers.Draw();

                horizontalBarrier.LineDraw();
                verticalBarrier.LineDraw();

                sBarrier.Draw();
                fBarrier.Draw();
                tBarrier.Draw();
                foBarrier.Draw();
                fiBarrier.Draw();

                winningPoint.Draw();

                pers.SaveLastPosition();

                Console.SetCursorPosition(0, 21);
                pers.Info();

                ConsoleKey act = Console.ReadKey().Key;

                Console.SetCursorPosition(0, 21);
                pers.ClearInfo();

                pers.Clear();

                pers.Action(act);

                pers.WriteSym();

                fElixir.GrabBy(pers);
                sElixir.GrabBy(pers);

                horizontalBarrier.Hit(pers);
                verticalBarrier.Hit(pers);

                fBarrier.HitB(pers);
                sBarrier.HitB(pers);
                tBarrier.HitB(pers);
                foBarrier.HitB(pers);
                fiBarrier.HitB(pers);

                pers.SaveLastPosition();
            }
            if (winningPoint.ReachBy(pers))
            {
            }
            else if (pers.Alive() == false)
            {
            }
        }
    }
}
