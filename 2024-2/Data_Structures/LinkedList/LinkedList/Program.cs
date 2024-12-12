using System;
using LinkedList;
using static HashTable;

class Program
{
    // static void Main(string[] args)
    // {
    //     DoublyLinkedList<int> list = new DoublyLinkedList<int>();
    //     list.AddLast(10);
    //     list.AddLast(20);
    //     list.AddLast(30);
    //
    //     Console.WriteLine("List:");
    //     list.PrintForward();
    //
    //     Console.ReadLine();
    // }
    
    static void Main(string[] args)
    {
        var hashTable = new HashTable(5);

        hashTable.Add("ID1", "João");
        hashTable.Add("ID2", "Maria");
        hashTable.Add("ID3", "Manuel");
        hashTable.Add("ID4", "Vasco");
        hashTable.Add("ID5", "Fernando");
        hashTable.Add("ID5", "António");

        Console.WriteLine("Value for key 'ID3': " + hashTable.Get("ID3"));

        hashTable.Remove("ID2");
        Console.WriteLine("After removing key 'ID2':");

        hashTable.PrintAll();
    }
}