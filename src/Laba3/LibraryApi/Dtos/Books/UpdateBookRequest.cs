using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.Books;

public class UpdateBookRequest
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Range(1, 2100)]
    public int Year { get; set; }

    public int AuthorId { get; set; }
}
