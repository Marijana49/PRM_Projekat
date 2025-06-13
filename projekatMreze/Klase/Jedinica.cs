using System;
using Enumeracije;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    [Serializable]
    public class Jedinica
    {
        public TipJedinice TipJedinice { get; set; }
        public int IDjedinice { get; set; }
        public string Status { get; set; }

        public Jedinica(TipJedinice tipJedinice, int iDjedinice, string status)
        {
            TipJedinice = tipJedinice;
            IDjedinice = iDjedinice;
            Status = status;
        }
    }
}
