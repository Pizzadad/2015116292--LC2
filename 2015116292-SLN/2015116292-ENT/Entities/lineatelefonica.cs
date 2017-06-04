using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT
{
    public class lineatelefonica
    {
        public string lineatelefonica_id { get; set; }
        public string lineatelefonica_numero { get; set; }

        public string Evaluacion_id { get; set; }
        public Evaluacion Evaluacion { get; set; }

        public List<tipolinea> _tipolinea { get; set; }

        public string admilinea_id { get; set; }

        public AdmiLinea AdmiLinea { get; set; }

        public lineatelefonica()
        {
            _tipolinea = new List<tipolinea>();
        }
    }
}
