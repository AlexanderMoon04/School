public class Program
{

   public static void BubbleSort(List<int> numbers)
   {
      for (int i = 0; i < numbers.Count - 1; i++)
      {
         for (int j = 0; j < numbers.Count - i - 1; j++)
         {
            if (numbers[j] > numbers[j + 1])
            {
               int aux = numbers[j];
               numbers[j] = numbers[j + 1];
               numbers[j + 1] = aux;
            }
         }
      }
      System.Console.WriteLine("Bubble sort realized succesfully. Press any key to continue...");
      Console.ReadKey();
   }

   public static void InsertionSort(List<int> numbers)
   {
      for (int i = 1; i < numbers.Count; i++)
      {
         int key = numbers[i];
         int j = i - 1;

         while (j >= 0 && numbers[j] > key)
         {
            numbers[j + 1] = numbers[j];
            j--;
         }
         numbers[j + 1] = key;
      }
      System.Console.WriteLine("Insertion sort realized succesfully. Press any key to continue...");
      Console.ReadKey();
   }

   public static void SelectionSort(List<int> numbers)
   {
      for (int i = 0; i < numbers.Count - 1; i++)
      {
         int minIndex = i;
         for (int j = i + 1; j < numbers.Count; j++)
         {
            if (numbers[j] < numbers[minIndex])
            {
               minIndex = j;
            }
         }
         int temp = numbers[minIndex];
         numbers[minIndex] = numbers[i];
         numbers[i] = temp;
      }
      System.Console.WriteLine("Selection sort realized succesfully. Press any key to continue...");
      Console.ReadKey();
   }

   public static void ViewArray(List<int> numbers)
   {
      System.Console.WriteLine("Viewing list numbers:");
      foreach (var number in numbers)
      {
         Console.Write($"{number} ");
      }
   }

   public static void Main()
   {
      List<int> numbers = new List<int> 
      {
         5, 3, 8, 1, 2
      };

      bool running = true;
      while (running)
      {
         Console.WriteLine("------------------------");
         Console.WriteLine("Sorting list");
         Console.WriteLine("Write the desired option:");
         Console.WriteLine("1. Input a list of numbers");
         Console.WriteLine("2. Choose sorting algorithm");
         Console.WriteLine("3. View numbers list");
         Console.WriteLine("4. Run all sorts");
         Console.WriteLine("5. Exit");
         int option;
         Console.WriteLine("Write the desired option:");
         string input = Console.ReadLine();

         if (!int.TryParse(input, out option))
         {
            Console.WriteLine("Please enter a valid number.");
            continue;
         }

         switch (option)
         {
            case 1:
               System.Console.WriteLine("Input a list of numbers (separated by spaces)");
               string numbersInput = Console.ReadLine();
               string[] numbersArray = numbersInput.Split(' ');
               numbers.Clear();
               int parsedNumber;
               foreach (var number in numbersArray)
               {
                  if (int.TryParse(number, out parsedNumber))
                  {
                     numbers.Add(parsedNumber);
                  }
                  else
                  {
                     System.Console.WriteLine($"'{number}' is not a valid number.");
                  }
               }
               System.Console.WriteLine("Press any key to continue...");
               Console.ReadKey();
               break;

            case 2:
               System.Console.WriteLine("1. Bubble Sort");
               System.Console.WriteLine("2. Insertion Sort");
               System.Console.WriteLine("3. Selection Sort");

               int optionSort;
               Console.WriteLine("Write the desired option:");
               string inputSort = Console.ReadLine();

               if (!int.TryParse(inputSort, out optionSort))
               {
                  Console.WriteLine("Please enter a valid number.");
                  continue;
               }

               switch (optionSort)
               {
                  case 1:
                     BubbleSort(numbers);
                     break;

                  case 2:
                     InsertionSort(numbers);
                     break;

                  case 3:
                     SelectionSort(numbers);
                     break;
                  default:
                     Console.WriteLine("Invalid option. Please try again.");
                     System.Console.WriteLine("Press any key to continue...");
                     Console.ReadKey();
                     break;
               }
               break;

            case 3:
               ViewArray(numbers);
               Console.WriteLine("\nPress any key to continue...");
               Console.ReadKey();
               break;

            case 4:
               BubbleSort(numbers);
               ViewArray(numbers);
               System.Console.WriteLine("");

               InsertionSort(numbers);
               ViewArray(numbers);
               System.Console.WriteLine("");

               SelectionSort(numbers);
               ViewArray(numbers);
               Console.WriteLine("Press any key to continue...");
               Console.ReadKey();

               break;

            case 5:
               running = false;
               System.Console.WriteLine("Exiting...");
               break;

            default:
               System.Console.WriteLine("Invalid option. Please try again.");
               System.Console.WriteLine("Press any key to continue...");
               Console.ReadKey();
               break;
         }
      }
   }
}