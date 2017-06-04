using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT
{
    public class Departamento
    {
        public string Departamento_id { get; set; }
        public string Departamento_nombre { get; set; }

        public List<Provincia> _Provincia { get; set; }

        public Departamento()
        {
            _Provincia = new List<Provincia>();
        }
     }
}
