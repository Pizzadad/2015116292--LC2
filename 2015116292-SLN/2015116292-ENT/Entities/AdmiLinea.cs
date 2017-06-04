using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
    public class AdmiLinea
    {
        public string admilinea_id { get; set; }
        public string admilinea_nombre { get; set; }

        public List<lineatelefonica> _lineatelefonica { get; set; }

        public AdmiLinea()
        {
            _lineatelefonica = new List<lineatelefonica>();
        }
    }
}
