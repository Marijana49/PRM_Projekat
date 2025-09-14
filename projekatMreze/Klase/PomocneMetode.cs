using System;

namespace Klase
{
    public class PomocneMetode
    {
        public static string OdrediStatusPacijenta(Pacijent p)
        {
            switch (p.VrstaZahteva.ToLower())
            {
                case "urgentna pomoc":
                    p.StatusPacijenta = "ceka prijem u bolnicu";
                    break;
                case "terapija":
                    p.StatusPacijenta = "ceka terapiju";
                    break;
                case "dijagnostika":
                    p.StatusPacijenta = "ceka pregled";
                    break;
                default:
                    Console.WriteLine("Nepoznat zahtev!");
                    break;
            }
            return p.StatusPacijenta;
        }

        public static void IspisPacijenata(Pacijent p)
        {
            Console.WriteLine($"{p.Ime.PadRight(14)} | {p.Prezime.PadRight(15)} | {p.LBO.ToString().PadLeft(4)} | {p.VrstaZahteva.PadRight(15)} | {p.StatusPacijenta.PadRight(15)} | {DateTime.Now}");
        }

        public static void IspisiZaglavlje()
        {
            Console.WriteLine("\nIme pacijenta | Prezime pacijenta | LBO | Zahtev | Status | Vreme obrade");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public static void IspisiJedinice(Jedinica uj, Jedinica tj, Jedinica dj)
        {
            Console.WriteLine("Tip jedinice | Broj pacijenata | Status");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{uj.TipJedinice.ToString().PadRight(15)} | {uj.BrPacijenata.ToString().PadLeft(7)} | {uj.Status.PadLeft(10)}");
            Console.WriteLine($"{dj.TipJedinice.ToString().PadRight(15)} | {dj.BrPacijenata.ToString().PadLeft(7)} | {dj.Status.PadLeft(10)}");
            Console.WriteLine($"{tj.TipJedinice.ToString().PadRight(15)} | {tj.BrPacijenata.ToString().PadLeft(7)} | {tj.Status.PadLeft(10)}");
        }
    }
}
