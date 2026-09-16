using SunnPOS.Api.DTOs.Products;
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
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow
        };

        _products.Add(product);

        return Task.FromResult(product);
    }

    public Task<Product?> UpdateAsync(
        Guid id,
        UpdateProductRequest request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is null)
        {
            return Task.FromResult<Product?>(null);
        }

        product.Code = request.Code;
        product.Name = request.Name;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;
        product.CategoryId = request.CategoryId;

        return Task.FromResult<Product?>(product);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is null)
        {
            return Task.FromResult(false);
        }

        _products.Remove(product);

        return Task.FromResult(true);
    }
}