using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Object 
    {
        public int x;
        public int y;
        public char sym;
            
        protected List<Point> pList;

        public bool Hit(Character character)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (character.x == pList[i].x && character.y == pList[i].y)
                {
                    character.Dmg();
                    character.ReturnLastPosition();
                    return true;
                }
            }
            return false;
        }

        public bool HitB(Character character)
        {
            if (character.x == x && character.y == y)
            {
                character.Dmg();
                character.ReturnLastPosition();
                return true;
            }
            return false;
        }

        public void LineDraw()
        {   
            foreach (Point i in pList)
            {
                i.Draw();
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
