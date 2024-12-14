using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta7odev2
{

    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan bir ses çıkarıyor.");
        }
    }

    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void SesCikar()
        {
            
            Console.WriteLine("Memeli bir ses çıkarıyor: Mırr Mırr!");
        }
    }

    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void SesCikar()
        {
            
            Console.WriteLine("Kuş bir ses çıkarıyor: Cik Cik!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçiniz:");
            Console.WriteLine("1 - Memeli");
            Console.WriteLine("2 - Kuş");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            Hayvan hayvan;

            if (secim == "1")
            {
                hayvan = new Memeli();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).TuyRengi = Console.ReadLine();
            }
            else if (secim == "2")
            {
                hayvan = new Kus();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği (cm): ");
                ((Kus)hayvan).KanatGenisligi = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim yaptınız.");
                return;
            }
            Console.WriteLine("\nHayvan Bilgileri:");
            Console.WriteLine($"Ad: {hayvan.Ad}, Tür: {hayvan.Tur}, Yaş: {hayvan.Yas}");

            if (hayvan is Memeli memeli)
            {
                Console.WriteLine($"Tüy Rengi: {memeli.TuyRengi}");
            }
            else if (hayvan is Kus kus)
            {
                Console.WriteLine($"Kanat Genişliği: {kus.KanatGenisligi} cm");
            }

            Console.WriteLine("\nHayvanın Çıkardığı Ses:");
            hayvan.SesCikar();

            // Konsolun kapanmasını önlemek için
            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
