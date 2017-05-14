using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            ToTable("Distrito");
            HasKey(dis => dis.Distrito_id);

            HasRequired(dis => dis.Provincia)
               .WithMany(dis => dis._Distrito);
        }
    }
}
