using Study.LabWork2;

namespace Study.LabWork2.UnitTests;

[TestFixture]
[NonParallelizable]
public sealed class ProgramTests
{
    [Test]
    public void MainSavesPrimeNumbersBySynchronizationTypeWithoutPerNumberConsoleProgress()
    {
        var tempDirectory = Path.Combine(Path.GetTempPath(), $"laba2-{Guid.NewGuid():N}");
        Directory.CreateDirectory(tempDirectory);

        var originalDirectory = Environment.CurrentDirectory;
        var originalOutput = Console.Out;
        using var output = new StringWriter();

        try
        {
            Environment.CurrentDirectory = tempDirectory;
            Console.SetOut(output);

            Program.Main();

            var resultPath = Path.Combine(tempDirectory, "prime-numbers.txt");
            Assert.That(File.Exists(resultPath), Is.True);

            var consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Not.Contain("проверяется число"));
            Assert.That(consoleOutput, Does.Not.Contain("найдено простое число"));
            Assert.That(consoleOutput, Does.Contain("=== Monitor ==="));
            Assert.That(consoleOutput, Does.Contain("=== Mutex ==="));
            Assert.That(consoleOutput, Does.Contain("=== Semaphore ==="));

            var fileContent = File.ReadAllText(resultPath);
            Assert.That(fileContent, Does.Contain("=== Monitor ==="));
            Assert.That(fileContent, Does.Contain("=== Mutex ==="));
            Assert.That(fileContent, Does.Contain("=== Semaphore ==="));
            Assert.That(fileContent, Does.Contain("2, 3, 5, 7"));
            Assert.That(fileContent, Does.Contain("9973"));
            Assert.That(fileContent, Does.Not.Contain("проверяется число"));
        }
        finally
        {
            Console.SetOut(originalOutput);
            Environment.CurrentDirectory = originalDirectory;
            Directory.Delete(tempDirectory, true);
        }
    }
}
