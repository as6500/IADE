using System;
using System.Collections.Generic;

class HashTable
{
    private int size;
    private LinkedList<KeyValuePair<string, string>>[] slots;

    public HashTable(int size)
    {
        this.size = size;
        slots = new LinkedList<KeyValuePair<string, string>>[size];
    }

    private int GetSlotIndex(string key)
    {
        return Math.Abs(key.GetHashCode()) % size;
    }

    public void Add(string key, string value)
    {
        int index = GetSlotIndex(key);

        if (slots[index] == null)
        {
            slots[index] = new LinkedList<KeyValuePair<string, string>>();
        }
        
        slots[index].AddLast(new KeyValuePair<string, string>(key, value));
    }


    public string Get(string key)
    {
        int index = GetSlotIndex(key);
        var slot = slots[index];

        if (slot != null)
        {
            foreach (var pair in slot)
            {
                if (pair.Key == key)
                {
                    return pair.Value;
                }
            }
        }

        throw new KeyNotFoundException("Key not found.");
    }

    public bool Remove(string key)
    {
        int index = GetSlotIndex(key);
        var slot = slots[index];

        if (slot != null)
        {
            var current = slot.First;

            while (current != null)
            {
                if (current.Value.Key == key)
                {
                    slot.Remove(current);
                    return true;
                }

                current = current.Next;
            }
        }

        return false;
    }

    public void PrintAll()
    {
        for (int i = 0; i < size; i++)
        {
            var slot = slots[i];

            if (slot != null)
            {
                Console.WriteLine($"Slot {i}:");

                foreach (var pair in slot)
                {
                    Console.WriteLine($"  Key: {pair.Key}, Value: {pair.Value}");
                }
            }
        }
    }
}
