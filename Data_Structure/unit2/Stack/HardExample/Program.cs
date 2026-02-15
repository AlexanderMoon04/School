public class Pogram
{
   public static void Main()
   {
      //rpn expression: 5 + ((1 + 2) * 4)
      string[] tokens = { "5", "1", "2", "+", "4", "*", "+" };
      Stack<int> operands = new Stack<int>();

      foreach (string t in tokens)
      {
         if (int.TryParse(t, out int number))
         {
            operands.Push(number);
         }
         else
         {
            //we get the lasts two operands
            int b = operands.Pop();
            int a = operands.Pop();

            switch(t)
            {
               case "+": operands.Push(a + b); break;
               case "*": operands.Push(a * b); break;
            }
         }
      }
      Console.WriteLine($"Result: {operands.Pop()}");
   }
}