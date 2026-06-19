using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

internal static class PrimeCounterRunner
{
    public static PrimeCountResultDto CountPrimes(
        int start,
        int end,
        int threadCount,
        string synchronizationType,
        Action<Action> synchronize)
    {
        if (start > end)
        {
            throw new ArgumentException("Начало диапазона не может быть больше конца диапазона.", nameof(start));
        }

        if (threadCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(threadCount), "Количество потоков должно быть больше нуля.");
        }

        ArgumentNullException.ThrowIfNull(synchronize);

        var primeCount = 0;
        var foundPrimes = new List<int>();
        var ranges = SplitRange(start, end, threadCount);
        var threads = new Thread[threadCount];
        var stopwatch = Stopwatch.StartNew();

        for (var index = 0; index < threadCount; index++)
        {
            var range = ranges[index];

            threads[index] = new Thread(() =>
            {
                for (var number = range.Start; number <= range.End; number++)
                {
                    if (!IsPrime(number))
                    {
                        continue;
                    }

                    synchronize(() =>
                    {
                        primeCount++;
                        foundPrimes.Add(number);
                    });
                }
            });
            threads[index].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = primeCount,
            ExecutionTime = stopwatch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = synchronizationType,
            FoundPrimes = foundPrimes
        };
    }

    private static (int Start, int End)[] SplitRange(int start, int end, int threadCount)
    {
        var totalNumbers = end - start + 1;
        var baseSize = totalNumbers / threadCount;
        var remainder = totalNumbers % threadCount;
        var ranges = new (int Start, int End)[threadCount];
        var currentStart = start;

        for (var index = 0; index < threadCount; index++)
        {
            var size = baseSize + (index < remainder ? 1 : 0);
            var currentEnd = currentStart + size - 1;
            ranges[index] = (currentStart, currentEnd);
            currentStart = currentEnd + 1;
        }

        return ranges;
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number == 2)
        {
            return true;
        }

        if (number % 2 == 0)
        {
            return false;
        }

        for (var divisor = 3; divisor <= number / divisor; divisor += 2)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }
}
