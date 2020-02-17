﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirst
{
    class Messages
    {

        /// <summary>
        /// Выводит победное сообщение
        /// </summary>
        public void WinningMessege(Character character)
        {
            Console.Clear();
            Console.WriteLine($"Поздравляем, Вы победили! Вы прошли за {character.actinosCounter} ход(ов)");
            Console.WriteLine();
            Info(character);
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
            Info(character);
            Console.ReadKey();
        }

        public void ClearStatus()
        {
            Console.SetCursorPosition(52, 1);
            Console.WriteLine("                             ");
        }

        /// <summary>
        /// Чистит дополнительный статус
        /// </summary>
        public void ClearAdditionalStatus()
        {
            Console.SetCursorPosition(52, 2);
            Console.WriteLine("                             ");
        }

        /// <summary>
        /// Выводит статус
        /// </summary>
        /// <param name="status"></param>
        public void WriteStatus(string status)
        {
            Console.SetCursorPosition(52, 1);
            ClearStatus();
            Console.SetCursorPosition(52, 1);
            Console.WriteLine($"{status}");
        }

        /// <summary>
        /// Выводит дополнительный статус
        /// </summary>
        /// <param name="status"></param>
        public void WriteAdditionalStatus(string status)
        {
            Console.SetCursorPosition(52, 2);
            ClearAdditionalStatus();
            Console.SetCursorPosition(52, 2);
            Console.WriteLine($"{status}");
        }

        /// <summary>
        /// Чистит предложение
        /// </summary>
        /// <param name="word"></param>
        public void ClearLine(string word)
        {
            char[] empty = new char[word.Length];
            for (int i = 0; i < word.Length - 1; i++)
            {
                empty[i] = ' ';
            }
            empty.ToString();
            Console.WriteLine(empty);
        }

        /// <summary>
        /// Чистит информацию о персонаже
        /// </summary>
        public void ClearInfo(Character character)
        {
            ClearLine(character.writeName);

            ClearLine(character.writeCoord);

            ClearLine(character.writeHealth);

            ClearLine(character.writeHealingEl);
        }


        /// <summary>
        /// Выводит информацию о персонаже
        /// </summary>
        public void Info(Character character)
        {
            character.writeName = ($"Персонаж {character.name}");
            Console.WriteLine(character.writeName);

            character.writeCoord = ($"Координаты {character.x}х{character.y}");
            Console.WriteLine(character.writeCoord);

            character.writeHealth = ($"Колл-во жизней {character.health}");
            Console.WriteLine(character.writeHealth);

            character.writeHealingEl = ($"Колл-во хилок {character.healingElixirs}");
            Console.WriteLine(character.writeHealingEl);
        }
    }
}