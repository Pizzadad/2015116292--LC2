using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2015116292_ENT;
using _2015116292_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2015116292_PER.Configurations
{
    public class TipoPlanConfiguration: EntityTypeConfiguration<TipoPlan>
     {
        public TipoPlanConfiguration()
        {
            ToTable("TipoPlan");
            HasKey(ti => ti.TipoPlan_id);

            Property(ti => ti.TipoPlan_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ti => ti.TipoPlan_caracteristica)
                .IsRequired();
        }
      
    }
}
