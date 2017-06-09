using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.Entities
{
   public class TipoPlan
    {   public string TipoPlan_caracteristica { get; set; }
        public string TipoPlan_id { get; set; }

        public ICollection<Plan> _Plan { get; set; }

        public TipoPlan()
        {
            _Plan = new Collection<Plan>();
        }
    }
}
