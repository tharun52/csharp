# 🗃️ Generic Repository Pattern in C# (Console App)

This is a simple C# console application that demonstrates how to use **generics** and **interfaces** with the **repository pattern** using an **in-memory data store**. The application allows basic **CRUD operations** on a sample entity (`Product`), following clean architecture principles.

---

## 📌 Features

- Generic repository with `Add`, `Get`, `Update`, and `Delete` methods.
- Interface-driven design using `IRepository<T>`.
- In-memory storage for quick and simple data handling.
- Console UI with a menu for user interaction.
- Option to print all stored products along with their IDs.

---

## 🧱 Project Structure

```
MyRepositoryPatternApp/
├── InMemoryRepository.cs     // Generic in-memory repository logic
├── IRepository.cs            // Interface for the repository
├── Product.cs                // Sample entity class
├── Program.cs                // Main console app with menu
└── MyRepositoryPatternApp.csproj // Project file
```

---
