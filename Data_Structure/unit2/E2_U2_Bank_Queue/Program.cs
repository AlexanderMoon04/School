using System;
using System.Collections.Generic;

public class Bank
{
   public class Customer
   {
      public string Name { get; set; }
      public DateTime DateArrival { get; set; }
   }
   public void AddCustomer(Queue<Customer> q)
   {
      System.Console.WriteLine("Customer's name to add: ");
      string customerName = Console.ReadLine();
      Customer newCustomer = new Customer { Name = customerName, DateArrival = DateTime.Now };
      q.Enqueue(newCustomer);
      System.Console.WriteLine($"Customer '{customerName}' added to the queue at {newCustomer.DateArrival:yyyy-MM-dd HH:mm:ss}.");
   }
   public void ProcessCustomer(Queue<Customer> q)
   {
      if (q.Count > 0)
      {
         Customer processedCustomer = q.Dequeue();
         System.Console.WriteLine($"Processed customer: {processedCustomer.Name}");
      }
      else
      {
         System.Console.WriteLine("The queue is empty.");
      }
   }
   public void ViewNextCustomer(Queue<Customer> q)
   {
      if (q.Count > 0)
      {
         Customer nextCustomer = q.Peek();
         System.Console.WriteLine($"Next customer: {nextCustomer.Name}");
      }
      else
      {
         System.Console.WriteLine("The queue is empty.");
      }
   }
   public void ShowFullQueue(Queue<Customer> q)
   {
      if (q.Count > 0)
      {
         Console.WriteLine("Full queue:");
         foreach (var customer in q)
         {
            Console.WriteLine($"Customer: {customer.Name}, Arrival Time: {customer.DateArrival:yyyy-MM-dd HH:mm:ss}");
         }
      }
      else
      {
         Console.WriteLine("The queue is empty.");
      }
   }

   public void PerformAction(Stack<string> a)
   {
      Console.WriteLine("\nEnter action to perform:");
      string action = Console.ReadLine();
      a.Push(action);
      Console.WriteLine($"'{action}' performed correctly");
      System.Console.WriteLine("Press any key to continue...");
   }
   public void UndoAction(Stack<string> a)
   {
      if (a.Count > 0)
      {
         string undoneAction = a.Pop();
         Console.WriteLine($"\nUndone action: {undoneAction}");
         System.Console.WriteLine("Press any key to continue...");

      }
      else
      {
         Console.WriteLine("\nNo actions to undo.");
         System.Console.WriteLine("Press any key to continue...");

      }

   }
   public void ViewCurrentAction(Stack<string> a)
   {
      if (a.Count > 0)
      {
         string currentAction = a.Peek();
         Console.WriteLine($"\nCurrent action: {currentAction}");
         System.Console.WriteLine("Press any key to continue...");

      }
      else
      {
         Console.WriteLine("\nNo actions available.");
         System.Console.WriteLine("Press any key to continue...");

      }
   }
   public void ViewHistoryActions(Stack<string> a)
   {
      if (a.Count > 0)
      {
         Console.WriteLine("\nActions history:");
         foreach (var action in a)
         {
            Console.WriteLine(action);
         }
         System.Console.WriteLine("Press any key to continue...");

      }
      else
      {
         Console.WriteLine("\nNo actions available.");
         System.Console.WriteLine("Press any key to continue...");
      }
   }
}

public class Program
{
   public static void MenuActions()
   {
      Bank bank = new Bank();
      Stack<string> actions = new Stack<string>();
      do
      {
         Console.WriteLine("\n--------Customer Actions --------");
         Console.WriteLine("1. Do something");
         Console.WriteLine("2. Undo action");
         Console.WriteLine("3. View current action");
         Console.WriteLine("4. Show actions history");
         Console.WriteLine("Press ESC to exit");

         ConsoleKeyInfo keyInfo = Console.ReadKey();
         switch (keyInfo.Key)
         {
            case ConsoleKey.D1: //1. Do something
               bank.PerformAction(actions);
               break;

            case ConsoleKey.D2: //2. Undo action
               bank.UndoAction(actions);
               break;

            case ConsoleKey.D3: //3. View current action
               bank.ViewCurrentAction(actions);
               break;

            case ConsoleKey.D4: //4. Show history actions
               bank.ViewHistoryActions(actions);
               break;
         }
      } while (Console.ReadKey().Key != ConsoleKey.Escape);
   }
   
   public static void Main()
   {
      Queue<Bank.Customer> customerQueue = new Queue<Bank.Customer>();
      Bank bank = new Bank();

      bool running = true;
      while (running)
      {
         Console.WriteLine("------------------------");
         Console.WriteLine("Bank queue simulator"); 
         //queue
         Console.WriteLine("Write the desired option:"); 
         Console.WriteLine("1. Add Customer");
         Console.WriteLine("2. Process Customer");
         Console.WriteLine("3. View next Customer");
         Console.WriteLine("4. Show full queue");
         //queue
         Console.WriteLine("5. Customer actions"); //stack
         Console.WriteLine("6. Exit");
         int option;
         Console.WriteLine("Write the desired option:");
         string input = Console.ReadLine() ?? string.Empty;

         if (!int.TryParse(input, out option))
         {
            Console.WriteLine("Please enter a valid number.");
            continue;
         }

         switch (option)
         {
            case 1:
               bank.AddCustomer(customerQueue);
               break;

            case 2:
               bank.ProcessCustomer(customerQueue);
               break;

            case 3:
               bank.ViewNextCustomer(customerQueue);
               break;

            case 4:
               bank.ShowFullQueue(customerQueue);
               break;

            case 5:
               MenuActions();
               break;

            case 6:
               running = false;
               System.Console.WriteLine("Exiting...");
               break;

            default:
               System.Console.WriteLine("Invalid option. Please try again.");
               System.Console.WriteLine("Press any key to continue...");
               Console.ReadKey();
               break;
         }
      }
   }
}