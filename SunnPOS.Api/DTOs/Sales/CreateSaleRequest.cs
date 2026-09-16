using System.ComponentModel.DataAnnotations;

namespace SunnPOS.Api.DTOs.Sales;

public class CreateSaleRequest
{
    public Guid? CustomerId { get; set; }

    [Range(0, double.MaxValue)]
    public decimal AmountPaid { get; set; }

    [Required]
    [MinLength(1)]
    public List<CreateSaleItemRequest> Items { get; set; } = new();
}