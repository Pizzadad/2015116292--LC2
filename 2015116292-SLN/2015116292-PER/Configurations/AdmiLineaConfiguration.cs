using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class AdmiLineaConfiguration : EntityTypeConfiguration<AdmiLinea>
    {
        public AdmiLineaConfiguration()
        {
            ToTable("AdmiLinea");
            HasKey(ad => ad.admilinea_id);

        }
    }
}
