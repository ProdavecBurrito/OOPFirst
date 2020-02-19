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

        Messages message = new Messages();
        public int healActiv = 0;
        Random rand;

        int x;
        int y;
        char sym = 'H';
        public HealingElixir(int _number)
        {
            rand = new Random();
            hList = new List<HealingElixir>(_number);
            for (int i = 0; i < _number; i++)
            {
                Thread.Sleep(1);
                x = rand.Next(1, 49);
                y = rand.Next(1, 19);
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
