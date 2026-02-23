using System.Collections;

public class Program
{
   public static void Main()
   {

      Queue<string> queueImpresion = new Queue<string>();
      queueImpresion.Enqueue("Mensual_Report.pdf");
      queueImpresion.Enqueue("Photo.jpg");
      queueImpresion.Enqueue("San_Andreas_Sheet_Codes.pdf");


      bool running = true;
      while (running)
      {
         Console.WriteLine("------------------------");
         Console.WriteLine("Printer queue simulator");
         Console.WriteLine("Write the desired option:");
         Console.WriteLine("1. Add job");
         Console.WriteLine("2. Process job");
         Console.WriteLine("3. View next job");
         Console.WriteLine("4. Show full queue");
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
               System.Console.WriteLine("Enter the name of the document to add:");
               string jobName = Console.ReadLine();
               queueImpresion.Enqueue(jobName);
               System.Console.WriteLine($"Document '{jobName}' added to the queue.");
               System.Console.WriteLine("Press any key to continue...");
               Console.ReadKey();
            break;

            case 2:
               if (queueImpresion.Count > 0)
               {
                  string processedJob = queueImpresion.Dequeue();
                  System.Console.WriteLine($"Processed job: {processedJob}");
               }
               else
               {
                  System.Console.WriteLine("The queue is empty.");
               }
               System.Console.WriteLine("Press any key to continue...");
               Console.ReadKey();
            break;

            case 3:
               if (queueImpresion.Count > 0)
               {
                  System.Console.WriteLine($"Next job: {queueImpresion.Peek()}");
               }
               else
               {
                  System.Console.WriteLine("The queue is empty.");
               }
               System.Console.WriteLine("Press any key to continue...");
               Console.ReadKey();
               break;

            case 4:
               if (queueImpresion.Count > 0)
               {
                  System.Console.WriteLine("Full queue:");
                  foreach (var document in queueImpresion)
                  {
                     System.Console.WriteLine(document);
                  }
               }
               else
               {
                  System.Console.WriteLine("The queue is empty.");
               }
               System.Console.WriteLine("Press any key to continue...");
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