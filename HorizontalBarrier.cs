using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class HorizontalBarrier : Object
    {
        public HorizontalBarrier(int startLineX, int lineLength, int y, char sym)
        {
            pList = new List<Point>(lineLength);
            for (int x = startLineX; x < lineLength + startLineX; x++)
            {
                Point point = new Point(x, y, sym);
                pList.Add(point);
            }
        }
    }
}
