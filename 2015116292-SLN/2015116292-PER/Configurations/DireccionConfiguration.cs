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
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direccion");
            HasKey(dire => dire.Direccion_id);

            Property(dire => dire.Direccion_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(dire => dire.Direccion_lugar)
                .IsRequired();

            HasRequired(v => v._Ubigeo)
                .WithMany(g => g._Direccion)
                .HasForeignKey(v => v.Ubigeo_id);
        }
    }
}
