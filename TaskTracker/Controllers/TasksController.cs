// ===================================================================
// CONTROLLER = the LOGIC. It receives a request (from the browser),
// changes the data, and chooses which View to show.
// Each method below is called an "action" (like a function in C).
// ===================================================================
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers;

public class TasksController : Controller
{
    // Our fake "database": a list kept in memory.
    // "static" = shared by everyone, and it resets when the app restarts.
    private static List<TaskItem> _tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learn git branches" },
        new TaskItem { Id = 2, Title = "Push project to GitHub" }
    };
    private static int _nextId = 3;   // next free Id (like an auto-increment)

    // SHOW the task list. Runs when you open the page.
    // View(_tasks) sends the list to Views/Tasks/Index.cshtml
    public IActionResult Index()
    {
        return View(_tasks);
    }

    // ADD a task. [HttpPost] = only runs when a form is submitted.
    // "title" comes from the text box named "title" in the View.
    [HttpPost]
    public IActionResult Create(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))   // ignore empty input
            _tasks.Add(new TaskItem { Id = _nextId++, Title = title.Trim() });

        // >>> EDIT HERE (branch: feature/task-priority)
        //     Add a "string priority" parameter above and set
        //     Priority = priority inside the new TaskItem { ... }

        return RedirectToAction(nameof(Index));  // go back to the list
    }

    // MARK done / undo. Finds the task by Id and flips IsDone.
    [HttpPost]
    public IActionResult Toggle(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) task.IsDone = !task.IsDone;   // true <-> false
        return RedirectToAction(nameof(Index));
    }

    // DELETE a task by Id.
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _tasks.RemoveAll(t => t.Id == id);
        return RedirectToAction(nameof(Index));
    }

    // >>> EDIT HERE (branch: feature/edit-task)
    //     Add new actions here: Edit(int id) [GET] and Edit(...) [POST]
}
