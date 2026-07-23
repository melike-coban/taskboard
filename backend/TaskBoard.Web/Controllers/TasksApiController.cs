using Microsoft.AspNetCore.Mvc;
using TaskBoard.Web.Models;
using TaskBoard.Web.ViewModels;

namespace TaskBoard.Web.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksApiController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Tasks);
    }

    [HttpPost]
    public IActionResult Create(CreateTaskViewModel request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest("Başlık zorunludur.");
        }

        var task = new TaskItem
        {
            Id = Tasks.Count + 1,
            Title = request.Title,
            Priority = request.Priority,
            Status = "Open",
            CreatedAt = DateTime.Now
        };

        Tasks.Add(task);

        return Created($"/api/tasks/{task.Id}", task);
    }
    [HttpPatch("{id}/complete")]
public IActionResult Complete(int id)
{
    var task = Tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
    {
        return NotFound();
    }

    task.Status = "Done";

    return Ok(task);
}
}