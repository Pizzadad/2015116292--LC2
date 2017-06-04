using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Plan
    {
        public string Plan_id { get; set; }
        public string Plan_descripcion { get; set; }
        public List<TipoPlan> _TipoPlan { get; set; }

        public string Evaluacion_id { get; set; }
        public Evaluacion Evaluacion { get; set; }

        public Plan()
        {
            _TipoPlan = new List<TipoPlan>();
        }
     }
}
