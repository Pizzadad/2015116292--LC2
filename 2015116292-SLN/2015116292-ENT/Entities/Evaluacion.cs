using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Evaluacion
    {
        public string Evaluacion_id { get; set; }
        public string Evaluacion_caso { get; set; }

        public string Cliente_id { get; set; }
        public Cliente _Cliente { get; set; }

        public string Plan_id { get; set; }
        public Plan _Plan { get; set; }

        public string lineatelefonica_id { get; set; }
        public lineatelefonica _lineatelefonica { get; set; }

        public string Centrodeatencion_id { get; set; }
        public Centrodeatencion _Centrodeatencion { get; set; }

        public string Trabajador_id { get; set; }
        public Trabajador _Trabajador { get; set; }

        public string Equipocelular_id { get; set; }
        public Equipocelular _Equipocelular { get; set; }

        public string Estadodeevaluacion_id { get; set; }
        public Estadodeevaluacion _Estadodeevaluacion { get; set; }

        public string Tipodeevaluacion_id { get; set; }
        public Tipodeevaluacion _Tipodeevaluacion { get; set; }

     
    }
}
