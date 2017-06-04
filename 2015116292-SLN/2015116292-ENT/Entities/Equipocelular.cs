using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Equipocelular
    {
        public string Equipocelular_id { get; set; }
        public string Equipocelular_modelo { get; set; }

        public string AdministradorEquipo_id { get; set; }
        public AdministradorEquipo AdministradorEquipo { get; set; }

        public string Evaluacion_id { get; set; }
        public Evaluacion Evaluacion { get; set; }

    }
}
