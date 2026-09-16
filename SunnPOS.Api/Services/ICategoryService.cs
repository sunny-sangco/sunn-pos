using SunnPOS.Api.DTOs.Categories;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(Guid id);

    Task<Category> CreateAsync(CreateCategoryRequest request);

    Task<Category?> UpdateAsync(
        Guid id,
        UpdateCategoryRequest request);

    Task<bool> DeleteAsync(Guid id);
}