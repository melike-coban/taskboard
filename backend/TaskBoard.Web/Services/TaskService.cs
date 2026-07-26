using Microsoft.EntityFrameworkCore;
using TaskBoard.Web.Data;
using TaskBoard.Web.Interfaces;
using TaskBoard.Web.Models;
using TaskBoard.Web.ViewModels;
using Microsoft.Extensions.Logging;

namespace TaskBoard.Web.Services;

public class TaskService : ITaskService
{
    private readonly TaskBoardDbContext _context;
    private readonly ILogger<TaskService> _logger;

    public TaskService(
    TaskBoardDbContext context,
    ILogger<TaskService> logger)
{
    _context = context;
    _logger = logger;
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
        if (string.IsNullOrWhiteSpace(request.Title))
{
    throw new ArgumentException("Başlık zorunludur.");
}
_logger.LogInformation(
    "Yeni görev oluşturuluyor: {Title}",
    request.Title);
        var task = new TaskItem
        {
            Title = request.Title.Trim(),
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
        if (string.IsNullOrWhiteSpace(request.Title))
{
    throw new ArgumentException("Başlık zorunludur.");
}
_logger.LogInformation(
    "Görev güncelleniyor. Id: {Id}, Title: {Title}",
    id,
    request.Title);
        var task = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            return false;

        task.Title = request.Title.Trim();
        task.Priority = request.Priority;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            return false;
_logger.LogInformation(
    "Görev siliniyor. Id: {Id}, Title: {Title}",
    task.Id,
    task.Title);
        _context.TaskItems.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task DeleteAllAsync()
{
    _logger.LogInformation("Tüm görevler siliniyor.");
    _context.TaskItems.RemoveRange(_context.TaskItems);
    await _context.SaveChangesAsync();
}
}