using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BMB_webshopProjekt.Model
{
    public class Kategoria
    {
        public int id { get; set; }
        public string megnevezes { get; set; }
        public int? szulokategoria_id { get; set; }

        public Kategoria() { }

        public Kategoria(int id, string megnevezes, int? szulokategoria_id)
        {
            this.id = id;
            this.megnevezes = megnevezes;
            this.szulokategoria_id = szulokategoria_id;
        }

        public class Kategoriak
        {
            public Kategoria[] data { get; set; }
        }
    }
}
