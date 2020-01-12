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

        public bool GrabBy(Character character)
        {
            if (character.x == x && character.y == y)
            {
                if (ElixirActiv())
                {
                    character.Heal();
                    HealActiv = 1;
                    return true;
                }
            }
            return false;
        }

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
