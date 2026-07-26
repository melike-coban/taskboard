# Gün 18

Bugün uygulamanın hata yönetimini geliştirdim.
Service katmanında Guard Clause kullanarak geçersiz verileri kontrol altına aldım.
Başlık alanının gereksiz boşluklarını Trim() ile temizledim.
ILogger kullanarak oluşturma, güncelleme ve silme işlemlerini logladım.
Controller tarafında beklenen hatalar için uygun HTTP durum kodları döndürdüm.
Global Exception Handler ekleyerek beklenmeyen hatalarda kullanıcıya teknik detay gösterilmesini engelledim.
Frontend tarafında API hata mesajlarını kullanıcıya daha anlaşılır şekilde göstermeyi sağladım.
