using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class HorizontalBarrier
    {
        List<Point> pList;

        public HorizontalBarrier(int startLineX, int lineLength, int y, char sym)
        {
            pList = new List<Point>(lineLength);
            for (int i = startLineX; i < lineLength + startLineX; i++)
            {
                Point point = new Point(i, y, sym);
                pList.Add(point);
            }
        }

        public void LineDraw()
        {
            foreach(var i in pList)
            {
                i.Draw();
            }
        }
    }
}
