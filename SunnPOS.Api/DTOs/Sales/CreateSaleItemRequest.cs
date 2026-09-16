using System.ComponentModel.DataAnnotations;

namespace SunnPOS.Api.DTOs.Sales;

public class CreateSaleItemRequest
{
    [Required]
    public Guid ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}