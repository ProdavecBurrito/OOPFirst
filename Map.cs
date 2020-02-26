using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPFirst
{
    class Map
    {
        Messages message = new Messages();
        public int MapWidth = 50;
        public int MapHight = 20;
        public char[,] map;

        List<Point> barrierList;

        public char[,] MapReader()
        {
            using (var readMap = new StreamReader(@"C:\Users\shipo\source\repos\OOPFirst\Map.txt"))
            {
                barrierList = new List<Point>();
                int i = 0;
                map = new char[MapHight, MapWidth];
                while (!readMap.EndOfStream)
                {
                    string mapRow = readMap.ReadLine();
                    for (int j = 0; j < mapRow.Length; ++j)
                    {
                        map[i, j] = mapRow[j];
                        if (map[i, j] == '#')
                        {
                            Point p = new Point(j, i, '#');
                            barrierList.Add(p);
                        }
                    }
                    i++;
                }
            }
            return map;
        }

        public void MapWriter(char[,] map)
        {
            for (int i = 0; i < MapHight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Функционал барьеров

        /// <summary>
        /// Проверка, не наступил ли перс на препятствие
        /// </summary>
        /// <param name="character">Имя персонажа</param>
        /// <returns></returns>dd
        public bool StepBy(Character character)
        {
            for (int i = 0; i < barrierList.Count; i++)
            {
                if (character.x == barrierList[i].x && character.y == barrierList[i].y)
                {
                    character.Dmg();
                    message.WriteAdditionalStatus("Вы наступили на препятствие");
                    character.ReturnLastPosition();
                    character.Draw();
                    barrierList[i].sym = '#';
                    barrierList[i].Draw();
                    return true;
                }
            }
            return false;
        }

        public void DrawBarriers()
        {
            foreach (Point i in barrierList)
            {
                i.Draw();
            }
        }
    }
}