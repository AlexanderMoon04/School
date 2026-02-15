// Create a 2D array to represent a matrix of grades (students x subjects),
// calculate averages per student and subject, and sort the students by descending
// average. Handle cases where grades are missing (using -1 as an indicator).
public class Program
{
   public static void Main(string[] args)
   {
      //create a 2D array to represent grades (students x subjects)
      double[,] califications = {
         { 8.5, 9.0, 7.5 },
         { 8.0, 6.5, -1 },
         { 7.0, 8.5, 9.0 },
         { 9.0, -1, 8.5 },
         { 8.5, 10, 9.5 }
      };

      double[,] averages = new double[califications.GetLength(0), 1]; //To store averages per student

      //califications.GetLength(0) gives number of students (rows)
      for (int i = 0; i < califications.GetLength(0); i++)
      {
         double sumStudent = 0;
         int countStudent = 0;
         //califications.GetLength(1) gives number of subjects (columns)
         for (int j = 0; j < califications.GetLength(1); j++)
         {
            //Ignore missing grades (-1), only sum when grade is valid
            if (califications[i, j] != -1) //This checks student i's grade for subject 
            {
               sumStudent += califications[i, j];
               countStudent++;
            }
         }
         //Get average if the number of valid califications is major than zero
         double averageStudent = countStudent > 0 ? sumStudent / countStudent : 0;
         System.Console.WriteLine($"Average of student {i + 1}: " + averageStudent);

         averages[i, 0] = averageStudent;
      }
      System.Console.WriteLine("-------------------------------------------------------");
      //Calculate average per subject, the same way as before but iterating columns first
      for (int j = 0; j < califications.GetLength(1); j++)
      {
         double sumSubject = 0;
         int countSubject = 0;
         for (int i = 0; i < califications.GetLength(0); i++)
         {
            if (califications[i, j] != -1)
            {
               sumSubject += califications[i, j];
               countSubject++;
            }
         }
         double averageSubject = countSubject > 0 ? sumSubject / countSubject : 0;
         System.Console.WriteLine($"Average grade for subject {j + 1}: " + averageSubject);
      }
      System.Console.WriteLine("-------------------------------------------------------");

      //Sort students by descending average
      SortByDescending(averages, 0);   //Sort by first column (average)
      System.Console.WriteLine("Students sorted by descending average:");
      for (int i = 0; i < averages.GetLength(0); i++)
      {
         System.Console.WriteLine($"Average: " + averages[i, 0]);
      }
      System.Console.WriteLine("Number of grades: " + califications.Length);
   }
   
   public static void SortByDescending(double[,] array, int columnIndex)
   {
      int rows = array.GetLength(0);
      int cols = array.GetLength(1);

      for (int i = 0; i < rows - 1; i++) // Bubble sort
      {
         for (int j = i + 1; j < rows; j++) // Compare rows
         {
            if (array[i, columnIndex] > array[j, columnIndex]) // For descending order
            {
               // Swap entire rows
               for (int k = 0; k < cols; k++) // Swap all columns
               {
                  double temp = array[i, k]; // Swap element
                  array[i, k] = array[j, k]; 
                  array[j, k] = temp; 
               }
            }
         }
      }
   }
}


