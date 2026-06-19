namespace LibraryApi.Dtos.Books;

public class BookResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Year { get; set; }

    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = string.Empty;

    public List<BookGenreResponse> Genres { get; set; } = [];
}
