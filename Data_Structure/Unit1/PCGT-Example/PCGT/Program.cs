public class Container<T> //Is able to store a collection of items of any type
{
   private List<T> elements = new List<T>();

   public void Add(T item)
   {
      elements.Add(item);
   }

   public void show()
   {
      foreach (var item in elements)
      {
         Console.WriteLine(item);
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
         stringContainer.Add("Items inside the string container:");
         stringContainer.show();
         stringContainer.Add("Second addition");
         stringContainer.show();
         Console.WriteLine("Verification complete");
      }
   }

