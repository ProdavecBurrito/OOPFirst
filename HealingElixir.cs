using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class HealingElixir
    {
        Messages message = new Messages();
        public int healActiv = 0;

        int x;
        int y;
        char sym = 'H';
        public HealingElixir(int _number)
        {
            Random rand = new Random();
            List<HealingElixir> hList = new List<HealingElixir>(_number);
            for (int i = 0; i < _number; i++)
            {
                x = rand.Next(1, 48);
                y = rand.Next(1, 18);
                Point p = new Point(x, y);
                HealingElixir m = new HealingElixir(p);
                hList.Add(m);
            }
        }

        public HealingElixir(Point p)
        {
            x = p.x;
            y = p.y;
        }

        /// <summary>
        /// Проверка на то, подобрал ли перс хилку
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool GrabBy(Character character, List<HealingElixir> healings)
        {
            for (int i = 0; i < healings.Count; i++)
            {
                if (character.x == healings[i].x && character.y == healings[i].y)
                {
                    if (healings[i].ElixirActiv())
                    {
                        character.healingElixirs += 1;
                        message.WriteAdditionalStatus("Вы подобрали хилку");
                        healActiv = 1;
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
        public void DrawHealings(List<HealingElixir> healings)
        {
            foreach (HealingElixir i in healings)
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
