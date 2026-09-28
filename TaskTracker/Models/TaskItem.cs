// ===================================================================
// MODEL = the DATA. Think of it as a struct in C.
// Each property below is one field of a task.
// ===================================================================
namespace TaskTracker.Models;

public class TaskItem
{
    public int Id { get; set; }              // unique number for each task
    public string Title { get; set; } = "";  // what the task says
    public bool IsDone { get; set; }         // false = pending, true = finished

    // >>> EDIT HERE (branch: feature/task-priority)
    //     Add:  public string Priority { get; set; } = "Normal";
    // >>> EDIT HERE (branch: feature/due-dates)
    //     Add:  public DateTime? DueDate { get; set; }
}
