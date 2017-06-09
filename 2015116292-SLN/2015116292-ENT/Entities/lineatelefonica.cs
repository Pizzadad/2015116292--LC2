using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class lineatelefonica
    {
        public string lineatelefonica_id { get; set; }
        public string lineatelefonica_numero { get; set; }

       public ICollection<AdmiLinea> _AdmiLinea { get; set; }
        public ICollection<Evaluacion> _Evaluacion { get; set; }

        public tipolinea _tipolinea { get; set; }
        public string tipolinea_id { get; set; }


        public lineatelefonica()
        {
            _AdmiLinea = new Collection<AdmiLinea>();
            _Evaluacion = new Collection<Evaluacion>();
        }

        
    }
}
