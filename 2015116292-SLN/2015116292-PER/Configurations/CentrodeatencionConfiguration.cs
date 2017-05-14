using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
  public  class CentrodeatencionConfiguration :   EntityTypeConfiguration<Centrodeatencion>
    {
        public CentrodeatencionConfiguration()
        {
            ToTable("Centrodeatencion");
            HasKey(cen => cen.Centrodeatencion_id);

        }
    }
}
