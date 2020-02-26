using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class WinningPoint : Point
    {
        public WinningPoint(int x, int y, char sym) : base(x, y, sym)
        {

        }
        /// <summary>
        /// Проверка, достиг ли персонаж победной точки
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool ReachBy(Character character)
        {
            if (character.x == x && character.y == y)
            {
                return true;
            }
            return false;
        }
    }
}
