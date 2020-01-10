using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Object 
    {
        protected List<Point> pList;

        public bool Hit(Character character)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (character.x == pList[i].x && character.y == pList[i].y)
                {
                    character.Dmg();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void LineDraw()
        {   
            foreach (Point i in pList)
            {
                i.Draw();
            }
        }
    }
}
