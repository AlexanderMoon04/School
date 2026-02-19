public class Node<T>
{
   public T Value { get; set; }
   public Node<T> Next { get; set; }
   public Node (T value) {Value = value;}
}

public class CircularList<T>
{
   private Node<T> lastNode;
   public void Insert (T data)
   {
      Node <T> node = new Node<T>(data);
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

   public void Show(int turns)
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
}

public class Program
{
   public static void Main()
   {
      CircularList<int> ring = new CircularList<int>();
      ring.Insert(10);
      ring.Insert(20);
      ring.Insert(30);

      Console.WriteLine("Circular list:");
      ring.Show(7);
   }
}