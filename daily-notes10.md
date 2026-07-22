# Gün 10

Bugün TaskBoard Console uygulamasını nesne yönelimli programlama yapısına uygun şekilde geliştirdim.
TaskItem modeli ve TaskStatus enumunu oluşturarak görevleri daha düzenli bir yapıda yönetmeye başladım.
TaskService sınıfı ile görev ekleme, listeleme ve tamamlama işlemlerini servis katmanına taşıdım.
LINQ kullanarak açık görevleri filtreleyip listeleyen metot geliştirdim.
Aynı başlıkla görev eklenmesini engelledim ve tamamlanan görevler için CompletedAt bilgisini kaydettim.
Kodun okunabilirliğini artırmak amacıyla model, servis ve enum yapılarını ayrı dosyalara ayırdım.
