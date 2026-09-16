using SunnPOS.Api.DTOs.Products;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task<Product> CreateAsync(CreateProductRequest request);

    Task<Product?> UpdateAsync(Guid id, UpdateProductRequest request);

    Task<bool> DeleteAsync(Guid id);
}