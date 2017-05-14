using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using _2015116292_ENT;

namespace _2015116292_PER.Configurations
{
    public class TipolineaConfiguration : EntityTypeConfiguration<tipolinea>
    {
        public TipolineaConfiguration()
        {
            ToTable("tipolinea");
            HasKey(t => t.tipolinea_id);

            HasRequired(t => t.lineatelefonica)
               .WithMany(t => t._tipolinea);
        }
    }
   }

