using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.Authors;

public class CreateAuthorRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
}
