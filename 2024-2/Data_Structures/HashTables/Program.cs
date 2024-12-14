using System;
using HashLinearProbing;
using HashChaining;

public class MainProgram
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose the data structure to work with:");
            Console.WriteLine("1. Inventory System (Linear Probing)");
            Console.WriteLine("2. HashTable (Chaining)");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1/2/3): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                LinearProbing();
            }
            else if (choice == "2")
            {
                HashChaining();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting the program.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    private static void LinearProbing()
    {

        // Create an inventory with a capacity of 5
        Inventory inventory = new Inventory(5);
        // Simulating user input to add items
        while (true)
        {
            Console.WriteLine("Enter a command ('add', 'delete', or 'exit'):");
            string command = Console.ReadLine().ToLower();
            if (command == "exit")
            {
                break;
            }
            else if (command == "add")
            {
                Console.WriteLine("Enter the name of the item to add:");
                string itemName = Console.ReadLine();
                inventory.AddItem(itemName);
                inventory.DisplayInventory();
            }
            else if (command == "delete")
            {
                Console.WriteLine("Enter the slot number to delete (1-5):");
                if (int.TryParse(Console.ReadLine(), out int slotIndex))
                {
                    inventory.DeleteItem(slotIndex - 1); // Convert to zero-based index
                    inventory.DisplayInventory();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid slot number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command. Please enter 'add', 'delete', or 'exit'.");
            }
        }
    }

    private static void HashChaining()
    {
        var hashTable = new HashTable(5);

        while (true)
        {
            Console.WriteLine("Enter a command ('add', 'delete', 'check' or 'exit'):");
            string command = Console.ReadLine().ToLower();
            if (command == "exit")
            {
                break;
            }
            else if (command == "add")
            {
                Console.WriteLine("Enter the name of the item to add:");
                string name = Console.ReadLine();
                Console.Write("Enter the ID (example ");
                Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to magenta (pink-like)
                Console.Write("\"4\"");
                Console.ResetColor(); // Reset text color to default
                Console.WriteLine("): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    hashTable.Add(id, name);
                    hashTable.PrintAll();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\"Invalid input. Please enter a valid slot number.\"");
                    Console.ResetColor();
                }
                
            }else if (command == "delete")
            {
                Console.Write("Enter the ID to delete (example ");
                Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to magenta (pink-like)
                Console.Write("\"5\"");
                Console.ResetColor(); // Reset text color to default
                Console.WriteLine("): ");
                if (int.TryParse(Console.ReadLine(), out int idToDelete))
                {
                    if (hashTable.Remove(idToDelete)){
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\" '{idToDelete}' has been successfully removed.\"");
                        Console.ResetColor();
                        hashTable.PrintAll();
                        
                    }else{
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" \"'{idToDelete}' does not exist in the hash table.\"");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\"Invalid input. add number.\"");
                    Console.ResetColor();
                }
            }
            else if (command == "check")
            {
                Console.Write("Enter the name of the ID to check (example :");
                Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to magenta (pink-like)
                Console.Write("\"2\"");
                Console.ResetColor(); // Reset text color to default
                Console.WriteLine("): ");
                if (int.TryParse(Console.ReadLine(), out int idcheck))
                {
                    hashTable.Get(idcheck);
                    if (hashTable.Get(idcheck) == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\"Invalid ID Check\"");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Set text color to magenta (pink-like)
                        Console.WriteLine($" '{idcheck}' \"has been successfully found and checked.\"");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\"Invalid input. add number.\"");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\"Invalid command. Please enter 'add', 'delete', or 'exit'.\"");
                Console.ResetColor();
            }
        }
    }
}