//Key points
//Deposit
// Withdrawal

// Validations for negative balances
// Withdrawal limits
// Transaction history (internal list)

using System;
using System.Collections.Generic;

public class BankAccount
{
   private double balance = 0;
   private List<string> history = new List<string>();
   public void Deposit(double amount)
   {
      balance += amount;
      history.Add("Deposit: " + amount);
   }
   public void Withdraw(double amount)
   {
      if (amount > 1000)
      {
         System.Console.WriteLine("Withdrawal limit exceeded. Maximum allowed is 1000.");
         return;
      }

      if (amount <= balance && amount > 0)
      {
         balance -= amount;
         history.Add($"Withdraw: {amount}");
      }
      else
      {
         Console.WriteLine("Insufficient funds for withdrawal.");
      }
   }
   public double GetBalance()
   {
      return balance;
   }
   public void ShowHistory()
   {
      Console.WriteLine("Transaction History:");
      foreach (var entry in history)
      {
         Console.WriteLine(entry);
      }
   }
}
public class Program
{
   public static void Main()
   {
      BankAccount account = new BankAccount();
      System.Console.WriteLine("Initial Balance: " + account.GetBalance());
      System.Console.WriteLine("Welcome, select the operation to perform:");

      while (true)
      {
         System.Console.WriteLine("1.Deposit  2.Withdraw  3.Show History  4.Exit");
         int option = int.Parse(Console.ReadLine());
         switch (option)
         {
            case 1:
               System.Console.WriteLine("Enter amount to deposit: ");
               account.Deposit(double.Parse(Console.ReadLine()));
               Console.WriteLine($"Balance after deposit: {account.GetBalance()}");
               break;

            case 2:
               System.Console.WriteLine("Enter amount to withdraw (max 1000):");
               account.Withdraw(double.Parse(Console.ReadLine()));
               Console.WriteLine($"Balance after withdrawal: {account.GetBalance()}");
               break;

            case 3:
               account.ShowHistory();
               break;

            case 4:
               System.Console.WriteLine("Have a nice day ;)");
               Environment.Exit(0);
               break;

            default:
               System.Console.WriteLine("Invalid option selected.");
               break;
         }
      }
   }
}
