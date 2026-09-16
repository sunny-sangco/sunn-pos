namespace SunnPOS.Api.Models;

public class Product
{
   public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }

    public DateTime CreatedAt { get; set; }
}