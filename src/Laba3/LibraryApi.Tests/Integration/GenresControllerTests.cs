using System.Net;
using System.Net.Http.Json;
using LibraryApi.Dtos.Genres;

namespace LibraryApi.Tests.Integration;

public class GenresControllerTests : IntegrationTestBase
{
    [Test]
    public async Task CreateGenre_ShouldReturnCreatedGenre()
    {
        var request = new CreateGenreRequest
        {
            Name = "Novel"
        };

        var response = await Client.PostAsJsonAsync("/api/genres", request);
        var genre = await response.Content.ReadFromJsonAsync<GenreResponse>();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre!.Id, Is.GreaterThan(0));
        Assert.That(genre.Name, Is.EqualTo("Novel"));
        Assert.That(genre.BooksCount, Is.EqualTo(0));
    }

    [Test]
    public async Task GetGenres_ShouldReturnGenres()
    {
        await CreateGenreAsync("Novel");
        await CreateGenreAsync("Drama");

        var genres = await Client.GetFromJsonAsync<List<GenreResponse>>("/api/genres");

        Assert.That(genres, Is.Not.Null);
        Assert.That(genres!, Has.Count.EqualTo(2));
        Assert.That(genres.Select(genre => genre.Name), Does.Contain("Novel"));
        Assert.That(genres.Select(genre => genre.Name), Does.Contain("Drama"));
    }

    [Test]
    public async Task UpdateGenre_ShouldUpdateGenre()
    {
        var createdGenre = await CreateGenreAsync("Novel");
        var request = new UpdateGenreRequest
        {
            Name = "Historical Novel"
        };

        var updateResponse = await Client.PutAsJsonAsync($"/api/genres/{createdGenre.Id}", request);
        var updatedGenre = await Client.GetFromJsonAsync<GenreResponse>($"/api/genres/{createdGenre.Id}");

        Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(updatedGenre, Is.Not.Null);
        Assert.That(updatedGenre!.Name, Is.EqualTo("Historical Novel"));
    }

    [Test]
    public async Task DeleteGenre_ShouldDeleteGenre()
    {
        var createdGenre = await CreateGenreAsync("Novel");

        var deleteResponse = await Client.DeleteAsync($"/api/genres/{createdGenre.Id}");
        var getResponse = await Client.GetAsync($"/api/genres/{createdGenre.Id}");

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetMissingGenre_ShouldReturnNotFound()
    {
        var response = await Client.GetAsync("/api/genres/999");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task CreateGenre_WithEmptyName_ShouldReturnBadRequest()
    {
        var request = new CreateGenreRequest
        {
            Name = ""
        };

        var response = await Client.PostAsJsonAsync("/api/genres", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    private async Task<GenreResponse> CreateGenreAsync(string name)
    {
        var response = await Client.PostAsJsonAsync("/api/genres", new CreateGenreRequest
        {
            Name = name
        });

        var genre = await response.Content.ReadFromJsonAsync<GenreResponse>();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(genre, Is.Not.Null);

        return genre!;
    }
}
