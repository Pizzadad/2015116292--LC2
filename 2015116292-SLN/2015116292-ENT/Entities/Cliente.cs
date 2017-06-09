using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Cliente
    {
        public string Cliente_id { get; set; }
        public string Cliente_nombre { get; set; }

        public ICollection<Evaluacion> _Evaluacion { get; set; }

        public Cliente()
        {
            _Evaluacion = new Collection<Evaluacion>();
        }
    }
}
