using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BMB_webshopProjekt.Model
{
    public class Termek
    {
        public int id { get; set; }
        public string nev { get; set; }
        public string leiras { get; set; }
        public int ar { get; set; }
        public int mennyiseg { get; set; }
        public int kategoria_id { get; set; }

        public Termek() { }

        public Termek(int id, string nev, string leiras, int ar, int mennyiseg, int kategoria_id)
        {
            this.id = id;
            this.nev = nev;
            this.leiras = leiras;
            this.ar = ar;
            this.mennyiseg = mennyiseg;
            this.kategoria_id = kategoria_id;
        }

        public class Termekek
        {
            public Termek[] data { get; set; }
        }
    }
}
