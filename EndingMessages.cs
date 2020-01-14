using System;

namespace OOPFirst
{
    class EndingMessages
    {
        /// <summary>
        /// Выводится сообщение о победе перса с информацией
        /// </summary>
        /// <param name="character">Имя перса</param>
        public void WinningMessege(Character character)
        {
            Console.Clear();
            Console.WriteLine($"Поздравляем, Вы победили! Вы прошли за {character.actinosCounter} ход(ов)");
            Console.WriteLine();
            character.Info();
            Console.ReadKey();
        }

        /// <summary>
        /// Выводится сообщение о гибели перса с информацией
        /// </summary>
        /// <param name="character">Имя перса</param>
        public void LosingMessage(Character character)
        {
            Console.Clear();
            Console.WriteLine($"Вы погибли. Сделанно {character.actinosCounter} ход(ов)");
            Console.WriteLine();
            character.Info();
            Console.ReadKey();
        }
    }
}
