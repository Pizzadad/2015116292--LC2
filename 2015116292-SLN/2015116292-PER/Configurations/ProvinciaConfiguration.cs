using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {

        public ProvinciaConfiguration()
        {
            ToTable("Provincia");
            HasKey(pro => pro.Provincia_id);

            HasRequired(pro => pro.Departamento)
               .WithMany(pro => pro._Provincia);
        }
    }
}
