using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direccion");
            HasKey(dire => dire.Direccion_id);

            HasRequired(dire => dire.Centrodeatencion)
               .WithMany(dire => dire._Direccion);
        }
    }
}
