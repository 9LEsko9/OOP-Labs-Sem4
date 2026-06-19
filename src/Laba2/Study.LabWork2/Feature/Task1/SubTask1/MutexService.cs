using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 2. Использует Mutex для синхронизации
/// </summary>
public sealed class MutexService : IPrimeCounter
{
    /// <summary>
    /// Подсчитывает простые числа в указанном диапазоне с синхронизацией через Mutex.
    /// </summary>
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        using var mutex = new Mutex();

        return PrimeCounterRunner.CountPrimes(start, end, threadCount, GetVersionName(), action =>
        {
            mutex.WaitOne();
            try
            {
                action();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        });
    }

    /// <summary>
    /// Возвращает название варианта синхронизации.
    /// </summary>
    public string GetVersionName() => "Mutex";
}
