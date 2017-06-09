using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Departamento
    {
        public string Departamento_id { get; set; }
        public string Departamento_nombre { get; set; }

        public Provincia _Provincia { get; set; }
        public string Provincia_id { get; set; }

        public ICollection<Ubigeo> _Ubigeo { get; private set; }

        public Departamento()
        {
            _Ubigeo = new List<Ubigeo>();
        }
     }
}
