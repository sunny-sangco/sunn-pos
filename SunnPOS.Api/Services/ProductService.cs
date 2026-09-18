using Microsoft.EntityFrameworkCore;
using SunnPOS.Api.Data;
using SunnPOS.Api.DTOs.Products;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public class ProductService : IProductService
{

    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .ToListAsync();
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

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

        _context.Products.Add(product);

        return Task.FromResult(product);
    }

    public Task<Product?> UpdateAsync(
        Guid id,
        UpdateProductRequest request)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

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
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product is null)
        {
            return Task.FromResult(false);
        }

        _context.Products.Remove(product);

        return Task.FromResult(true);
    }
}