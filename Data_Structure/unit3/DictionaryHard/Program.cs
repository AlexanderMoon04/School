class ContactInfo
{
   public string PhoneNumber { get; set; } = string.Empty;
   public string Email { get; set; } = string.Empty;
   public string Vehicle { get; set; } = string.Empty;
}

class Program
{
   static void Main()
   {
      var agenda = new Dictionary<string, ContactInfo>();

      agenda.Add("Ana", new ContactInfo
      {
         PhoneNumber = "123456789",
         Email = "adaw@domain.com",
         Vehicle = "Toyota Camry"
      });
      agenda.Add("John", new ContactInfo
      {
         PhoneNumber = "987654321",
         Email = "faaw@fe.com",
         Vehicle = "Honda Accord"
      });

      if (agenda.ContainsKey("Ana"))
      {
         ContactInfo anaInfo = agenda["Ana"];

         System.Console.WriteLine("Ana's Contact Information:");
         System.Console.WriteLine($"Phone Number: {anaInfo.PhoneNumber}");
         System.Console.WriteLine($"Email: {anaInfo.Email}");
         System.Console.WriteLine($"Vehicle: {anaInfo.Vehicle}");
      }
      
      //update
      if (agenda.ContainsKey("Ana"))
      {
         agenda["Ana"].Email = "ana.updated@domain.com";
         System.Console.WriteLine("\nUpdated Ana's Email:");
         System.Console.WriteLine($"Email: {agenda["Ana"].Email}");
      }

      System.Console.WriteLine("--Full agenda--");
      foreach (var entry in agenda)
      {
         Console.WriteLine($"{entry.Key.ToUpper()}: {entry.Value.PhoneNumber} | {entry.Value.Vehicle} | {entry.Value.Vehicle}");
      }
   }
}