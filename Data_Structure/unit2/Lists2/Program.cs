public class Product
{
   public string Name { get; set; }
   public double Price { get; set; }
}
public class Program
{
   public static void Main()
   {
      List<Product> shoppingCart = new List<Product>
      {
         new Product { Name = "Laptop", Price = 999.99 },
         new Product { Name = "Smartphone", Price = 499.49 },
         new Product { Name = "Tablet", Price = 299.99 },
         new Product { Name = "Earphones", Price = 69.99 }
      };

      //Filter products with price greater than 100 using LINQ
      var price = shoppingCart.Where(p => p.Price > 100).ToList();

      System.Console.WriteLine("Products with price greater than 100:");
      price.ForEach(p => System.Console.WriteLine($"- {p.Name}: ${p.Price}"));
   }
}