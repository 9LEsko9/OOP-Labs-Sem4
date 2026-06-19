using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.Genres;

public class CreateGenreRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
