using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Character : Point
    {
        int x;
        int y;
        char sym;

        public Character(int _x, int _y, char _sym) : base(_x, _y, _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }
    }
}
