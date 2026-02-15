// Implement a generic class Container<T> where T must be a class
// (constraint where T : class), with the ability to store multiple elements (using an
// internal array), add, remove, and search for elements. Include a generic method to
// compare elements.

public class Container<T> where T : class //must be a reference type class
{
   //internal array to store elements
   private T[] elements = new T[elementsSize];
   private static int elementsSize = 10; //Initial size of the array
   public void Add(T item)
   {
      //Find first null position to add the item
      for (int i = 0; i < elements.Length; i++)
      {
         if (elements[i] == null)
         {
            elements[i] = item;
            return;
         }
      }
     System.Console.WriteLine("Array full, cannot add more items.");
   }
   public void Show()
      {
      for (int i = 0; i < elements.Length; i++)
      {
         if (elements[i] != null)
            Console.WriteLine($"{i + 1}. {elements[i]}");
      }  
      System.Console.WriteLine("-------------------------");
   }
   public void Remove(T item)
   {
      for (int i = 0; i < elements.Length; i++)
      {
         if (elements[i] != null && elements[i].Equals(item))
         {
            elements[i] = null; //Remove item by setting to null
            return;
         }
      }
      Console.WriteLine("Item not found, cannot remove: " + item);
   }
   public void Search(T item)
   {
      for (int i = 0; i < elements.Length; i++)
      {
         if (elements[i] != null && elements[i].Equals(item))
         {
            Console.WriteLine("Item found: " + item);
            return;
         }
      }
      Console.WriteLine("Item not found: " + item);
   }
   public void Compare(int item1,int item2)
   {
      item1--; //Adjust for zero-based index
      item2--; 

      if (elements[item1] != null && elements[item2] != null)
      {
         if (elements[item1].Equals(elements[item2]))
         {
            Console.WriteLine($"Items are equal: ({elements[item1]}) and ({elements[item2]})");
         }
         else
         {
            Console.WriteLine($"Items are not equal: ({elements[item1]}) and ({elements[item2]})");
         }
      }
      else
      {
         Console.WriteLine("One or both items are null, cannot compare.");
      }
   }
}
public class Program
{
   public static void Main()
   {
      Container<string> stringContainer = new Container<string>();
      stringContainer.Add("Hello");
      stringContainer.Add("World");
      stringContainer.Add("Items");
      stringContainer.Add("Baguette");
      stringContainer.Add("Omelette");
      stringContainer.Show();

      stringContainer.Remove("Hello");
      stringContainer.Search("World");
      stringContainer.Search("Hello");
      stringContainer.Add("Croissant");
      stringContainer.Add("Baguette");
      stringContainer.Compare(1,2);
      stringContainer.Compare(4,6);
      stringContainer.Show();
   }
}

