using TaskBoard.Console.Models;
using TaskBoard.Console.Services;
var taskService = new TaskService();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== TASKBOARD ===");
    Console.WriteLine("1 - Görevleri Listele");
    Console.WriteLine("2 - Görev Ekle");
    Console.WriteLine("3 - Tamamlandı Yap");
    Console.WriteLine("4 - Açık Görevleri Listele");
    Console.WriteLine("0 - Çıkış");
    Console.Write("Seçiminiz: ");

    var choice = Console.ReadLine();

    if (choice == "0")
        break;

    else if (choice == "1")
        ListTasks(taskService);

    else if (choice == "2")
        AddTask(taskService);

    else if (choice == "3")
        CompleteTask(taskService);

    else if (choice == "4")
        ListOpenTasks(taskService);

    else
        Console.WriteLine("Geçersiz seçim.");
}

static void AddTask(TaskService taskService)
{
    Console.Write("Görev başlığı: ");
    var title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Görev başlığı boş olamaz.");
        return;
    }

    Console.Write("Öncelik: ");
    var priority = Console.ReadLine();

    var task = new TaskItem
    {
        Title = title,
        Priority = priority ?? "Normal"
    };

    taskService.Add(task);

    Console.WriteLine("Görev eklendi.");
}
static void ListTasks(TaskService taskService)
{
    var tasks = taskService.GetAll();

    if (tasks.Count == 0)
    {
        Console.WriteLine("Henüz görev bulunmuyor.");
        return;
    }

    Console.WriteLine("\nGörev Listesi:");

    foreach (var task in tasks)
    {
        Console.WriteLine($"{task.Id}. {task.Title} | {task.Priority} | {task.Status}");
    }
}
static void CompleteTask(TaskService taskService)
{
    Console.Write("Tamamlanacak görev ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Geçersiz ID.");
        return;
    }

    taskService.MarkAsDone(id);

    Console.WriteLine("Görev tamamlandı.");
}
static void ListOpenTasks(TaskService taskService)
{
    var tasks = taskService.GetByStatus(TaskBoard.Console.Models.TaskStatus.Open);

    if (tasks.Count == 0)
    {
        Console.WriteLine("Açık görev bulunmuyor.");
        return;
    }

    Console.WriteLine("\nAçık Görevler:");

    foreach (var task in tasks)
    {
        Console.WriteLine($"{task.Id}. {task.Title} | {task.Priority}");
    }
}
