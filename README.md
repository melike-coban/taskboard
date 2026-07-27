# TaskBoard

## Proje Özeti

TaskBoard, görevlerin oluşturulmasını, takip edilmesini ve yönetilmesini sağlayan full-stack bir görev takip uygulamasıdır.

- Kullanıcılar görev ekleyebilir, listeleyebilir, güncelleyebilir ve silebilir.
- Görevler öncelik ve durum bilgileri ile yönetilir.
- Görevler üzerinde arama ve filtreleme işlemleri yapılabilir.
- Backend tarafında ASP.NET Core Web API kullanılmıştır.
- Frontend ve backend arasında API iletişimi sağlanmıştır.
- Veriler Entity Framework Core kullanılarak SQLite veritabanında saklanmaktadır.
- Kullanıcı giriş sistemi ve rol bazlı yetkilendirme eklenmiştir.
- Servis katmanı kullanılarak iş mantığı controller katmanından ayrılmıştır.
- API tarafında filtreleme ve sayfalama desteği bulunmaktadır.
- Proje Git ve GitHub kullanılarak versiyon kontrolü ile geliştirilmiştir.

---

# Kullanılan Teknolojiler

## Frontend

- HTML5
- CSS3
- JavaScript
- Fetch API

## Backend

- C#
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core

## Veritabanı

- SQLite

## Araçlar

- Git
- GitHub
- Swagger

---

# Özellikler

## Görev Yönetimi

- Görev oluşturma
- Görev listeleme
- Görev güncelleme
- Görev silme
- Görev tamamlama

## Arama ve Filtreleme

Uygulamada görevler için:

- Başlığa göre arama
- Duruma göre filtreleme
- Önceliğe göre filtreleme

özellikleri bulunmaktadır.

Desteklenen öncelik değerleri:

- high
- normal
- low

---

# Sayfalama

API tarafında sayfalama desteği bulunmaktadır.

Kullanılan parametreler:

```
page
pageSize
```

Örnek kullanım:

```
/api/tasks?page=1&pageSize=5
```

API cevabında:

- Toplam kayıt sayısı
- Mevcut sayfa numarası
- Toplam sayfa sayısı

bilgileri döndürülmektedir.

---

# Proje Yapısı

## Frontend

```
frontend
│
├── index.html
│
├── css
│   └── style.css
│
└── js
    ├── app.js
    └── apiClient.js
```

Frontend tarafında kullanıcı arayüzü oluşturulmuş ve backend API ile iletişim Fetch API kullanılarak sağlanmıştır.

---

## Backend

```
backend
│
└── TaskBoard.Web
    │
    ├── Controllers
    ├── Services
    ├── Interfaces
    ├── Models
    ├── ViewModels
    ├── Data
    └── Migrations
```

Backend katmanları:

- **Controllers:** HTTP isteklerini yönetir.
- **Services:** İş mantığını içerir.
- **Models:** Veri modellerini temsil eder.
- **Data:** Veritabanı bağlantısını sağlar.
- **ViewModels:** Kullanıcıdan gelen verilerin yönetilmesini sağlar.

---

# API Endpointleri

## Görevleri Listeleme

GET

```
/api/tasks
```

Desteklenen parametreler:

```
search
status
priority
page
pageSize
```

Örnek:

```
/api/tasks?priority=high&page=1&pageSize=5
```

---

## Görev Oluşturma

POST

```
/api/tasks
```

---

## Görev Güncelleme

PUT

```
/api/tasks/{id}
```

---

## Görevi Tamamlama

PATCH

```
/api/tasks/{id}/done
```

---

## Görev Silme

DELETE

```
/api/tasks/{id}
```

---

# Veritabanı

Projede SQLite veritabanı kullanılmıştır.

Entity Framework Core ile:

- Veritabanı bağlantısı oluşturulmuştur.
- Migration işlemleri yapılmıştır.
- CRUD işlemleri gerçekleştirilmiştir.
- Görev verileri kalıcı olarak saklanmaktadır.

---

# Kullanıcı Yetkilendirme

Projede cookie authentication kullanılmıştır.

Roller:

- Admin
- User

Admin kullanıcıları:

- Görev silebilir.
- Yönetim işlemlerini gerçekleştirebilir.

User kullanıcıları:

- Yetkileri dahilinde işlem yapabilir.

---

# Hata Yönetimi ve Loglama

Projede:

- Model doğrulama işlemleri
- Exception yönetimi
- ILogger kullanımı

uygulanmıştır.

API tarafında uygun HTTP durum kodları döndürülmektedir.

---

# Kurulum

Projeyi bilgisayarınıza aldıktan sonra backend klasörüne gidin:

```bash
cd backend/TaskBoard.Web
```

Gerekli paketleri yüklemek için:

```bash
dotnet restore
```

Projeyi derlemek için:

```bash
dotnet build
```

---

# Çalıştırma

Backend uygulamasını çalıştırmak için:

```bash
dotnet run
```

Frontend için:

```
frontend/index.html
```

dosyasını Live Server kullanarak açabilirsiniz.

---

# Test

Testleri çalıştırmak için:

```bash
dotnet test
```

API kontrolü için:

```
/api/tasks
```

endpointi kullanılabilir.

Örnek:

```
/api/tasks?page=1&pageSize=5
```

---

# Kontrol Listesi

- [x] Frontend ve backend bağlantısı yapıldı.
- [x] REST API endpointleri oluşturuldu.
- [x] CRUD işlemleri tamamlandı.
- [x] SQLite veritabanı kullanıldı.
- [x] Entity Framework Core kullanıldı.
- [x] Kullanıcı yetkilendirme sistemi eklendi.
- [x] Arama ve filtreleme özellikleri tamamlandı.
- [x] Sayfalama desteği eklendi.
- [x] Hata yönetimi yapıldı.
- [x] Loglama sistemi eklendi.
- [x] README final hale getirildi.

---

# Geliştirme Fırsatları

- Daha gelişmiş sıralama seçenekleri eklenebilir.
- Pagination arayüzü geliştirilebilir.
- Bildirim sistemi eklenebilir.
- Daha kapsamlı kullanıcı yönetimi yapılabilir.

---

# Geliştirici

Melike Çoban

Full-Stack Staj Projesi - TaskBoard
