using System;
using System.Collections.Generic;

public class Inventory
{
    public List<string> Slots { get; private set; }
    public int Capacity { get; private set; }

    public Inventory(int capacity)
    {
        Capacity = capacity;
        Slots = new List<string>(capacity);
        
        for (int i = 0; i < capacity; i++)
        {
            Slots.Add(null); // Use `null` to indicate an empty slot
        }
    }

    // Check if the inventory has space for more items
    public bool IsFull()
    {
        return !Slots.Contains(null);
    }

    // Add an item to the inventory
    public bool AddItem(string itemName)
    {
        if (IsFull())
        {
            Console.WriteLine("Inventory is full. Cannot add more items.");
            return false;
        }

        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] == null)
            {
                Slots[i] = itemName;
                Console.WriteLine($"Added {itemName} to slot {i + 1}.");
                return true;
            }
        }

        return false;
    }

    // Display all items in the inventory
    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] == null)
            {
                Console.WriteLine($"  Slot {i + 1}: (Empty)");
            }
            else
            {
                Console.WriteLine($"  Slot {i + 1}: {Slots[i]}");
            }
        }
    }
    public bool DeleteItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= Slots.Count)
        {
            Console.WriteLine("Invalid slot number.");
            return false;
        }

        if (Slots[slotIndex] == null)
        {
            Console.WriteLine($"Slot {slotIndex + 1} is already empty.");
            return false;
        }

        Console.WriteLine($"Removed {Slots[slotIndex]} from slot {slotIndex + 1}.");
        Slots[slotIndex] = null; // Clear the slot
        return true;
    }
}

public class InventorySystem
{
    public static void Main(string[] args)
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

        Console.WriteLine("Final Inventory:");
        inventory.DisplayInventory();
    }
}