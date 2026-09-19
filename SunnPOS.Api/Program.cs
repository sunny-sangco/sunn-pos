using Microsoft.EntityFrameworkCore;
using SunnPOS.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

// Add controller support
builder.Services.AddControllers();

// Register the Swagger generator
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs / routing explorer
builder.Services.AddSwaggerGen();

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
    
       // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
