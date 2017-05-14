using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT
{
   public class TipoPlan
    {   public string TipoPlan_caracteristica { get; set; }
        public string TipoPlan_id { get; set; }

        public string Plan_id { get; set; }

        public Plan Plan { get; set; }
    }
}
