﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Mines
    {
        public int mineActiv = 0;
        int x;
        int y;
        char sym = ' ';

        List<Mines> pList;

        Random randX = new Random();
        Random randY = new Random();

        public Mines (int _number)
        {
            pList = new List<Mines>(_number);
            for (int i = 0; i < _number; i++)
            {
                x = randX.Next(1,48);
                y = randY.Next(1,18);
                Mines m = new Mines(x, y);
                pList.Add(m);
            }
        }

        public Mines(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void DrawMines()
        {
            foreach (Mines i in pList)
            {
                i.Draw();
            }
        }

        /// <summary>
        /// Проверка нахождение на мину
        /// </summary>
        /// <param name="character">Имя персонажа</param>
        /// <returns></returns>
        public bool StepBy(Character character)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (character.x == pList[i].x && character.y == pList[i].y)
                {
                    if (pList[i].MineActiv())
                    {
                        character.Dmg();
                        character.WriteAdditionalStatus("Вы наступили на мину");
                        pList[i].mineActiv = 1;
                        pList[i].sym = 'M';
                        return true;
                    }
                }
            }
            return false;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        /// <summary>
        /// Проверка, наступал ли персонаж на эту мину
        /// </summary>
        /// <returns></returns>
        public bool MineActiv()
        {
            if (mineActiv == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
