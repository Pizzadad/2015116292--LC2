using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
     public class tipolinea
    {
        public string tipolinea_id { get; set; }
        public string tipolinea_nombre { get; set; }

        public ICollection<lineatelefonica> _lineatelefonica { get; set; }

        public tipolinea()
        {
            _lineatelefonica = new Collection<lineatelefonica>();
        }

    }
}
