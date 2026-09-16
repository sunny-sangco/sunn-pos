using Microsoft.AspNetCore.Mvc;
using SunnPOS.Api.DTOs.Categories;
using SunnPOS.Api.Services;

namespace SunnPOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCategoryRequest request)
    {
        var category = await _categoryService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = category.Id },
            category);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateCategoryRequest request)
    {
        var category =
            await _categoryService.UpdateAsync(id, request);

        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _categoryService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}