using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
[NonParallelizable]
public sealed class MonitorServiceTests
{
    [Test]
    public void GetVersionNameReturnsMonitorName()
    {
        var service = new MonitorService();

        Assert.That(service.GetVersionName(), Is.EqualTo("Monitor"));
    }

    [Test]
    public void CountPrimesReturnsExpectedResultForDefaultRange()
    {
        var service = new MonitorService();
        var originalOutput = Console.Out;
        Console.SetOut(TextWriter.Null);

        try
        {
            var result = service.CountPrimes(1, 10000, 4);

            Assert.That(result.PrimeCount, Is.EqualTo(1229));
            Assert.That(result.ThreadCount, Is.EqualTo(4));
            Assert.That(result.SynchronizationType, Is.EqualTo("Monitor"));
            Assert.That(result.FoundPrimes, Has.Count.EqualTo(1229));
            Assert.That(result.FoundPrimes, Does.Contain(2));
            Assert.That(result.FoundPrimes, Does.Contain(9973));
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }

    [Test]
    public void CountPrimesWritesThreadProgressAndFoundPrimes()
    {
        var service = new MonitorService();
        using var writer = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(writer);

        try
        {
            var result = service.CountPrimes(1, 10, 2);

            Assert.That(result.PrimeCount, Is.EqualTo(4));

            var output = writer.ToString();
            Assert.That(output, Does.Contain("Поток 1: проверяется число 1"));
            Assert.That(output, Does.Contain("Поток 1: найдено простое число 2"));
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }

    [Test]
    public void CountPrimesRejectsInvalidArguments()
    {
        var service = new MonitorService();

        Assert.That(() => service.CountPrimes(10, 1, 4), Throws.ArgumentException);
        Assert.That(() => service.CountPrimes(1, 10, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}
