using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Provincia
    {
        public string Provincia_id { get; set; }
        public string Provincia_nombre { get; set; }

        public Distrito _Distrito { get; set; }
    public string Distrito_id { get; set; }

        public ICollection<Departamento> _Departamento { get; private set; }

        public Provincia()
        {
            _Departamento = new List<Departamento>();
        }
        
    }
}
