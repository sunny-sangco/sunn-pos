using Microsoft.AspNetCore.Mvc;
using SunnPOS.Api.DTOs.Sales;
using SunnPOS.Api.Services;

namespace SunnPOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _saleService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sale = await _saleService.GetByIdAsync(id);

        if (sale is null)
            return NotFound();

        return Ok(sale);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateSaleRequest request)
    {
        var sale = await _saleService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = sale.Id },
            sale);
    }
}