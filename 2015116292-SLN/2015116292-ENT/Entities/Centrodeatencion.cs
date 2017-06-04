using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Centrodeatencion
    {
        public string Centrodeatencion_id { get; set; }
        public string Centrodeatencion_nombre { get; set; }
        public List<Direccion> _Direccion { get; set; }

        public string Evaluacion_id { get; set; }
        public Evaluacion Evaluacion { get; set; }

        public Centrodeatencion()
        {
            _Direccion = new List<Direccion>();
        }
    }
}
