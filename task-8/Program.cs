using System;

public class Program
{
    static void Main(string[] args)
    {
        IRepository<Product> repository = new InMemoryRepository<Product>();

        bool continueRunning = true;

        while (continueRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Get Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Print All Products");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Add Product
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Product Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    var newProduct = new Product { Name = name, Price = price };
                    repository.Add(newProduct);
                    break;

                case "2":
                    // Get Product by ID
                    Console.Write("Enter Product ID: ");
                    int id = int.Parse(Console.ReadLine());

                    var product = repository.Get(id);
                    if (product != null)
                    {
                        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                    break;

                case "3":
                    // Update Product
                    Console.Write("Enter Product ID to Update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Product Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Product Price: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());

                    var updatedProduct = new Product { Id = updateId, Name = newName, Price = newPrice };
                    repository.Update(updateId, updatedProduct);
                    break;

                case "4":
                    // Delete Product
                    Console.Write("Enter Product ID to Delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    repository.Delete(deleteId);
                    break;

                case "5":
                    // Print All Products
                    repository.PrintAll();
                    break;

                case "6":
                    continueRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
