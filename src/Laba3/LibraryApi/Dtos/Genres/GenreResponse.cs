namespace LibraryApi.Dtos.Genres;

public class GenreResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int BooksCount { get; set; }
}
