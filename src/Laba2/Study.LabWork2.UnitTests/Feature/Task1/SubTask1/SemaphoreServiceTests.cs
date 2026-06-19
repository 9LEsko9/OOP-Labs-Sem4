using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
[NonParallelizable]
public sealed class SemaphoreServiceTests
{
    [Test]
    public void GetVersionNameReturnsSemaphoreName()
    {
        var service = new SemaphoreService();

        Assert.That(service.GetVersionName(), Is.EqualTo("Semaphore"));
    }

    [Test]
    public void CountPrimesReturnsExpectedResultForDefaultRange()
    {
        var service = new SemaphoreService();
        var originalOutput = Console.Out;
        Console.SetOut(TextWriter.Null);

        try
        {
            var result = service.CountPrimes(1, 10000, 4);

            Assert.That(result.PrimeCount, Is.EqualTo(1229));
            Assert.That(result.ThreadCount, Is.EqualTo(4));
            Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
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
    public void CountPrimesDoesNotWriteThreadProgress()
    {
        var service = new SemaphoreService();
        using var writer = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(writer);

        try
        {
            var result = service.CountPrimes(1, 10, 2);

            Assert.That(result.PrimeCount, Is.EqualTo(4));

            Assert.That(writer.ToString(), Is.Empty);
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }

    [Test]
    public void CountPrimesRejectsInvalidArguments()
    {
        var service = new SemaphoreService();

        Assert.That(() => service.CountPrimes(10, 1, 4), Throws.ArgumentException);
        Assert.That(() => service.CountPrimes(1, 10, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}
