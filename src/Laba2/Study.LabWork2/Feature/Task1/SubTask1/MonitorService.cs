using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    /// <summary>
    /// Подсчитывает простые числа в указанном диапазоне с синхронизацией через Monitor.
    /// </summary>
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        var syncRoot = new object();

        return PrimeCounterRunner.CountPrimes(start, end, threadCount, GetVersionName(), action =>
        {
            lock (syncRoot)
            {
                action();
            }
        });
    }

    /// <summary>
    /// Возвращает название варианта синхронизации.
    /// </summary>
    public string GetVersionName() => "Monitor";
}
