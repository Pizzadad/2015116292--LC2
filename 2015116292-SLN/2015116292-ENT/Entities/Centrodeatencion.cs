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

        public Direccion _Direccion { get; set; }
        public string Direccion_id { get; set; }

        public ICollection<Evaluacion> _Evaluacion { get; private set; }


        public Centrodeatencion()
        {
            _Evaluacion = new List<Evaluacion>();
        }
    }
}
