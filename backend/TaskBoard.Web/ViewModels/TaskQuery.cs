namespace TaskBoard.Web.ViewModels;

public class TaskQuery
{
    public string? Search { get; set; }

    public string? Status { get; set; }

    public string? Priority { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}