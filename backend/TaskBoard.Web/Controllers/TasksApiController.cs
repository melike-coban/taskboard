using Microsoft.AspNetCore.Mvc;
using TaskBoard.Web.Interfaces;
using TaskBoard.Web.ViewModels;

namespace TaskBoard.Web.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksApiController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksApiController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var task = await _taskService.CreateAsync(request);

        return Created($"/api/tasks/{task.Id}", task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateTaskViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updated = await _taskService.UpdateAsync(id, request);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _taskService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
    [HttpDelete]
public async Task<IActionResult> DeleteAll()
{
    await _taskService.DeleteAllAsync();

    return NoContent();
}
}