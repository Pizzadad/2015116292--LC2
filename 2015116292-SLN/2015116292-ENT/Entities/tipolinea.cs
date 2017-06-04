using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT
{
     public class tipolinea
    {
        public string tipolinea_id { get; set; }
        public string tipolinea_nombre { get; set; }

        public string lineatelefonica_id { get; set; }

        public lineatelefonica lineatelefonica { get; set; }

    }
}
