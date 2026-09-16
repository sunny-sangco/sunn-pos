var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add controller support
builder.Services.AddControllers();

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
