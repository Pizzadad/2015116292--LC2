using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using _2015116292_ENT;
using _2015116292_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2015116292_PER.Configurations
{
    public class TipolineaConfiguration : EntityTypeConfiguration<tipolinea>
    {
        public TipolineaConfiguration()
        {
            ToTable("tipolinea");
            HasKey(t => t.tipolinea_id);

            Property(t => t.tipolinea_id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.tipolinea_nombre)
                .IsRequired();
        }
    }
   }

