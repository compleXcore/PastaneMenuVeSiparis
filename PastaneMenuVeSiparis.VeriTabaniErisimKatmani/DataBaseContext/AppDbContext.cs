using PastaneMenuVeSiparis.VarlikKatmani;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.VeriTabaniErisimKatmani.DataBaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        public AppDbContext() : base("projeWpf24")
        {
            Database.SetInitializer<AppDbContext>(new MyDBStart());
        }
    }

    public class MyDBStart : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.Kategoriler.Add(new Kategori { Ad = "Börek" });
            context.Kategoriler.Add(new Kategori { Ad = "Kek" });
            context.Kategoriler.Add(new Kategori { Ad = "Poğaça" });
            context.Kategoriler.Add(new Kategori { Ad = "Tatlı" });
            context.Kategoriler.Add(new Kategori { Ad = "Tuzlu" });
            context.SaveChanges();

            context.Urunler.Add(new Urun
            {
                Ad = "Gül Böreği",
                Fiyat = 100,
                KategoriId = 1
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Ispanalı Börek",
                Fiyat = 95,
                KategoriId = 1
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Kıymalı Börek",
                Fiyat = 150,
                KategoriId = 1
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Su Böregi",
                Fiyat = 75,
                KategoriId = 1
            });

            context.Urunler.Add(new Urun
            {
                Ad = "Çikolatalı Kek",
                Fiyat = 120,
                KategoriId = 2
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Islak Kek",
                Fiyat = 160,
                KategoriId = 2
            });
            context.Urunler.Add(new Urun
            {
                Ad = "limonlu Kek",
                Fiyat = 110,
                KategoriId = 2
            });

            context.Urunler.Add(new Urun
            {
                Ad = "Sade Poğaça",
                Fiyat = 25,
                KategoriId = 3
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Susamlı Poğaça",
                Fiyat = 30,
                KategoriId = 3
            });

            context.Urunler.Add(new Urun
            {
                Ad = "Dolma Baklava",
                Fiyat = 50,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Ekler",
                Fiyat = 55,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Kuru Baklava",
                Fiyat = 85,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Şekerpare",
                Fiyat = 100,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Soğuk Baklava",
                Fiyat = 110,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Soğuk Baklava Beyaz",
                Fiyat = 1650,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Soğuk Baklava Çikolata",
                Fiyat = 200,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Soğuk Baklava Fıstık",
                Fiyat = 120,
                KategoriId = 4
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Tulumba",
                Fiyat = 140,
                KategoriId = 4
            });

            context.Urunler.Add(new Urun
            {
                Ad = "Lokmalik Tuzlu",
                Fiyat = 20,
                KategoriId = 5
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Lokmalik Tuzlu 2",
                Fiyat = 30,
                KategoriId = 5
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Sirkeli Tuzlu",
                Fiyat = 25,
                KategoriId = 5
            });
            context.Urunler.Add(new Urun
            {
                Ad = "Tahinli Tuzlu",
                Fiyat = 20,
                KategoriId = 5
            });
            context.SaveChanges();

            context.Kullanicilar.Add(new Kullanici
            {
                KullaniciAdi = "tilda",
                KullaniciSifre = "hamza4141"
            });
            context.SaveChanges();
        }
    }
}
