using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class HealingElixir
    {
        public int healActiv = 0;

        int x;
        int y;
        char sym;
        public HealingElixir(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
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
                    character.WriteAdditionalStatus("Вы подобрали хилку");
                    healActiv = 1;
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
            if (healActiv == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
