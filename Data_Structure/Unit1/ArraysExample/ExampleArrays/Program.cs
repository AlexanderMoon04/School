using System;

public class Program
{
   public static void Main(string[] args)
   {
      double[] califications = { 8.5, 9.0, 7.5, 8.0, 9.5 };
      double sum = 0;
      foreach (var calif in califications)
      {
         sum += calif;
      }
      double average = sum / califications.Length;
      System.Console.WriteLine("Average of grades: " + average);
      System.Console.WriteLine("Number of grades: " + califications.Length);  
      System.Console.WriteLine("Verification completed: arrays works fine!");
   }
}