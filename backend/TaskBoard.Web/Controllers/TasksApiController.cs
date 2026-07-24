using Microsoft.EntityFrameworkCore;
using TaskBoard.Web.Data;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Web.Models;
using TaskBoard.Web.ViewModels;

namespace TaskBoard.Web.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksApiController : ControllerBase
{
    private readonly TaskBoardDbContext _context;

public TasksApiController(TaskBoardDbContext context)
{
    _context = context;
}

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.TaskItems.ToList());
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
            Id = _context.TaskItems.Count() + 1,
            Title = request.Title,
            Priority = request.Priority,
            Status = "Open",
            CreatedAt = DateTime.Now
        };

        _context.TaskItems.Add(task);
_context.SaveChanges();

        return Created($"/api/tasks/{task.Id}", task);
    }
    [HttpPatch("{id}/complete")]
public IActionResult Complete(int id)
{
    var task = _context.TaskItems.FirstOrDefault(t => t.Id == id);

    if (task == null)
    {
        return NotFound();
    }

    task.Status = "Done";
    _context.SaveChanges();

    return Ok(task);
}
}