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

      public void OptimizedQuickSort(string[] titles)
      {
         string[] arrInsertion = (string[])titles.Clone();
         Array.Sort(arrInsertion);
      }

      public void LinearSearch(string title)
      {
         Node current = head;
         while (current != null)
         {
            if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
               Console.WriteLine($"Found: {current.Data} (Linear Search).");
               return;
            }
            current = current.Next;
         }
         Console.WriteLine("Book not found (Linear Search).");
      }

      public int OptimizedBinarySearch(string[] arr, string t)
      {
         int izq = 0, der = arr.Length - 1;
         while (izq <= der)
         {
            int m = izq + (der - izq) / 2;
            int compare = string.Compare(arr[m], t, StringComparison.OrdinalIgnoreCase);
            if (compare == 0) return m;
            if (compare < 0) izq = m + 1;
            else der = m - 1;
         }
         return -1;
      }

      public string[] GetSortedTitlesSnapshot()
      {
         string[] titles = new string[Count];
         Node current = head;
         int index = 0;

         while (current != null)
         {
            titles[index++] = current.Data.Title;
            current = current.Next;
         }

         Array.Sort(titles, StringComparer.OrdinalIgnoreCase);
         return titles;
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

      public void RemoveBook(string title)
      {
         Node current = head;
         while (current != null)
         {
            if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
               if (current == head)
               {
                  head = current.Next;
                  if (head != null) head.Previous = null;
               }
               else if (current == tail)
               {
                  tail = current.Previous;
                  if (tail != null) tail.Next = null;
               }
               else
               {
                  current.Previous.Next = current.Next;
                  current.Next.Previous = current.Previous;
               }
               Count--;
               Console.WriteLine($"Book '{title}' removed successfully.");
               return;
            }
            current = current.Next;
         }
         Console.WriteLine($"Book '{title}' not found. Cannot remove.");
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

         bool running = true;
         while (running)
         {
            Console.WriteLine("------------------------");
            Console.WriteLine("Write the desired option:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Search for a book (Linear and Binary Search)");
            Console.WriteLine("3. Remove a book");
            Console.WriteLine("4. Display all books");
            Console.WriteLine("5. Sort books (Selection Sort and Quick Sort)");
            Console.WriteLine("6. Exit");
            int option;
            Console.WriteLine("Write the desired option:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out option))
            {
               Console.WriteLine("Please enter a valid number.");
               continue;
            }

            switch (option)
            {
               case 1: //Add a book
                  Console.WriteLine("Enter book title:");
                  string title = Console.ReadLine();
                  System.Console.WriteLine("Enter book author:");
                  string author = Console.ReadLine();
                  System.Console.WriteLine("Enter book price:");
                  double price;
                  while (!double.TryParse(Console.ReadLine(), out price))
                  {
                     System.Console.WriteLine("Invalid price. Please enter a valid number:");
                  }
                  myLibrary.AddBook(new Book { Title = title, Author = author, Price = price });
                  Console.WriteLine($"Book '{title}' added successfully.");
                  break;

               case 2: //Search for a book
                  Console.WriteLine("Enter book title to search:");
                  string searchTitle = Console.ReadLine();
                  timer.Start();
                  myLibrary.LinearSearch(searchTitle);
                  timer.Stop();
                  Console.WriteLine($"Linear Search Time: {timer.ElapsedTicks} ticks.");

                  string[] sortedTitles = myLibrary.GetSortedTitlesSnapshot();
                  timer.Restart();  
                  myLibrary.OptimizedBinarySearch(sortedTitles, searchTitle);
                  timer.Stop();
                  Console.WriteLine($"Binary Search Time: {timer.ElapsedTicks} ticks.");
                  break;


               case 3: //Remove a book
                  Console.WriteLine("Enter book title to remove:");
                  string removeTitle = Console.ReadLine();
                  myLibrary.RemoveBook(removeTitle);
                  break;

               case 4: //Display all books
                  myLibrary.DisplayAll();
                  break;

               case 5: //Sort books
                  Console.WriteLine("\nSorting by Title (Selection Sort)...");
                  timer.Restart();
                  myLibrary.SelectionSort();
                  timer.Stop();
                  Console.WriteLine($"Selection Sort Time: {timer.ElapsedTicks} ticks.");

                  Console.WriteLine("\nSorting by Title (Optimized Quick Sort)...");
                  timer.Restart();
                  myLibrary.OptimizedQuickSort(titles);
                  timer.Stop();
                  Console.WriteLine($"Optimized Quick Sort Time: {timer.ElapsedTicks} ticks.");
                  break;

               case 6: //exit
                  running = false;
                  break;

               default:
                  System.Console.WriteLine("Invalid option. Please try again.");
                  break;
            }
         }
      }
   }
}