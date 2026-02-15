public class Program
{
   public static void Main(string[] args)
   {
      //Declaration and inalization
      List<string> students = new List<string>();

      //Adding elements
      students.Add("John");
      students.Add("Jane");
      students.Add("Jim");

      ShowStudents(students);

      //Delete by value
      students.Remove("Jane");
      students.Remove("Jake");

      ShowStudents(students);

      //Add element
      students.Add("Yon Sina");

      ShowStudents(students);

      //Add element
      students.Add("Goku");

      ShowStudents(students);
   }
   public static void ShowStudents(List<string> students)
   {
      System.Console.WriteLine("List of students:");
      foreach (var student in students)
      {
         System.Console.WriteLine($"-{student}");
      }
      System.Console.WriteLine("-------------------");
   }
}