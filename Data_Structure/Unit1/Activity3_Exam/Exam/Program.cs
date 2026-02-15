// To develop a console application that manages packages and routes by integrating Abstract Data Types for modeling ,
// Arrays for storage , Recursion for route optimization , and Generic Classes for system flexibility.

public class Package
{
   private int id;
   private string destination;
   private double weight;
}

public class Warehouse
{
   private int stock=100;
   //Manage inbound and outbound operations for packages
   public void Inbound(int package)
   {
      stock += package;
      System.Console.WriteLine($"Number of packages in stock: {stock}");
   }
   public void Outbound(int package)
   {
      if (package <= stock && package > 0)
      {
         stock -= package;
         System.Console.WriteLine($"Number of packages in stock: {stock}");
      }
      else
      {
         System.Console.WriteLine("Insufficient packages in stock for outbound operation.");
      }
   }
   public void CheckStock()
   {
      System.Console.WriteLine($"Current stock: {stock} packages.");
   }
}

// Design a generic class Container<T> where T must be a class (where T: class) to store different types of delivery items.
// Use an internal array to manage elements and implement methods to add, remove, and search.
// Include a generic method to compare elements within the container.

public class Container<T> where T : class //must be a reference type class
{
   //internal array to store items
   private T[] items = new T[itemsSize];
   private static int itemsSize = 10; //Initial size of the array
   public void Add(T item)
   {
      //Find first null position to add the item
      for (int i = 0; i < items.Length; i++)
      {
         if (items[i] == null)
         {
            items[i] = item;
            return;
         }
      }
      System.Console.WriteLine("Array full, cannot add more items.");
   }
   public void Show()
   {
      for (int i = 0; i < items.Length; i++)
      {
         if (items[i] != null)
            Console.WriteLine($"{i + 1}. {items[i]}");
      }
      System.Console.WriteLine("-------------------------");
   }
   public void Remove(T item)
   {
      for (int i = 0; i < items.Length; i++)
      {
         if (items[i] != null && items[i].Equals(item))
         {
            items[i] = null; //Remove item by setting to null
            return;
         }
      }
      Console.WriteLine("Item not found, cannot remove: " + item);
   }
   public void Search(T item)
   {
      for (int i = 0; i < items.Length; i++)
      {
         if (items[i] != null && items[i].Equals(item))
         {
            Console.WriteLine("Item found: " + item);
            return;
         }
      }
      Console.WriteLine("Item not found: " + item);
   }
   public void Compare(int item1, int item2)
   {
      item1--; //Adjust for zero-based index
      item2--;

      if (items[item1] != null && items[item2] != null)
      {
         if (items[item1].Equals(items[item2]))
         {
            Console.WriteLine($"Items are equal: ({items[item1]}) and ({items[item2]})");
         }
         else
         {
            Console.WriteLine($"Items are not equal: ({items[item1]}) and ({items[item2]})");
         }
      }
      else
      {
         Console.WriteLine("One or both items are null, cannot compare.");
      }
   }
}

public class OptimalRoute
{
   private static Dictionary<((int, int), (int, int)), int> Distance = new Dictionary<((int, int), (int, int)), int>();
   private static int callCounter = 0; // Track recursive calls

   //Recursive function to optimize route or distance between two points in the city map
   //function must include memoization to store previous results and avoid redundant calculations
   //limit of n <= 50 to avoid excessive computation
   //recursive call counter to monitor performance
   //considers blocked sectors (-1) as obstacles

   public static int BestRoute(
      (int row, int col) start,
      (int row, int col) end,
      int[,] cityMap,
      //having a visited set to avoid cycles
      HashSet<(int, int)> visited = null)
   {
      callCounter++;

      // Constraint: Prevent excessive recursion (n <= 50)
      if (callCounter > 50)
      {
         throw new InvalidOperationException("Recursion limit exceeded (n > 50)");
      }
      // Initialize visited set on first call
      if (visited == null)
      {
         visited = new HashSet<(int, int)>();
      }
      // Check memoization - avoid redundant calculations
      if (Distance.ContainsKey((start, end)))
      {
         return Distance[(start, end)];
      }
      // Base case: reached destination
      if (start.row == end.row && start.col == end.col)
      {
         return 0;
      }
      // Prevent cycles: if already visited this position, return max value
      if (visited.Contains(start))
      {
         return int.MaxValue;
      }
      // Check if start position is valid (not blocked)
      if (cityMap[start.row, start.col] == -1)
      {
         return int.MaxValue; // Cannot traverse blocked sector
      }
      // Mark current position as visited
      visited.Add(start);
      int minDistance = int.MaxValue;
      // Possible moves: up, down, left, right
      (int row, int col)[] moves = new (int, int)[]
      {
         (start.row - 1, start.col), // Up
         (start.row + 1, start.col), // Down
         (start.row, start.col - 1), // Left
         (start.row, start.col + 1)  // Right
      };
      foreach (var move in moves)
      {
         // Check bounds
         if (move.row >= 0 && move.row < cityMap.GetLength(0) &&
             move.col >= 0 && move.col < cityMap.GetLength(1))
         {
            // Check if sector is not blocked (-1) and not visited
            if (cityMap[move.row, move.col] != -1 && !visited.Contains(move))
            {
               // Create a copy of visited set for this branch
               var newVisited = new HashSet<(int, int)>(visited);

               int distance = BestRoute(move, end, cityMap, newVisited);
               if (distance != int.MaxValue)
               {
                  distance += 1; // Only add if valid path
                  if (distance < minDistance)
                  {
                     minDistance = distance;
                  }
               }
            }
         }
      }
      // Store result in memoization dictionary
      if (minDistance != int.MaxValue)
      {
         Distance[(start, end)] = minDistance;
      }
      return minDistance;
   }
   // Method to reset call counter for new calculations
   public static void ResetCallCounter()
   {
      callCounter = 0;
   }
   // Method to get call counter value
   public static int GetCallCounter()
   {
      return callCounter;
   }
   // Method to display route statistics
   public static void DisplayRouteInfo(
      (int row, int col) warehouse1,
      (int row, int col) warehouse2,
      int distance)
   {
      System.Console.WriteLine("-------------------------------------------------------");
      System.Console.WriteLine("------------------- Route Information -----------------");
      System.Console.WriteLine($"Start Warehouse: ({warehouse1.row}, {warehouse1.col})");
      System.Console.WriteLine($"End Warehouse:   ({warehouse2.row}, {warehouse2.col})");
      System.Console.WriteLine($"Minimum Distance: {distance} cells");
      System.Console.WriteLine($"Recursive Calls:  {callCounter}");
   }
}

public class Program
{
   public static void Main()
   {
      //2D array to represent a map of city sectors (N, M) sector and number of packages
      int[,] cityMap = {
         //Sector(rows) * warehouse(columns) 
         { 8, 9, 7 },
         { 8, 6, -1 },
         { 7, 8, 9 },
         { 9, -1, 8 },
         { 8, 10, 9 }
      };
      double[,] averages = new double[cityMap.GetLength(0), 1]; //To store averages per sector

      System.Console.WriteLine("-------------------------------------------------------");
      Warehouse warehouse = new Warehouse();
      System.Console.WriteLine("Package and Route Management System");
      System.Console.WriteLine("ADT");
      warehouse.CheckStock();
      warehouse.Inbound(20);
      warehouse.Outbound(50);

      System.Console.WriteLine("-------------------------------------------------------");
      System.Console.WriteLine("Multidimensional array storage");
      for (int i = 0; i < cityMap.GetLength(0); i++)
      {
         int sumPackage = 0;
         int countPackage = 0;
         //cityMap.GetLength(1) gives number of columns
         for (int j = 0; j < cityMap.GetLength(1); j++)
         {
            //Ignore missing cordinates (-1), only sum when grade is valid
            if (cityMap[i, j] != -1) //This checks package i's coordinate for sector 
            {
               sumPackage += cityMap[i, j];
               countPackage++;
            }
         }
         //Get average if the number of valid coordinates is major than zero
         double averagePackage = countPackage > 0 ? (double)sumPackage / countPackage : 0;
         System.Console.WriteLine($"Average of packages for sector {i + 1}: " + averagePackage);

         averages[i, 0] = averagePackage;
      }

      //Sort packages by descending average
      SortByDescending(averages, 0);   //Sort by first column (average)
      System.Console.WriteLine("Packages sorted by descending average:");
      for (int i = 0; i < averages.GetLength(0); i++)
      {
         System.Console.WriteLine($"Average sector: " + averages[i, 0]);
      }
      System.Console.WriteLine("Number of sectors: " + averages.GetLength(0));
      System.Console.WriteLine("-------------------------------------------------------");
      //Recursivity
      // Route from warehouse (0,0) to (4,2)
      OptimalRoute.ResetCallCounter();
      int minDistance = OptimalRoute.BestRoute((0, 0), (4, 2), cityMap);
      OptimalRoute.DisplayRouteInfo((0, 0), (4, 2), minDistance);


      System.Console.WriteLine("-------------------------------------------------------");
      System.Console.WriteLine("Generic class and constraints");
      Container<string> stringContainer = new Container<string>();
      stringContainer.Add("Jeans");
      stringContainer.Add("Beans can");
      stringContainer.Add("Soap");
      stringContainer.Add("Baguette");
      stringContainer.Add("Omelette");
      stringContainer.Show();

      stringContainer.Remove("Jeans");
      stringContainer.Search("Beans can");
      stringContainer.Search("Jeans");
      stringContainer.Add("Croissant");
      stringContainer.Add("Baguette");
      stringContainer.Compare(1, 2);
      stringContainer.Compare(4, 6);
      stringContainer.Show();
   }

   public static void SortByDescending(double[,] array, int columnIndex)
   {
      int rows = array.GetLength(0);
      int cols = array.GetLength(1);

      for (int i = 0; i < rows - 1; i++) // Bubble sort
      {
         for (int j = i + 1; j < rows; j++) // Compare rows
         {
            if (array[i, columnIndex] > array[j, columnIndex]) // For descending order
            {
               // Swap entire rows
               for (int k = 0; k < cols; k++) // Swap all columns
               {
                  double temp = array[i, k]; // Swap element
                  array[i, k] = array[j, k];
                  array[j, k] = temp;
               }
            }
         }
      }
   }

}