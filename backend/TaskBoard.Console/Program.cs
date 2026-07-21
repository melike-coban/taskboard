var tasks = new List<string>();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== TASKBOARD ===");
    Console.WriteLine("1 - Görevleri Listele");
    Console.WriteLine("2 - Yeni Görev Ekle");
    Console.WriteLine("0 - Çıkış");
    Console.Write("Seçiminiz: ");

    var choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("Program kapatılıyor...");
        break;
    }
    else if (choice == "1")
    {
        ListTasks(tasks);
    }
    else if (choice == "2")
    {
        AddTask(tasks);
    }
    else
    {
        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen tekrar deneyin.");
    }
}

static void AddTask(List<string> tasks)
{
    Console.Write("Görev başlığı: ");
    var title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Görev başlığı boş bırakılamaz.");
        return;
    }

    Console.Write("Öncelik (Düşük / Normal / Yüksek): ");
    var priority = Console.ReadLine();

    tasks.Add($"{title} - {priority}");

    Console.WriteLine("Görev başarıyla eklendi.");
}
static void ListTasks(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Henüz görev bulunmuyor.");
        return;
    }

    Console.WriteLine("\nGörev Listesi:");

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]}");
    }
}
