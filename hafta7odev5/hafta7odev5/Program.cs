using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta7odev5
{
    abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public abstract decimal HesaplaOdeme();

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad}, Fiyat: {Fiyat} TL");
        }
    }

    class Kitap : Urun
    {
        public string Yazar { get; set; }
        private const decimal VergiOrani = 0.10m;

        public Kitap(string ad, decimal fiyat, string yazar)
            : base(ad, fiyat)
        {
            Yazar = yazar;
        }

        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * VergiOrani);
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazar: {Yazar}, Ödenecek Tutar: {HesaplaOdeme()} TL");
        }
    }

    class Elektronik : Urun
    {
        public string Marka { get; set; }
        private const decimal VergiOrani = 0.25m;

        public Elektronik(string ad, decimal fiyat, string marka)
            : base(ad, fiyat)
        {
            Marka = marka;
        }
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * VergiOrani);
        }
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Marka: {Marka}, Ödenecek Tutar: {HesaplaOdeme()} TL");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Urun> urunler = new List<Urun>();

            urunler.Add(new Kitap("C# Programlama", 50, "Ahmet Kılıç"));
            urunler.Add(new Kitap("Veri Yapıları", 70, "Oğuzhan Kayalar"));
            urunler.Add(new Elektronik("Telefon", 10000, "Samsung"));
            urunler.Add(new Elektronik("Laptop", 15000, "Apple"));

            foreach(var urun in urunler)
            {
                urun.BilgiYazdir();
                Console.WriteLine("--------------------------");
            }

            Console.ReadLine();
        }
    }
}
