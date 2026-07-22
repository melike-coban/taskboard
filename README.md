# TaskBoard

Bu proje, uzaktan Full-Stack Staj Programı kapsamında geliştirilen **TaskBoard** isimli basit bir görev takip uygulamasıdır.

## Proje Amacı

TaskBoard, kullanıcıların görevlerini oluşturabildiği, listeleyebildiği ve ilerleyen günlerde düzenleyip silebileceği bir web uygulaması olarak geliştirilmektedir. Proje, HTML, CSS, JavaScript ve ASP.NET Core MVC teknolojileri kullanılarak adım adım oluşturulacaktır.

## Kullanılan Teknolojiler

- HTML5
- CSS3 _(ilerleyen günlerde eklenecek)_
- JavaScript _(ilerleyen günlerde eklenecek)_
- ASP.NET Core MVC _(ilerleyen günlerde eklenecek)_

## Yapılan Çalışmalar

### Gün 1

- Proje klasör yapısı oluşturuldu.
- Temel HTML sayfası hazırlandı.
- `header`, `main`, `section` ve `footer` etiketleri kullanılarak sayfa yapısı oluşturuldu.
- İlk görev ekleme alanı hazırlandı.
- GitHub reposu oluşturuldu ve ilk commit gerçekleştirildi.

### Gün 2

- Görev önceliği seçimi için `select` alanı eklendi.
- Görev açıklaması için `textarea` alanı eklendi.
- Görevleri listelemek amacıyla HTML tablosu oluşturuldu.
- Tabloda `thead` ve `tbody` yapısı kullanıldı.
- Form alanlarına `required`, `maxlength` ve `placeholder` özellikleri eklendi.
- Tabloya üç örnek görev eklendi.
- Form alanlarında `label` kullanılarak erişilebilirlik iyileştirildi.

### Gün 3

- CSS dosyası (`style.css`) oluşturuldu ve HTML dosyasına bağlandı.
- Sayfaya temel font, arka plan rengi ve boşluk düzeni eklendi.
- Görev tablosu ve görev ekleme formu kart (card) görünümüne dönüştürüldü.
- Öncelik seviyeleri için renkli badge sınıfları oluşturuldu.
- Form butonuna hover efekti eklendi.
- CSS değişkenleri kullanılarak tekrar eden renk ve boşluk değerleri düzenlendi.
- Tablo okunabilirliğini artıracak satır boşlukları ve temel stiller eklendi.

### Gün 4

- Dashboard bölümüne Toplam Görev, Açık Görev ve Tamamlanan görevleri gösteren KPI kartları eklendi.
- KPI kartları CSS Grid kullanılarak düzenlendi.
- Form ve görev listesi masaüstünde iki sütun, mobilde tek sütun olacak şekilde responsive hale getirildi.
- Tablo için `overflow-x` özelliği eklenerek küçük ekranlarda yatay kaydırma desteği sağlandı.
- Sayfanın 390px, 768px ve 1280px ekran genişliklerinde görünümü kontrol edildi.

### Gün 5

- TaskBoard sayfası dashboard görünümüne dönüştürüldü.
- KPI kartları güncellenerek görev istatistikleri gösterildi.
- Görev listesi ve yeni görev formu kart yapısına dönüştürüldü.
- Görev tablosuna 5 örnek görev eklendi.
- Öncelik ve durum bilgileri renkli badge yapısıyla gösterildi.
- Boş görev listesi için Empty State bölümü eklendi.

### Gün 6

- JavaScript için `app.js` dosyası oluşturuldu ve HTML dosyasına bağlandı.
- Formun `submit` olayı JavaScript ile yakalandı.
- Kullanıcının girdiği görev başlığı ve öncelik bilgileri okunarak tabloya dinamik olarak eklendi.
- Boş görev başlığı kontrolü yapılarak hatalı girişler engellendi.
- Görev eklendikten sonra form temizlendi ve imleç tekrar görev başlığı alanına getirildi.
- Toplam Görev ve Açık Görev KPI kartları otomatik güncellendi.
- Görev sayısına göre Empty State görünümü kontrol edildi.

### Gün 7

- Görevler için `tasks` adında bir dizi (state) oluşturuldu.
- `createTask()` fonksiyonu ile yeni görev nesneleri oluşturulacak şekilde düzenleme yapıldı.
- `renderTasks()` fonksiyonu kullanılarak görev tablosu dinamik olarak oluşturuldu.
- Yeni görevler doğrudan tabloya eklenmek yerine `tasks` dizisine eklenmeye başlandı.
- Duruma göre filtreleme (Tümü, Açık, Tamamlandı) özelliği eklendi.
- Önceliğe göre filtreleme özelliği eklendi.
- Tamamla butonu ile görevlerin durumu silinmeden güncellenebilir hale getirildi.
- Toplam Görev, Açık Görev ve Tamamlanan Görev KPI kartları `tasks` dizisi üzerinden otomatik hesaplanacak şekilde düzenlendi.
- `map()`, `filter()` ve `find()` array metotları kullanılarak kod tekrarları azaltıldı.

### Gün 8

- Görevler localStorage kullanılarak tarayıcıya kaydedilecek şekilde düzenlendi.
- Sayfa açılırken görevler localStorage üzerinden yüklenir hale getirildi.
- JSON verisi güvenli şekilde okunarak olası parse hataları kontrol altına alındı.
- `tasks.json` dosyası oluşturularak Fetch API ile örnek görevlerin okunması sağlandı.
- `async/await` ve `try/catch` yapıları kullanılarak veri yükleme işlemleri gerçekleştirildi.
- Örnek görevleri içeri aktarma özelliği eklendi.
- LocalStorage verilerini temizleme özelliği eklendi.
- Kullanıcıya yükleme ve hata durumları hakkında bilgilendirme mesajları gösterilecek şekilde düzenleme yapıldı.

### Gün 9

- `TaskBoard.Console` isimli C# Console projesi oluşturuldu.
- Görevleri listeleme, ekleme ve çıkış işlemlerini içeren bir menü geliştirildi.
- Kullanıcıdan görev başlığı ve öncelik bilgisi alınarak görevler `List<string>` içerisinde saklandı.
- Boş görev başlığı kontrolü eklenerek hatalı girişler engellendi.
- Görevler numaralı şekilde listelenecek şekilde düzenlendi.
- Hatalı menü seçimlerinde kullanıcıya uyarı mesajı gösterildi.
- Kod okunabilirliği artırmak amacıyla görev ekleme ve listeleme işlemleri metotlara ayrıldı.

### Gün 10

- `TaskItem` modeli oluşturularak görevler nesne tabanlı yapıya dönüştürüldü.
- `TaskStatus` enumu eklenerek görev durumları yönetilebilir hale getirildi.
- `TaskService` sınıfı oluşturularak görev ekleme, listeleme ve tamamlama işlemleri servis katmanına taşındı.
- Console menüsü `TaskService` üzerinden çalışacak şekilde yeniden düzenlendi.
- LINQ kullanılarak sadece açık görevleri listeleme özelliği eklendi.
- Aynı başlıkla görev eklenmesi engellendi.
- Görev tamamlandığında `CompletedAt` alanı otomatik olarak doldurulacak şekilde düzenleme yapıldı.

### Gün 11

- ASP.NET Core MVC kullanılarak `TaskBoard.Web` projesi oluşturuldu.
- `TaskItem` modeli eklenerek görev verileri nesne tabanlı hale getirildi.
- `TasksController` oluşturularak örnek görev listesi Controller üzerinden View'a gönderildi.
- Razor View kullanılarak görevler dinamik olarak tabloda listelendi.
- Bootstrap ile tablo tasarımı iyileştirildi.
- Görev durumu ve öncelik bilgileri Bootstrap badge bileşenleri ile görsel olarak gösterildi.
- `ViewData` kullanılarak sayfa başlığı dinamik hale getirildi.
