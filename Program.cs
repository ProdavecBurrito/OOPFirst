﻿using System;
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

            Messages message = new Messages();

            char[,] newMap;

            Map map = new Map();
            newMap = map.MapReader();
            map.MapWriter(newMap);

            Mines mines = new Mines(12);

            HealingElixir healingElixirs = new HealingElixir(5);

            Point p = new Point(4, 8, '*');
            Character pers = new Character(p);

            Point winP = new Point(48, 18, '%');
            WinningPoint winningPoint = new WinningPoint(winP);

            pers.SetHealth(8);
            pers.SetName("Hodr");

            healingElixirs.Draw();

            map.DrawBarriers();

            while (pers.Alive() && winningPoint.ReachBy(pers) != true)
            {
                pers.Draw();

                mines.DrawMines();

                winningPoint.Draw();

                pers.SaveLastPosition();

                Console.SetCursorPosition(0, 21);
                message.Info(pers);

                ConsoleKey act = Console.ReadKey().Key;
                message.ClearAdditionalStatus();

                Console.SetCursorPosition(0, 21);
                message.ClearInfo(pers);

                pers.Clear();

                pers.Action(act);

                pers.WriteSym();

                healingElixirs.GrabBy(pers, healingElixirs);

                map.StepBy(pers);

                mines.StepBy(pers);

                pers.SaveLastPosition();
            }
            if (winningPoint.ReachBy(pers))
            {
                message.WinningMessege(pers);
            }
            else if (pers.Alive() == false)
            {
                message.LosingMessage(pers);
            }
        }
    }
}
