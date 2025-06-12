using Otob_sBilet.R.S;
using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Otobüs Sefer Rezervasyon Sistemi");

        // Sefer Oluşturma
        Console.Write("Kalkış şehri: ");
        string nereden = Console.ReadLine();
        Console.Write("Varış şehri: ");
        string nereye = Console.ReadLine();
        Console.Write("Sefer tipi (1-Şehirlerarası, 2-Şehiriçi): ");
        string tip = Console.ReadLine();

        Sefer sefer;
        if (tip == "2")
            sefer = new SehiriciSefer(nereden, nereye);
        else
            sefer = new SehirlerarasiSefer(nereden, nereye);

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{sefer.Nereden} ---> {sefer.Nereye} Seferi");
            sefer.Otobus.KoltuklariGoster();

            // Koltuk Seçimi
            Console.Write("\nRezervasyon yapmak istediğiniz koltuk numarasını girin (0 = çıkış): ");
            if (int.TryParse(Console.ReadLine(), out int koltukNo))
            {
                if (koltukNo == 0)
                    break;

                if (sefer.RezervasyonYap(koltukNo))
                {
                    // Bilet Yazdırma
                    sefer.BiletYazdir(koltukNo);
                }
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}