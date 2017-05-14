using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT
{
    public class Provincia
    {
        public string Provincia_id { get; set; }
        public string Provincia_nombre { get; set; }

        public string Departamento_id { get; set; }

        public Departamento Departamento { get; set; }

        public List<Distrito> _Distrito { get; set; }
        public Provincia()
        {
            _Distrito = new List<Distrito>();
        }
        
    }
}
