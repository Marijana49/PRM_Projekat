using System;

namespace Klase
{
    [Serializable]
    public class Pacijent
    {
        public int LBO { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string VrstaZahteva { get; set; }
        public string StatusPacijenta { get; set; }

        public Pacijent(int lBO, string ime, string prezime, string adresa, string vrstaZahteva, string status)
        {
            LBO = lBO;
            Ime = ime;
            Prezime = prezime;
            Adresa = adresa;
            VrstaZahteva = vrstaZahteva;
            StatusPacijenta = status;
        }
    }
}
