using Microsoft.EntityFrameworkCore;
using TaskBoard.Web.Models;

namespace TaskBoard.Web.Data;

public class TaskBoardDbContext : DbContext
{
    public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();
}