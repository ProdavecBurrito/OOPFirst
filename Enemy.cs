using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Enemy
    {
        int x;
        int y;
        int count = 1;
        char sym = '2';
        char saveSym = '2';
        List<Enemy> enemies;
        Random rand;

        Map map = new Map();
        
        public Enemy (int number)
        {
            map.MapReader();
            rand = new Random();
            enemies = new List<Enemy>(number);
            for (int i = 0; i < number; i++)
            {
                Thread.Sleep(1);
                x = rand.Next(1, 49);
                y = rand.Next(1, 19);
                Enemy m = new Enemy(x, y);
                enemies.Add(m);
            }
        }

        public Enemy (int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        /// <summary>
        /// Логика преследования
        /// </summary>
        /// <param name="pers"></param>
        public void MoveToChar(Character pers) // Это одеяло из if-ов конечно напрягает, но как по другому сделать - я хз, если честно
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].x != pers.x || enemies[i].y != pers.y)
                {
                    if (enemies[i].x == pers.x && enemies[i].y != pers.y)
                    {
                        if (enemies[i].y > pers.y)
                        {
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].y - 1 == map.barrierList[j].y && enemies[i].x == map.barrierList[j].x)
                                {
                                    while (enemies[i].y -1 == map.barrierList[j].y && enemies[i].x + count == map.barrierList[j].x 
                                          || enemies[i].y - 1 == map.barrierList[j].y && enemies[i].x - count == map.barrierList[j].x)
                                    {
                                        count++;
                                    }
                                }
                                else if (j == map.barrierList.Count - 1)
                                {
                                    enemies[i].y--;
                                }
                            }
                        }
                        if (enemies[i].y < pers.y)
                        {
                            enemies[i].x++;
                        }
                    }
                    else if (enemies[i].y == pers.y && enemies[i].x != pers.x)
                    {
                        if (enemies[i].x > pers.x)
                        {
                            enemies[i].x--;
                        }
                        if (enemies[i].x < pers.x)
                        {
                            enemies[i].x++;
                        }
                    }
                    else if (enemies[i].x - pers.x < enemies[i].y - pers.y && enemies[i].x != pers.x)
                    {
                        if (enemies[i].x > pers.x)
                        {
                            enemies[i].x--;
                        }
                        else if (enemies[i].x < pers.x)
                        {
                            enemies[i].x++;
                        }
                    }
                    else if (x - pers.x > enemies[i].y - pers.y && enemies[i].y != pers.y)
                    {
                        if (enemies[i].y > pers.y)
                        {
                            enemies[i].y--;
                        }
                        else if (enemies[i].y < pers.y)
                        {
                            enemies[i].y++;
                        }
                    }
                }
            }
        }

        public void ClearEnemis()
        {
            foreach (Enemy i in enemies)
            {
                i.sym = ' ';
                i.Draw();
            }
        }

        public void DrawEnemies()
        {
            foreach (Enemy i in enemies)
            {
                i.Draw();
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void WriteSym()
        {
            foreach (Enemy i in enemies)
            {
                i.sym = saveSym;
                i.Draw();
            }
        }
    }
}
