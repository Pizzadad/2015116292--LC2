using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class Equipocelular
    {
        public string Equipocelular_id { get; set; }
        public string Equipocelular_modelo { get; set; }

        public ICollection<AdministradorEquipo> _AdministradorEquipo { get; set; }
        public ICollection<Evaluacion> _Evaluacion { get; set; }

        public Equipocelular()
        {
            _AdministradorEquipo = new Collection<AdministradorEquipo>();
            _Evaluacion = new Collection<Evaluacion>();
        }
    }
}
