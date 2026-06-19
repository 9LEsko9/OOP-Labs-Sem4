using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 3. Использует Semaphore для синхронизации
/// </summary>
public sealed class SemaphoreService : IPrimeCounter
{
    /// <summary>
    /// Подсчитывает простые числа в указанном диапазоне с синхронизацией через Semaphore.
    /// </summary>
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        using var semaphore = new Semaphore(1, 1);

        return PrimeCounterRunner.CountPrimes(start, end, threadCount, GetVersionName(), action =>
        {
            semaphore.WaitOne();
            try
            {
                action();
            }
            finally
            {
                semaphore.Release();
            }
        });
    }

    /// <summary>
    /// Возвращает название варианта синхронизации.
    /// </summary>
    public string GetVersionName() => "Semaphore";
}
