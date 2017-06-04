using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Ubigeo
    {
        public  string Ubigeo_id { get; set; }
        public string Ubigeo_numero { get; set; }
        public Departamento Departamento { get; set; }
        public Provincia Provincia { get; set; }
        public Distrito Distrito { get; set; }

        public string Direccion_id { get; set; }
        public Direccion Direccion { get; set; }
    }
}
