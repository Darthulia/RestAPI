using System.ComponentModel.DataAnnotations;

namespace RestAPI.DTOs;

public class AdDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(1000, ErrorMessage = "Description can be at most 1000 characters.")]
    public string Description { get; set; } = string.Empty;

    // Nullable so that [Required] can detect a missing price (a plain decimal would default to 0).
    [Required(ErrorMessage = "Price is required.")]
    [Range(0, 10_000_000, ErrorMessage = "Price must be between 0 and 10 000 000.")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    [StringLength(50, ErrorMessage = "Category can be at most 50 characters.")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email is not a valid email address.")]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
}
