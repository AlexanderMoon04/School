public class Task
{
   public int id { get; set; }
   public string Description { get; set; }
   public bool IsCompleted { get; set; }
}
public class Program
{
   public static void Main()
   {
      List<Task> backlog = new List<Task>();

      //inserting tasks in specific positions
      backlog.Insert(0, new Task { id = 1, Description = "Fix critical bug", IsCompleted = false });
      backlog.Add(new Task { id = 2, Description = "Update documentation", IsCompleted = true });
      backlog.Add(new Task { id = 3, Description = "Clean code", IsCompleted = false });

      //Search for a specific task by id
      Task pendingTask = backlog.Find(t => t.id == 3);
      if (pendingTask != null) pendingTask.IsCompleted = true;

      //order list by Description
      backlog.Sort((x, y) => x.Description.CompareTo(y.Description));

      System.Console.WriteLine("Task Backlog state (ordered by alphabetical order):");
      foreach (var task in backlog)
      {
         string state = task.IsCompleted ? "[Completed]" : "[Pending]";
         Console.WriteLine($"{state} {task.Description}");
      }
   }
}