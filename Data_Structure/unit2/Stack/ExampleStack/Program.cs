public class Program
{
   public static void Main()
   {
      Stack<string> historyActions = new Stack<string>();

      //push some actions to the stack
      historyActions.Push("Visited Home Page");
      historyActions.Push("Clicked on Product Page");
      historyActions.Push("Added Product to Cart");

      Console.WriteLine($"Actual action to undo: {historyActions.Peek()}"); //check the top element without removing it

      //Delete element from top
      string undoAction = historyActions.Pop(); //remove the top element and return it
      Console.WriteLine($"'{undoAction}' was eliminated");

      System.Console.WriteLine("\nRemaining actions in history:");
      foreach (var action in historyActions)
      {
         Console.WriteLine($"- {action}");

      }
   }
}