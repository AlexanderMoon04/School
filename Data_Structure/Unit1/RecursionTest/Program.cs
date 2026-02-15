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
      Console.WriteLine($"\n--- Route Information ---");
      Console.WriteLine($"Start Warehouse: ({warehouse1.row}, {warehouse1.col})");
      Console.WriteLine($"End Warehouse:   ({warehouse2.row}, {warehouse2.col})");
      Console.WriteLine($"Minimum Distance: {distance} cells");
      Console.WriteLine($"Recursive Calls:  {callCounter}");
   }
}

public class Program
{
   public static void Main()
   {
      // 2D array to represent a map of city sectors (rows x columns) with package quantities
      int[,] cityMap = {
         //Sector(rows) * warehouse(columns) 
         { 8, 9, 7 },      // Row 0
         { 8, 6, -1 },     // Row 1 (blocked at 1,2)
         { 7, 8, 9 },      // Row 2
         { 9, -1, 8 },     // Row 3 (blocked at 3,1)
         { 8, 10, 9 }      // Row 4
      };

      System.Console.WriteLine("\n========== Recursion for Route Optimization ==========");
      // Example 1: Route from warehouse (0,0) to (4,2)
      OptimalRoute.ResetCallCounter();
      int distance1 = OptimalRoute.BestRoute((0, 0), (4, 2), cityMap);
      if (distance1 != int.MaxValue)
      {
         OptimalRoute.DisplayRouteInfo((0, 0), (4, 2), distance1);
      }
      else
      {
         System.Console.WriteLine("No valid route");
      }
      // Example 2: Route from warehouse (0,0) to (1,1)
      OptimalRoute.ResetCallCounter();
      int distance2 = OptimalRoute.BestRoute((0, 0), (1, 1), cityMap);
      if (distance2 != int.MaxValue)
      {
         OptimalRoute.DisplayRouteInfo((0, 0), (1, 1), distance2);
      }
      else
      {
         System.Console.WriteLine("No valid route");
      }
      // Example 3: Route from warehouse (2,0) to (4,2)
      OptimalRoute.ResetCallCounter();
      int distance3 = OptimalRoute.BestRoute((2, 0), (4, 2), cityMap);
      if (distance3 != int.MaxValue)
      {
         OptimalRoute.DisplayRouteInfo((2, 0), (4, 2), distance3);
      }
      else
      {
         System.Console.WriteLine("No valid route");
      }
      System.Console.WriteLine("\n================================================");
   }
}