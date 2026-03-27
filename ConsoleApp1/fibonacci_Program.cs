using System;

/// <summary>
/// Консольное приложение для вычисления чисел Фибоначчи.
/// Используется для демонстрации отладки в Microsoft Visual Studio.
/// </summary>
namespace FibonacciDebug
{
    class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// Запрашивает у пользователя номер позиции и выводит соответствующее число Фибоначчи.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            Console.WriteLine("=== Числа Фибоначчи ===");
            Console.Write("Введите номер позиции (n >= 0): ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Ошибка: введите целое неотрицательное число.");
                return;
            }

            long result = Fibonacci(n);
            Console.WriteLine($"Fibonacci({n}) = {result}");
        }

        /// <summary>
        /// Рекурсивно вычисляет n-е число Фибоначчи.
        /// </summary>
        /// <remarks>
        /// Последовательность Фибоначчи: 0, 1, 1, 2, 3, 5, 8, 13, ...
        /// Базовые случаи: F(0) = 0, F(1) = 1.
        /// Рекурсивный случай: F(n) = F(n-1) + F(n-2).
        /// </remarks>
        /// <param name="n">Порядковый номер числа в последовательности (начиная с 0).</param>
        /// <returns>n-е число Фибоначчи.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="n"/> отрицательное.
        /// </exception>
        static long Fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Аргумент не может быть отрицательным.");

            // Базовые случаи рекурсии
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Рекурсивный случай
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
