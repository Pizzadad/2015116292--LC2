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

        public string Centrodeatencion_id { get; set; }
        public Centrodeatencion Centrodeatencion { get; set; }

        public List<Ubigeo> _Ubigeo { get; set; }
        public Direccion()
        {
            _Ubigeo = new List<Ubigeo>();
        }
      
    }
}
