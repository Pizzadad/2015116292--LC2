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
    public class EquipocelularConfiguration:  EntityTypeConfiguration<Equipocelular>
    {
        public EquipocelularConfiguration()
        {
            ToTable("Equipocelular");
            HasKey(eq => eq.Equipocelular_id);

            HasRequired(eq => eq.AdministradorEquipo)
               .WithMany(eq => eq._Equipocelular);

            HasRequired(eq => eq.Evaluacion)
                .WithMany(eq => eq._Equipocelular);
        }

    }
}
