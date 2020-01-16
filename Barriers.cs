using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Barriers
    {
        //int x;
        //int y;
        //char sym;


        //public Barriers(int _x, int _y, char _sym)
        //{
        //    x = _x;
        //    y = _y;
        //    sym = _sym;
        //}

        List<Point> barrierList = new List<Point>();

        Map map = new Map();

        /// <summary>
        /// Проверка, не наступил ли перс на препятствие
        /// </summary>
        /// <param name="character">Имя персонажа</param>
        /// <returns></returns>dd
        public bool StepBy(Character character)
        {
            barrierList = map.GetBarriers();
            for (int i = 0; i < barrierList.Count; i++)
            {
                if (character.x == barrierList[i].x && character.y == barrierList[i].y)
                {
                    character.Dmg();
                    character.WriteAdditionalStatus("Вы наступили на препятствие");
                    character.ReturnLastPosition();
                    character.Draw();
                    barrierList[i].sym = '#';
                    barrierList[i].Draw();
                    return true;
                }
            }
            return false;
        }

        //public void DrawBarriers()
        //{
        //    foreach (Point i in barrierList)
        //    {
        //        i.Draw();
        //    }
        //}
    }
}
