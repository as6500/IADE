using System;
using System.Collections.Generic;
using HashChaining;


namespace HashLinearProbing
{
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
}

