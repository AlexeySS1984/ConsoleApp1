using System;
using System.Collections.Generic;

/// <summary>
/// Консольное приложение «Галактики».
/// Демонстрирует фильтрацию объектов по типу и отладку в Microsoft Visual Studio.
/// </summary>
namespace GalaxiesDebug
{
    /// <summary>
    /// Перечисление типов галактик по морфологической классификации Хаббла.
    /// </summary>
    enum GalaxyType
    {
        /// <summary>Эллиптическая галактика.</summary>
        Elliptical,

        /// <summary>Спиральная галактика.</summary>
        Spiral,

        /// <summary>Спиральная галактика с перемычкой.</summary>
        BarredSpiral,

        /// <summary>Неправильная галактика.</summary>
        Irregular
    }

    /// <summary>
    /// Представляет отдельную галактику с её характеристиками.
    /// </summary>
    class Galaxy
    {
        /// <summary>Название галактики.</summary>
        public string Name { get; set; }

        /// <summary>Морфологический тип галактики.</summary>
        public GalaxyType Type { get; set; }

        /// <summary>Расстояние до галактики в мегапарсеках.</summary>
        public double DistanceMpc { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Galaxy"/>.
        /// </summary>
        /// <param name="name">Название галактики.</param>
        /// <param name="type">Тип галактики.</param>
        /// <param name="distanceMpc">Расстояние в мегапарсеках.</param>
        public Galaxy(string name, GalaxyType type, double distanceMpc)
        {
            Name = name;
            Type = type;
            DistanceMpc = distanceMpc;
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{Name} [{Type}] — {DistanceMpc} Мпк";
    }

    class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// Создаёт список галактик и выводит спиральные галактики на консоль.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            var galaxies = new List<Galaxy>
            {
                new Galaxy("Млечный Путь",   GalaxyType.BarredSpiral, 0),
                new Galaxy("Андромеда",       GalaxyType.Spiral,       0.765),
                new Galaxy("Треугольника",    GalaxyType.Spiral,       0.970),
                new Galaxy("Большое Магелл.", GalaxyType.Irregular,    0.049),
                new Galaxy("Центавр A",       GalaxyType.Elliptical,   3.800),
                new Galaxy("NGC 1300",        GalaxyType.BarredSpiral, 18.7),
            };

            Console.WriteLine("=== Спиральные галактики ===");
            var spirals = FindGalaxies(galaxies, GalaxyType.Spiral);
            foreach (var g in spirals)
                Console.WriteLine(g);

            Console.WriteLine("\n=== Галактики с перемычкой ===");
            var barred = FindGalaxies(galaxies, GalaxyType.BarredSpiral);
            foreach (var g in barred)
                Console.WriteLine(g);
        }

        /// <summary>
        /// Возвращает из списка только галактики указанного типа.
        /// </summary>
        /// <param name="galaxies">Исходный список всех галактик.</param>
        /// <param name="type">Тип галактики для фильтрации.</param>
        /// <returns>
        /// Список объектов <see cref="Galaxy"/>, тип которых совпадает с <paramref name="type"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="galaxies"/> равно <c>null</c>.
        /// </exception>
        static List<Galaxy> FindGalaxies(List<Galaxy> galaxies, GalaxyType type)
        {
            if (galaxies == null)
                throw new ArgumentNullException(nameof(galaxies));

            var result = new List<Galaxy>();
            foreach (var galaxy in galaxies)
            {
                // Сравнение выполняется через перечисление, регистр не важен
                if (galaxy.Type == type)
                    result.Add(galaxy);
            }
            return result;
        }
    }
}
