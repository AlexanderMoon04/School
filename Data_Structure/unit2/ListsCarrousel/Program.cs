public class Program
{
   public static void Main()
   {
      List<string> colors = new List<string> { "Red", "Green", "Blue", "Yellow", "Purple" };

      for(int i =0; i<10; i++)
      {
         string actualColor = colors[i % colors.Count];
         Console.WriteLine($"Turn  {i}: {actualColor}");
      }
   }
}