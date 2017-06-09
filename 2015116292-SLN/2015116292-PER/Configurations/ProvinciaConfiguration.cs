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
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {

        public ProvinciaConfiguration()
        {
            ToTable("Provincia");
            HasKey(pro => pro.Provincia_id);

            Property(pro => pro.Provincia_id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pro => pro.Provincia_nombre)
                .IsRequired();


            HasRequired(v => v._Distrito)
                .WithMany(g => g._Provincia)
                .HasForeignKey(v => v.Distrito_id);
        }
    }
}
