using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Tipodeevaluacion
    {
        public string Tipodeevaluacion_id { get; set; }
        public string Tipodeevaluacion_tipo { get; set; }

        public ICollection<Evaluacion> _Evaluacion { get; set; }

        public Tipodeevaluacion()
        {
            _Evaluacion = new Collection<Evaluacion>();
        }
    }
}
