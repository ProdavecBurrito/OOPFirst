using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class HealingElixir : Object
    {
        public int HealActiv = 0;

        public HealingElixir(int _x, int _y, char _sym) : base (_x,_y,_sym)
        {
        }

        /// <summary>
        /// Проверка на то, подобрал ли перс хилку
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool GrabBy(Character character)
        {
            if (character.x == x && character.y == y)
            {
                if (ElixirActiv())
                {
                    character.healingElixirs += 1;
                    HealActiv = 1;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка, не подбирал ли перс эту хилку
        /// </summary>
        /// <returns></returns>
        public bool ElixirActiv()
        {
            if (HealActiv == 0)
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
