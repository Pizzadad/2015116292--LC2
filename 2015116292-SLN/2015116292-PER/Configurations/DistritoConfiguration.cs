using _2015116292_ENT;
using _2015116292_ENT.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            Property(dis => dis.Distrito_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(dis => dis.Distrito_nombre)
                .IsRequired();
        }
    }
}
