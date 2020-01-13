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

        public Object(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Object(int startLine, int lineLength, int secondCoordinateLine, char sym, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                pList = new List<Point>(lineLength);
                for (int x = startLine; x < lineLength + startLine; x++)
                {
                    Point point = new Point(x, secondCoordinateLine, sym);
                    pList.Add(point);
                }
            }
            else if (direction == Direction.DOWN)
            {
                pList = new List<Point>(lineLength);
                for (int y = startLine; y < lineLength + startLine; y++)
                {
                    Point point = new Point(secondCoordinateLine, y, sym);
                    pList.Add(point);
                }
            }
        }

        /// <summary>
        /// Проверка, не наступил ли перс на припятствие
        /// </summary>
        /// <param name="character">Имя персонажа</param>
        /// <returns></returns>
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

        /// <summary>
        /// Проверка, не наступил ли перс на припятствие
        /// </summary>
        /// <param name="character">Имя персонажа</param>
        /// <returns></returns>
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
