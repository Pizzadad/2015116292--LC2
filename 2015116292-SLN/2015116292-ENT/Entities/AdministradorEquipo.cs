using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class AdministradorEquipo
    {
        public string AdministradorEquipo_id { get; set; }
        public string AdministradorEquipo_modelo { get; set; }
        public List<Equipocelular> _Equipocelular { get; set; }
        public AdministradorEquipo()
        {
            _Equipocelular = new List<Equipocelular>();
        }
       
    }
}
