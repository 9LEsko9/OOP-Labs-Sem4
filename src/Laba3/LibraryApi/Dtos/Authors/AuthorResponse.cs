namespace LibraryApi.Dtos.Authors;

public class AuthorResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public int BooksCount { get; set; }
}
