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

        public TipoPlan _TipoPlan { get; set; }
        public string TipoPlan_id { get; set; }

        public ICollection<Evaluacion> _Evaluacion { get; private set; }

        public Plan()
        {
            _Evaluacion = new List<Evaluacion>();
        }
     }
}
