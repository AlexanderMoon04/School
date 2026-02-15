// Implement a recursive function to calculate the nth Fibonacci number,
// but with memory (using a dictionary to store previous results) and validation for large
// numbers (limit to n <= 50 to avoid overflow). Include a recursive call counter.

public class Fibonacci
{
   private static Dictionary<long, long> fibValues = new Dictionary<long, long> { { 0, 0 }, { 1, 1 } };

   public static long CalculateFiboNumber(int n)
   {
      if (!fibValues.ContainsKey(n)) //check if value already calculated
         fibValues[n] = CalculateFiboNumber(n - 1) + CalculateFiboNumber(n - 2);

      return fibValues[n];
   }
}

public class Program
{
   public static void Main()
   {

      while (true)
      {
         System.Console.WriteLine("\nEnter a number between 0 and 50 to calculate the nth Fibonacci number (or -1 to exit):");

         if (!int.TryParse(Console.ReadLine(), out int n))
         {
            System.Console.WriteLine("Invalid input. Please enter a valid integer.\n");
            continue;
         }

         if (n == -1)
         {
            break;
         }

         if (n < 0 || n > 50)
         {
            System.Console.WriteLine("Please enter a valid number between 0 and 50.");
         }
         else
         {
            long result = Fibonacci.CalculateFiboNumber(n);
            System.Console.WriteLine($"Fibonacci number ({n}) = {result}");
         }
      }

      Console.WriteLine("Bye.");
   }
}