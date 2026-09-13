using SunnPOS.Api.DTOs;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        return Task.FromResult(product);
    }

    public Task<Product> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Price = request.Price,
            StockQuantity = request.StockQuantity,
            CreatedAt = DateTime.UtcNow
        };

        _products.Add(product);

        return Task.FromResult(product);
    }
}