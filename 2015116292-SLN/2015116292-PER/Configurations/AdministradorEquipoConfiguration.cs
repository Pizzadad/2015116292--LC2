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
   public class AdministradorEquipoConfiguration : EntityTypeConfiguration<AdministradorEquipo>
    {
        public AdministradorEquipoConfiguration()
        {
            ToTable("AdministradorEquipo");
            HasKey(adm => adm.AdministradorEquipo_id);

            Property(adm => adm.AdministradorEquipo_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(adm => adm.AdministradorEquipo_modelo)
                .IsRequired();

            HasRequired(v => v._Equipocelular)
                .WithMany(g => g._AdministradorEquipo)
                .HasForeignKey(v => v.Equipocelular_id);

        }
    }
}
