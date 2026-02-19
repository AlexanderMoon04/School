//Simulate web browser navigation using stack data structure
public class Program
{
   public static void Main()
   {
      Stack<string> WebHistory = new Stack<string>(); 

      do
      {
         Console.WriteLine("\n------------------------");
         Console.WriteLine("1. Visit a page");
         Console.WriteLine("2. Go back");
         Console.WriteLine("3. View current page");
         Console.WriteLine("4. Show history");
         Console.WriteLine("Press ESC to exit");

         ConsoleKeyInfo keyInfo = Console.ReadKey();
         switch (keyInfo.Key)
         {
            case ConsoleKey.D1: //1. Visit a page
               Console.WriteLine("\nEnter the page name:");
               string pageName = Console.ReadLine();
               WebHistory.Push(pageName);
               System.Console.WriteLine("Push any key to continue...");
               break;
         
            case ConsoleKey.D2: //2. Go back
               if (WebHistory.Count > 0)
               {
                  string lastPage = WebHistory.Pop();
                  Console.WriteLine($"\nWent back from {lastPage}");
                  System.Console.WriteLine("Push any key to continue...");
               }
               else
               {
                  Console.WriteLine("\nNo pages to go back to.");
                  System.Console.WriteLine("Push any key to continue...");
               }
               break;

            case ConsoleKey.D3: //3. View current page
               if (WebHistory.Count > 0)
               {
                  string currentPage = WebHistory.Peek();
                  Console.WriteLine($"\nCurrent page: {currentPage}");
                  System.Console.WriteLine("Push any key to continue...");
               }
               else
               {
                  Console.WriteLine("\nNo pages visited yet.");
                  System.Console.WriteLine("Push any key to continue...");
               }
               break;

            case ConsoleKey.D4: //4. Show history
               if (WebHistory.Count > 0)
               {
                  Console.WriteLine("\nBrowsing history:");
                  foreach (var page in WebHistory)
                  {
                     Console.WriteLine($"- {page}");
                  }
                  System.Console.WriteLine("Push any key to continue...");
               }
               else
               {
                  Console.WriteLine("\nNo browsing history.");
                  System.Console.WriteLine("Push any key to continue...");
               }
               break;
         }
      } while (Console.ReadKey().Key != ConsoleKey.Escape);
   }
}