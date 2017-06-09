using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Estadodeevaluacion
    {
        public string Estadodeevaluacion_id { get; set; }
        public string Estadodeevaluacion_estado { get; set; }

        public ICollection<Evaluacion> _Evaluacion { get; set; }

        public Estadodeevaluacion()
        {
            _Evaluacion = new Collection<Evaluacion>();
        }
    }
}
