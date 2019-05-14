# **SINAV PROGRAMI**
### **Projeyi Çalıştırmak İçin Yapılacaklar**
- İndirdiğiniz projenin dosyalarının içindeki 'sp.sln' dosyasını bir üst klasöre taşıyın ve dosyaların olduğu klasörün adını sp olarak değiştirin.
- Projeyi çalıştıracağınız bilgisayarda sp_test isimli bir veritabanı oluşturun, ardından proje dosyalarının içinde bulunan sp.sql veritabanını oluşturduğunuz veritabanına aktarın.
- Projeyi açtıktan sonra 'VeritabaniIslemler.cs' dosyasında 'ConnectionString' methodundan veritabanı bilgilerinizi güncelleyin. 
- Giriş Sayfası Yönetici Girişi Bilgileri; eposta: admin@admin.com şifre: root
- Proje içinde elimden geldiğinde açıklama satırı ve region kullanmaya ve hangi methodların, değişkenlerin ne işe yaradığını anlatmaya çalıştım. Umarım anlarsınız :smile:
------------

### **Sayfa İçeriği**
#### **Giriş Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa1.PNG)

- Sayfa üzerinde şfire göster gizle yapabilirsiniz.
- Güvenlik kodunu yenileyebilirsiniz.
- Herhangi bir textboxda iken ENTER tuşuna basarsanız, giriş butonu çalışacaktır.
- E posta alanında doğru bir e posta kalıbı girilip girilmediği kontrol edilmektedir.
- Bilgilerin doğru girilmesi durumunda anasayfaya yönlendirilirsiniz.

#### **Anasayfa**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa2.PNG)

- Bu sayfa üzerinden diğer bütün sayfalara geçiş yapabilrsiniz.
- Ek olarak sağ alt köşede bulunan butona tıklayarak işlem yapacağınız dönemi seçebilirsiniz.

#### **Dönem Belirleme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa3.PNG)

- Bu sayfada karşımıza 'Güz' ve 'Bahar' olmak üzere iki adet buton çıkar ve seçiminize göre diğer sayfalarda işlem yapacağınız dönem belirlenmiş olur.

#### **Dersler Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa4.PNG)

- Bu sayfada ekleyeceğiniz ders kodunu, ders adını girerek ve dersi ekleyeceğiniz bölümü ve dönemi seçerek ders ekleyebilirsiniz.
- Aşağıdaki datagridde eklenen derslerin listesini görebilir ve düzenle butonuna tıklayarak yukarıdaki formdan düzenleyebilir ya da sil butonuna tıklayarak dersi silebilirsiniz.
> **Uyarı!!!**
Ekleyeceğiniz ders eğer bütün bölümlerin aldığı bir ders ise ORTAK DERS seçeneğini seçiniz. Bu sayede bölümler tablosunda kayıtlı olan bütün bölümler için, seçilmiş olan dönem tablosuna ders kaydedilir.

#### **Bölümler Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa5.PNG)

- Bu sayfada Bölüm Adını,Program Kodunu ve Program Adını girerek bölümü kaydedebilirsiniz.
- Aşağıda bulunan listeden de düzenleye basarak bölüm bilgilerini yukarıdaki formdan güncelleyebilir ya da sil butonuna basarak bölümü silebilirsiniz.

#### **Saatler Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa6.PNG)

- Bu sayfada birinci dropdowndan saati, ikinci dropdowndan ise dakikayı seçerek saat kaydedebilirsiniz.
- Aşağıda bulunan listeden kaydedilmiş saatleri görebilir, düzenle butonuna tıklayarak yukarıdan güncelleyebilir ya da sil butonuna tıklayarak saati silebilirsiniz.

#### **Tarihler Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa7.PNG)

- Bu sayfada birinci datetimepickerdan başlangıç tarihini, ikinci datetimepickerdan bitiş tarihini seçerek iki tarih arasındaki tarihleri veritabanına kaydedebilirsiniz.
- Belirli aralıktaki tarihleri kaydettikten sonra seçilen tarihler arasındaki milli ve dini bayramları silmeniz istenecektir.
- Aşağıda bulunan listeden kaydedilen tarihleri görebilir, düzenleye tıklayarak tarihi güncelleyebilir ya da sile tıklayarak tarihi silebilirsiniz.
- Tümünü Sil butonuna tıklayarak kayıtlı olan bütün tarihleri silebilirsiniz.

#### **Derslikler Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa8.PNG)

-  Bu sayfadan sınavın gerçekleşeceği derslikler ile ilgili işlemler yapabilirsiniz.
- Derslik adını ve kapasitesini girerek dersliği girebilirsiniz.
- Aşağıda bulunan listeden kaydedilmiş listeleri görüntüleyebilir, düzenleye tıklayarak dersliği güncelleyebilir ya da sil butonuna tıklayarak dersliği silebilirsiniz.

#### **Öğretim Elemanı Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa9.PNG)

- Bu sayfadan Öğretim Elemanları ile ilgili işlemleri yapabilirsiniz.
- Öğretim elemanının Ünvanını, Adını ve Soyadını, Bölümünü, E posta adresini, Şifresini ve Yetkisini (sınav programına giriş için) belirleyerek ekleyebilirsiniz.
- Aşağıda bulunan datagridden öğretim elemanlarını görüntüleyebilirsiniz. 
- Düzenle butonuna tıklayarak öğretim elemanının verilerini güncelleyebilir ya da sil butonuna tıklayarak öğretim elemanını silebilirsiniz.

#### **Sınav Programı Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa10.PNG)

- Sayfaya ilk girişte listelemek istediğiniz dönem sorulacaktır.
- Sayfanın sol bölümünde öğretim elemanlarının kendi sınav sayıları ve gözetmenlik sayıları listelenmiştir.
- Sayfanın sağ bölümünde seçilen döneme göre sınavlar listelenmiştir.
- Listede sadece 20 kayıt gösterilmektedir.
- Listenin üstünda bulunan sağ ve sol oklarla sayfalar arası geçiş yapabilir.
- Sayfalama butonlarının yanındaki 'Sırala' alanıyla sayfadaki verileri (Tarihe, Derse, Bölüme göre) sıralayabilirsiniz.
- Sıralama Alanının sağındaki 'Gizlenecek Alanları Seçin' alanıyla liste üzerinde; SıraNo, Program Kodu, Program Adı, Dönem, Ders Kodu, Ders Adı, Yerleşen Öğrenci Sayısı) alanlarını gizleyebilirsiniz.
- Filtreleme kısmında listeyi; Bölüm Adı, Bölüm Kodu, Öğretim Şekli, Öğretim Görevlisi, Sınav Tarihi ve Sınav Saatine göre filtreleyebilirsiniz.
- Filtreleme yaptıktan sonra filtreleri kaldırmak için, en sağda bulunan Filtreleri Temizle butonunu kullanabilirsiniz.
- Liste üzerinden düzenlenebilecek alanlar;
  1.  Öğretim Şekli
  2. Öğrenci Sayısı
  3. Sınav Tarihi
  4. Sınav Saati
  5. Öğretim Elemanı
  6. Derslik 1, Derslik 2, Derslik 3, Derslik 4
  7. Gözetmen 1, Gözetmen 2, Gözetmen3
- Form üzerinde düzenlenebilen alanlara ister mouse ile tıklanarak ister klavye ile alan seçilip ENTER tuşuna basarak düzenleme sayfası açılabilir. 
- Yazılan öğrenci sayısı ve seçilen dersliklerin kapasitesi karşılaştırılıp, yerleşen öğrenci sayısı alanında gösterilmektedir. Eğer öğrenci sayısı derslik kapasitesinden fazla ise Yerleşen Öğrenci Sayısı alanı kırmızı olur. Eğer dersliklerin toplam kapasitesi yeterli ise Yerleşen Öğrenci Sayısı alanı yeşil olur.
- Eğer bir öğretim elemanı kendi sınavına kaydedilir ya da başka bir sınava gözetmen olarak kaydedilir ise sol tarafta bulunan listede o öğretim elemanın Kendi Sınav Sayısı ya da Gözetmenlik Sayısı artmaktadır. Aynı şekilde değşitiril ise azalmaktadır.
- Yazdır butonu şimdilik bütün verileri excel e aktarmaktadır.


#### **Öğretim Şekli Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa11.PNG)
- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın öğretim şekli alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Açılan sayfada kullanıcı dropdownda bulunan; Gündüz Öğretim (G), İkinci Öğretim (İO) den birini seçip kaydedebilir.

#### **Öğrenci Sayısı Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa12.PNG)

- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın öğrenci sayısı alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Kullanıcı sınava girecek öğrenci sayısını girip ENTER tuşuna basarak ya da kaydet butonuna tıklayarak veriyi kaydedebilir.

#### **Tarih Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa13.PNG)

- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın Tarih alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Kullanıcı dropdowndan tarihi seçtikten sonra ENTER tuşuna basar ya da KAYDET butonuna tıklarsa seçilen tarih ve saatte; Bölüm, öğretim elemanı, gözetmenin başka sınavı var mı kontrol edilir ve derslikler kullanılıyor mu kontrol edilir. Eğer ediliyorsa kullanıcıya devam edip etmek istemediği sorulur.

#### **Saat Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa14.PNG)

- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın Saat alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Kullanıcı dropdowndan saati seçtikten sonra ENTER tuşuna basar ya da KAYDET butonuna tıklarsa seçilen tarih ve saatte; Bölüm, öğretim elemanı, gözetmenin başka sınavı var mı kontrol edilir ve derslikler kullanılıyor mu kontrol edilir. Eğer ediliyorsa kullanıcıya devam edip etmek istemediği sorulur.

#### **Öğretim Elemanı Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa15.PNG)

- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın Ünvan alanına ya da Ad Soyad alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Seçilen tarih ve saatte müsait olan öğretim elemanları yeşil renkte görünürken. Müsait olmayan öğretim elemanları kırmızı renkte görünür.
- Eğer kullanıcı kırmızı renkte olan bir öğretim elemanı seçerse kullanıcı uyarılır. Devam etmek isterse kaydedilir.

#### **Derslik Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa16.PNG)

- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın Derslik1, Derslik2, Derslik3 ve Derslik4 alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Seçilen tarih ve saatte kullanılan derslikler kırmızı renkte görünür iken, kullanılmayan yeşil renkte görünür.
- Kırmızı renkte olan bir derslik seçilirse kullanıcı uyarılır. Devam etmek isterse kaydedilir.
- Kaydedilen dersliğin kapasitesi ve aynı sınavda kullanılan diğer dersliklerin ortak kapasitesi ile öğrenci sayısına bakılarak, eğer öğrenci sayısı kapasiteden büyük ise Yerleşen Öğrenci Sayısı alanı kırmızı renkte, değil ise yeşil renkte olur.

#### **Gözetmen Değiştirme Sayfası**
![](https://github.com/omerdurmaz2/SP/blob/master/img/Sayfa17.PNG)

- Sınav Programı sayfasında eğer kullanıcı düzenlemek istediği sınavın Gözetmen1, Gözetmen2 ya da Gözetmen3 alanına tıklarsa bu sayfa çıkar.
- Sayfa üzerinde ENTER  tuşuna basıldığında veriyi veritabanına kaydeder ve sayfa kapatılır.
- Sayfa üzerinde ESC tuşuna basıldığında veri kaydedilmeden sayfa kapatılır.
- Seçilen tarih ve saatte müsait olan öğretim elemanları yeşil renkte görünürken. Müsait olmayan öğretim elemanları kırmızı renkte görünür.
- Eğer kullanıcı kırmızı renkte olan bir öğretim elemanı seçerse kullanıcı uyarılır. Devam etmek isterse kaydedilir.
- Bir öğretim elemanını sınava hem gözetmen hem de öğretim elemanı olarak seçebiliriz.
------------

