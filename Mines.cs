using System;
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

        List<Point> pList;
        Random randX = new Random();
        Random randY = new Random();

        public Mines (int _number)
        {
            pList = new List<Point>(_number);
            for (int i = 0; i < _number; i++)
            {
                x = randX.Next(1,48);
                y = randY.Next(1,18);
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }

        public void DrawMines()
        {
            foreach (Point i in pList)
            {
                i.Draw();
            }
        }

        public bool StepBy(Character character)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (character.x == pList[i].x && character.y == pList[i].y)
                {
                    character.Dmg();
                    pList[i].sym = 'M';
                    return true;
                }
            }
            return false;
        }
    }
}
