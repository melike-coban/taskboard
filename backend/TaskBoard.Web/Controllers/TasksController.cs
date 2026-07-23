using Microsoft.AspNetCore.Mvc;
using TaskBoard.Web.Models;
using TaskBoard.Web.ViewModels;

namespace TaskBoard.Web.Controllers;

public class TasksController : Controller
{
    public IActionResult Index()
    {
        var tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Id = 1,
                Title = "HTML Formları",
                Priority = "Yüksek",
                Status = "Open"
            },
            new TaskItem
            {
                Id = 2,
                Title = "CSS Düzeni",
                Priority = "Normal",
                Status = "Done"
            },
            new TaskItem
            {
                Id = 3,
                Title = "JavaScript",
                Priority = "Düşük",
                Status = "Open"
            },
            new TaskItem
          {
    Id = 4,
    Title = "README Güncelle",
    Priority = "Normal",
    Status = "Open"
},

new TaskItem
{
    Id = 5,
    Title = "GitHub Commit",
    Priority = "Yüksek",
    Status = "Done"
}
        };
ViewData["Title"] = "Görev Listesi";
        return View(tasks);
    }
    [HttpGet]
public IActionResult Create()
{
    return View();
}

[HttpPost]
public IActionResult Create(CreateTaskViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    return RedirectToAction(nameof(Index));
}
}