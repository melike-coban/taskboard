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
