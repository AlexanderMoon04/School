public class Program
{
   public static void Main()
   {
      LinkedList<string> players = new LinkedList<string>();
      players.AddLast("Alice");
      players.AddLast("Bob");
      players.AddLast("Charlie");

      LinkedListNode<string> currentPlayer = players.First;

      // Simulate turns
      for (int i = 0; i < 10; i++)
      {
         Console.WriteLine($"Turn {i}: {currentPlayer.Value}");
         currentPlayer = currentPlayer.Next ?? players.First; // Move to next player, loop back to first if at the end
         
      }
   }
}