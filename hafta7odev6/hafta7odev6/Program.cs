using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta7odev6
{
    interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void BildirimGonder(string mesaj);
    }

    interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    class Yayinci : IYayinci
    {
        private List<IAbone> aboneler;

        public Yayinci()
        {
            aboneler = new List<IAbone>();
        }
        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
            Console.WriteLine("Yeni bir abone eklendi.");
        }
        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
            Console.WriteLine("Bir abone çıkarıldı.");
        }

        public void BildirimGonder(string mesaj)
        {
            Console.WriteLine($"\n[Yayıncı]: {mesaj}");
            foreach(var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    class Abone : IAbone
    {
        private string Ad { get; set; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"[{Ad}]: Bildirim alındı -> {mesaj}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Yayinci yayinci = new Yayinci();

            Abone abone1 = new Abone("Sıla");
            Abone abone2 = new Abone("Kayra");
            Abone abone3 = new Abone("Fatma");

            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            yayinci.BildirimGonder("Yeni bir makale yayınlandı!");

            yayinci.AboneCikar(abone1);

            yayinci.BildirimGonder("Yeni bir video yüklendi!");

            Console.ReadLine();
        }
    }
}
