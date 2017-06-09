using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Ubigeo
    {
        public  string Ubigeo_id { get; set; }
        public string Ubigeo_numero { get; set; }

        public Departamento _Departamento { get; set; }
        public Provincia _Provincia { get; set; }
        public Distrito _Distrito { get; set; }

        public string Departamento_id { get; set; }
        public string Provincia_id { get; set; }
        public string Distrito_id { get; set; }

        public ICollection<Direccion> _Direccion { get; private set; }

        public Ubigeo()
        {
            _Direccion = new Collection<Direccion>();
        }

    }
}
