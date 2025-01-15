using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BMB_webshopProjekt.Model
{
    public class Kep
    {
        public int id { get; set; }
        public string url { get; set; }
        public int termek_id { get; set; }

        public Kep() { }

        public Kep(int id, string url, int termek_id)
        {
            this.id = id;
            this.url = url;
            this.termek_id = termek_id;
        }

        public class Kepek
        {
            public Kep[] data { get; set; }
        }
    }
}
