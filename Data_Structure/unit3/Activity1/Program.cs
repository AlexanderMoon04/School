//To implement a Binary Search Tree (BST) data structure in C# to manage an online store's inventory,
// enabling efficient searches and data retrieval through traversal algorithms.

public class Product
{
   public string Name { get; set; }
   public float Price { get; set; }
   public Product? Left;
   public Product? Right;

   public Product(string name, float price)
   {
      Name = name;
      Price = price;
   }
}

public class BinarySearchTree
{
   public Product? Root;

   public void Insert(float value) => Root = InsertRecursive(Root, value);

   private Product InsertRecursive(Product? root, float value)
   {
      if (root == null) return new Product("", value);
      if (value < root.Price) root.Left = InsertRecursive(root.Left, value);
      else if (value > root.Price) root.Right = InsertRecursive(root.Right, value);
      return root;
   }

   public bool Search(float value) => SearchRecursive(Root, value);

   private bool SearchRecursive(Product? root, float value)
   {
      if (root == null) return false;
      if (root.Price == value) return true;
      return value < root.Price ? SearchRecursive(root.Left, value) : SearchRecursive(root.Right, value);
   }
   public void Delete(float value) => Root = DeleteRecursive(Root, value);

   private Product? DeleteRecursive(Product? root, float value)
   {
      if (root == null) return null;

      if (value < root.Price) root.Left = DeleteRecursive(root.Left, value);
      else if (value > root.Price) root.Right = DeleteRecursive(root.Right, value);
      else
      {
         if (root.Left == null) return root.Right;
         if (root.Right == null) return root.Left;
         root.Price = MinValue(root.Right);
         root.Right = DeleteRecursive(root.Right, root.Price);
      }
      return root;
   }

   private float MinValue(Product node)
   {
      float min = node.Price;
      while (node.Left != null) { min = node.Left.Price; node = node.Left; }
      return min;
   }

   //Tree visualization 
   public void PrintTree(Product? node, string indent = "", bool last = true)
   {
      if (node == null) return;

      System.Console.WriteLine(indent);
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
      System.Console.WriteLine(node.Price);

      var children = new List<Product?>();
      if (node.Left != null) children.Add(node.Left);
      if (node.Right != null) children.Add(node.Right);

      for (int i = 0; i < children.Count; i++)
         PrintTree(children[i], indent, i == children.Count - 1);
   }
}

public class Program
{
   public static void Main()
   {
      BinarySearchTree bst = new BinarySearchTree();

      Product root = new Product("", 1);
      root.Left = new Product("", 2);
      root.Right = new Product("", 3);
      root.Left.Left = new Product("", 4);
      root.Left.Right = new Product("", 5);
      root.Left.Right.Left = new Product("", 6);
      root.Left.Right.Right = new Product("", 7);
      root.Right.Left = new Product("", 8);
      root.Right.Right = new Product("", 9);
      root.Right.Right.Left = new Product("", 10);
      root.Right.Right.Right = new Product("", 11);



      // Estructura del árbol:
      //                      1 (root/Parent)
      //                     / \
      // (Child/Parent)     2   3     (Child/Leaf)
      //                   / \
      // (Child/Leaf)     4   5     (Child/Leaf)
      var root = new Product("", 1);
      root.Left = new Product("", 2);
      root.Right = new Product("", 3);
      root.Left.Left = new Product("", 4);
      root.Left.Right = new Product("", 5);

      Console.WriteLine("1. Preorden (R-I-D):");
      TraversePreOrder(root);
      Console.WriteLine("\n\n2. Inorden (I-R-D):");
      TraverseInOrder(root);
      Console.WriteLine("\n\n3. Postorden (I-D-R):");
      TraversePostOrder(root);
      Console.WriteLine("\n\n4. Por Niveles (BFS):");
      TraverseLevelOrder(root);
   }

   public static void TraversePreOrder(Product? node)
   {
      if (node == null) return;
      Console.Write(node.Price + " "); // Raíz
      TraversePreOrder(node.Left);     // Izquierda
      TraversePreOrder(node.Right);    // Derecha
   }

   public static void TraverseInOrder(Product? node)
   {
      if (node == null) return;
      TraverseInOrder(node.Left);      // Izquierda
      Console.Write(node.Price + " "); // Raíz
      TraverseInOrder(node.Right);     // Derecha
   }

   public static void TraversePostOrder(Product? node)
   {
      if (node == null) return;
      TraversePostOrder(node.Left);    // Izquierda
      TraversePostOrder(node.Right);   // Derecha
      Console.Write(node.Price + " "); // Raíz
   }

   // --- RECORRIDO Breadth-First Search (BFS) ---

   public static void TraverseLevelOrder(Product? root)
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



