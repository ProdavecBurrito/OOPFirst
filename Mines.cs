using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Mines
    {
        Messages message = new Messages();
        public int mineActiv = 0;
        int x;
        int y;
        char sym = ' ';
        Random rand;

        List<Mines> mList;

        public Mines (int _number)
        {
            rand = new Random();
            mList = new List<Mines>(_number);
            for (int i = 0; i < _number; i++)
            {
                x = rand.Next(1,48);
                y = rand.Next(1,18);
                Point p = new Point(x, y);
                Mines m = new Mines(p);
                mList.Add(m);
            }
        }

        public Mines(Point p)
        {
            x = p.x;
            y = p.y;
        }

        public void DrawMines()
        {
            foreach (Mines i in mList)
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
            for (int i = 0; i < mList.Count; i++)
            {
                if (character.x == mList[i].x && character.y == mList[i].y)
                {
                    if (mList[i].MineActiv())
                    {
                        character.Dmg();
                        message.WriteAdditionalStatus("Вы наступили на мину");
                        mList[i].mineActiv = 1;
                        mList[i].sym = 'M';
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
