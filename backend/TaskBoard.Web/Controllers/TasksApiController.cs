using Microsoft.AspNetCore.Mvc;
using TaskBoard.Web.Interfaces;
using TaskBoard.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

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

    try
    {
        var task = await _taskService.CreateAsync(request);

        return Created($"/api/tasks/{task.Id}", task);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(new
        {
            message = ex.Message
        });
    }
}

   [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, CreateTaskViewModel request)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
        var updated = await _taskService.UpdateAsync(id, request);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
    catch (ArgumentException ex)
    {
        return BadRequest(new
        {
            message = ex.Message
        });
    }
}
[Authorize(Roles = "Admin")]
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
    [Authorize(Roles = "Admin")]
    [HttpDelete]
public async Task<IActionResult> DeleteAll()
{
    await _taskService.DeleteAllAsync();

    return NoContent();
}
}