using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    [Serializable]
    public class Pacijent
    {
        public int LBO {  get; set; }
        public string Ime {  get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string VrstaZahteva { get; set; }
        public string Status { get; set; }

        public Pacijent(int lBO, string ime, string prezime, string adresa, string vrstaZahteva, string status)
        {
            LBO = lBO;
            Ime = ime;
            Prezime = prezime;
            Adresa = adresa;
            VrstaZahteva = vrstaZahteva;
            Status = status;
        }
    }
}
