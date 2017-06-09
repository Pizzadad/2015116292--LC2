using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Trabajador
    {
        public string Trabajador_id { get; set; }
        public string Trabajador_nombre { get; set; }
        

        public ICollection<Evaluacion> _Evaluacion { get; set; }

        public Trabajador()
        {
            _Evaluacion = new Collection<Evaluacion>();
        }
    }
}
