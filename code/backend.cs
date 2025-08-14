using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

// Burası sadece kod'tur başlatıcı 'main.cs' dir

namespace Backend
{
    class Backend_kod
    {
        string oyuncuhamle = "taş", rakiphamle = "kağıt";
        int oyuncuhamlesay, rakip_can = 3, oyuncu_can = 3;
        Random rnd = new Random();

        public void OyunBasladi()
        {
            System.Console.WriteLine("Taş-Kağıt-Makas oyununa hoş geldiniz...");
            rakip_can = 3;
            oyuncu_can = 3;
            OyuncuHamle();
        }

        public void OyuncuHamle()
        {
            System.Console.WriteLine("[1] Taş\n[2] Kağıt\n[3] Makas");
            System.Console.Write("Hamleniz: ");
            oyuncuhamlesay = Convert.ToInt32(System.Console.ReadLine());

            switch (oyuncuhamlesay)
            {
                case 1: oyuncuhamle = "taş"; break;
                case 2: oyuncuhamle = "kağıt"; break;
                case 3: oyuncuhamle = "makas"; break;
                default:
                    System.Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                    OyuncuHamle();
                    return;
            }

            RakipHamle();
        }

        public void Oyun()
        {
            if (oyuncuhamle == rakiphamle)
            {
                System.Console.WriteLine("Bu el berabere!");
            }
            else if (
                (oyuncuhamle == "taş" && rakiphamle == "makas") ||
                (oyuncuhamle == "kağıt" && rakiphamle == "taş") ||
                (oyuncuhamle == "makas" && rakiphamle == "kağıt")
            )
            {
                rakip_can -= 1;
                System.Console.WriteLine("Bu eli sen kazandın!");

            }
            else
            {
                oyuncu_can -= 1;
                System.Console.WriteLine("Bu eli rakip kazandı!");

            }

            if (rakip_can == 0)
            {
                System.Console.WriteLine("Tebrikler, kazandınız!");
                Environment.Exit(0);
            }
            else if (oyuncu_can == 0)
            {
                System.Console.WriteLine("Maalesef kaybettiniz!");
                Environment.Exit(0);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine($"Rakip hamlesi: {rakiphamle} | Rakip can: {rakip_can}");
            System.Console.WriteLine($"Oyuncu hamlesi: {oyuncuhamle} | Oyuncu can: {oyuncu_can}");
            OyuncuHamle();
        }

        public void RakipHamle()
        {
            System.Console.WriteLine("Rakip hamle seçiyor...");
            System.Threading.Thread.Sleep(1000);

            int hamle = rnd.Next(1, 4);
            switch (hamle)
            {
                case 1: rakiphamle = "taş"; break;
                case 2: rakiphamle = "kağıt"; break;
                case 3: rakiphamle = "makas"; break;
            }

            Oyun();
        }

        public void Exit()
        {
            Environment.Exit(0);

        }
    }
}