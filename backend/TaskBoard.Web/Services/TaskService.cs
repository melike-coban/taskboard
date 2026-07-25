using Microsoft.EntityFrameworkCore;
using TaskBoard.Web.Data;
using TaskBoard.Web.Interfaces;
using TaskBoard.Web.Models;
using TaskBoard.Web.ViewModels;

namespace TaskBoard.Web.Services;

public class TaskService : ITaskService
{
    private readonly TaskBoardDbContext _context;

    public TaskService(TaskBoardDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems.ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TaskItem> CreateAsync(CreateTaskViewModel request)
    {
        var task = new TaskItem
        {
            Title = request.Title,
            Priority = request.Priority,
            Status = "Open",
            CreatedAt = DateTime.Now
        };

        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<bool> UpdateAsync(int id, CreateTaskViewModel request)
    {
        var task = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            return false;

        task.Title = request.Title;
        task.Priority = request.Priority;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            return false;

        _context.TaskItems.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }
}