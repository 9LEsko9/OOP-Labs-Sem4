using System.Net;
using System.Net.Http.Json;
using LibraryApi.Dtos.Authors;

namespace LibraryApi.Tests.Integration;

public class AuthorsControllerTests : IntegrationTestBase
{
    [Test]
    public async Task CreateAuthor_ShouldReturnCreatedAuthor()
    {
        var request = new CreateAuthorRequest
        {
            Name = "Leo Tolstoy",
            Country = "Russia"
        };

        var response = await Client.PostAsJsonAsync("/api/authors", request);
        var author = await response.Content.ReadFromJsonAsync<AuthorResponse>();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(author, Is.Not.Null);
        Assert.That(author!.Id, Is.GreaterThan(0));
        Assert.That(author.Name, Is.EqualTo("Leo Tolstoy"));
        Assert.That(author.Country, Is.EqualTo("Russia"));
        Assert.That(author.BooksCount, Is.EqualTo(0));
    }

    [Test]
    public async Task GetAuthors_ShouldReturnAuthors()
    {
        await CreateAuthorAsync("Leo Tolstoy", "Russia");
        await CreateAuthorAsync("Jane Austen", "United Kingdom");

        var authors = await Client.GetFromJsonAsync<List<AuthorResponse>>("/api/authors");

        Assert.That(authors, Is.Not.Null);
        Assert.That(authors!, Has.Count.EqualTo(2));
        Assert.That(authors.Select(author => author.Name), Does.Contain("Leo Tolstoy"));
        Assert.That(authors.Select(author => author.Name), Does.Contain("Jane Austen"));
    }

    [Test]
    public async Task GetAuthorById_ShouldReturnAuthor()
    {
        var createdAuthor = await CreateAuthorAsync("Leo Tolstoy", "Russia");

        var author = await Client.GetFromJsonAsync<AuthorResponse>($"/api/authors/{createdAuthor.Id}");

        Assert.That(author, Is.Not.Null);
        Assert.That(author!.Id, Is.EqualTo(createdAuthor.Id));
        Assert.That(author.Name, Is.EqualTo("Leo Tolstoy"));
        Assert.That(author.Country, Is.EqualTo("Russia"));
    }

    [Test]
    public async Task UpdateAuthor_ShouldUpdateAuthor()
    {
        var createdAuthor = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var request = new UpdateAuthorRequest
        {
            Name = "Lev Tolstoy",
            Country = "Russian Empire"
        };

        var updateResponse = await Client.PutAsJsonAsync($"/api/authors/{createdAuthor.Id}", request);
        var updatedAuthor = await Client.GetFromJsonAsync<AuthorResponse>($"/api/authors/{createdAuthor.Id}");

        Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(updatedAuthor, Is.Not.Null);
        Assert.That(updatedAuthor!.Name, Is.EqualTo("Lev Tolstoy"));
        Assert.That(updatedAuthor.Country, Is.EqualTo("Russian Empire"));
    }

    [Test]
    public async Task DeleteAuthor_ShouldDeleteAuthor()
    {
        var createdAuthor = await CreateAuthorAsync("Leo Tolstoy", "Russia");

        var deleteResponse = await Client.DeleteAsync($"/api/authors/{createdAuthor.Id}");
        var getResponse = await Client.GetAsync($"/api/authors/{createdAuthor.Id}");

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetMissingAuthor_ShouldReturnNotFound()
    {
        var response = await Client.GetAsync("/api/authors/999");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task CreateAuthor_WithEmptyName_ShouldReturnBadRequest()
    {
        var request = new CreateAuthorRequest
        {
            Name = "",
            Country = "Russia"
        };

        var response = await Client.PostAsJsonAsync("/api/authors", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    private async Task<AuthorResponse> CreateAuthorAsync(string name, string country)
    {
        var response = await Client.PostAsJsonAsync("/api/authors", new CreateAuthorRequest
        {
            Name = name,
            Country = country
        });

        var author = await response.Content.ReadFromJsonAsync<AuthorResponse>();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(author, Is.Not.Null);

        return author!;
    }
}
