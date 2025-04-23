## 📘 Book API - Mini Microservice using ASP.NET Core

A simple RESTful Web API built with **ASP.NET Core**, demonstrating clean architecture practices like **Dependency Injection**, **CRUD operations**, **Swagger documentation**, and **async programming** using **Entity Framework Core with an In-Memory Database**.

---

### 🚀 Features

- Manage `Book` resources (Create, Read, Update, Delete)
- In-memory database (no external setup needed)
- Swagger UI for API documentation and testing
- Async/await in all DB calls
- Service layer architecture with dependency injection

---

## 📂 Project Structure

```
BookApi/
│
├── Controllers/
│   └── BookController.cs        # Handles all HTTP endpoints for Book
│
├── Models/
│   └── Book.cs                  # Book model (Id, Title, Author)
│
├── Services/
│   ├── IBookService.cs          # Interface for book operations
│   └── BookService.cs           # In-memory implementation of book service
│
├── Program.cs                   # Entry point, configures app & DI
└── BookApi.csproj               # Project file with package references
```

---

## 🛠️ Setup Instructions

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) or later

## 📄 API Endpoints

| Method | Endpoint            | Description          |
|--------|---------------------|----------------------|
| GET    | `/api/books`        | Get all books        |
| GET    | `/api/books/{id}`   | Get book by ID       |
| POST   | `/api/books`        | Add new book         |
| PUT    | `/api/books/{id}`   | Update existing book |
| DELETE | `/api/books/{id}`   | Delete a book        |

---

## 🔍 Key Code Highlights

### ✅ Dependency Injection (Program.cs)

```csharp
builder.Services.AddSingleton<IBookService, BookService>();
```

Registers `BookService` as a singleton dependency implementing `IBookService`.

---

### ✅ Swagger Integration (Program.cs)

```csharp
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
});
```

```csharp
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API V1");
});
```

Adds interactive Swagger UI to test the API.

---

### ✅ Book Model (Models/Book.cs)

```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
```

Defines the structure of a Book entity.

---

### ✅ Service Layer (Services/BookService.cs)

```csharp
public async Task<Book?> GetBookAsync(int id)
{
    return await Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
}
```

Performs asynchronous fetch of a book from in-memory list.

---

### ✅ Controller (Controllers/BookController.cs)

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Book>> Get(int id)
{
    var book = await _bookService.GetBookAsync(id);
    if (book == null)
        return NotFound();
    return Ok(book);
}
```

Handles GET request to fetch a specific book by ID.

---
