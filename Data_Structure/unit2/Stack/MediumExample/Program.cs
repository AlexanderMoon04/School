public class Program
{
   public static bool IsBalanced(string expression)
   {
      Stack<char> stack = new Stack<char>();

      foreach (char c in expression)
      {
         if (c == '(')
         {
            stack.Push(c);
         }
         else if (c == ')')
         {
            //try to close something that was not opened
            if (stack.Count == 0) return false;

            stack.Pop();
         }
      }
      //if counting is not zero, there are some opened parentheses that were not closed
      return stack.Count == 0;
   }
   
   public static void Main()
   {
      //correct case
      string okExpression = "((a + b)* c )";

      //incorrect case 1 - more closing parentheses than opening ones
      string wrongExpression1 = "(a + b))";

      //incorrect case 2 - a closing parenthesis is missing
      string wrongExpression2 = "((a + b) * c";

      Console.WriteLine($"'{okExpression}' is valid? {IsBalanced(okExpression)}");
      Console.WriteLine($"'{wrongExpression1}' is valid? {IsBalanced(wrongExpression1)}");
      Console.WriteLine($"'{wrongExpression2}' is valid? {IsBalanced(wrongExpression2)}");
   }

}