using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

public class Simple
{
   public void Add(List<string> songs, string songToAdd)
   {
      songs.Add(songToAdd);
      Console.WriteLine($"Song {songToAdd} added succesfully!");
   }
   public void Delete(List<string> songs, string songToRemove)
   {
      if (songs.Remove(songToRemove))
      {
         Console.WriteLine($"Song {songToRemove} removed successfully.");
      }
      else
      {
         Console.WriteLine($"Song {songToRemove} not found.");
      }
   }
   public void Play(List<string> songs)
   {
      foreach (var song in songs)
      {
         System.Console.WriteLine($"Playing {song}...");
         Thread.Sleep(2000);
      }
      System.Console.WriteLine("That's it ;)");
   }

   public void Display(List<string> songs)
   {
      songs.Sort();
      Console.WriteLine("Songs in alphabetical order:");
      foreach (var song in songs)
      {
         Console.WriteLine($"{song}");
      }
   }
}
public class DoublyLinked
{
   public void Add(LinkedList<string> songs, string songToAdd)
   {
      songs.AddLast(songToAdd);
      Console.WriteLine($"Song {songToAdd} added succesfully!");
   }

   public void Delete(LinkedList<string> songs, string songToRemove)
   {
      if (songs.Remove(songToRemove))
      {
         Console.WriteLine($"Song {songToRemove} removed successfully.");
      }
      else
      {
         Console.WriteLine($"Song {songToRemove} not found.");
      }
   }

   public void Play(LinkedList<string> songs)
   {
      if (songs.Count == 0)
      {
         Console.WriteLine("No songs in the list :(");
         return;
      }
      LinkedListNode<string> currentSong = songs.First;
      while (true)
      {
         Console.WriteLine($"Playing: {currentSong.Value}");
         Console.WriteLine("Press 2 to go to the next song, 1 to go to the previous song, or 0 to exit");

         var key = Console.ReadKey(true).Key; // Capture key press without displaying it

         if (key == ConsoleKey.D2) // Next song
         {
            if (currentSong.Next != null)
            {
               currentSong = currentSong.Next;
            }
            else
            {
               Console.WriteLine("You are at the last song.");
            }
         }
         else if (key == ConsoleKey.D1) // Previous song
         {
            if (currentSong.Previous != null)
            {
               currentSong = currentSong.Previous;
            }
            else
            {
               Console.WriteLine("You are at the first song.");
            }
         }
         else if (key == ConsoleKey.D0) // Exit
         {
            Console.WriteLine("Exiting the player.");
            break;
         }
         else
         {
            Console.WriteLine("Invalid key. Please press 1, 2, or 0.");
         }
      }
   }
   public void Display(LinkedList<string> songs)
   {
      foreach (var song in songs)
      {
         Console.WriteLine(song);
      }
   }
}
public class Node<T>
{
   public T Value { get; set; }
   public Node<T> Next { get; set; }
   public Node(T value) { Value = value; }
}
public class CircularList<T>
{
   private Node<T> lastNode;
   public void Insert(CircularList<T> songs, T data)
   {
      Node<T> node = new Node<T>(data);
      if (lastNode == null)
      {
         node.Next = node;
         lastNode = node;
      }
      else
      {
         node.Next = lastNode.Next;
         lastNode.Next = node;
         lastNode = node;
      }
   }
   public void Delete(CircularList<string> songs, T data)
   {
      if (lastNode == null) return;

      Node<T> current = lastNode.Next;
      Node<T> previous = lastNode;

         if (current.Value.Equals(data))
         {
            if (current == lastNode)
            {
               if (current.Next == current)
               {
                  lastNode = null; // List becomes empty
               }
               else
               {
                  previous.Next = current.Next;
                  lastNode = previous; // Update last node if we're deleting the last node
               }
            }
            else
            {
               previous.Next = current.Next; // Bypass the current
            }
            Console.WriteLine($"Song {data} removed successfully.");
         }
   }
   public void Play(int turns)
   {
      if (lastNode == null) return;
      Node<T> actual = lastNode.Next;
      for (int i = 0; i < turns; i++)
      {
         Console.WriteLine(actual.Value + " -> ");
         actual = actual.Next;
      }

      Console.WriteLine("...");
   }

   public void Display(CircularList<string> songs)
   {
      if (lastNode == null)
      {
         Console.WriteLine("No songs in the list :(");
         return;
      }
      Node<T> current = lastNode.Next;
      do
      {
         Console.WriteLine(current.Value);
         current = current.Next;
      } while (current != lastNode.Next);
   }

}
public class Program
{
   public static string SelectList(ref string selectedList)
   {
      System.Console.WriteLine("----------------------");
      Console.WriteLine("Select desired list:");
      Console.WriteLine("1. Simple");
      Console.WriteLine("2. DoubleLinked");
      Console.WriteLine("3. Circular");
      int listOption = int.Parse(Console.ReadLine());
      switch (listOption)
      {
         case 1:
            selectedList = "simple";
            break;
         case 2:
            selectedList = "doubleLinked";
            break;
         case 3:
            selectedList = "circular";
            break;
         default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
      }
      return selectedList;
   }
   public static void Main()
   {
      Simple simple = new Simple();
      DoublyLinked doublyLinked = new DoublyLinked();
      CircularList<string> circular = new CircularList<string>();

      List<string> SimpleSongs = new List<string>();
      LinkedList<string> DoublyLinkedSongs = new LinkedList<string>();
      CircularList<string> CircularSongs = new CircularList<string>();

      string selectedList = "simple";

      bool running = true;
      while (running)
      {
         Console.WriteLine("------------------------");
         Console.WriteLine($"Actual list type: {selectedList}");
         Console.WriteLine("Write the desired option:");
         Console.WriteLine("1. Change list type");
         Console.WriteLine("2. Add a song");
         Console.WriteLine("3. Remove a song");
         Console.WriteLine("4. Play");
         Console.WriteLine("5. Display all songs");
         Console.WriteLine("6. Exit");
         int option;
         Console.WriteLine("Write the desired option:");
         string input = Console.ReadLine();

         if (!int.TryParse(input, out option))
         {
            Console.WriteLine("Please enter a valid number.");
            continue;
         }

         switch (option)
         {
            case 1:
               selectedList = SelectList(ref selectedList);
               break;

            case 2:
               System.Console.Write("Song name: ");
               string songToAdd = Console.ReadLine();
               if (selectedList == "simple")
                  simple.Add(SimpleSongs, songToAdd);
               else if (selectedList == "doubleLinked")
                  doublyLinked.Add(DoublyLinkedSongs, songToAdd);
               else if (selectedList == "circular")
                  circular.Insert(CircularSongs, songToAdd);
               break;

            case 3:
               System.Console.WriteLine("Song name: ");
               string songToDelete = Console.ReadLine();
               if (selectedList == "simple")
                  simple.Delete(SimpleSongs, songToDelete);
               else if (selectedList == "doubleLinked")
                  doublyLinked.Delete(DoublyLinkedSongs, songToDelete);
               else if (selectedList == "circular")
                  circular.Delete(CircularSongs, songToDelete);
               break;

            case 4:
               if (selectedList == "simple")
                  simple.Play(SimpleSongs);
               else if (selectedList == "doubleLinked")
                  doublyLinked.Play(DoublyLinkedSongs);
               else if (selectedList == "circular")
                  circular.Play(10);
               break;

            case 5:
               if (selectedList == "simple")
                  simple.Display(SimpleSongs);
               else if (selectedList == "doubleLinked")
                  doublyLinked.Display(DoublyLinkedSongs);
               else if (selectedList == "circular")
                  circular.Display(CircularSongs);
                  break;

            case 6:
               System.Console.WriteLine("\nExiting...");
               running = false;
               break;

            default:
               System.Console.WriteLine("Invalid option. Please try again.");
               break;
         }
      }
   }
}