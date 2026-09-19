# SunnPOS API

A small Point-of-Sale system built with ASP.NET Core, C#, EF Core, and SQL.

SunnPOS API provides RESTful endpoints for managing products, categories, customers, inventory, and sales. It uses Entity Framework Core for data access and MariaDB for persistence.

## Tech Stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- MariaDB
- Pomelo.EntityFrameworkCore.MySql
- REST API
- Swagger / OpenAPI

## Architecture

The project follows a service-based architecture that separates HTTP handling from application/business logic and data access.

```text
SunnPOS.Api
├── Controllers/
│   ├── ProductsController.cs
│   ├── CategoriesController.cs
│   ├── CustomersController.cs
│   └── SalesController.cs
│
├── DTOs/
│   ├── Products/
│   ├── Categories/
│   ├── Customers/
│   └── Sales/
│
├── Models/
│   ├── Product.cs
│   ├── Category.cs
│   ├── Customer.cs
│   ├── Sale.cs
│   └── SaleItem.cs
│
├── Services/
│   ├── IProductService.cs
│   ├── ProductService.cs
│   ├── ICategoryService.cs
│   ├── CategoryService.cs
│   ├── ICustomerService.cs
│   ├── CustomerService.cs
│   ├── ISaleService.cs
│   └── SaleService.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Program.cs
└── appsettings.json


