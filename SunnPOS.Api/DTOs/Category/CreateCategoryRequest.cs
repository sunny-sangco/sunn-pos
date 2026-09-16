using System.ComponentModel.DataAnnotations;

namespace SunnPOS.Api.DTOs.Categories;

public class CreateCategoryRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(250)]
    public string Description { get; set; } = string.Empty;
}