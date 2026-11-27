using System.ComponentModel.DataAnnotations;

namespace RestAPI.DTOs;

public class AdPatchDto
{
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    public string? Title { get; set; }

    [StringLength(1000, MinimumLength = 1, ErrorMessage = "Description must be between 1 and 1000 characters.")]
    public string? Description { get; set; }

    [Range(0, 10_000_000, ErrorMessage = "Price must be between 0 and 10 000 000.")]
    public decimal? Price { get; set; }

    [StringLength(50, MinimumLength = 1, ErrorMessage = "Category must be between 1 and 50 characters.")]
    public string? Category { get; set; }

    [EmailAddress(ErrorMessage = "Email is not a valid email address.")]
    [StringLength(100)]
    public string? Email { get; set; }
}
