public class Bank // class Bank to manage the queue of customers and their
                  // actions
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
      Customer newCustomer =
          new Customer { Name = customerName, DateArrival = DateTime.Now };
      q.Enqueue(newCustomer);
      System.Console.WriteLine(
          $"Customer '{customerName}' added to the queue at {newCustomer.DateArrival:yyyy-MM-dd HH:mm:ss}.");
   }
   public void ProcessCustomer(Queue<Customer> q)
   {
      if (q.Count > 0)
      {
         Customer processedCustomer = q.Dequeue();
         System.Console.WriteLine(
             $"Processed customer: {processedCustomer.Name}");
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
            Console.WriteLine(
                $"Customer: {customer.Name}, Arrival Time: {customer.DateArrival:yyyy-MM-dd HH:mm:ss}");
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
   public void ToListAndSort(Queue<Customer> q, List<Customer> l)
   {
      if (q.Count == 0)
      {
         Console.WriteLine("The queue is empty.");
         return;
      }
      else if (q.Count == 1)
      {
         Console.WriteLine("Only one customer is present, no need to sort.");
         l.Clear();
         l.Add(q.Peek());
         return;
      }
      else
      {
         // Clear list before adding items and sorting
         l.Clear();
         foreach (var customer in q)
         {
            l.Add(customer);
         }
         // Sort alphabetically by Customer.Name
         l.Sort((x, y) => string.Compare(x.Name, y.Name,
                                         StringComparison.Ordinal));
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
            case ConsoleKey.D1: // 1. Do something
               bank.PerformAction(actions);
               break;

            case ConsoleKey.D2: // 2. Undo action
               bank.UndoAction(actions);
               break;

            case ConsoleKey.D3: // 3. View current action
               bank.ViewCurrentAction(actions);
               break;

            case ConsoleKey.D4: // 4. Show history actions
               bank.ViewHistoryActions(actions);
               break;
         }
      } while (Console.ReadKey().Key !=
               ConsoleKey.Escape); // Menu loop until ESC is pressed
   }

   public static void Main()
   {
      Queue<Bank.Customer> customerQueue = new Queue<Bank.Customer>();
      Bank bank = new Bank();
      List<Bank.Customer> customerList = new List<Bank.Customer>();

      bool running = true;
      while (running)
      {
         Console.WriteLine("------------------------");
         Console.WriteLine("Bank queue simulator");
         // queue
         Console.WriteLine("Write the desired option:");
         Console.WriteLine("1. Add Customer");
         Console.WriteLine("2. Process Customer");
         Console.WriteLine("3. View next Customer");
         Console.WriteLine("4. Show full queue");
         Console.WriteLine("5. Sort customers by name");
         Console.WriteLine("6. Search for customer");
         // queue
         Console.WriteLine("7. Customer actions"); // stack
         Console.WriteLine("8. Exit");
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
               bank.ToListAndSort(customerQueue, customerList);
               foreach (var customer in customerList)
               {
                  Console.WriteLine($"- {customer.Name}");
               }
               break;

            case 6:
               // Search
               if (customerList.Count == 0)
               {
                  System.Console.WriteLine("Please use option 5 to order the list first");
               }
               System.Console.WriteLine("Please ingress the name of the client you are searching for");
               string nameSearch = Console.ReadLine();
               Bank.Customer search = new Bank.Customer { Name = nameSearch };
               int index = customerList.BinarySearch(
               search,
               Comparer<Bank.Customer>.Create((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal))
           );

               if (index >= 0)
               {
                  Console.WriteLine($"The customer {customerList[index].Name} was found at position {index}");
                  Console.WriteLine($"Arrival Time: {customerList[index].DateArrival:yyyy-MM-dd HH:mm:ss}");
               }
               else
               {
                  Console.WriteLine($"the customer '{nameSearch}' was not found.");
               }

               break;
            case 7:
               MenuActions();
               break;

            case 8:
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