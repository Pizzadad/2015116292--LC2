using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Trabajador
    {
        public string Trabajador_id { get; set; }
        public string Trabajador_nombre { get; set; }
        public string Trabajador_tipotrab { get; set; }

        public string Evaluacion_id { get; set; }
        public Evaluacion Evaluacion { get; set; }
    }
}
