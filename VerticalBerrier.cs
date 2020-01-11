using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class VerticalBerrier : Object
    {
        public VerticalBerrier(int startLineY, int lineLength, int x, char sym)
        {
            pList = new List<Point>(lineLength);
            for (int y = startLineY; y < lineLength + startLineY; y++)
            {
                Point point = new Point(x, y, sym);
                pList.Add(point);
            }
        }
    }
}
