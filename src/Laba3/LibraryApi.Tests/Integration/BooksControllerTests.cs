using System.Net;
using System.Net.Http.Json;
using LibraryApi.Dtos.Authors;
using LibraryApi.Dtos.Books;
using LibraryApi.Dtos.Genres;

namespace LibraryApi.Tests.Integration;

public class BooksControllerTests : IntegrationTestBase
{
    [Test]
    public async Task CreateBook_ShouldReturnCreatedBook()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var request = new CreateBookRequest
        {
            Title = "War and Peace",
            Year = 1869,
            AuthorId = author.Id
        };

        var response = await Client.PostAsJsonAsync("/api/books", request);
        var book = await response.Content.ReadFromJsonAsync<BookResponse>();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(book, Is.Not.Null);
        Assert.That(book!.Id, Is.GreaterThan(0));
        Assert.That(book.Title, Is.EqualTo("War and Peace"));
        Assert.That(book.Year, Is.EqualTo(1869));
        Assert.That(book.AuthorId, Is.EqualTo(author.Id));
        Assert.That(book.AuthorName, Is.EqualTo("Leo Tolstoy"));
        Assert.That(book.Genres, Has.Count.EqualTo(0));
    }

    [Test]
    public async Task GetBookById_ShouldReturnBookWithAuthor()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var createdBook = await CreateBookAsync("War and Peace", 1869, author.Id);

        var book = await Client.GetFromJsonAsync<BookResponse>($"/api/books/{createdBook.Id}");

        Assert.That(book, Is.Not.Null);
        Assert.That(book!.Id, Is.EqualTo(createdBook.Id));
        Assert.That(book.Title, Is.EqualTo("War and Peace"));
        Assert.That(book.AuthorId, Is.EqualTo(author.Id));
        Assert.That(book.AuthorName, Is.EqualTo("Leo Tolstoy"));
    }

    [Test]
    public async Task UpdateBook_ShouldUpdateBook()
    {
        var firstAuthor = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var secondAuthor = await CreateAuthorAsync("Jane Austen", "United Kingdom");
        var createdBook = await CreateBookAsync("War and Peace", 1869, firstAuthor.Id);
        var request = new UpdateBookRequest
        {
            Title = "Pride and Prejudice",
            Year = 1813,
            AuthorId = secondAuthor.Id
        };

        var updateResponse = await Client.PutAsJsonAsync($"/api/books/{createdBook.Id}", request);
        var updatedBook = await Client.GetFromJsonAsync<BookResponse>($"/api/books/{createdBook.Id}");

        Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(updatedBook, Is.Not.Null);
        Assert.That(updatedBook!.Title, Is.EqualTo("Pride and Prejudice"));
        Assert.That(updatedBook.Year, Is.EqualTo(1813));
        Assert.That(updatedBook.AuthorId, Is.EqualTo(secondAuthor.Id));
        Assert.That(updatedBook.AuthorName, Is.EqualTo("Jane Austen"));
    }

    [Test]
    public async Task DeleteBook_ShouldDeleteBook()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var createdBook = await CreateBookAsync("War and Peace", 1869, author.Id);

        var deleteResponse = await Client.DeleteAsync($"/api/books/{createdBook.Id}");
        var getResponse = await Client.GetAsync($"/api/books/{createdBook.Id}");

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task CreateBook_WithMissingAuthor_ShouldReturnBadRequest()
    {
        var request = new CreateBookRequest
        {
            Title = "Unknown Book",
            Year = 2024,
            AuthorId = 999
        };

        var response = await Client.PostAsJsonAsync("/api/books", request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    public async Task AddGenreToBook_ShouldAttachGenre()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var book = await CreateBookAsync("War and Peace", 1869, author.Id);
        var genre = await CreateGenreAsync("Novel");

        var attachResponse = await Client.PostAsync($"/api/books/{book.Id}/genres/{genre.Id}", null);
        var genres = await Client.GetFromJsonAsync<List<BookGenreResponse>>($"/api/books/{book.Id}/genres");

        Assert.That(attachResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres!, Has.Count.EqualTo(1));
        Assert.That(genres[0].Id, Is.EqualTo(genre.Id));
        Assert.That(genres[0].Name, Is.EqualTo("Novel"));
    }

    [Test]
    public async Task GetBookGenres_ShouldReturnAttachedGenres()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var book = await CreateBookAsync("War and Peace", 1869, author.Id);
        var novel = await CreateGenreAsync("Novel");
        var drama = await CreateGenreAsync("Drama");

        await Client.PostAsync($"/api/books/{book.Id}/genres/{novel.Id}", null);
        await Client.PostAsync($"/api/books/{book.Id}/genres/{drama.Id}", null);

        var genres = await Client.GetFromJsonAsync<List<BookGenreResponse>>($"/api/books/{book.Id}/genres");

        Assert.That(genres, Is.Not.Null);
        Assert.That(genres!, Has.Count.EqualTo(2));
        Assert.That(genres.Select(genre => genre.Name), Does.Contain("Novel"));
        Assert.That(genres.Select(genre => genre.Name), Does.Contain("Drama"));
    }

    [Test]
    public async Task RemoveGenreFromBook_ShouldDetachGenre()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var book = await CreateBookAsync("War and Peace", 1869, author.Id);
        var genre = await CreateGenreAsync("Novel");
        await Client.PostAsync($"/api/books/{book.Id}/genres/{genre.Id}", null);

        var deleteResponse = await Client.DeleteAsync($"/api/books/{book.Id}/genres/{genre.Id}");
        var genres = await Client.GetFromJsonAsync<List<BookGenreResponse>>($"/api/books/{book.Id}/genres");

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres!, Has.Count.EqualTo(0));
    }

    [Test]
    public async Task AddGenreToMissingBook_ShouldReturnNotFound()
    {
        var genre = await CreateGenreAsync("Novel");

        var response = await Client.PostAsync($"/api/books/999/genres/{genre.Id}", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task AddMissingGenreToBook_ShouldReturnNotFound()
    {
        var author = await CreateAuthorAsync("Leo Tolstoy", "Russia");
        var book = await CreateBookAsync("War and Peace", 1869, author.Id);

        var response = await Client.PostAsync($"/api/books/{book.Id}/genres/999", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
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

    private async Task<BookResponse> CreateBookAsync(string title, int year, int authorId)
    {
        var response = await Client.PostAsJsonAsync("/api/books", new CreateBookRequest
        {
            Title = title,
            Year = year,
            AuthorId = authorId
        });

        var book = await response.Content.ReadFromJsonAsync<BookResponse>();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(book, Is.Not.Null);

        return book!;
    }
}
