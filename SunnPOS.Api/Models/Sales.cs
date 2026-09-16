namespace SunnPOS.Api.Models;

public class Sale
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal AmountPaid { get; set; }

    public decimal ChangeAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<SaleItem> Items { get; set; } = new();
}