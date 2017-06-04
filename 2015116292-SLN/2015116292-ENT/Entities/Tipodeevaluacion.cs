using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Tipodeevaluacion
    {
        public string Tipodeevaluacion_id { get; set; }
        public string Tipodeevaluacion_tipo { get; set; }

        public string Evaluacion_id { get; set; }
        public Evaluacion Evaluacion { get; set; }
    }
}
