# 🌱 ASP.NET Core Web API Learning Series (Beginner-Friendly)

Welcome! 👋

This repository accompanies our **ASP.NET Core Web API learning sessions**, designed for beginners — especially those **new to C# and backend development**. The goal is to move step-by-step from *zero knowledge* to being able to **build a simple REST API connected to a real database**.

This README is both:

* 📘 A **learning guide** for peers
* 🧑🏽‍🏫 A **teaching reference** during sessions

We focus on **clarity, practice, and confidence**, not rushing or deep theory.

---

## 🧭 Learning Goals (Big Picture)

By the end of Session 5, you should be able to:

* Understand what a Web API is and why it exists
* Read and navigate an ASP.NET Core project
* Create API endpoints using controllers
* Use DTOs and interfaces for clean code
* Apply Dependency Injection
* Connect your API to a PostgreSQL database using EF Core
* Persist data (not just in-memory lists)

---

## 🗂️ Project Structure (High-Level)

You’ll see folders like:

* **Controllers/** → Handles HTTP requests (GET, POST, etc.)
* **DTOs/** → Shapes of data sent/received
* **Services/** → Business logic lives here
* **Data/** → Database context (EF Core)
* **Models/** → Database entities
* **Program.cs** → App startup & configuration

Think of it like:

> Controller → Service → Database

---

## 🟢 Session 1 – Introduction to Web APIs & ASP.NET Core

### What we covered:

* What is a Web API?
* REST basics (GET, POST, PUT, DELETE)
* What ASP.NET Core is used for
* Creating a Web API project
* Running the project

### Key idea:

A Web API lets **different systems talk to each other over HTTP**.

---

## 🟢 Session 2 – Project Files & WeatherForecast Example

### What we covered:

* Scaffolding a Web API project
* Understanding important files:

  * `Program.cs`
  * `Controllers`
  * `appsettings.json`
* Exploring the `WeatherForecast` example

### Example:

```csharp
app.MapGet("/weatherforecast", () => { ... })
```

### Key ideas:

* `MapGet` defines a **GET endpoint**
* `.WithName()` gives it a readable name
* `.WithOpenApi()` exposes it to Swagger

---

## 🟢 Session 3 – Controllers, DTOs & Interfaces

### Controllers

Controllers define **API endpoints**.

```csharp
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
```

### DTOs (Data Transfer Objects)

DTOs define **what data enters or leaves** the API.

Why we use them:

* Protect internal models
* Control exposed fields
* Keep APIs clean

> DTO = the contract between client and server

### Interfaces

Interfaces define **what a service can do**, not how.

```csharp
public interface ICustomerService
{
    void AddCustomer(CustomerDto customer);
}
```

Why interfaces matter:

* Loose coupling
* Easier testing
* Cleaner architecture

---

## 🟢 Session 4 – Dependency Injection (DI)

### What is Dependency Injection?

Instead of creating objects manually, **ASP.NET Core provides them for you**.

```csharp
builder.Services.AddScoped<ICustomerService, CustomerService>();
```

This tells ASP.NET Core:

> “When someone asks for `ICustomerService`, give them `CustomerService`.”

### Where DI is used

```csharp
public CustomerController(ICustomerService customerService)
{
    _customerService = customerService;
}
```

### Routing & Controllers

```csharp
app.UseRouting();
app.MapControllers();
builder.Services.AddControllers();
```

Together, these enable:

* Routing requests
* Discovering controllers
* Handling HTTP calls

---

## 🟢 Session 5 – Databases with EF Core & PostgreSQL (Light & Practical)

### Why move away from in-memory lists?

```csharp
private readonly List<CustomerDto> customers = [];
```

❌ Data disappears when the app restarts
❌ Not realistic for real systems

### Solution: Database + EF Core

EF Core lets us:

* Work with databases using C#
* Avoid writing raw SQL
* Persist data properly

### Key Concepts Introduced

#### DbContext

Represents a **connection to the database**.

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
}
```

#### Entity

A class mapped to a database table.

```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

#### PostgreSQL Connection

Configured in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "..."
}
```

### What we aim to achieve

* Replace in-memory lists
* Save customers to PostgreSQL
* Read data from the database

No deep SQL — just **understanding the flow**.

---

## 🔁 Request Flow (End-to-End)

1. Client sends HTTP request
2. Controller receives request
3. Service processes logic
4. EF Core saves/reads from PostgreSQL
5. API returns response

---

## 🧠 Learning Philosophy

* Beginner-first explanations
* Real-world patterns (without overwhelm)
* Questions encouraged
* Mistakes are part of learning

> You don’t need to master everything — you just need to understand the flow.

---

## 🚀 What’s Next

After this foundation, we can move into:

* Authentication & Authorization
* Validation
* More advanced EF Core usage
* Deployment concepts

---

Happy learning 💙
Let’s build APIs with confidence, not fear.

