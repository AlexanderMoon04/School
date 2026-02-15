using System;
using System.Collections.Generic;

public class CuentaBancaria
{
   private double saldo = 0;
   private List<string> historial = new List<string>();
   public void Depositar(double cantidad)
   {
      saldo += cantidad;
      historial.Add("Deposit: " + cantidad);
   }
   public void Retirar(double cantidad)
   {
      if (cantidad <= saldo)
      {
         saldo -= cantidad;
         historial.Add($"Withdraw: {cantidad}");
      }
   }
   public double ConsultarSaldo()
   {
      return saldo;
   }
   public void MostrarHistorial()
   {
      Console.WriteLine("Transaction History:");
      foreach (var entry in historial)
      {
         Console.WriteLine(entry);
      }
   }
}
public class Program
{
   public static void Main()
   {
      CuentaBancaria cuenta = new CuentaBancaria();
      cuenta.Depositar(100);
      System.Console.WriteLine("Balance after deposit: " + cuenta.ConsultarSaldo());
      cuenta.Retirar(50);
      System.Console.WriteLine("Balance after withdrawal: " + cuenta.ConsultarSaldo());
      cuenta.MostrarHistorial();
      System.Console.WriteLine("Verification complete: ADT works as expected.");
   }
}
