using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta7odev4
{
    abstract class Hesap
    {
        public int HesapNo { get; set; }
        public decimal Bakiye { get; protected set; }

        public Hesap(int hesapNo, decimal baslangicBakiye)
        {
            HesapNo = hesapNo;
            Bakiye = baslangicBakiye;
        }

        public virtual void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL.");
            }
            else
            {
                Console.WriteLine("Yatırılıcak miktar pozitif olmalıdır.");
            }
        }
        public virtual void ParaCek(decimal miktar)
        {
            if (miktar > 0 && miktar <= Bakiye)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL.");
            }
            else
            {
                Console.WriteLine("Çekim işlemi yapılamadı. Yetersiz bakiye veya geçersiz miktar.");
            }
        }
    }

    class BirikimHesabi : Hesap
    {
        public decimal FaizOrani { get; set; }

        public BirikimHesabi(int hesapNo, decimal baslangicBakiye, decimal faizOrani)
            : base(hesapNo, baslangicBakiye)
        {
            FaizOrani = faizOrani;
        }

        public override void ParaYatir(decimal miktar)
        {
            base.ParaYatir(miktar);
            decimal faiz = miktar * FaizOrani / 100;
            Bakiye += faiz;
            Console.WriteLine($"Faiz eklendi: {faiz} TL. Güncel bakiye: {Bakiye} TL.");
        }
    }

    class VadesizHesap : Hesap
    {
        private const decimal IslemUcreti = 5;
        public VadesizHesap(int hesapNo, decimal baslangicBakiye)
        : base(hesapNo, baslangicBakiye) { }

        public override void ParaCek(decimal miktar)
        {
            if (miktar + IslemUcreti <= Bakiye)
            {
                Bakiye -= miktar + IslemUcreti;
                Console.WriteLine($"{miktar} TL çekildi. İşlem ücreti: {IslemUcreti} TL. Yeni bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Çekim işlemi yapılamadı. Yetersiz bakiye.");
            }
        }
    }

    interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    class Program
    {
        static void Main(string[] args)
        {
            BirikimHesabi birikimHesabi = new BirikimHesabi(12345, 1000, 2);
            birikimHesabi.ParaYatir(500);
            birikimHesabi.ParaCek(200);

            Console.WriteLine("\n--- Birikim Hesabı Özeti ---");
            Console.WriteLine($"Hesap No: {birikimHesabi.HesapNo}, Bakiye: {birikimHesabi.Bakiye} TL");

            VadesizHesap vadesizHesap = new VadesizHesap(67890, 1500);
            vadesizHesap.ParaYatir(300);
            vadesizHesap.ParaCek(400);

            Console.WriteLine("\n--- Vadesiz Hesap Özeti ---");
            Console.WriteLine($"Hesap No: {vadesizHesap.HesapNo}, Bakiye: {vadesizHesap.Bakiye} TL");

            Console.ReadLine();
        }
    }
}
