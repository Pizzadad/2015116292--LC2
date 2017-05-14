using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT
{
    public class Evaluacion
    {
        public string Evaluacion_id { get; set; }
        public string Evaluacion_caso { get; set; }

        public string Cliente_id { get; set; }
        public Cliente Cliente { get; set; }

        public string Plan_id { get; set; }
        public Plan Plan { get; set; }

        public string lineatelefonica_id { get; set; }
        public lineatelefonica lineatelefonica { get; set; }

        public string Centrodeatencion_id { get; set; }
        public Centrodeatencion Centrodeatencion { get; set; }

        public string Trabajador_id { get; set; }
        public Trabajador Trabajador { get; set; }

        public string Equipocelular_id { get; set; }
        public List<Equipocelular> _Equipocelular { get; set; }

        public string Estadodeevaluacion_id { get; set; }
        public List<Estadodeevaluacion> _Estadodeevaluacion { get; set; }

        public string Tipodeevaluacion_id { get; set; }
        public List<Tipodeevaluacion> _Tipodeevaluacion { get; set; }

        public Evaluacion()
        {
            _Equipocelular = new List<Equipocelular>();
            _Estadodeevaluacion = new List<Estadodeevaluacion>();
            _Tipodeevaluacion = new List<Tipodeevaluacion>();
        }

    }
}
