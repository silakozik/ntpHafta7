using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta7odev1
{
    // Temel Calisan sınıfı
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}");
        }
    }

    //Yazilimci Sinifi
    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazılım Dili: {YazilimDili}");
        }
    }

    //Muhasebeci Sinifi
    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçiniz: ");
            Console.WriteLine("1 - Yazılımcı");
            Console.WriteLine("2 - Muhasebeci");
            Console.WriteLine("Seçiminiz:");
            string secim = Console.ReadLine();

            Calisan calisan;

            if (secim == "1")
            {
                calisan = new Yazilimci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = decimal.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();
                Console.Write("Yazılım Dili: ");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine();
            }

            else if(secim == "2")
            {
                calisan = new Muhasebeci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = decimal.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();
                Console.Write("Muhasebe Yazılımı: ");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim yaptınız.");
                return;
            }

            Console.WriteLine("\nÇalışan Bilgileri:");
            calisan.BilgiYazdir();

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
