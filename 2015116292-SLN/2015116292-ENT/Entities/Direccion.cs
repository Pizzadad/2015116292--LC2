using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Direccion
    {
        public string Direccion_id { get; set; }
        public string Direccion_lugar { get; set; }

        public Ubigeo _Ubigeo { get; set; }
        public string Ubigeo_id { get; set; }

        public ICollection<Centrodeatencion> _Centrodeatencion { get; private set; }

        public Direccion()
        {
            _Centrodeatencion = new List<Centrodeatencion>();
        }
      
    }
}
