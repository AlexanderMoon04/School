using System.Globalization;

//To implement a Binary Search Tree (BST) data structure in C# to manage an online store's inventory,
// enabling efficient searches and data retrieval through traversal algorithms.

public class Product
{
   public string Name { get; set; }
   public double Price { get; set; }
   public Product? Left; // Left child node in the BST, representing products with lower prices.
// 
   public Product? Right; // Right child node in the BST, representing products with higher prices.

   // Constructor to initialize a product with its name and price.
   public Product(string name, double price)
   {
      Name = name;
      Price = price;
   }
}

public class BinarySearchTree
{
   public Product? Root; // Root node of the BST, representing the starting point for all operations (insertions, searches, deletions).

   public void Insert(string name, double price)
      => Root = InsertRecursive(Root, name, price);

   // Recursive method to insert a new product into the BST based on its price.
   private Product InsertRecursive(Product? root, string name, double price)
   {
      if (root == null) return new Product(name, price);

      if (price < root.Price)
         root.Left = InsertRecursive(root.Left, name, price);
      else if (price > root.Price)
         root.Right = InsertRecursive(root.Right, name, price);
      else
      {
         root.Name = name; // Update existing product name if price is the same
      }

      return root;
   }

   // Search by price
   public bool Search(double value) => SearchRecursive(Root, value);
   // Recursive method to search for a product by price in the BST.
   private bool SearchRecursive(Product? root, double value)
   {
      if (root == null) return false;
      if (root.Price == value) return true;
      return value < root.Price ? SearchRecursive(root.Left, value) : SearchRecursive(root.Right, value);
   }
   public void Delete(double value) => Root = DeleteRecursive(Root, value);

   private Product? DeleteRecursive(Product? root, double value) 
   {
      if (root == null) return null;

      if (value < root.Price) root.Left = DeleteRecursive(root.Left, value);
      else if (value > root.Price) root.Right = DeleteRecursive(root.Right, value);
      else
      {
         if (root.Left == null) return root.Right;
         if (root.Right == null) return root.Left;
         Product successor = MinNode(root.Right);
         root.Name = successor.Name;
         root.Price = successor.Price;
         root.Right = DeleteRecursive(root.Right, successor.Price);
      }
      return root;
   }

   // Helper method to find the node with the minimum price in a subtree, used during deletion to maintain BST properties.
   private Product MinNode(Product node)
   {
      while (node.Left != null) node = node.Left;
      return node;
   }

   //Tree visualization method to print the tree structure in a readable format.
   public void PrintTree(Product? node, string indent = "", bool last = true)
   {
      if (node == null) return;

      System.Console.Write(indent);
      if (last)
      {
         System.Console.Write("└─");
         indent += "  ";
      }
      else
      {
         System.Console.Write("├─");
         indent += "│ ";
      }
      System.Console.WriteLine($"{node.Name} (${FormatPrice(node.Price)})");

      var children = new List<Product?>();
      if (node.Left != null) children.Add(node.Left);
      if (node.Right != null) children.Add(node.Right);

      for (int i = 0; i < children.Count; i++)
         PrintTree(children[i], indent, i == children.Count - 1);
   }

   // Helper method to format price with two decimal places and invariant culture.
   private static string FormatPrice(double price)
      => price.ToString("0.##", CultureInfo.InvariantCulture);

   //Search by range price
   public void SearchByPriceRange(double minPrice, double maxPrice)
   {
      if (minPrice > maxPrice)
      {
         double temp = minPrice;
         minPrice = maxPrice;
         maxPrice = temp;
      }

      bool foundAny = false;
      SearchByPriceRangeRecursive(Root, minPrice, maxPrice, ref foundAny);

      if (!foundAny)
      {
         Console.WriteLine("* Products not found in the specified price range.");
      }
   }

   // Recursive method to search for products within a specified price range.
   private void SearchByPriceRangeRecursive(Product? node, double minPrice, double maxPrice, ref bool foundAny)
   {
      if (node == null) return;

      // Prune subtrees that cannot contain values inside the range.
      if (node.Price > minPrice)
      {
         SearchByPriceRangeRecursive(node.Left, minPrice, maxPrice, ref foundAny);
      }

      if (node.Price >= minPrice && node.Price <= maxPrice)
      {
         foundAny = true;
         Console.WriteLine($"* Found: [ {node.Name} - ${FormatPrice(node.Price)} ]"); // Print products that fall within the specified price range.
      }

      if (node.Price < maxPrice)
      {
         SearchByPriceRangeRecursive(node.Right, minPrice, maxPrice, ref foundAny); // Prune subtrees that cannot contain values inside the range.
      }
   }
}

public class Program
{
   public static void Main()
   {
      BinarySearchTree bst = new BinarySearchTree(); // Create a new binary search tree instance

      //Insertions
      bst.Insert("Monitor", 299.99);
      bst.Insert("Mouse", 55.99);
      bst.Insert("Laptop", 1399.99);
      bst.Insert("Cable", 2.99);
      bst.Insert("Mouse Pad", 12.99);
      bst.Insert("Keyboard", 69.99);
      bst.Insert("Printer", 249.99);
      bst.Insert("Smartphone", 344.99);
      bst.Insert("Tablet", 230.99);
      bst.Insert("Headsets", 110.99);
      bst.Insert("GTX5090TI", 6499.99);

      bst.Delete(6499.99);

      System.Console.WriteLine("-------------------------------------------");
      System.Console.WriteLine("Tree visual structure (Hierarchy)");
      System.Console.WriteLine("-------------------------------------------");
      bst.PrintTree(bst.Root); //BFS visualization
      System.Console.WriteLine("-------------------------------------------");

      System.Console.WriteLine("-------------------------------------------");
      System.Console.WriteLine("DFS (ordered by price)");
      System.Console.WriteLine("-------------------------------------------");
      TraverseInOrder(bst.Root);
      System.Console.WriteLine("-------------------------------------------");

      System.Console.WriteLine("-------------------------------------------");
      double minPrice = 100;
      double maxPrice = 500;
      System.Console.WriteLine($"Search by range price (${minPrice:0.##} - ${maxPrice:0.##})");
      System.Console.WriteLine("-------------------------------------------");
      bst.SearchByPriceRange(minPrice, maxPrice);
      System.Console.WriteLine("-------------------------------------------");
   }

   public static void TraversePreOrder(Product? node) // Root-Left-Right
   {
      if (node == null) return;
      Console.Write($"{node.Name} (${node.Price:0.##}) "); //root
      TraversePreOrder(node.Left);     // Izquierda
      TraversePreOrder(node.Right);    // Derecha
   }

   public static void TraverseInOrder(Product? node) // Left-Root-Right
   {
      if (node == null) return;

      TraverseInOrder(node.Left); // lower prices first
      Console.WriteLine($"> [ {node.Name} - ${node.Price.ToString("0.##", CultureInfo.InvariantCulture)} ]");
      TraverseInOrder(node.Right); // higher prices
   }

   public static void TraversePostOrder(Product? node) // Left-Right-Root
   {
      if (node == null) return;
      TraversePostOrder(node.Left);    // Izquierda
      TraversePostOrder(node.Right);   // Derecha
      Console.Write(node.Price + " "); // Raíz
   }

   // --- RECORRIDO Breadth-First Search (BFS) ---

   public static void TraverseLevelOrder(Product? root) // Left-Right-Root
   {
      if (root == null) return;

      Queue<Product> queue = new Queue<Product>();
      queue.Enqueue(root); // Empezamos por la raíz

      while (queue.Count > 0)
      {
         Product node = queue.Dequeue(); // Sacamos el primero en la fila
         Console.Write(node.Price + " ");

         // Agregamos los hijos a la fila para ser visitados después
         if (node.Left != null) queue.Enqueue(node.Left);
         if (node.Right != null) queue.Enqueue(node.Right);
      }
   }
}



