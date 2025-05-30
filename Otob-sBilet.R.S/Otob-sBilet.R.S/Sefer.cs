﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otob_sBilet.R.S
{
    public abstract class Sefer : IRezervasyon
    {
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public Otobus Otobus { get; set; }

        public Sefer(string nereden, string nereye)
        {
            Nereden = nereden;
            Nereye = nereye;
            Otobus = new Otobus(30); // 2x2
        }

        public virtual void RezervasyonYap(int koltukNumarasi)
        {
            if (koltukNumarasi < 1 || koltukNumarasi > Otobus.Koltuklar.Length)
            {
                Console.WriteLine("Hatalı koltuk numarası!");
                return;
            }

            var koltuk = Otobus.Koltuklar[koltukNumarasi - 1];
            if (koltuk.DoluMu)
            {
                Console.WriteLine("Bu koltuk zaten dolu!");
            }
            else
            {
                koltuk.DoluMu = true;
                Console.WriteLine($"Koltuk {koltukNumarasi} başarıyla rezerve edildi.");
            }
        }
    }

}
