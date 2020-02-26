using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        // По сути - конструктор точно такой же как и у хилки. 
        // Тут я решил все таки у тебя спросить - так норм, или все таки копипаста и по хорошему, надо создавать абстрактный класс и его наследовать хилке и мине?
        public Mines (int _number)
        {
            rand = new Random(Guid.NewGuid().GetHashCode());
            mList = new List<Mines>(_number);
            for (int i = 0; i < _number; i++)
            {
                x = rand.Next(1, 49);
                y = rand.Next(1, 19);
                Mines m = new Mines(x, y);
                mList.Add(m);
            }
        }

        public Mines(int _x, int _y)
        {
            x = _x;
            y = _y;
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
