using TaskBoard.Console.Models;

namespace TaskBoard.Console.Services;

public class TaskService
{
    private readonly List<TaskItem> tasks = new();

    public void Add(TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
        {
            return;
        }

        if (tasks.Any(t => t.Title.Equals(task.Title, StringComparison.OrdinalIgnoreCase)))
        {
            System.Console.WriteLine("Bu başlıkta bir görev zaten mevcut.");
            return;
        }

        task.Id = tasks.Count + 1;

        tasks.Add(task);
    }

    public List<TaskItem> GetAll()
    {
        return tasks;
    }

    public void MarkAsDone(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return;
        }

        task.Status = TaskBoard.Console.Models.TaskStatus.Done;
        task.CompletedAt = DateTime.Now;
    }

    public List<TaskItem> GetByStatus(TaskBoard.Console.Models.TaskStatus status)
    {
        return tasks
            .Where(t => t.Status == status)
            .ToList();
    }
}