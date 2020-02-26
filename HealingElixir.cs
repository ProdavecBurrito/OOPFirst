using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class HealingElixir
    {
        List<HealingElixir> hList;
        Map map = new Map();
        Messages message = new Messages();
        public int healActiv = 0;
        Random rand;

        int x;
        int _x;
        int y;
        int _y;
        char sym = 'H';
        public HealingElixir(int _number)
        {
            map.MapReader();
            rand = new Random(Guid.NewGuid().GetHashCode());
            hList = new List<HealingElixir>(_number);
            for (int i = 0; i < _number; i++)
            {
                _x = rand.Next(1, 49);
                for (int j = 0; j < map.barrierList.Count; j++)
                {
                    if (_x == map.barrierList[j].x)
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
                    if (j == map.barrierList.Count - 1 && _y != map.barrierList[j].y)
                    {
                        y = _y;
                    }
                }
                HealingElixir m = new HealingElixir(x, y);
                hList.Add(m);
            }
        }

        public HealingElixir(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        /// <summary>
        /// Проверка на то, подобрал ли перс хилку
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool GrabBy(Character character)
        {
            for (int i = 0; i < hList.Count; i++)
            {
                if (character.x == hList[i].x && character.y == hList[i].y)
                {
                    if (hList[i].ElixirActiv())
                    {
                        character.healingElixirs += 1;
                        message.WriteAdditionalStatus("Вы подобрали хилку");
                        hList[i].healActiv = 1;
                        hList[i].sym = ' ';
                        return true;
                    }
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
        public void DrawHealings()
        {
            foreach (HealingElixir i in hList)
            {
                i.Draw();
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
