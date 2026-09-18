using Microsoft.EntityFrameworkCore;
using SunnPOS.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

// Add controller support
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)));

// Add services to the container.

// Register our services
builder.Services.AddScoped<
    SunnPOS.Api.Services.IProductService,
    SunnPOS.Api.Services.ProductService>();

builder.Services.AddScoped<
    SunnPOS.Api.Services.ICategoryService,
    SunnPOS.Api.Services.CategoryService>();

builder.Services.AddScoped<
    SunnPOS.Api.Services.ICustomerService,
    SunnPOS.Api.Services.CustomerService>();

builder.Services.AddScoped<
    SunnPOS.Api.Services.ISaleService,
    SunnPOS.Api.Services.SaleService>();
    
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
