# 🛒 Day01 — Products & Categories REST API

> **ASP.NET Core Web API** · Entity Framework Core · SQL Server · Swagger

A fully functional REST API built on Day 1 of learning Web API development. The API manages a simple product catalog with categories, supporting full CRUD operations on both resources.

---

## 🚀 Tech Stack

| Technology | Version |
|---|---|
| ASP.NET Core Web API | .NET 8 |
| Entity Framework Core | Latest |
| SQL Server (LocalDB/Express) | — |
| Swagger / OpenAPI | Swashbuckle |

---

## 📁 Project Structure

```
Day01/
├── Controllers/
│   ├── ProductController.cs     # CRUD endpoints for Products
│   └── CategoryController.cs    # CRUD endpoints for Categories
├── Models/
│   ├── Product.cs               # Product entity
│   └── Category.cs              # Category entity
├── ViewModels/
│   ├── ProductVM.cs             # Product read model
│   ├── ProductAddVM.cs          # Product create/update model
│   ├── CategoryVM.cs            # Category read model
│   └── CategoryAddVM.cs         # Category create/update model
├── Data/
│   ├── Context/
│   │   └── AppContext.cs        # DbContext + seed data
│   └── Configrations/
│       └── ProductConfigration.cs  # Fluent API relationships
├── Migrations/                  # EF Core migrations
└── Program.cs                   # App entry point & middleware
```

---

## 🗃️ Data Models

### Category
| Property | Type | Description |
|---|---|---|
| `Id` | int | Primary Key |
| `Name` | string | Category name |
| `Products` | ICollection\<Product\> | Navigation property |

### Product
| Property | Type | Description |
|---|---|---|
| `Id` | int | Primary Key |
| `Title` | string | Product name |
| `Description` | string | Product description |
| `Count` | int | Stock quantity |
| `Price` | double | Product price |
| `CategoryId` | int | Foreign Key → Category |

**Relationship:** One Category → Many Products (configured via Fluent API)

---

## 📡 API Endpoints

### Products · `/api/Product`

| Method | Endpoint | Description | Response |
|---|---|---|---|
| `GET` | `/api/Product` | Get all products (with category name) | `200 OK` |
| `GET` | `/api/Product/{id}` | Get product by ID | `200 OK` / `404 Not Found` |
| `POST` | `/api/Product` | Add a new product | `201 Created` |
| `PUT` | `/api/Product/{id}` | Update existing product | `204 No Content` / `404 Not Found` |
| `DELETE` | `/api/Product/{id}` | Delete a product | `200 OK` / `400 Bad Request` |

#### POST / PUT Body — `ProductAddVM`
```json
{
  "categId": 1,
  "title": "iPhone 15 Pro",
  "description": "128GB, Natural Titanium",
  "count": 10,
  "price": 999.99
}
```

#### GET Response — `ProductVM`
```json
{
  "title": "iPhone 15 Pro",
  "description": "128GB, Natural Titanium",
  "count": 10,
  "price": 999.99,
  "category": "Smartphones"
}
```

---

### Categories · `/api/Category`

| Method | Endpoint | Description | Response |
|---|---|---|---|
| `GET` | `/api/Category` | Get all categories | `200 OK` |
| `GET` | `/api/Category/{id}` | Get category by ID | `200 OK` |
| `POST` | `/api/Category` | Add a new category | `201 Created` |
| `PUT` | `/api/Category/{id}` | Update category name | `204 No Content` / `404 Not Found` |
| `DELETE` | `/api/Category/{id}` | Delete a category | `200 OK` / `400 Bad Request` |

#### POST / PUT Body — `CategoryAddVM`
```json
{
  "name": "Smartphones"
}
```

---

## 🌱 Seed Data

The database is pre-seeded with sample data via `OnModelCreating`:

**Categories:** Smartphones · Laptops & PCs · Accessories

**Products:** iPhone 15 Pro · Samsung Galaxy S24 · MacBook Air M3 · Dell XPS 13 · Sony WH-1000XM5

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server Express (or any SQL Server instance)

### Setup

**1. Clone the repository**
```bash
git clone <your-repo-url>
cd Day01
```

**2. Update the connection string**

In `Data/Context/AppContext.cs`, replace the connection string with your own:
```csharp
optionsBuilder.UseSqlServer("Data source=YOUR_SERVER;Initial catalog=Day01APIs;Integrated security=true;TrustServerCertificate=True");
```

**3. Apply migrations**
```bash
dotnet ef database update
```

**4. Run the project**
```bash
dotnet run
```

**5. Open Swagger UI**
```
https://localhost:{port}/swagger
```

---

## 💡 Key Concepts Applied

- **ViewModels** — Separating API contracts from database models (no direct entity exposure)
- **Fluent API** — Configuring relationships via `IEntityTypeConfiguration<T>` in a dedicated class
- **EF Core Migrations** — Database-first schema management with seed data
- **RESTful Conventions** — Proper HTTP methods and status codes (`201 Created`, `204 No Content`, `404 Not Found`)
- **Eager Loading** — Using `.Include()` to load related Category data with Products

---

## 🔮 What's Next

- [ ] Dependency Injection for `DbContext`
- [ ] Repository Pattern
- [ ] Data Annotations / FluentValidation
- [ ] Async/Await throughout
- [ ] Authentication & Authorization (JWT)
- [ ] Global error handling middleware

---

*Day 01 of building Web APIs with ASP.NET Core — more coming soon.*
