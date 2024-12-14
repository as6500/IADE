using System;
using System.Collections.Generic;
using HashLinearProbing;

namespace HashChaining
{
        
    class HashTable
    {
        private int size;
        private LinkedList<KeyValuePair<int, string>>[] slots;

        public HashTable(int size)
        {
            this.size = size;
            slots = new LinkedList<KeyValuePair<int, string>>[size];
        }

        private int GetSlotIndex(int key)
        {
            return (key - 1) % size;
        }

        public void Add(int key, string value)
        {
            int index = GetSlotIndex(key);

            if (slots[index] == null)
            {
                slots[index] = new LinkedList<KeyValuePair<int, string>>();
            }
            
            slots[index].AddLast(new KeyValuePair<int, string>(key, value));
        }


        public string Get(int key)
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
            return null;
        }

        public bool Remove(int key)
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
                if (slots[i] == null)
                {
                    Console.WriteLine($"  Slot {i + 1}: ");
                }else
                {
                    Console.WriteLine($"  Slot {i + 1}:");
                    foreach (var pair in slots[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"    \"Key: {pair.Key}\", ");
                        Console.Write($"\"Value: {pair.Value}\" \n");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
