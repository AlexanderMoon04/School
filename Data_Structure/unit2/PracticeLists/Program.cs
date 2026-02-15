public class Linear
{
   public void Add(string song)
   {
   
   }
   public void Play
}
public class Navigable
{
   
}
public class Loop
{
   
}
public class Program
{
   public static void Main()
   {
      List<string> songs = new List<string>();
      string selectedList = "simple";


      while (true)
      
      {
         Console.WriteLine($"Actual list type: {selectedList}");
         Console.WriteLine("1. Change list type");
         Console.WriteLine("2. Add a song");
         Console.WriteLine("3. Remove a song");
         Console.WriteLine("4. Play");
         Console.WriteLine("5. Exit");
         int option = int.Parse(Console.ReadLine());

      switch (option)
      {
         case 1:
            Console.WriteLine("Select desired list:");
            Console.WriteLine("1. Simple");
            Console.WriteLine("2. DoubleLinked");
            Console.WriteLine("3. Circular");
            

            break;
         case 2:
            Console.WriteLine("Song name: ");
            songs.Add(Console.ReadLine());
            break;
         case 3:
            Console.WriteLine("Remove song: ");
            songs.Remove(Console.ReadLine());
            
            break;
         case 4:
            songs.Sort();
            Console.WriteLine("Songs in alphabetical order:");
            foreach (var song in songs)
            {
               Console.WriteLine($"{song}: {songs} ");
            }
            break;
         case 5:
            
            break;
         
      }

      }


   }
}