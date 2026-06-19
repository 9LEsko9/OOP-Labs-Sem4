using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

/// <summary>
/// Начальная точка входа для заданий лабораторной работы №2.
/// </summary>
public static class Program
{
    /// <summary>
    /// Имя файла, в который сохраняются найденные простые числа.
    /// </summary>
    public const string PrimeNumbersFileName = "prime-numbers.txt";

    private const int START = 1;
    private const int END = 10000;
    private const int THREAD_COUNT = 4;

    /// <summary>
    /// Запускает задание 1.1 для трех вариантов синхронизации.
    /// </summary>
    public static void Main()
    {
        IPrimeCounter[] counters =
        [
            new MonitorService(),
            new MutexService(),
            new SemaphoreService()
        ];

        var primeNumberFileLines = new List<string>();

        foreach (var counter in counters)
        {
            Console.WriteLine($"=== {counter.GetVersionName()} ===");
            var result = counter.CountPrimes(START, END, THREAD_COUNT);
            Console.WriteLine(result);
            Console.WriteLine();

            primeNumberFileLines.Add($"=== {result.SynchronizationType} ===");
            primeNumberFileLines.Add(string.Join(", ", result.FoundPrimes.OrderBy(number => number)));
            primeNumberFileLines.Add(string.Empty);
        }

        File.WriteAllLines(PrimeNumbersFileName, primeNumberFileLines);
        Console.WriteLine($"Простые числа сохранены в файл: {Path.GetFullPath(PrimeNumbersFileName)}");
    }
}
