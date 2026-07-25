using TaskBoard.Web.Models;
using TaskBoard.Web.ViewModels;

namespace TaskBoard.Web.Interfaces;

public interface ITaskService
{
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(CreateTaskViewModel request);
    Task<bool> UpdateAsync(int id, CreateTaskViewModel request);
    Task<bool> DeleteAsync(int id);
}