using SunnPOS.Api.DTOs.Categories;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly List<Category> _categories = new();

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Category>>(_categories);
    }

    public Task<Category?> GetByIdAsync(Guid id)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);

        return Task.FromResult(category);
    }

    public Task<Category> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        _categories.Add(category);

        return Task.FromResult(category);
    }

    public Task<Category?> UpdateAsync(
        Guid id,
        UpdateCategoryRequest request)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);

        if (category is null)
            return Task.FromResult<Category?>(null);

        category.Name = request.Name;
        category.Description = request.Description;

        return Task.FromResult<Category?>(category);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);

        if (category is null)
            return Task.FromResult(false);

        _categories.Remove(category);

        return Task.FromResult(true);
    }
}