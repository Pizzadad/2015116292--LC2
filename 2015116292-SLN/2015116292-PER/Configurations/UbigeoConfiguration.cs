using _2015116292_ENT;
using _2015116292_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class UbigeoConfiguration : EntityTypeConfiguration<Ubigeo>
    {
        public UbigeoConfiguration()
        {
            ToTable("Ubigeo");
            HasKey(ubi => ubi.Ubigeo_id);

            HasRequired(ubi => ubi.Direccion)
               .WithMany(ubi => ubi._Ubigeo);
            
        }
    }
}
