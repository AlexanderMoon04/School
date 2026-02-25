using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Title: {Title,-25} | Author: {Author,-15} | Price: ${Price,8:F2}";
        }
    }

    public class Node
    {
        public Book Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(Book book)
        {
            Data = book;
            Next = null;
            Previous = null;
        }
    }

    public class LibraryInventory
    {
        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public void AddBook(Book newBook)
        {
            Node newNode = new Node(newBook);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            Count++;
        }

        public void SelectionSort()
        {
            for (Node i = head; i != null; i = i.Next)
            {
                Node min = i;
                for (Node j = i.Next; j != null; j = j.Next)
                {
                    if (string.Compare(j.Data.Title, min.Data.Title) < 0)
                        min = j;
                }
                Book temp = i.Data;
                i.Data = min.Data;
                min.Data = temp;
            }
        }

        public void OptimizedQuickSort()
        {
            Console.WriteLine("\n[ERROR] Quick Sort not implemented yet.");
        }

        public void LinearSearch(string title)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {current.Data}");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine("Book not found (Linear Search).");
        }

        public void OptimizedBinarySearch(string title)
        {
            Console.WriteLine("\n[ERROR] Binary Search not implemented yet.");
        }

        public void DisplayAll()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LibraryInventory myLibrary = new LibraryInventory();
            Stopwatch timer = new Stopwatch();

            string[] titles = { "Don Quixote", "One Hundred Years of Solitude", "The Little Prince", "Hopscotch", "1984", "Fahrenheit 451" };
            foreach (var t in titles)
                myLibrary.AddBook(new Book { Title = t, Author = "Generic Author", Price = 20.00 });

            Console.WriteLine("=== LIBRARY SYSTEM (TEST MODE) ===");
            myLibrary.DisplayAll();

            Console.WriteLine("\nSorting by Title (Selection Sort)...");
            timer.Start();
            myLibrary.SelectionSort();
            timer.Stop();
            Console.WriteLine($"Selection Sort Time: {timer.ElapsedTicks} ticks.");

            Console.WriteLine("\nSearching for '1984'...");
            timer.Restart();
            myLibrary.LinearSearch("1984");
            timer.Stop();
            Console.WriteLine($"Linear Search Time: {timer.ElapsedTicks} ticks.");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}