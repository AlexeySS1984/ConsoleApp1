using System;

/// <summary>
/// Консольное приложение «Буквы».
/// Демонстрирует построение строки из массива символов и её отправку,
/// а также применение инструментов отладки Microsoft Visual Studio.
/// </summary>
namespace LettersDebug
{
    class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// Строит имя из набора букв в цикле и передаёт его в <see cref="SendMessage"/>.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            // Массив букв для построения имени
            char[] letters = { 'f', 'r', 'e', 'd', ' ', 'f', 'l', 'i', 'n', 't' };

            string name = string.Empty;

            // Цикл перебирает все элементы массива.
            // Исправлено: граница i < letters.Length (было i <= letters.Length — ошибка выхода за границы)
            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
            }

            SendMessage(name);
        }

        /// <summary>
        /// Выводит приветственное сообщение для указанного имени.
        /// </summary>
        /// <param name="name">Имя получателя сообщения.</param>
        /// <remarks>
        /// Если <paramref name="name"/> пустое или состоит только из пробелов,
        /// выводится сообщение с предупреждением.
        /// </remarks>
        static void SendMessage(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Предупреждение: имя не задано.");
                return;
            }

            Console.WriteLine($"Привет, {name}! Это сообщение для вас.");
        }
    }
}
