using System.ComponentModel.DataAnnotations;
namespace TaskBoard.Web.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Başlık zorunludur.")]
public string Title { get; set; } = string.Empty;

    public string Priority { get; set; } = "Normal";

    public string Status { get; set; } = "Open";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}