using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta7odev3
{

    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public decimal Bakiye { get; set; }
        public string HesapSahibi { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        public virtual void ParaCek(decimal miktar)
        {
           if(miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz Bakiye.");
            }
            else
            {
                Bakiye -=miktar;
                Console.WriteLine($"{miktar} TL çekildi. Kalan bakiye: {Bakiye} TL");
            }
        }

        public virtual void BilgiYazdir() 
        {
            Console.WriteLine($"Hesap Numarası: {HesapNumarasi}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL");
        }
    }

    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; } // Gün olarak vade süresi
        public double FaizOrani { get; set; } // Yüzde olarak faiz oranı

        public override void ParaCek(decimal miktar)
        {
            if (VadeSuresi > 0)
            {
                Console.WriteLine("Vade dolmadan para çekemezsiniz.");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} gün, Faiz Oranı: {FaizOrani}%");
        }

    }

    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (miktar > (Bakiye + EkHesapLimiti))
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti.");
            }
            else if (miktar > Bakiye)
            {
                decimal ekHesapKullanilan = miktar - Bakiye;
                Bakiye = 0;
                Console.WriteLine($"{ekHesapKullanilan} TL ek hesaptan kullanıldı. Ek hesap limiti kalan: {EkHesapLimiti - ekHesapKullanilan} TL");
                EkHesapLimiti -= ekHesapKullanilan;
            }
            else
            {
                base.ParaCek(miktar);
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçiniz:");
            Console.WriteLine("1 - Vadesiz Hesap");
            Console.WriteLine("2 - Vadeli Hesap");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            Hesap hesap;

            if (secim == "1")
            {
                hesap = new VadesizHesap();
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                ((VadesizHesap)hesap).EkHesapLimiti = decimal.Parse(Console.ReadLine());
            }
            else if (secim == "2")
            {
                hesap = new VadeliHesap();
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Vade Süresi (gün): ");
                ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı (%): ");
                ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim yaptınız.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nBir işlem seçiniz:");
                Console.WriteLine("1 - Para Yatır");
                Console.WriteLine("2 - Para Çek");
                Console.WriteLine("3 - Hesap Bilgilerini Görüntüle");
                Console.WriteLine("4 - Çıkış");
                Console.Write("Seçiminiz: ");
                string islem = Console.ReadLine();

                if (islem == "1")
                {
                    Console.Write("Yatırılacak Tutar: ");
                    decimal miktar = decimal.Parse(Console.ReadLine());
                    hesap.ParaYatir(miktar);
                }
                else if (islem == "2")
                {
                    Console.Write("Çekilecek Tutar: ");
                    decimal miktar = decimal.Parse(Console.ReadLine());
                    hesap.ParaCek(miktar);
                }
                else if (islem == "3")
                {
                    hesap.BilgiYazdir();
                }
                else if (islem == "4")
                {
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem.");
                }
            }

            // Konsolun kapanmasını önlemek için
            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }   
}
