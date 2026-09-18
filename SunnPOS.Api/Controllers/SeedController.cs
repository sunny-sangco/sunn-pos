using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SunnPOS.Api.Data;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly AppDbContext _context;

    public SeedController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Seed()
    {
        // Prevent duplicate seeding
        if (await _context.Categories.AnyAsync())
        {
            return BadRequest(new
            {
                message = "Database already contains data. Seeding was skipped."
            });
        }

        // =========================================================
        // CATEGORIES
        // =========================================================

        var categories = new List<Category>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Beverages",
                Description = "Hot and cold beverages",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Snacks",
                Description = "Light snacks and finger foods",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Rice Meals",
                Description = "Filipino rice meals",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Fast Food",
                Description = "Burgers, fries and other quick meals",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Desserts",
                Description = "Sweet treats and desserts",
                CreatedAt = DateTime.UtcNow
            }
        };

        await _context.Categories.AddRangeAsync(categories);

        // =========================================================
        // PRODUCTS
        // =========================================================


        var products = new List<Product>
        {
            // =========================================================
            // BEVERAGES
            // =========================================================

            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-001",
                Name = "Absolute Distilled Water 500ml",
                Price = 15.00m,
                StockQuantity = 100,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-002",
                Name = "Coca-Cola 330ml Can",
                Price = 35.00m,
                StockQuantity = 80,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-003",
                Name = "Sprite 330ml Can",
                Price = 35.00m,
                StockQuantity = 80,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-004",
                Name = "Royal 330ml Can",
                Price = 35.00m,
                StockQuantity = 70,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-005",
                Name = "C2 Green Tea 350ml",
                Price = 25.00m,
                StockQuantity = 60,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-006",
                Name = "Nestea Iced Tea 330ml",
                Price = 30.00m,
                StockQuantity = 60,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-007",
                Name = "Gatorade 500ml",
                Price = 45.00m,
                StockQuantity = 50,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "BEV-008",
                Name = "Summit Water 1L",
                Price = 30.00m,
                StockQuantity = 70,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },

            // =========================================================
            // SNACKS
            // =========================================================

            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-001",
                Name = "Piattos Cheese 85g",
                Price = 45.00m,
                StockQuantity = 50,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-002",
                Name = "Nova Multigrain Snacks 78g",
                Price = 45.00m,
                StockQuantity = 50,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-003",
                Name = "Chippy BBQ 110g",
                Price = 35.00m,
                StockQuantity = 50,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-004",
                Name = "Boy Bawang Garlic 100g",
                Price = 35.00m,
                StockQuantity = 50,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-005",
                Name = "Oishi Prawn Crackers 90g",
                Price = 30.00m,
                StockQuantity = 45,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-006",
                Name = "Choco Mucho Chocolate Bar",
                Price = 25.00m,
                StockQuantity = 60,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-007",
                Name = "Fita Crackers",
                Price = 12.00m,
                StockQuantity = 100,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SNK-008",
                Name = "SkyFlakes Crackers",
                Price = 12.00m,
                StockQuantity = 100,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow
            },

            // =========================================================
            // CANNED GOODS / GROCERY
            // =========================================================

            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-001",
                Name = "Argentina Corned Beef 175g",
                Price = 48.00m,
                StockQuantity = 40,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-002",
                Name = "555 Sardines 155g",
                Price = 27.00m,
                StockQuantity = 50,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-003",
                Name = "Mega Sardines 155g",
                Price = 25.00m,
                StockQuantity = 50,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-004",
                Name = "Century Tuna 180g",
                Price = 45.00m,
                StockQuantity = 40,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-005",
                Name = "Lucky Me Pancit Canton Original",
                Price = 18.00m,
                StockQuantity = 100,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-006",
                Name = "Lucky Me Beef Noodles",
                Price = 16.00m,
                StockQuantity = 100,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-007",
                Name = "Nescafe Classic 25g",
                Price = 45.00m,
                StockQuantity = 60,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "GRC-008",
                Name = "Bear Brand Milk 33g",
                Price = 15.00m,
                StockQuantity = 100,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow
            },

            // =========================================================
            // PERSONAL CARE / HOUSEHOLD
            // =========================================================

            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-001",
                Name = "Safeguard Classic Soap 60g",
                Price = 35.00m,
                StockQuantity = 50,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-002",
                Name = "Colgate Toothpaste 50g",
                Price = 55.00m,
                StockQuantity = 40,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-003",
                Name = "Head & Shoulders Sachet",
                Price = 12.00m,
                StockQuantity = 80,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-004",
                Name = "Cream Silk Sachet",
                Price = 12.00m,
                StockQuantity = 80,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-005",
                Name = "Surf Powder Detergent 60g",
                Price = 10.00m,
                StockQuantity = 100,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-006",
                Name = "Downy Fabric Conditioner Sachet",
                Price = 12.00m,
                StockQuantity = 80,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-007",
                Name = "Zonrox Bleach 250ml",
                Price = 30.00m,
                StockQuantity = 40,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "HOM-008",
                Name = "Joy Dishwashing Liquid 200ml",
                Price = 35.00m,
                StockQuantity = 40,
                CategoryId = categories[3].Id,
                CreatedAt = DateTime.UtcNow
            },

            // =========================================================
            // DESSERTS / SWEETS
            // =========================================================

            new()
            {
                Id = Guid.NewGuid(),
                Code = "SWT-001",
                Name = "Cloud 9 Chocolate Bar",
                Price = 25.00m,
                StockQuantity = 60,
                CategoryId = categories[4].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SWT-002",
                Name = "Choc Nut",
                Price = 15.00m,
                StockQuantity = 80,
                CategoryId = categories[4].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SWT-003",
                Name = "Rebisco Chocolate Cracker",
                Price = 12.00m,
                StockQuantity = 80,
                CategoryId = categories[4].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SWT-004",
                Name = "Dutch Mill Yogurt Drink",
                Price = 25.00m,
                StockQuantity = 50,
                CategoryId = categories[4].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SWT-005",
                Name = "Selecta Ice Cream Cup",
                Price = 35.00m,
                StockQuantity = 40,
                CategoryId = categories[4].Id,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Code = "SWT-006",
                Name = "Stik-O Wafer Stick",
                Price = 30.00m,
                StockQuantity = 60,
                CategoryId = categories[4].Id,
                CreatedAt = DateTime.UtcNow
            }
        };

        await _context.Products.AddRangeAsync(products);

        // =========================================================
        // CUSTOMERS
        // =========================================================

        var customers = new List<Customer>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Juan Dela Cruz",
                PhoneNumber = "09171234567",
                Email = "juan@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Maria Santos",
                PhoneNumber = "09181234567",
                Email = "maria@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pedro Reyes",
                PhoneNumber = "09191234567",
                Email = "pedro@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Ana Garcia",
                PhoneNumber = "09201234567",
                Email = "ana@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Carlo Mendoza",
                PhoneNumber = "09211234567",
                Email = "carlo@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sofia Ramos",
                PhoneNumber = "09221234567",
                Email = "sofia@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mark Villanueva",
                PhoneNumber = "09231234567",
                Email = "mark@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Lisa Fernandez",
                PhoneNumber = "09241234567",
                Email = "lisa@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Kevin Bautista",
                PhoneNumber = "09251234567",
                Email = "kevin@example.com",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Angela Cruz",
                PhoneNumber = "09261234567",
                Email = "angela@example.com",
                CreatedAt = DateTime.UtcNow
            }
        };

        await _context.Customers.AddRangeAsync(customers);

        // =========================================================
        // SALES
        // =========================================================

        var random = new Random(12345);

        var sales = new List<Sale>();

        for (int i = 0; i < 15; i++)
        {
            // Pick 1-4 random products
            var selectedProducts = products
                .OrderBy(_ => random.Next())
                .Take(random.Next(1, 5))
                .ToList();

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                CustomerId = random.Next(0, 10) < 8
                    ? customers[random.Next(customers.Count)].Id
                    : null,
                CreatedAt = DateTime.UtcNow.AddDays(-random.Next(0, 30))
            };

            decimal total = 0;

            foreach (var product in selectedProducts)
            {
                var quantity = random.Next(1, 4);
                var subtotal = product.Price * quantity;

                var item = new SaleItem
                {
                    Id = Guid.NewGuid(),
                    SaleId = sale.Id,
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Subtotal = subtotal
                };

                sale.Items.Add(item);
                total += subtotal;
            }

            sale.TotalAmount = total;

            // Generate realistic payment amounts
            var paymentOptions = new[]
            {
                total,
                Math.Ceiling(total / 50) * 50,
                Math.Ceiling(total / 100) * 100,
                Math.Ceiling(total / 500) * 500
            };

            sale.AmountPaid = paymentOptions
                .Where(x => x >= total)
                .OrderBy(x => x)
                .First();

            sale.ChangeAmount = sale.AmountPaid - sale.TotalAmount;

            sales.Add(sale);
        }

        await _context.Sales.AddRangeAsync(sales);

        // =========================================================
        // SAVE EVERYTHING
        // =========================================================

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Mock data seeded successfully.",
            categories = categories.Count,
            products = products.Count,
            customers = customers.Count,
            sales = sales.Count,
            saleItems = sales.Sum(x => x.Items.Count)
        });
    }
}
