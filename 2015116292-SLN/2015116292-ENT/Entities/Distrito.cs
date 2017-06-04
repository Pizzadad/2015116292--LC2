using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Distrito
    {
        public string Distrito_id { get; set; }
        public string Distrito_nombre { get; set; }

        public string Provincia_id { get; set; }

        public Provincia Provincia { get; set; }
    }
}
