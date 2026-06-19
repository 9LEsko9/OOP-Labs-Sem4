namespace LibraryApi.Tests.Integration;

[TestFixture]
[NonParallelizable]
public abstract class IntegrationTestBase
{
    protected TestWebApplicationFactory Factory = null!;
    protected HttpClient Client = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        Factory = new TestWebApplicationFactory();
        await Factory.InitializeAsync();

        Client = Factory.CreateClient();
    }

    [SetUp]
    public async Task SetUp()
    {
        await TestDatabaseCleaner.ClearAsync(Factory.Services);
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        Client.Dispose();
        await Factory.DisposeAsync();
    }
}
