//Manage a product inventory in a store
//Linked list to store products (name, price and quantity)
//Applying a sorting algorithm to sort products by price, and a search method to find products.
//The program must allow add, delete, sort and search for products.
public class Product
{
   public string Name { get; set; }
   public double Price { get; set; }
   public int Quantity { get; set; }

   public static void AddProduct(LinkedList<Product> inventory, string name, double price, int quantity)
   {
      inventory.AddLast(new Product { Name = name, Price = price, Quantity = quantity });
   }

   public static void DeleteProduct(LinkedList<Product> inventory, string name)
   {
      //Node implementation
      var node = inventory.First;
      while (node != null)  
      {
         if (string.Equals(node.Value.Name, name, StringComparison.OrdinalIgnoreCase))
         {
            inventory.Remove(node);
            Console.WriteLine($"Product {name} removed successfully.");
            System.Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
            return;
         }
         node = node.Next;
      }

      Console.WriteLine($"Product {name} not found.");
      System.Console.WriteLine("Enter any key to continue...");
      Console.ReadKey();
   }

   public static void SearchProduct(LinkedList<Product> inventory, string name)
   {
      foreach (var product in inventory)
      {
         if (string.Equals(product.Name, name, StringComparison.OrdinalIgnoreCase))
         {
            Console.WriteLine($"Product found: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            System.Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
            return;
         }
      }
      Console.WriteLine("Product not found.");
      System.Console.WriteLine("Enter any key to continue...");
      Console.ReadKey();
   }

   public static void SortProductsByPrice(LinkedList<Product> inventory)
   {
      // Convert to List for sorting, then rebuild LinkedList
      var temp = new List<Product>(inventory);
      temp.Sort((a, b) => a.Price.CompareTo(b.Price));

      inventory.Clear();
      foreach (var product in temp)
      {
         inventory.AddLast(product);
      }

      foreach (var product in inventory)
      {
         Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
      }
      System.Console.WriteLine("Enter any key to continue...");
      Console.ReadKey();
   }
}
public class Program
{
   public static void Main()
   {
      LinkedList<Product> inventory = new LinkedList<Product>();

      inventory.AddLast(new Product { Name = "Laptop", Price = 999.99, Quantity = 10 });
      inventory.AddLast(new Product { Name = "Smartphone", Price = 499.99, Quantity = 20 });
      inventory.AddLast(new Product { Name = "Headphones", Price = 199.99, Quantity = 15 });
      inventory.AddLast(new Product { Name = "Croissant", Price = 4.99, Quantity = 25 });
      inventory.AddLast(new Product { Name = "Wine", Price = 19.99, Quantity = 12 });

      bool running = true;
      while (running)
      {
         Console.WriteLine("------------------------");
         Console.WriteLine("Inventory Management System");
         Console.WriteLine("Write the desired option:");
         Console.WriteLine("1. Add a product");
         Console.WriteLine("2. Remove a product");
         Console.WriteLine("3. Sort products by price");
         Console.WriteLine("4. Search for a product");
         Console.WriteLine("5. Exit");
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
            case 1:
               Console.WriteLine("Enter product name:");
               string name = Console.ReadLine();
               Console.WriteLine("Enter product price:");
               double price;
               while (!double.TryParse(Console.ReadLine(), out price))
               {
                  Console.WriteLine("Please enter a valid price.");
               }
               int quantity;
               Console.WriteLine("Enter product quantity:");
               while(!int.TryParse(Console.ReadLine(), out quantity))
               {
                  Console.WriteLine("Please enter a valid quantity.");
               }
               Product.AddProduct(inventory, name, price, quantity);
               break;

            case 2:
               Console.WriteLine("Enter product name to delete:");
               string nameToDelete = Console.ReadLine();
               Product.DeleteProduct(inventory, nameToDelete);
               break;

            case 3:
               Product.SortProductsByPrice(inventory);
               break;

            case 4:
               Console.WriteLine("Enter product name to search:");
               string nameToSearch = Console.ReadLine();
               Product.SearchProduct(inventory, nameToSearch);
               break;

            case 5:
               System.Console.WriteLine("\nExiting...");
               running = false;
               break;

            default:
               System.Console.WriteLine("Invalid option. Please try again.");
               break;
         }
      }
   }
}

