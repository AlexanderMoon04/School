class Program
{
   static void Main()
      {
      Dictionary<string, string> contacts = new Dictionary<string, string>();

      //1. Create
      contacts.Add("Ana","123456789");
      contacts.Add("John", "987654321");
      contacts["sofia"] = "555555555"; // another way to add   
      System.Console.WriteLine("Elements in the dictionary:");
      System.Console.WriteLine("---------------------------");

      //2. Read
      if (contacts.ContainsKey("Ana"))
      {
         System.Console.WriteLine($"Ana's phone number: {contacts["Ana"]}");
      }
      //3. Update
      if (contacts.ContainsKey("John"))
      {
         contacts["John"] = "111111111"; // update John's phone number
         System.Console.WriteLine($"John's updated phone number: {contacts["John"]}");
      }
      //4. Delete
      bool removed = contacts.Remove("sofia");
      if (removed)
      {
         System.Console.WriteLine("Sofia's contact removed successfully.");
      }
      else
      {
         System.Console.WriteLine("Sofia's contact not found.");
      }

      //final verification 
      System.Console.WriteLine("\nFinal contacts in the dictionary:");
      foreach (var contact in contacts)
      {
         System.Console.WriteLine($"{contact.Key}: {contact.Value}");
      }

   }
}