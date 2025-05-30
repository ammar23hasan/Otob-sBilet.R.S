﻿using Otob_sBilet.R.S;
using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Otobüs Sefer Rezervasyon Sistemi");

        Sefer sefer = new SehirlerarasiSefer("Gaziantep", "Halep");

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{sefer.Nereden} ---> {sefer.Nereye} Seferi");
            sefer.Otobus.KoltuklariGoster();

            Console.Write("\nRezervasyon yapmak istediğiniz koltuk numarasını girin (0 = çıkış): ");
            if (int.TryParse(Console.ReadLine(), out int koltukNo))
            {
                if (koltukNo == 0)
                    break;

                sefer.RezervasyonYap(koltukNo);
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}