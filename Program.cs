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
            EndingMessages endingMessage = new EndingMessages();
            Console.CursorVisible = false;

            char[,] newMap;

            Map map = new Map();
            newMap = map.MapReader();
            map.MapWriter(newMap);

            Mines mines = new Mines(10);

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

            map.DrawBarriers();

            while (pers.Alive() && winningPoint.ReachBy(pers) != true)
            {
                pers.Draw();

                mines.DrawMines();

                winningPoint.Draw();

                pers.SaveLastPosition();

                Console.SetCursorPosition(0, 21);
                pers.Info();

                ConsoleKey act = Console.ReadKey().Key;
                pers.ClearAdditionalStatus();

                Console.SetCursorPosition(0, 21);
                pers.ClearInfo();

                pers.Clear();

                pers.Action(act);

                pers.WriteSym();

                fElixir.GrabBy(pers);
                sElixir.GrabBy(pers);

                map.StepBy(pers);

                mines.StepBy(pers);

                pers.SaveLastPosition();
            }
            if (winningPoint.ReachBy(pers))
            {
                endingMessage.WinningMessege(pers);
            }
            else if (pers.Alive() == false)
            {
                endingMessage.LosingMessage(pers);
            }
        }
    }
}
