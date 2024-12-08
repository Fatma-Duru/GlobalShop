using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GlobalShop.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var Kategoriler = new List<Category>()
            {
                 new Category(){ Name= "Saat", Description= "Saat Ürünleri"},
                 new Category(){ Name= "Bilgisayar", Description= "Bilgisayar Ürünleri"},
                 new Category(){ Name= "Elektronik", Description= "Elektronik Ürünleri"},
                 new Category(){ Name= "Telefon", Description= "Telefon Ürünleri"},
                 new Category(){ Name= "Beyaz Eşya", Description= "Beyaz Eşya Ürünleri"},

            };

            foreach (var kategori in Kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>
            {
                // Saat Kategorisi Ürünleri
                new Product { Name = "Kol Saati", Description = "Şık ve zarif tasarımıyla hem günlük kullanımda hem de özel günlerde stilinizi tamamlayacak modern bir kol saati. Uzun ömürlü pil ve su geçirmez özellikleriyle öne çıkıyor.", Price = 500, Stock = 10, IsApproved = true, CategoryId = 1, IsHome=true, Image="KolSaati.jpg"},
                new Product { Name = "Duvar Saati", Description = "Minimalist çizgileriyle her türlü dekorasyona uyum sağlayan, kaliteli malzemelerden üretilmiş, sessiz çalışma mekanizmasına sahip modern bir duvar saati.", Price = 250, Stock = 20, IsApproved = true, CategoryId = 1, IsHome=true, Image="DuvarSaati.jpg"},
                new Product { Name = "Cep Saati", Description = "Klasik ve nostaljik bir tarzı benimseyenler için tasarlanmış, zarif işlemeleri ve dayanıklı yapısıyla göz dolduran özel üretim cep saati.", Price = 1500, Stock = 5, IsApproved = true, CategoryId = 1, IsHome=true, Image="CepSaati.jpg"},
                new Product { Name = "Akıllı Saat", Description = "Gelişmiş teknolojisi sayesinde sağlık takibi, bildirim yönetimi ve daha fazlasını sunan, yeni nesil akıllı saat modeli. Uzun batarya ömrü ve estetik tasarımıyla dikkat çekiyor.", Price = 2000, Stock = 8, IsApproved = true, CategoryId = 1, IsHome=true, Image="AkilliSaat.jpg"},
                new Product { Name = "Masa Saati", Description = "Doğal ahşap malzemeden üretilmiş, hem dekoratif hem de işlevsel yapısıyla ofis ve ev kullanımı için ideal bir masa saati.", Price = 300, Stock = 15, IsApproved = true, CategoryId = 1, Image="MasaSaati.jpg"},

                // Bilgisayar Kategorisi Ürünleri
                new Product { Name = "Gaming Laptop", Description = "Oyun tutkunları için özel olarak tasarlanmış, yüksek performanslı ekran kartı ve işlemcisiyle kesintisiz oyun deneyimi sunan üst düzey bir dizüstü bilgisayar.", Price = 15000, Stock = 5, IsApproved = true, CategoryId = 2, IsHome = true, Image="GamingLaptop.jpg"},
                new Product { Name = "İş Bilgisayarı", Description = "Günlük ofis işleri, toplantılar ve profesyonel kullanım için optimize edilmiş, hafif ve taşınabilir yapısıyla iş dünyasının vazgeçilmezi.", Price = 7000, Stock = 10, IsApproved = true, CategoryId = 2, Image="IsBilgisayari.jpg"},
                new Product { Name = "Tablet", Description = "Yüksek çözünürlüklü ekranı ve hafif tasarımıyla hem iş hem eğlence için mükemmel bir seçim olan taşınabilir tablet bilgisayar.", Price = 4000, Stock = 15, IsApproved = true, CategoryId = 2, IsHome = true, Image="Tablet.jpg"},
                new Product { Name = "Monitör", Description = "Geniş ekran ve 4K çözünürlüğüyle grafik tasarımcılar ve oyuncular için harika bir deneyim sunan yüksek kaliteli monitör.", Price = 3000, Stock = 12, IsApproved = true, CategoryId = 2, IsHome = true, Image="Monitor.jpg"},
                new Product { Name = "Klavye ve Mouse", Description = "Oyun deneyimini en üst seviyeye çıkaran ergonomik tasarımlı klavye ve mouse seti. RGB aydınlatmalı klavyesi ile geceleri de etkileyici bir kullanım sunar.", Price = 1000, Stock = 20, IsApproved = true, CategoryId = 2, Image="KlavyeVeMouse.jpg"},

                // Elektronik Kategorisi Ürünleri
                new Product { Name = "Televizyon", Description = "Geniş ekranı ve üstün 4K UHD görüntü kalitesiyle evde sinema keyfi yaşatmak için tasarlanmış bir televizyon. Smart TV özellikleriyle internet bağlantısı imkanı sunar.", Price = 8000, Stock = 3, IsApproved = true, CategoryId = 3, IsHome = true, Image="Televizyon.jpg"},
                new Product { Name = "Ses Sistemi", Description = "Etkileyici bir ses deneyimi sunan, 5.1 surround özellikli kaliteli bir ses sistemi. Hem müzik hem film keyfi için ideal.", Price = 2000, Stock = 7, IsApproved = true, CategoryId = 3, Image="SesSistemi.jpg"},
                new Product { Name = "Kulaklık", Description = "Taşınabilir ve şık tasarımıyla kablosuz bağlantı imkanı sunan bluetooth kulaklık. Gürültü engelleme özelliğiyle berrak bir ses kalitesi sağlar.", Price = 750, Stock = 25, IsApproved = true, CategoryId = 3, IsHome = true, Image="Kulaklik.jpg"},
                new Product { Name = "Projeksiyon", Description = "Yüksek çözünürlüklü görüntü kalitesiyle iş toplantılarından film gösterimlerine kadar birçok alanda kullanılabilen taşınabilir projeksiyon cihazı.", Price = 4500, Stock = 4, IsApproved = true, CategoryId = 3, Image="Projeksiyon.jpg"},
                new Product { Name = "Akıllı Ev Sistemi", Description = "Evdeki cihazları uzaktan kontrol etmenizi sağlayan, konfor ve güvenliği artıran bir akıllı ev sistemi.", Price = 6000, Stock = 6, IsApproved = true, CategoryId = 3, Image="AkilliEvSistemi.jpg"},

                // Telefon Kategorisi Ürünleri
                new Product { Name = "Akıllı Telefon", Description = "Gelişmiş özellikleri ve şık tasarımıyla dikkat çeken, yüksek performanslı ve uzun pil ömürlü bir akıllı telefon modeli.", Price = 10000, Stock = 8, IsApproved = true, CategoryId = 4, IsHome = true, Image="AkilliTelefon.jpg"},
                new Product { Name = "Kablosuz Şarj Cihazı", Description = "Hızlı şarj desteği ve kompakt tasarımıyla kullanım kolaylığı sağlayan bir kablosuz şarj cihazı.", Price = 500, Stock = 18, IsApproved = true, CategoryId = 4, IsHome=true, Image="KablosuzSarz.jpg"},
                new Product { Name = "Telefon Kılıfı", Description = "Çeşitli renk seçenekleriyle sunulan, dayanıklı ve esnek yapısıyla telefonunuzu darbelere karşı koruyan silikon kılıf.", Price = 150, Stock = 50, IsApproved = true, CategoryId = 4, Image="TelefonKilifi.jpg"},
                new Product { Name = "Ekran Koruyucu", Description = "Telefon ekranını çizilmelere ve darbelere karşı koruyan, yüksek geçirgenliğe sahip kırılmaz cam ekran koruyucu.", Price = 100, Stock = 30, IsApproved = true, CategoryId = 4, Image="EkranKoruyucu.jpg"},
                new Product { Name = "Bluetooth Hoparlör", Description = "Kablosuz bağlantı imkanı ve taşınabilir tasarımıyla her yerde müzik keyfi sunan kompakt bir bluetooth hoparlör.", Price = 800, Stock = 15, IsApproved = true, CategoryId = 4, Image="BluetoothHoparlor.jpg"}
            };



            foreach (var urun in urunler)
            {
                context.Products.Add(urun);

            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
