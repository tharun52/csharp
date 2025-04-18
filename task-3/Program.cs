using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> items = new List<string>();
        string input;

        Console.WriteLine("Welcome to the Task Manager!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1 - Add item");
            Console.WriteLine("2 - Remove item");
            Console.WriteLine("3 - Display all items");
            Console.WriteLine("4 - Exit");
            Console.Write("Enter your choice: ");
            input = Console.ReadLine().Trim();

            if (input == "1")
            {
                Console.Write("Enter item to add: ");
                string addItem = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(addItem))
                {
                    items.Add(addItem);
                    Console.WriteLine($"'{addItem}' added to the list.");
                }
                else
                {
                    Console.WriteLine("Item cannot be empty.");
                }
            }
            else if (input == "2")
            {
                Console.Write("Enter item to remove: ");
                string removeItem = Console.ReadLine().Trim();
                if (items.Remove(removeItem))
                {
                    Console.WriteLine($"'{removeItem}' removed from the list.");
                }
                else
                {
                    Console.WriteLine($"'{removeItem}' not found in the list.");
                }
            }
            else if (input == "3")
            {
                Console.WriteLine("\nCurrent items in the list:");
                if (items.Count == 0)
                {
                    Console.WriteLine("The list is empty.");
                }
                else
                {
                    foreach (string item in items)
                    {
                        Console.WriteLine($"- {item.ToUpper()}");
                    }
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("Exiting the program.");
                return;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}
