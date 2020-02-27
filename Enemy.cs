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
        int _x;
        int y;
        int _y;
        char sym = '2';
        char saveSym = '2';
        List<Enemy> enemies;
        Random rand;

        Map map = new Map();
        
        public Enemy (int number)
        {
            map.MapReader();
            rand = new Random(Guid.NewGuid().GetHashCode());
            enemies = new List<Enemy>(number);
            for (int i = 0; i < number; i++)
            {
                _x = rand.Next(1, 49);
                for (int j = 0; j < map.barrierList.Count; j++)
                {
                    if (_x == map.barrierList[j].x )
                    {
                        j = 0;
                        _x = rand.Next(1, 49);
                    }
                    else if (j == map.barrierList.Count - 1 && _x != map.barrierList[j].x)
                    {
                        x = _x;
                    }
                }
                _y = rand.Next(1, 19);
                for (int j = 0; j < map.barrierList.Count; j++)
                {
                    if (_y == map.barrierList[j].y)
                    {
                        j = 0;
                        _y = rand.Next(1, 19);
                    }
                    else if (j == map.barrierList.Count - 1 && _y != map.barrierList[j].y)
                    {
                        y = _y;
                    }
                }
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
                    // Выравнивание по оси У
                    if (enemies[i].x == pers.x && enemies[i].y != pers.y)
                    {
                        if (enemies[i].y > pers.y)
                        {
                            // Логика обхода препятствий (ЛОП)
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].y - 1 == map.barrierList[j].y && enemies[i].x == map.barrierList[j].x)
                                {
                                    for (int l = 0; l < map.barrierList.Count; l++)
                                    {
                                        if (enemies[i].x < pers.x && enemies[i].x + 1 != map.barrierList[l].x)
                                        {
                                            enemies[i].x++;
                                            break;
                                        }
                                        else if (enemies[i].x > pers.x && enemies[i].x - 1 != map.barrierList[l].x)
                                        {
                                            enemies[i].x--;
                                            break;
                                        }
                                    }
                                }
                                else if (j == map.barrierList.Count - 1 && enemies[i].y - 1 != map.barrierList[j].y)
                                {
                                    enemies[i].y--;
                                }
                            }
                        }
                        else if (enemies[i].y < pers.y)
                        {
                            // ЛОП
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].y + 1 == map.barrierList[j].y && enemies[i].x == map.barrierList[j].x)
                                {
                                    for (int l = 0; l < map.barrierList.Count; l++)
                                    {
                                        if (enemies[i].x < pers.x && enemies[i].x + 1 != map.barrierList[l].x)
                                        {
                                            enemies[i].x++;
                                            break;
                                        }
                                        else if (enemies[i].x > pers.x && enemies[i].x - 1 != map.barrierList[l].x)
                                        {
                                            enemies[i].x--;
                                            break;
                                        }
                                    }
                                }
                                else if (j == map.barrierList.Count - 1 && enemies[i].y + 1 != map.barrierList[j].y)
                                {
                                    enemies[i].y++;
                                }
                            }
                        }
                    }
                    // Выравнивание по оси Х
                    else if (enemies[i].y == pers.y && enemies[i].x != pers.x)
                    {
                        if (enemies[i].x > pers.x)
                        {
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].x - 1 == map.barrierList[j].x && enemies[i].y == map.barrierList[j].y)
                                {
                                    for (int l = 0; l < map.barrierList.Count; l++)
                                    {
                                        if (enemies[i].y + 1 != map.barrierList[l].y && enemies[i].y < pers.y)
                                        {
                                            enemies[i].y++;
                                            break;
                                        }
                                        else if (l == map.barrierList.Count - 1 && enemies[i].y-1 != map.barrierList[l].y)
                                        {
                                            enemies[i].y--;
                                            break;
                                        }
                                    }
                                }
                                else if (j == map.barrierList.Count - 1 && enemies[i].x - 1 != map.barrierList[j].x)
                                {
                                    enemies[i].x--;
                                }
                            }
                        }
                        else if (enemies[i].x < pers.x)
                        {
                            enemies[i].x++;
                        }
                    }
                    // Если врагу быстрее выравнится по оси Х
                    else if (enemies[i].x - pers.x < enemies[i].y - pers.y && enemies[i].x != pers.x)
                    {
                        if (enemies[i].x > pers.x)
                        {
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].x - 1 == map.barrierList[j].x)
                                {
                                    for (int l = 0; l < map.barrierList.Count; l++)
                                    {
                                        if (enemies[i].y + 1 != map.barrierList[l].y && enemies[i].y < pers.y)
                                        {
                                            enemies[i].y++;
                                            break;
                                        }
                                        else if (enemies[i].y - 1 != map.barrierList[l].y && enemies[i].y > pers.y)
                                        {
                                            enemies[i].y--;
                                            break;
                                        }
                                    }
                                }
                                else if (j == map.barrierList.Count - 1 && enemies[i].y - 1 != map.barrierList[j].y)
                                {
                                    enemies[i].x--;
                                }
                            }
                        }
                        else if (enemies[i].x < pers.x)
                        {
                            enemies[i].x++;
                        }
                    }
                    // Если врагу быстрее выравнится по оси У
                    else if (enemies[i].x - pers.x > enemies[i].y - pers.y && enemies[i].y != pers.y)
                    {
                        if (enemies[i].y > pers.y)
                        {
                            // ЛОП
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].y - 1 == map.barrierList[j].y && enemies[i].x == map.barrierList[j].x)
                                {
                                    for (int l = 0; l < map.barrierList.Count; l++)
                                    {
                                        if (enemies[i].x + 1 != map.barrierList[l].x && enemies[i].x < pers.x)
                                        {
                                            enemies[i].x++;
                                            break;
                                        }
                                        else if (enemies[i].x - 1 != map.barrierList[l].x && enemies[i].x > pers.x)
                                        {
                                            enemies[i].x--;
                                            break;
                                        }
                                    }
                                }
                                else if(j == map.barrierList.Count - 1 && enemies[i].y - 1 != map.barrierList[j].y)
                                {
                                    enemies[i].y--;
                                }
                            }
                        }
                        else if (enemies[i].y < pers.y)
                        {
                            // ЛОП
                            for (int j = 0; j < map.barrierList.Count; j++)
                            {
                                if (enemies[i].y + 1 == map.barrierList[j].y && enemies[i].x == map.barrierList[j].x)
                                {
                                    for (int l = 0; l < map.barrierList.Count; l++)
                                    {
                                        if (enemies[i].x < pers.x && enemies[i].x + 1 != map.barrierList[l].x)
                                        {
                                            enemies[i].x++;
                                            break;
                                        }
                                        else if (enemies[i].x > pers.x && enemies[i].x - 1 != map.barrierList[l].x)
                                        {
                                            enemies[i].x--;
                                            break;
                                        }
                                    }
                                }
                                else if (j == map.barrierList.Count - 1 && enemies[i].y + 1 != map.barrierList[j].y)
                                {
                                    enemies[i].y++;
                                }
                            }
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
